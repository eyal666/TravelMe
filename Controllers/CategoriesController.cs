﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TravelMe.Models;
using TravelMe_webapp.Models;
using TravelMe.Utils;
using System.Collections.Generic;
using System;

namespace TravelMe.Controllers
{
  [Authorize(Roles = SD.AdminUserRole)]
  public class CategoriesController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Categories
    public ActionResult Index(string search = null, string option = null)
    {
      List<Category> categories;
      categories = (from p in db.Categories select p).ToList();

      if (!String.IsNullOrEmpty(search) && option != null)
      {
        search = search.ToLower();
        if (option.Equals(SD.byCategory))
        {
          categories = categories.Where(c => c.CategoryName.ToLower().Contains(search)).ToList();
        }
      }
      return View(categories);
    }

    // GET: Categories/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Category category = db.Categories.Find(id);
      if (category == null)
      {
        return HttpNotFound();
      }
      return View(category);
    }

    // GET: Categories/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Categories/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Category category)
    {
      if (ModelState.IsValid)
      {
        db.Categories.Add(category);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View();
    }

    // GET: Categories/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Category category = db.Categories.Find(id);
      if (category == null)
      {
        return HttpNotFound();
      }
      return View(category);
    }

    // POST: Categories/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Category category)
    {
      if (ModelState.IsValid)
      {
        db.Entry(category).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View();
    }

    // GET: Categories/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Category category = db.Categories.Find(id);
      if (category == null)
      {
        return HttpNotFound();
      }
      return View(category);
    }

    // POST: Categories/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id)
    {
      Category category = db.Categories.Find(id);
      db.Categories.Remove(category);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
    }
  }
}
