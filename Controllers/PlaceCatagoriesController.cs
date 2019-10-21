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
    [Authorize(Roles = SD.AdminUserRole)]
    public class PlaceCatagoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlaceCatagories
        public ActionResult Index()
        {
            var placeCatagories = db.PlaceCatagories.Include(p => p.Place);
            return View(placeCatagories.ToList());
        }

        // GET: PlaceCatagories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceCatagory placeCatagory = db.PlaceCatagories.Find(id);
            if (placeCatagory == null)
            {
                return HttpNotFound();
            }
            return View(placeCatagory);
        }

        // GET: PlaceCatagories/Create
        public ActionResult Create()
        {
            ViewBag.PlaceID = new SelectList(db.Places, "ID", "Address");
            return View();
        }

        // POST: PlaceCatagories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PlaceID,CatagoryID")] PlaceCatagory placeCatagory)
        {
            if (ModelState.IsValid)
            {
                db.PlaceCatagories.Add(placeCatagory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaceID = new SelectList(db.Places, "ID", "Address", placeCatagory.PlaceID);
            return View(placeCatagory);
        }

        // GET: PlaceCatagories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceCatagory placeCatagory = db.PlaceCatagories.Find(id);
            if (placeCatagory == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceID = new SelectList(db.Places, "ID", "Address", placeCatagory.PlaceID);
            return View(placeCatagory);
        }

        // POST: PlaceCatagories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PlaceID,CatagoryID")] PlaceCatagory placeCatagory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placeCatagory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceID = new SelectList(db.Places, "ID", "Address", placeCatagory.PlaceID);
            return View(placeCatagory);
        }

        // GET: PlaceCatagories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceCatagory placeCatagory = db.PlaceCatagories.Find(id);
            if (placeCatagory == null)
            {
                return HttpNotFound();
            }
            return View(placeCatagory);
        }

        // POST: PlaceCatagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlaceCatagory placeCatagory = db.PlaceCatagories.Find(id);
            db.PlaceCatagories.Remove(placeCatagory);
            db.SaveChanges();
            return RedirectToAction("Index");
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
