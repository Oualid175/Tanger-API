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
    public class SolutionController : ControllerBase
    {
        private readonly Tanger_APIDbContext _context;

        public SolutionController(Tanger_APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Solution
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solution>>> GetSolutions()
        {
            return await _context.Solutions.ToListAsync();
        }

        // GET: api/Solution/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solution>> GetSolution(int id)
        {
            var solution = await _context.Solutions.FindAsync(id);

            if (solution == null)
            {
                return NotFound();
            }

            return solution;
        }

        // PUT: api/Solution/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolution(int id, Solution solution)
        {
            if (id != solution.Id)
            {
                return BadRequest();
            }

            _context.Entry(solution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolutionExists(id))
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

        // POST: api/Solution
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Solution>> PostSolution(Solution solution)
        {
            _context.Solutions.Add(solution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolution", new { id = solution.Id }, solution);
        }

        // DELETE: api/Solution/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolution(int id)
        {
            var solution = await _context.Solutions.FindAsync(id);
            if (solution == null)
            {
                return NotFound();
            }

            _context.Solutions.Remove(solution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SolutionExists(int id)
        {
            return _context.Solutions.Any(e => e.Id == id);
        }
    }
}
