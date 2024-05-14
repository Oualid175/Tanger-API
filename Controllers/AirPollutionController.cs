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

    public class AirPollutionController : Controller
    {
        private readonly Tanger_APIDbContext _context;

        public AirPollutionController(Tanger_APIDbContext context)
        {
            _context = context;
        }

        // GET: AirPollution
        public async Task<IActionResult> Index()
        {
            return View(await _context.AirPollutions.ToListAsync());
        }

        // GET: AirPollution/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airPollution = await _context.AirPollutions
                .FirstOrDefaultAsync(m => m.AirPollutionId == id);
            if (airPollution == null)
            {
                return NotFound();
            }

            return View(airPollution);
        }

        // GET: AirPollution/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AirPollution/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirPollutionId,LocationId,Pollutant,PollutantLevel,Timestamp")] AirPollution airPollution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airPollution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airPollution);
        }

        // GET: AirPollution/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var airPollution = await _context.AirPollutions.FindAsync(id);
            if (airPollution == null)
            {
                return NotFound();
            }
            return View(airPollution);
        }

        // POST: AirPollution/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AirPollutionId,LocationId,Pollutant,PollutantLevel,Timestamp")] AirPollution airPollution)
        {
            if (id != airPollution.AirPollutionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airPollution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirPollutionExists(airPollution.AirPollutionId))
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
            return View(airPollution);
        }

        // GET: AirPollution/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airPollution = await _context.AirPollutions
                .FirstOrDefaultAsync(m => m.AirPollutionId == id);
            if (airPollution == null)
            {
                return NotFound();
            }

            return View(airPollution);
        }

        // POST: AirPollution/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airPollution = await _context.AirPollutions.FindAsync(id);
            if (airPollution != null)
            {
                _context.AirPollutions.Remove(airPollution);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirPollutionExists(int id)
        {
            return _context.AirPollutions.Any(e => e.AirPollutionId == id);
        }
    }
}
