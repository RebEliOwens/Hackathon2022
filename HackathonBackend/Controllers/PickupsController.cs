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
        public async Task<ActionResult<IEnumerable<Pickup>>> GetPickup()
        {
          if (_context.Pickup == null)
          {
              return NotFound();
          }
            return await _context.Pickup.ToListAsync();
        }

        // GET: api/Pickups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pickup>> GetPickup(int id)
        {
          if (_context.Pickup == null)
          {
              return NotFound();
          }
            var pickup = await _context.Pickup.FindAsync(id);

            if (pickup == null)
            {
                return NotFound();
            }

            return pickup;
        }

        // PUT: api/Pickups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPickup(int id, Pickup pickup)
        {
            if (id != pickup.Id)
            {
                return BadRequest();
            }

            _context.Entry(pickup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PickupExists(id))
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
        public async Task<ActionResult<Pickup>> PostPickup(Pickup pickup)
        {
          if (_context.Pickup == null)
          {
              return Problem("Entity set 'AppDbContext.Pickup'  is null.");
          }
            _context.Pickup.Add(pickup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPickup", new { id = pickup.Id }, pickup);
        }

        // DELETE: api/Pickups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePickup(int id)
        {
            if (_context.Pickup == null)
            {
                return NotFound();
            }
            var pickup = await _context.Pickup.FindAsync(id);
            if (pickup == null)
            {
                return NotFound();
            }

            _context.Pickup.Remove(pickup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PickupExists(int id)
        {
            return (_context.Pickup?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
