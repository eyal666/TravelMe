using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using TravelMe.Utils;
using TravelMe.ViewModel;
using TravelMe.Models;
using TravelMe_webapp.Models;

namespace TravelMe.Controllers
{
    //  [Authorize]
    public class PostDetailsController : Controller
    {
        private ApplicationDbContext db;

        public PostDetailsController()
        {
            db = ApplicationDbContext.Create();
        }
        
        public ActionResult Index(int id)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(u => u.Id == userid);
            var postModel = db.Posts.Include(p => p.Place).SingleOrDefault(p => p.ID == id);
            var author = db.Users.FirstOrDefault(u => u.Id == postModel.UserID);
            var currentCount = ++postModel.NumOfViews;
            PostViewModel model = new PostViewModel
            {
                Post = new Post
                {
                    ID = postModel.ID,
                    Title = postModel.Title,
                    Body = postModel.Body,
                    ImageUrl = postModel.ImageUrl,
                    UserID = author == null ? "Guest Account" : author.Email,
                    PlaceID = postModel.PlaceID,
                    Rating = postModel.Rating,
                    NumOfViews = currentCount,
                    DateAdded = postModel.DateAdded,
                    Place = postModel.Place,
                    Category = postModel.Category,
                    CategoryName = postModel.CategoryName,
                }
            };

            //To Write Cookie to local computer
            HttpCookie cookie = new HttpCookie("Visited");
            cookie["pid"] = model.Post.ID.ToString();
            cookie["uid"] = model.Post.UserID.ToString();
            Response.Cookies.Add(cookie);
            //HttpContext.CurrentHandler.Response.Cookies.Add(cookie);



            //to read cookie from local computer
            Cook temp = new Cook();
            var cookie1 = Request.Cookies["Visited"];
            // 
            var t = cookie1["pid"];
            temp.UID = cookie1["uid"];
            temp.PID = t;
            db.Cooks.Add(temp);
            db.SaveChanges();

            //cookie1["pid"]
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}
