using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tanger_API.Models;

namespace Tanger_API.Controllers
{

    public class WaterWasteController : Controller
    {
        private readonly Tanger_APIDbContext _context;

        public WaterWasteController(Tanger_APIDbContext context)
        {
            _context = context;
        }

        // GET: WaterWaste
        public async Task<IActionResult> Index()
        {
            return View(await _context.WaterWastes.ToListAsync());
        }

        // GET: WaterWaste/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterWaste = await _context.WaterWastes
                .FirstOrDefaultAsync(m => m.WaterWasteId == id);
            if (waterWaste == null)
            {
                return NotFound();
            }

            return View(waterWaste);
        }

        // GET: WaterWaste/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WaterWaste/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WaterWasteId,LocationId,WasteType,WasteVolume,Timestamp")] WaterWaste waterWaste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waterWaste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waterWaste);
        }

        // GET: WaterWaste/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var waterWaste = await _context.WaterWastes.FindAsync(id);
            if (waterWaste == null)
            {
                return NotFound();
            }
            return View(waterWaste);
        }

        // POST: WaterWaste/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WaterWasteId,LocationId,WasteType,WasteVolume,Timestamp")] WaterWaste waterWaste)
        {
            if (id != waterWaste.WaterWasteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waterWaste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaterWasteExists(waterWaste.WaterWasteId))
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
            return View(waterWaste);
        }

        // GET: WaterWaste/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterWaste = await _context.WaterWastes
                .FirstOrDefaultAsync(m => m.WaterWasteId == id);
            if (waterWaste == null)
            {
                return NotFound();
            }

            return View(waterWaste);
        }

        // POST: WaterWaste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waterWaste = await _context.WaterWastes.FindAsync(id);
            if (waterWaste != null)
            {
                _context.WaterWastes.Remove(waterWaste);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaterWasteExists(int id)
        {
            return _context.WaterWastes.Any(e => e.WaterWasteId == id);
        }
    }
}
