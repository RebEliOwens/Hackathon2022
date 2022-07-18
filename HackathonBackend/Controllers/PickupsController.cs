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
    public class PickupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PickupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pickups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pickups>>> GetPickups()
        {
          if (_context.Pickups == null)
          {
              return NotFound();
          }
            return await _context.Pickups.ToListAsync();
        }

        // GET: api/Pickups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pickups>> GetPickups(int id)
        {
          if (_context.Pickups == null)
          {
              return NotFound();
          }
            var pickups = await _context.Pickups.FindAsync(id);

            if (pickups == null)
            {
                return NotFound();
            }

            return pickups;
        }

        // PUT: api/Pickups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPickups(int id, Pickups pickups)
        {
            if (id != pickups.RowId)
            {
                return BadRequest();
            }

            _context.Entry(pickups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PickupsExists(id))
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

        // POST: api/Pickups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pickups>> PostPickups(Pickups pickups)
        {
          if (_context.Pickups == null)
          {
              return Problem("Entity set 'AppDbContext.Pickups'  is null.");
          }
            _context.Pickups.Add(pickups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPickups", new { id = pickups.RowId }, pickups);
        }

        // DELETE: api/Pickups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePickups(int id)
        {
            if (_context.Pickups == null)
            {
                return NotFound();
            }
            var pickups = await _context.Pickups.FindAsync(id);
            if (pickups == null)
            {
                return NotFound();
            }

            _context.Pickups.Remove(pickups);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PickupsExists(int id)
        {
            return (_context.Pickups?.Any(e => e.RowId == id)).GetValueOrDefault();
        }
    }
}
