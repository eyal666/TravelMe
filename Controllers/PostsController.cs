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
  public class PostsController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Posts
    [Authorize(Roles = SD.AdminUserRole)]
    public ActionResult Index()
    {
      ViewBag.CategoryNames = db.Categories.ToList();
      var posts = db.Posts.Include(p => p.Category);
      return View(posts.ToList());
    }

    // GET: Posts/Details/5
    [Authorize(Roles = SD.AdminUserRole)]
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
    [Authorize()]
    public ActionResult Create()
    {
      var category = db.Categories.ToList();
      var model = new PostViewModel
      {
        Categories = category
      };
      ViewBag.PlaceID = new SelectList(db.Places, "ID", "Address");
      return View(model);
    }

    // POST: Posts/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize()]
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
        ImageUrl = "",
        UserID = user == null ? "Guest Account" : user.Id,
        PlaceID = postVM.Post.ID,
        Rating = postVM.Post.Rating,
        NumOfViews = 0,
        DateAdded = DateTime.Now,
        Place = place,
        CategoryName = postVM.Post.CategoryName
      };
      db.Posts.Add(post);
      db.SaveChanges();
      //Caching post picture
      var imagePath = Server.MapPath("~/Content/Photos/Posts/" + post.ID + ".png");
      using (var client = new WebClient())
      {
        client.DownloadFile(postVM.Post.ImageUrl, imagePath);
      }
      post.ImageUrl = "/Content/Photos/Posts/" + post.ID + ".png";
      place.AddPostID(post.ID);
      db.SaveChanges();
      return Redirect("/PostDetails/Index/" + post.ID);
    }


    [ValidateAntiForgeryToken]
    [Authorize()]
    public int CreateEdit(Post newPost)
    {
      var userid = User.Identity.GetUserId();
      var user = db.Users.FirstOrDefault(u => u.Id == userid);


      var place = db.Places.FirstOrDefault(p => p.Address == newPost.Place.Address);
      if (place == null)
      {
        place = new Place
        {
          Address = newPost.Place.Address,
          Longtitude = newPost.Place.Longtitude,
          Latitude = newPost.Place.Latitude,
          AvgRating = newPost.Rating,
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
        place.AvgRating = (avg + newPost.Rating) / place.NumOfPosts;
      }

      var post = new Post
      {
        ID = newPost.ID,
        Title = newPost.Title,
        Body = newPost.Body,
        ImageUrl = "",
        UserID = user == null ? "Guest Account" : user.Id,
        PlaceID = place.ID,
        Rating = newPost.Rating,
        NumOfViews = newPost.NumOfViews,
        DateAdded = DateTime.Now,
        Place = place,
        CategoryName = newPost.CategoryName

      };
      db.Posts.Add(post);
      db.SaveChanges();
      //Caching post picture
      var imagePath = Server.MapPath("~/Content/Photos/Posts/" + post.ID + ".png");
      using (var client = new WebClient())
      {
        client.DownloadFile(newPost.ImageUrl, imagePath);
      }
      post.ImageUrl = "/Content/Photos/Posts/" + post.ID + ".png";
      place.AddPostID(post.ID);
      db.SaveChanges();
      return post.ID;
    }

    // GET: Posts/Edit/5
    [Authorize()]
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
      var model = new PostViewModel
      {
        Post = post,
        Categories = db.Categories.ToList()
      };
      ViewBag.PlaceID = new SelectList(db.Places, "ID", "Address", post.PlaceID);
      return View(model);
    }

    // POST: Posts/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize()]
    public ActionResult Edit(Post post)
    {
      Post oldPost = post;
      int newID = CreateEdit(oldPost);
      DeleteConfirmed(post.ID);
      return Redirect("/PostDetails/Index/" + newID);

    }

    // GET: Posts/Delete/5
    [Authorize()]
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
      var model = new PostViewModel
      {
        Post = post,
        Categories = db.Categories.ToList()
      };
      return View(model);
    }

    // POST: Posts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize()]
    public ActionResult DeleteConfirmed(int id)
    {
      Post post = db.Posts.Find(id);
      Place place = db.Places.Find(post.PlaceID);
      string imgToDelete = Server.MapPath("~/Content/Photos/Posts/" + post.ID + ".png");
      if (System.IO.File.Exists(imgToDelete))
      {
        System.IO.File.Delete(imgToDelete);
      }
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
