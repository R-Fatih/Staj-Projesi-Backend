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

    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet("mainProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetMainProducts()
        {
            if (_context.Slider == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Anasayfa Ürünleri Başarıyla Listelendi !",
                data = _context.Product.Where(a=>a.isHome==1).ToList(),
                image_path = "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_v/original/"
            });
        }
        [HttpPost("productDetail")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductDetail([Required][FromForm] int product_id)
        {
            if (_context.Slider == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Ürün Başarıyla Listelendi !",
                data = _context.Product.Where(a => a.id == product_id).ToList(),
                image_path = "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_v/original/"
                ,images=new List<string>
                {
                      "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_v/original/vip-set-premium-cizgili-oyun-alani-hedyeli-vp-600-215.jpg",
        "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_v/original/vip-set-premium-cizgili-oyun-alani-hedyeli-vp-600-216.jpg",
        "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_v/original/vip-set-premium-cizgili-oyun-alani-hedyeli-vp-600-217.jpg"
                }
            });
        }
        [HttpPost("getUrl")]
        public async Task<ActionResult<IEnumerable<Product>>> GetUrl([Required][FromForm] string url_string, [Required][FromForm] int page, [Required][FromForm] int per_page, [Required][FromForm] string sorting)
        {
            if (_context.Slider == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Ürünler Başarıyla Listelendi !",
                data = _context.Product.FromSqlRaw($"select * from Product where url='{url_string}' order by id {sorting} OFFSET {page * per_page} ROWS FETCH NEXT {per_page} ROWS ONLY;").ToList(),
                image_path = "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_v/original/"
            });
        }
        [HttpPost("searchProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetSearchProduct([Required][FromForm] string keywords, [Required][FromForm] int page, [Required][FromForm] int per_page, [Required][FromForm] string sorting)
        {
            if (_context.Slider == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Ürünler Başarıyla Listelendi !",
                data = _context.Product.FromSqlRaw($"select * from Product where title like '%{keywords}%' order by id {sorting} OFFSET {page*per_page} ROWS FETCH NEXT {per_page} ROWS ONLY;").ToList(),
                image_path = "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_v/original/"
            });
        }
        [HttpPost("productList")]
        public async Task<ActionResult<IEnumerable<Product>>> GetproductList([Required][FromForm] int category_id,[FromForm] int category, [Required][FromForm] int page, [Required][FromForm] int per_page, [Required][FromForm] string sorting)
        {
            if (_context.Slider == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Ürünler Başarıyla Listelendi !",
                data = _context.Product.FromSqlRaw($"select * from Product where third_group_id={category_id} order by id {sorting} OFFSET {page * per_page} ROWS FETCH NEXT {per_page} ROWS ONLY;").ToList(),
                image_path = "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_v/original/"
            });
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          if (_context.Product == null)
          {
              return NotFound();
          }
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
          if (_context.Product == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
          }
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
