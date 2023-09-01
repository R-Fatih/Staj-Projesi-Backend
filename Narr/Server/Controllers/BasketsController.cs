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
    public class BasketsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BasketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Baskets
        [HttpGet("GetBasket")]
        public async Task<ActionResult<IEnumerable<Basket>>> GetBasket()
        {
            if (_context.Slider == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Ürünler getirildi.",
                data = _context.Basket.Include(a => a.Product).ToList(),
                total = _context.Basket.ToList().Sum(a => a.Product.price*a.qty)
            }); ;
        }
        [HttpPost("AddBasket")]
        public async Task<ActionResult<Basket>> AddBasket([Required][FromForm] int product_id, [Required][FromForm] int qty)
        {
            if (_context.Basket == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Basket'  is null.");
            }
            string userId = Request.Cookies["ci_session"];

            var basket = _context.Basket.Where(a => a.UserId == userId && a.ProductId == product_id).ToList();
            if (basket.Count == 0)
            {
                _context.Basket.Add(new Basket { ProductId = product_id, qty = qty, UserId = userId });
                await _context.SaveChangesAsync();

            }
            else
            {
                basket[0].qty += qty;
                _context.Entry(basket[0]).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }


            return Ok(new
            {
                status = "success",
                message = "Ürün Başarıyla Sepete Eklendi !",
                sessionid = userId
            });
        }


        // GET: api/Baskets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Basket>> GetBasket(int id)
        {
          if (_context.Basket == null)
          {
              return NotFound();
          }
            var basket = await _context.Basket.FindAsync(id);

            if (basket == null)
            {
                return NotFound();
            }

            return basket;
        }

        // PUT: api/Baskets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasket(int id, Basket basket)
        {
            if (id != basket.id)
            {
                return BadRequest();
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasketExists(id))
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

        // POST: api/Baskets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Basket>> PostBasket(Basket basket)
        {
          if (_context.Basket == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Basket'  is null.");
          }
            _context.Basket.Add(basket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasket", new { id = basket.id }, basket);
        }

        // DELETE: api/Baskets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket(int id)
        {
            if (_context.Basket == null)
            {
                return NotFound();
            }
            var basket = await _context.Basket.FindAsync(id);
            if (basket == null)
            {
                return NotFound();
            }

            _context.Basket.Remove(basket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BasketExists(int id)
        {
            return (_context.Basket?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
