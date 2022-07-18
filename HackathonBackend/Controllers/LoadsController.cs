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
        public async Task<ActionResult<IEnumerable<Load>>> GetLoad()
        {
          if (_context.Load == null)
          {
              return NotFound();
          }
            return await _context.Load.ToListAsync();
        }

        // GET: api/Loads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Load>> GetLoad(int id)
        {
          if (_context.Load == null)
          {
              return NotFound();
          }
            var load = await _context.Load.FindAsync(id);

            if (load == null)
            {
                return NotFound();
            }

            return load;
        }

        // PUT: api/Loads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoad(int id, Load load)
        {
            if (id != load.Id)
            {
                return BadRequest();
            }

            _context.Entry(load).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoadExists(id))
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
        public async Task<ActionResult<Load>> PostLoad(Load load)
        {
          if (_context.Load == null)
          {
              return Problem("Entity set 'AppDbContext.Load'  is null.");
          }
            _context.Load.Add(load);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoad", new { id = load.Id }, load);
        }

        // DELETE: api/Loads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoad(int id)
        {
            if (_context.Load == null)
            {
                return NotFound();
            }
            var load = await _context.Load.FindAsync(id);
            if (load == null)
            {
                return NotFound();
            }

            _context.Load.Remove(load);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoadExists(int id)
        {
            return (_context.Load?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
