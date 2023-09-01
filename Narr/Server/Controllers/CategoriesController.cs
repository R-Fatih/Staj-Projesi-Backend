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

    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet("firstCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetFirstCategories()
        {
            if (_context.Category == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Ana Kategoriler Başarıyla Listelendi !",
                data = _context.Category.Where(a => a.first_group_id == null).ToList(),
                image_path = "http://eticaret.demo.pigasoft.com/panel/uploads/product_first_group_v/"
            });
        }
        [HttpPost("secondCategories")]
        public async Task<ActionResult<Category>> PostSecondCategories([Required][FromForm] int first_category_id)
        {
            if (_context.Category == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Category'  is null.");
            }


            return Ok(new
            {
                status = "success",
                message = "2. Kategoriler Başarıyla Listelendi !",
                data = _context.Category.Where(a => a.first_group_id == first_category_id&&a.rank==1).ToList(),
                image_path = "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_second_group_v/350x216/"
            });
        }
        [HttpPost("thirdCategories")]
        public async Task<ActionResult<Category>> PostThirdCategories([Required][FromForm] int second_category_id)
        {
            if (_context.Category == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Category'  is null.");
            }


            return Ok(new
            {
                status = "success",
                message = "3. Kategoriler Başarıyla Listelendi !",
                data = _context.Category.Where(a => a.second_group_id == second_category_id).ToList(),
                image_path = "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_third_group_v/350x216/"
            });
        }
        [Consumes("application/x-www-form-urlencoded")]
        [HttpPost("fourthCategories")]
        public async Task<ActionResult<Category>> PostFourthCategories([Required][FromForm] int third_group_id)
        {
            if (_context.Category == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Category'  is null.");
            }


            return Ok(new
            {
                status = "success",
                message = "3. Kategoriler Başarıyla Listelendi !",
                data = _context.Category.Where(a => a.third_group_id == third_group_id).ToList(),
                image_path = "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_third_group_v/350x216/"
            });
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            if (_context.Category == null)
            {
                return NotFound();
            }
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            if (_context.Category == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Category'  is null.");
            }
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.id }, category);
        }

        // DELETE: api/Categories/5
       

        private bool CategoryExists(int id)
        {
            return (_context.Category?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
