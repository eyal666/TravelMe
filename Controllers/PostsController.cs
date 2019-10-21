using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelMe.Models;
using TravelMe.Utils;
using TravelMe.ViewModel;
using TravelMe_webapp.Models;

namespace TravelMe.Controllers
{
    [Authorize(Roles = SD.AdminUserRole)]
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Place);

            return View(posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            var model = new PostViewModel
            {
                Post = post,
                Categories = db.Categories.ToList()
            };

            return View(model);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.PlaceID = new SelectList(db.Places, "ID", "Address");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel postVM)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(u => u.Id == userid);


            var place = db.Places.FirstOrDefault(p => p.Address == postVM.Post.Place.Address);
            if (place == null)
            {
                place = new Place
                {
                    Address = postVM.Post.Place.Address,
                    Longtitude = postVM.Post.Place.Longtitude,
                    Latitude = postVM.Post.Place.Latitude,
                    AvgRating = postVM.Post.Rating,
                    NumOfPosts = 1
                };
                db.Places.Add(place);
            }
            else
            {
                var avg = db.Posts
                            .Where(p => p.PlaceID == place.ID && p.Rating != 0)
                            .Average(p => p.Rating);
                place.NumOfPosts++;
                place.AvgRating = (avg + postVM.Post.Rating) / place.NumOfPosts;
            }
            var post = new Post
            {
                ID = postVM.Post.ID,
                Title = postVM.Post.Title,
                Body = postVM.Post.Body,
                ImageUrl = postVM.Post.ImageUrl,
                UserID = user == null ? "Guest Account" : user.Id,
                PlaceID = postVM.Post.ID,
                Rating = postVM.Post.Rating,
                NumOfViews = 0,
                DateAdded = DateTime.Now,
                Place = place
            };
            db.Posts.Add(post);
            db.SaveChanges();
            place.AddPostID(post.ID);
            db.SaveChanges();
            return Redirect("/PostDetails/Index/" + post.ID);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceID = new SelectList(db.Places, "ID", "Address", post.PlaceID);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/PostDetails/Index/" + post.ID);
            }
            ViewBag.PlaceID = new SelectList(db.Places, "ID", "Address", post.PlaceID);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            Place place = db.Places.Find(post.PlaceID);
            if (place.NumOfPosts <= 1)
            {
                db.Places.Remove(place);
            }
            else
            {
                place.NumOfPosts--;
                place.RemovePostID(post.ID);
            }

            db.Posts.Remove(post);
            db.SaveChanges();
            return Redirect("/Home/Index/");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
