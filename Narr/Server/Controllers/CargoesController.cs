using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Narevim.Server.Data;
using Narevim.Shared;
using Narr.Server.Data;

namespace Narevim.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class CargoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CargoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cargoes
        [HttpGet("cargo")]
        public async Task<ActionResult<IEnumerable<Basket>>> GetCargo()
        {
            if (_context.Cargo == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                data = _context.Cargo.ToList(),
                error_code = 0,
                message = "Kargo listesi çekildi",
            }); ;
        }
        // GET: api/Cargoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> GetCargo(int id)
        {
          if (_context.Cargo == null)
          {
              return NotFound();
          }
            var cargo = await _context.Cargo.FindAsync(id);

            if (cargo == null)
            {
                return NotFound();
            }

            return cargo;
        }

        // PUT: api/Cargoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargo(int id, Cargo cargo)
        {
            if (id != cargo.id)
            {
                return BadRequest();
            }

            _context.Entry(cargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(id))
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

        // POST: api/Cargoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cargo>> PostCargo(Cargo cargo)
        {
          if (_context.Cargo == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Cargo'  is null.");
          }
            _context.Cargo.Add(cargo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCargo", new { id = cargo.id }, cargo);
        }

        // DELETE: api/Cargoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            if (_context.Cargo == null)
            {
                return NotFound();
            }
            var cargo = await _context.Cargo.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }

            _context.Cargo.Remove(cargo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CargoExists(int id)
        {
            return (_context.Cargo?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
