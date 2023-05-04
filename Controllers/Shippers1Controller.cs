using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTemp.Models;

namespace WebTemp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Shippers1Controller : ControllerBase
    {
        private readonly NorthwindContext _context;

        public Shippers1Controller(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Shippers1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shippers>>> GetShippers()
        {
          if (_context.Shippers == null)
          {
              return NotFound();
          }
            return await _context.Shippers.ToListAsync();
        }

        // GET: api/Shippers1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shippers>> GetShippers(int id)
        {
          if (_context.Shippers == null)
          {
              return NotFound();
          }
            var shippers = await _context.Shippers.FindAsync(id);

            if (shippers == null)
            {
                return NotFound();
            }

            return shippers;
        }

        // PUT: api/Shippers1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippers(int id, Shippers shippers)
        {
            if (id != shippers.ShipperId)
            {
                return BadRequest();
            }

            _context.Entry(shippers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippersExists(id))
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

        // POST: api/Shippers1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shippers>> PostShippers(Shippers shippers)
        {
          if (_context.Shippers == null)
          {
              return Problem("Entity set 'NorthwindContext.Shippers'  is null.");
          }
            _context.Shippers.Add(shippers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShippers", new { id = shippers.ShipperId }, shippers);
        }

        // DELETE: api/Shippers1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippers(int id)
        {
            if (_context.Shippers == null)
            {
                return NotFound();
            }
            var shippers = await _context.Shippers.FindAsync(id);
            if (shippers == null)
            {
                return NotFound();
            }

            _context.Shippers.Remove(shippers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShippersExists(int id)
        {
            return (_context.Shippers?.Any(e => e.ShipperId == id)).GetValueOrDefault();
        }
    }
}
