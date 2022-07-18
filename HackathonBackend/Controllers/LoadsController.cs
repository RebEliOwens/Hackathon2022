using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HackathonBackend.Models;

namespace HackathonBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoadsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Loads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loads>>> GetLoads()
        {
          if (_context.Loads == null)
          {
              return NotFound();
          }
            return await _context.Loads.ToListAsync();
        }

        // GET: api/Loads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loads>> GetLoads(int id)
        {
          if (_context.Loads == null)
          {
              return NotFound();
          }
            var loads = await _context.Loads.FindAsync(id);

            if (loads == null)
            {
                return NotFound();
            }

            return loads;
        }

        // PUT: api/Loads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoads(int id, Loads loads)
        {
            if (id != loads.Id)
            {
                return BadRequest();
            }

            _context.Entry(loads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoadsExists(id))
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

        // POST: api/Loads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loads>> PostLoads(Loads loads)
        {
          if (_context.Loads == null)
          {
              return Problem("Entity set 'AppDbContext.Loads'  is null.");
          }
            _context.Loads.Add(loads);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoads", new { id = loads.Id }, loads);
        }

        // DELETE: api/Loads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoads(int id)
        {
            if (_context.Loads == null)
            {
                return NotFound();
            }
            var loads = await _context.Loads.FindAsync(id);
            if (loads == null)
            {
                return NotFound();
            }

            _context.Loads.Remove(loads);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoadsExists(int id)
        {
            return (_context.Loads?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
