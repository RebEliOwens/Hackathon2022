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
        public async Task<ActionResult<IEnumerable<Drop>>> GetDrop()
        {
          if (_context.Drop == null)
          {
              return NotFound();
          }
            return await _context.Drop.ToListAsync();
        }

        // GET: api/Drops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drop>> GetDrop(int id)
        {
          if (_context.Drop == null)
          {
              return NotFound();
          }
            var drop = await _context.Drop.FindAsync(id);

            if (drop == null)
            {
                return NotFound();
            }

            return drop;
        }

        // PUT: api/Drops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrop(int id, Drop drop)
        {
            if (id != drop.Id)
            {
                return BadRequest();
            }

            _context.Entry(drop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DropExists(id))
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
        public async Task<ActionResult<Drop>> PostDrop(Drop drop)
        {
          if (_context.Drop == null)
          {
              return Problem("Entity set 'AppDbContext.Drop'  is null.");
          }
            _context.Drop.Add(drop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrop", new { id = drop.Id }, drop);
        }

        // DELETE: api/Drops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrop(int id)
        {
            if (_context.Drop == null)
            {
                return NotFound();
            }
            var drop = await _context.Drop.FindAsync(id);
            if (drop == null)
            {
                return NotFound();
            }

            _context.Drop.Remove(drop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DropExists(int id)
        {
            return (_context.Drop?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
