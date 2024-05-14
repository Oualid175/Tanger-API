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
    public class ForestPollutionController : ControllerBase
    {
        private readonly Tanger_APIDbContext _context;

        public ForestPollutionController(Tanger_APIDbContext context)
        {
            _context = context;
        }

        // GET: api/ForestPollution
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForestPollution>>> GetForestPollutions()
        {
            return await _context.ForestPollutions.ToListAsync();
        }

        // GET: api/ForestPollution/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ForestPollution>> GetForestPollution(int id)
        {
            var forestPollution = await _context.ForestPollutions.FindAsync(id);

            if (forestPollution == null)
            {
                return NotFound();
            }

            return forestPollution;
        }

        // PUT: api/ForestPollution/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForestPollution(int id, ForestPollution forestPollution)
        {
            if (id != forestPollution.ForestPollutionId)
            {
                return BadRequest();
            }

            _context.Entry(forestPollution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForestPollutionExists(id))
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

        // POST: api/ForestPollution
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ForestPollution>> PostForestPollution(ForestPollution forestPollution)
        {
            _context.ForestPollutions.Add(forestPollution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForestPollution", new { id = forestPollution.ForestPollutionId }, forestPollution);
        }

        // DELETE: api/ForestPollution/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForestPollution(int id)
        {
            var forestPollution = await _context.ForestPollutions.FindAsync(id);
            if (forestPollution == null)
            {
                return NotFound();
            }

            _context.ForestPollutions.Remove(forestPollution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ForestPollutionExists(int id)
        {
            return _context.ForestPollutions.Any(e => e.ForestPollutionId == id);
        }
    }
}
