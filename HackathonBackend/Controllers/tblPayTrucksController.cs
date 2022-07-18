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
    public class tblPayTrucksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public tblPayTrucksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tblPayTrucks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblPayTruck>>> GetPayTruck()
        {
          if (_context.PayTruck == null)
          {
              return NotFound();
          }
            return await _context.PayTruck.ToListAsync();
        }

        // GET: api/tblPayTrucks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tblPayTruck>> GettblPayTruck(int id)
        {
          if (_context.PayTruck == null)
          {
              return NotFound();
          }
            var tblPayTruck = await _context.PayTruck.FindAsync(id);

            if (tblPayTruck == null)
            {
                return NotFound();
            }

            return tblPayTruck;
        }

        // PUT: api/tblPayTrucks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttblPayTruck(int id, tblPayTruck tblPayTruck)
        {
            if (id != tblPayTruck.RowId)
            {
                return BadRequest();
            }

            _context.Entry(tblPayTruck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblPayTruckExists(id))
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

        // POST: api/tblPayTrucks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tblPayTruck>> PosttblPayTruck(tblPayTruck tblPayTruck)
        {
          if (_context.PayTruck == null)
          {
              return Problem("Entity set 'AppDbContext.PayTruck'  is null.");
          }
            _context.PayTruck.Add(tblPayTruck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettblPayTruck", new { id = tblPayTruck.RowId }, tblPayTruck);
        }

        // DELETE: api/tblPayTrucks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetblPayTruck(int id)
        {
            if (_context.PayTruck == null)
            {
                return NotFound();
            }
            var tblPayTruck = await _context.PayTruck.FindAsync(id);
            if (tblPayTruck == null)
            {
                return NotFound();
            }

            _context.PayTruck.Remove(tblPayTruck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tblPayTruckExists(int id)
        {
            return (_context.PayTruck?.Any(e => e.RowId == id)).GetValueOrDefault();
        }
    }
}
