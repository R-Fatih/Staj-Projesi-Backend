using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class CitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet("City")]
        public async Task<ActionResult<IEnumerable<Basket>>> GetCity()
        {
            if (_context.Slider == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Adres listesi çekildi",
                data = _context.City.ToList(),
                error_code= 0
            });
        }

        [HttpPost("Town")]
        public async Task<ActionResult<IEnumerable<Basket>>> PostTown([Required][FromForm] int city_id)
        {
            if (_context.Slider == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Adres listesi çekildi",
                data = _context.Town.Where(a=>a.cityid==city_id).ToList(),
                error_code = 0
            });
        }
        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
          if (_context.City == null)
          {
              return NotFound();
          }
            var city = await _context.City.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (id != city.id)
            {
                return BadRequest();
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
          if (_context.City == null)
          {
              return Problem("Entity set 'ApplicationDbContext.City'  is null.");
          }
            _context.City.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { id = city.id }, city);
        }

        // DELETE: api/Cities/5
        

        private bool CityExists(int id)
        {
            return (_context.City?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
