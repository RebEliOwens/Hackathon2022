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
    public class tblDropsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public tblDropsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tblDrops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblDrops>>> GetDrops()
        {
          if (_context.Drops == null)
          {
              return NotFound();
          }
            return await _context.Drops.ToListAsync();
        }

        // GET: api/tblDrops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tblDrops>> GettblDrops(int id)
        {
          if (_context.Drops == null)
          {
              return NotFound();
          }
            var tblDrops = await _context.Drops.FindAsync(id);

            if (tblDrops == null)
            {
                return NotFound();
            }

            return tblDrops;
        }

        // PUT: api/tblDrops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttblDrops(int id, tblDrops tblDrops)
        {
            if (id != tblDrops.RowId)
            {
                return BadRequest();
            }

            _context.Entry(tblDrops).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblDropsExists(id))
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

        // POST: api/tblDrops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tblDrops>> PosttblDrops(tblDrops tblDrops)
        {
          if (_context.Drops == null)
          {
              return Problem("Entity set 'AppDbContext.Drops'  is null.");
          }
            _context.Drops.Add(tblDrops);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettblDrops", new { id = tblDrops.RowId }, tblDrops);
        }

        // DELETE: api/tblDrops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetblDrops(int id)
        {
            if (_context.Drops == null)
            {
                return NotFound();
            }
            var tblDrops = await _context.Drops.FindAsync(id);
            if (tblDrops == null)
            {
                return NotFound();
            }

            _context.Drops.Remove(tblDrops);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tblDropsExists(int id)
        {
            return (_context.Drops?.Any(e => e.RowId == id)).GetValueOrDefault();
        }
    }
}
