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
    public class tblPickupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public tblPickupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tblPickups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblPickups>>> GetPickups()
        {
          if (_context.Pickups == null)
          {
              return NotFound();
          }
            return await _context.Pickups.ToListAsync();
        }

        // GET: api/tblPickups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tblPickups>> GettblPickups(int id)
        {
          if (_context.Pickups == null)
          {
              return NotFound();
          }
            var tblPickups = await _context.Pickups.FindAsync(id);

            if (tblPickups == null)
            {
                return NotFound();
            }

            return tblPickups;
        }

        // PUT: api/tblPickups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttblPickups(int id, tblPickups tblPickups)
        {
            if (id != tblPickups.RowId)
            {
                return BadRequest();
            }

            _context.Entry(tblPickups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblPickupsExists(id))
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

        // POST: api/tblPickups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tblPickups>> PosttblPickups(tblPickups tblPickups)
        {
          if (_context.Pickups == null)
          {
              return Problem("Entity set 'AppDbContext.Pickups'  is null.");
          }
            _context.Pickups.Add(tblPickups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettblPickups", new { id = tblPickups.RowId }, tblPickups);
        }

        // DELETE: api/tblPickups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetblPickups(int id)
        {
            if (_context.Pickups == null)
            {
                return NotFound();
            }
            var tblPickups = await _context.Pickups.FindAsync(id);
            if (tblPickups == null)
            {
                return NotFound();
            }

            _context.Pickups.Remove(tblPickups);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tblPickupsExists(int id)
        {
            return (_context.Pickups?.Any(e => e.RowId == id)).GetValueOrDefault();
        }
    }
}
