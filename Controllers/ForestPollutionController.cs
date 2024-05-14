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

    public class ForestPollutionController : Controller
    {
        private readonly Tanger_APIDbContext _context;

        public ForestPollutionController(Tanger_APIDbContext context)
        {
            _context = context;
        }

        // GET: ForestPollution
        public async Task<IActionResult> Index()
        {
            return View(await _context.ForestPollutions.ToListAsync());
        }

        // GET: ForestPollution/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forestPollution = await _context.ForestPollutions
                .FirstOrDefaultAsync(m => m.ForestPollutionId == id);
            if (forestPollution == null)
            {
                return NotFound();
            }

            return View(forestPollution);
        }

        // GET: ForestPollution/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForestPollution/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ForestPollutionId,LocationId,Pollutant,Severity,Timestamp")] ForestPollution forestPollution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forestPollution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forestPollution);
        }

        // GET: ForestPollution/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var forestPollution = await _context.ForestPollutions.FindAsync(id);
            if (forestPollution == null)
            {
                return NotFound();
            }
            return View(forestPollution);
        }

        // POST: ForestPollution/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ForestPollutionId,LocationId,Pollutant,Severity,Timestamp")] ForestPollution forestPollution)
        {
            if (id != forestPollution.ForestPollutionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forestPollution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForestPollutionExists(forestPollution.ForestPollutionId))
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
            return View(forestPollution);
        }

        // GET: ForestPollution/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forestPollution = await _context.ForestPollutions
                .FirstOrDefaultAsync(m => m.ForestPollutionId == id);
            if (forestPollution == null)
            {
                return NotFound();
            }

            return View(forestPollution);
        }

        // POST: ForestPollution/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forestPollution = await _context.ForestPollutions.FindAsync(id);
            if (forestPollution != null)
            {
                _context.ForestPollutions.Remove(forestPollution);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForestPollutionExists(int id)
        {
            return _context.ForestPollutions.Any(e => e.ForestPollutionId == id);
        }
    }
}
