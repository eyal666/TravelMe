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
    public class PostDetailsController : Controller
    {
        private ApplicationDbContext db;

        public PostDetailsController()
        {
            db = ApplicationDbContext.Create();
        }
        // GET: BookDetail
        public ActionResult Index(int id)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(u => u.Id == userid);

            var postModel = db.Posts.Include(p => p.Place).SingleOrDefault(p => p.ID == id);

            Post model = new Post
            {
                ID = postModel.ID,
                Title = postModel.Title,
                Body = postModel.Body,
                ImageUrl = postModel.ImageUrl,
                UserID = postModel.UserID,
                PlaceID = postModel.PlaceID,
                Rating = postModel.Rating,
                NumOfViews = postModel.NumOfViews,
                DateAdded = postModel.DateAdded,
                Place = postModel.Place
            };

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
