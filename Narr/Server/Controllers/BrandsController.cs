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
    public class BrandsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BrandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Brands
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<Basket>>> GetBrand()
        {
            if (_context.Brand  == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                data = _context.Brand.ToList(),
                error_code = 0,
                message = "Marka listesi çekildi",
                image_path= "http://eticaret.demo.pigasoft.com/panel/uploads/brands_v/228x290/"
            }); ;
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
          if (_context.Brand == null)
          {
              return NotFound();
          }
            var brand = await _context.Brand.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, Brand brand)
        {
            if (id != brand.id)
            {
                return BadRequest();
            }

            _context.Entry(brand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
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

        // POST: api/Brands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Consumes("application/x-www-form-urlencoded")]
        [HttpPost("brandProductList")]
        public async Task<ActionResult<Brand>> PostBrand([Required][FromForm] int page, [Required][FromForm] int per_page, [Required][FromForm] int brand_id, [Required][FromForm]  string sorting)
        {
            if (_context.Brand == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                data = _context.Brand.FromSqlRaw($"select * from Brand where id={brand_id}  order by id {sorting} OFFSET {page * per_page} ROWS FETCH NEXT {per_page} ROWS ONLY;").ToList(),
                error_code = 0,
                message = "Ürünler listesi çekildi",
                image_path = "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_v/original/"
            }); ;
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            if (_context.Brand == null)
            {
                return NotFound();
            }
            var brand = await _context.Brand.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.Brand.Remove(brand);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrandExists(int id)
        {
            return (_context.Brand?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
