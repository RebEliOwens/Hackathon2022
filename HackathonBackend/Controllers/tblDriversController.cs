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
    public class tblDriversController : ControllerBase
    {
        private readonly AppDbContext _context;

        public tblDriversController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tblDrivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblDriver>>> GetDriver()
        {
          if (_context.Driver == null)
          {
              return NotFound();
          }
            return await _context.Driver.ToListAsync();
        }

        // GET: api/tblDrivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tblDriver>> GettblDriver(int id)
        {
          if (_context.Driver == null)
          {
              return NotFound();
          }
            var tblDriver = await _context.Driver.FindAsync(id);

            if (tblDriver == null)
            {
                return NotFound();
            }

            return tblDriver;
        }

        // PUT: api/tblDrivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttblDriver(int id, tblDriver tblDriver)
        {
            if (id != tblDriver.DriverId)
            {
                return BadRequest();
            }

            _context.Entry(tblDriver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblDriverExists(id))
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

        // POST: api/tblDrivers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tblDriver>> PosttblDriver(tblDriver tblDriver)
        {
          if (_context.Driver == null)
          {
              return Problem("Entity set 'AppDbContext.Driver'  is null.");
          }
            _context.Driver.Add(tblDriver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettblDriver", new { id = tblDriver.DriverId }, tblDriver);
        }

        // DELETE: api/tblDrivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetblDriver(int id)
        {
            if (_context.Driver == null)
            {
                return NotFound();
            }
            var tblDriver = await _context.Driver.FindAsync(id);
            if (tblDriver == null)
            {
                return NotFound();
            }

            _context.Driver.Remove(tblDriver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tblDriverExists(int id)
        {
            return (_context.Driver?.Any(e => e.DriverId == id)).GetValueOrDefault();
        }
    }
}
