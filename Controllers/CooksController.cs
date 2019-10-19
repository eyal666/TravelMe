using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelMe.Models;

namespace TravelMe.Controllers
{
    public class CooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cooks
        public ActionResult Index()
        {
            return View(db.Cooks.ToList());
        }

        // GET: Cooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cook cook = db.Cooks.Find(id);
            if (cook == null)
            {
                return HttpNotFound();
            }
            return View(cook);
        }

        // GET: Cooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UID,PID")] Cook cook)
        {
            if (ModelState.IsValid)
            {
                db.Cooks.Add(cook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cook);
        }

        // GET: Cooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cook cook = db.Cooks.Find(id);
            if (cook == null)
            {
                return HttpNotFound();
            }
            return View(cook);
        }

        // POST: Cooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UID,PID")] Cook cook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cook);
        }

        // GET: Cooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cook cook = db.Cooks.Find(id);
            if (cook == null)
            {
                return HttpNotFound();
            }
            return View(cook);
        }

        // POST: Cooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cook cook = db.Cooks.Find(id);
            db.Cooks.Remove(cook);
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
