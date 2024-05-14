using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tanger_API.Models;

namespace Tanger_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterWasteController : ControllerBase
    {
        private readonly Tanger_APIDbContext _context;

        public WaterWasteController(Tanger_APIDbContext context)
        {
            _context = context;
        }

        // GET: api/WaterWaste
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterWaste>>> GetWaterWastes()
        {
            return await _context.WaterWastes.ToListAsync();
        }

        // GET: api/WaterWaste/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterWaste>> GetWaterWaste(int id)
        {
            var waterWaste = await _context.WaterWastes.FindAsync(id);

            if (waterWaste == null)
            {
                return NotFound();
            }

            return waterWaste;
        }

        // PUT: api/WaterWaste/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterWaste(int id, WaterWaste waterWaste)
        {
            if (id != waterWaste.WaterWasteId)
            {
                return BadRequest();
            }

            _context.Entry(waterWaste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterWasteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WaterWaste
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WaterWaste>> PostWaterWaste(WaterWaste waterWaste)
        {
            _context.WaterWastes.Add(waterWaste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaterWaste", new { id = waterWaste.WaterWasteId }, waterWaste);
        }

        // DELETE: api/WaterWaste/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaterWaste(int id)
        {
            var waterWaste = await _context.WaterWastes.FindAsync(id);
            if (waterWaste == null)
            {
                return NotFound();
            }

            _context.WaterWastes.Remove(waterWaste);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WaterWasteExists(int id)
        {
            return _context.WaterWastes.Any(e => e.WaterWasteId == id);
        }
    }
}
