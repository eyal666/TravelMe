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
using System.Net;
using TravelMeML.Model;

namespace TravelMe.Controllers
{
      [Authorize]
    public class PostDetailsController : Controller
    {
        private ApplicationDbContext db;

        public PostDetailsController()
        {
            db = ApplicationDbContext.Create();
        }
        
        public ActionResult Index(int? id)
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

            var addarray = model.Post.Place.Address.Split(',');
            var country = addarray[addarray.Length - 1];
            Cook temp = new Cook();
            temp.PID = model.Post.ID.ToString();
            temp.UID = this.User.Identity.GetUserId();
            temp.Rating = model.Post.Rating.ToString();
            temp.Address = country;
            temp.Cat = model.Post.CategoryName;
            db.Cooks.Add(temp);
            db.SaveChanges();

            // Add input data
            var input = new ModelInput();
            input.Address = country;
            input.Cat = model.Post.CategoryName;

            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(input);
            var i = result.Prediction;
            model.Post.Rec = i;



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
