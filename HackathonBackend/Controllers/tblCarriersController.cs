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
    public class tblCarriersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public tblCarriersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tblCarriers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblCarrier>>> GetCarrier()
        {
          if (_context.Carrier == null)
          {
              return NotFound();
          }
            return await _context.Carrier.ToListAsync();
        }

        // GET: api/tblCarriers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tblCarrier>> GettblCarrier(int id)
        {
          if (_context.Carrier == null)
          {
              return NotFound();
          }
            var tblCarrier = await _context.Carrier.FindAsync(id);

            if (tblCarrier == null)
            {
                return NotFound();
            }

            return tblCarrier;
        }

        // PUT: api/tblCarriers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttblCarrier(int id, tblCarrier tblCarrier)
        {
            if (id != tblCarrier.CarrierId)
            {
                return BadRequest();
            }

            _context.Entry(tblCarrier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCarrierExists(id))
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

        // POST: api/tblCarriers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tblCarrier>> PosttblCarrier(tblCarrier tblCarrier)
        {
          if (_context.Carrier == null)
          {
              return Problem("Entity set 'AppDbContext.Carrier'  is null.");
          }
            _context.Carrier.Add(tblCarrier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettblCarrier", new { id = tblCarrier.CarrierId }, tblCarrier);
        }

        // DELETE: api/tblCarriers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetblCarrier(int id)
        {
            if (_context.Carrier == null)
            {
                return NotFound();
            }
            var tblCarrier = await _context.Carrier.FindAsync(id);
            if (tblCarrier == null)
            {
                return NotFound();
            }

            _context.Carrier.Remove(tblCarrier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tblCarrierExists(int id)
        {
            return (_context.Carrier?.Any(e => e.CarrierId == id)).GetValueOrDefault();
        }
    }
}
