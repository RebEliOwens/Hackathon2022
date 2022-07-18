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
    public class DropsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DropsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Drops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drops>>> GetDrops()
        {
          if (_context.Drops == null)
          {
              return NotFound();
          }
            return await _context.Drops.ToListAsync();
        }

        // GET: api/Drops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drops>> GetDrops(int id)
        {
          if (_context.Drops == null)
          {
              return NotFound();
          }
            var drops = await _context.Drops.FindAsync(id);

            if (drops == null)
            {
                return NotFound();
            }

            return drops;
        }

        // PUT: api/Drops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrops(int id, Drops drops)
        {
            if (id != drops.RowId)
            {
                return BadRequest();
            }

            _context.Entry(drops).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DropsExists(id))
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

        // POST: api/Drops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Drops>> PostDrops(Drops drops)
        {
          if (_context.Drops == null)
          {
              return Problem("Entity set 'AppDbContext.Drops'  is null.");
          }
            _context.Drops.Add(drops);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrops", new { id = drops.RowId }, drops);
        }

        // DELETE: api/Drops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrops(int id)
        {
            if (_context.Drops == null)
            {
                return NotFound();
            }
            var drops = await _context.Drops.FindAsync(id);
            if (drops == null)
            {
                return NotFound();
            }

            _context.Drops.Remove(drops);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DropsExists(int id)
        {
            return (_context.Drops?.Any(e => e.RowId == id)).GetValueOrDefault();
        }
    }
}
