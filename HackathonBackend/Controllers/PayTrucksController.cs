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
    public class PayTrucksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PayTrucksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PayTrucks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayTruck>>> GetPayTruck()
        {
          if (_context.PayTruck == null)
          {
              return NotFound();
          }
            return await _context.PayTruck.ToListAsync();
        }

        // GET: api/PayTrucks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayTruck>> GetPayTruck(int id)
        {
          if (_context.PayTruck == null)
          {
              return NotFound();
          }
            var payTruck = await _context.PayTruck.FindAsync(id);

            if (payTruck == null)
            {
                return NotFound();
            }

            return payTruck;
        }

        // PUT: api/PayTrucks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayTruck(int id, PayTruck payTruck)
        {
            if (id != payTruck.RowId)
            {
                return BadRequest();
            }

            _context.Entry(payTruck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayTruckExists(id))
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

        // POST: api/PayTrucks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PayTruck>> PostPayTruck(PayTruck payTruck)
        {
          if (_context.PayTruck == null)
          {
              return Problem("Entity set 'AppDbContext.PayTruck'  is null.");
          }
            _context.PayTruck.Add(payTruck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayTruck", new { id = payTruck.RowId }, payTruck);
        }

        // DELETE: api/PayTrucks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayTruck(int id)
        {
            if (_context.PayTruck == null)
            {
                return NotFound();
            }
            var payTruck = await _context.PayTruck.FindAsync(id);
            if (payTruck == null)
            {
                return NotFound();
            }

            _context.PayTruck.Remove(payTruck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PayTruckExists(int id)
        {
            return (_context.PayTruck?.Any(e => e.RowId == id)).GetValueOrDefault();
        }
    }
}
