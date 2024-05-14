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
    public class AirPollutionController : ControllerBase
    {
        private readonly Tanger_APIDbContext _context;

        public AirPollutionController(Tanger_APIDbContext context)
        {
            _context = context;
        }

        // GET: api/AirPollution
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirPollution>>> GetAirPollutions()
        {
            return await _context.AirPollutions.ToListAsync();
        }

        // GET: api/AirPollution/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirPollution>> GetAirPollution(int id)
        {
            var airPollution = await _context.AirPollutions.FindAsync(id);

            if (airPollution == null)
            {
                return NotFound();
            }

            return airPollution;
        }

        // PUT: api/AirPollution/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirPollution(int id, AirPollution airPollution)
        {
            if (id != airPollution.AirPollutionId)
            {
                return BadRequest();
            }

            _context.Entry(airPollution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirPollutionExists(id))
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

        // POST: api/AirPollution
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirPollution>> PostAirPollution(AirPollution airPollution)
        {
            _context.AirPollutions.Add(airPollution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirPollution", new { id = airPollution.AirPollutionId }, airPollution);
        }

        // DELETE: api/AirPollution/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirPollution(int id)
        {
            var airPollution = await _context.AirPollutions.FindAsync(id);
            if (airPollution == null)
            {
                return NotFound();
            }

            _context.AirPollutions.Remove(airPollution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirPollutionExists(int id)
        {
            return _context.AirPollutions.Any(e => e.AirPollutionId == id);
        }
    }
}
