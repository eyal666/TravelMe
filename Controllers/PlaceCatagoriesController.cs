using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelMe_webapp.Models;

namespace TravelMe_webapp.Controllers
{
    public class PlaceCatagoriesController : Controller
    {
        private readonly TravelMe_webappContext _context;

        public PlaceCatagoriesController(TravelMe_webappContext context)
        {
            _context = context;
        }

        // GET: PlaceCatagories
        public async Task<IActionResult> Index()
        {
            var travelMe_webappContext = _context.PlaceCatagory.Include(p => p.Place);
            return View(await travelMe_webappContext.ToListAsync());
        }

        // GET: PlaceCatagories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeCatagory = await _context.PlaceCatagory
                .Include(p => p.Place)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (placeCatagory == null)
            {
                return NotFound();
            }

            return View(placeCatagory);
        }

        // GET: PlaceCatagories/Create
        public IActionResult Create()
        {
            ViewData["PlaceID"] = new SelectList(_context.Place, "ID", "Location");
            return View();
        }

        // POST: PlaceCatagories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PlaceID,CatagoryID")] PlaceCatagory placeCatagory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placeCatagory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaceID"] = new SelectList(_context.Place, "ID", "Location", placeCatagory.PlaceID);
            return View(placeCatagory);
        }

        // GET: PlaceCatagories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeCatagory = await _context.PlaceCatagory.FindAsync(id);
            if (placeCatagory == null)
            {
                return NotFound();
            }
            ViewData["PlaceID"] = new SelectList(_context.Place, "ID", "Location", placeCatagory.PlaceID);
            return View(placeCatagory);
        }

        // POST: PlaceCatagories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PlaceID,CatagoryID")] PlaceCatagory placeCatagory)
        {
            if (id != placeCatagory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placeCatagory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceCatagoryExists(placeCatagory.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaceID"] = new SelectList(_context.Place, "ID", "Location", placeCatagory.PlaceID);
            return View(placeCatagory);
        }

        // GET: PlaceCatagories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeCatagory = await _context.PlaceCatagory
                .Include(p => p.Place)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (placeCatagory == null)
            {
                return NotFound();
            }

            return View(placeCatagory);
        }

        // POST: PlaceCatagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placeCatagory = await _context.PlaceCatagory.FindAsync(id);
            _context.PlaceCatagory.Remove(placeCatagory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaceCatagoryExists(int id)
        {
            return _context.PlaceCatagory.Any(e => e.ID == id);
        }
    }
}
