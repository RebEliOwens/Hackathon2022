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
    public class tblLoadsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public tblLoadsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tblLoads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblLoads>>> GetLoads()
        {
          if (_context.Loads == null)
          {
              return NotFound();
          }
            return await _context.Loads.ToListAsync();
        }

        // GET: api/tblLoads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tblLoads>> GettblLoads(int id)
        {
          if (_context.Loads == null)
          {
              return NotFound();
          }
            var tblLoads = await _context.Loads.FindAsync(id);

            if (tblLoads == null)
            {
                return NotFound();
            }

            return tblLoads;
        }

        // PUT: api/tblLoads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttblLoads(int id, tblLoads tblLoads)
        {
            if (id != tblLoads.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblLoads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblLoadsExists(id))
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

        // POST: api/tblLoads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tblLoads>> PosttblLoads(tblLoads tblLoads)
        {
          if (_context.Loads == null)
          {
              return Problem("Entity set 'AppDbContext.Loads'  is null.");
          }
            _context.Loads.Add(tblLoads);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettblLoads", new { id = tblLoads.Id }, tblLoads);
        }

        // DELETE: api/tblLoads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetblLoads(int id)
        {
            if (_context.Loads == null)
            {
                return NotFound();
            }
            var tblLoads = await _context.Loads.FindAsync(id);
            if (tblLoads == null)
            {
                return NotFound();
            }

            _context.Loads.Remove(tblLoads);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tblLoadsExists(int id)
        {
            return (_context.Loads?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
