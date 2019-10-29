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
using TravelMe_webapp.Models;

namespace TravelMe.Controllers
{

    public class PlacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Places
        [Authorize(Roles = SD.AdminUserRole)]
        public ActionResult Index(string search = null, string option = null)
        {
            if (search != null)
            {
                List<Place> places;
                search = search.ToLower();
                places = (from p in db.Places select p).ToList();
                if (option.Equals(SD.byPlaceName))
                {
                    places = places.Where(p => p.Address.ToLower().Contains(search)).ToList();
                }
                if (option.Equals(SD.byAvgRating))
                {
                    places = places.Where(p => p.AvgRating == float.Parse(search)).ToList();
                }
                if (option.Equals(SD.byNumOfPosts))
                {
                    places = places.Where(p => p.NumOfPosts == int.Parse(search)).ToList();
                }
               

                return View(places);
            }
            else
            {
                return View(db.Places.ToList());
            }
            
        }

        // GET: Places/Details/5
        [Authorize(Roles = SD.AdminUserRole)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: Places/Create
        [Authorize(Roles = SD.AdminUserRole)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminUserRole)]
        public ActionResult Create([Bind(Include = "ID,Address,Longtitude,Latitude,AvgRating,NumOfPosts")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Places.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(place);
        }

        // GET: Places/Edit/5
        [Authorize(Roles = SD.AdminUserRole)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminUserRole)]
        public ActionResult Edit(Place place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(place);
        }

        // GET: Places/Delete/5
        [Authorize(Roles = SD.AdminUserRole)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminUserRole)]
        public ActionResult DeleteConfirmed(int id)
        {
            Place place = db.Places.Find(id);
            //TODO: delete all posts connected to place
            
            db.Places.Remove(place);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetAllPlaces()
        {
            var places = db.Places.ToList();
            return Json(places, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = SD.AdminUserRole)]
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
