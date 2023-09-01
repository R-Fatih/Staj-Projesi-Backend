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
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet("orders")]
        public async Task<ActionResult<IEnumerable<Basket>>> GetOrders()
        {
            string userId = Request.Cookies["ci_session"];

            if (_context.Order == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Kullancı bilgileri başarılı bir şekilde getirildi.",
                data = _context.Order.Where(a => a.user_id == userId).Select(a=>new Order{
                    cargo_id = a.cargo_id,
                    member_adress   = a.member_adress,
                    order_date = a.order_date,
                    order_detail= _context.Order.Where(a => a.user_id == userId).Join(_context.OrderProduct, a => a.order_number, b => b.order_number, (a, b) => new {a,b}).Join(_context.Product, a => a.b.product_id, b => b.id, (a, products) => new { a,products}).Where(c=>c.a.a.order_number==a.order_number).Select(d=>d.products).ToList()
                    ,order_note=a.order_note,
                    order_number=a.order_number,
                    order_state=a.order_state,
                    payment_id=a.payment_id,
                    total_amount=a.total_amount,
                    user_id=a.user_id,
                   
                }).ToList(),
                image_path= "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_v/original/"
            });
        }
        [HttpPost("orderDetail")]
        public async Task<ActionResult<IEnumerable<Basket>>> GetorderDetail([Required][FromForm] string order_number)
        {
            string userId = Request.Cookies["ci_session"];

            if (_context.Order == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Kullancı bilgileri başarılı bir şekilde getirildi.",
                data = _context.OrderProduct.Where(a=>a.order_number==order_number).Join(_context.Product, a => a.product_id, b => b.id, (a, products) =>  products ).ToList(),
                image_path = "https://www.demo.pigasoft.com/eticaret/panel/uploads/product_v/original/"
            });
        }
        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
          if (_context.Order == null)
          {
              return NotFound();
          }
            var order = await _context.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("createOrder")]
        public async Task<ActionResult<Order>> PostOrder([Required][FromForm] int payment_type, [Required][FromForm] int cargo_id, [Required][FromForm] string order_note)
        {
            string userId = Request.Cookies["ci_session"];
            Order order = new Order
            {
                cargo_id = cargo_id,
                order_note = order_note,
                user_id = userId,
                order_number = Guid.NewGuid().ToString()
                , order_date = DateTime.Now.ToString("d")
                ,
            };
            if (_context.Order == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Order'  is null.");
          }
            _context.Order.Add(order);
            foreach (var item in _context.Basket.Include(a=>a.Product).Where(a=>a.UserId==userId).ToList())
            {

                _context.OrderProduct.Add(new OrderProduct { order_number = order.order_number, product_id = item.ProductId,qty=item.qty });


            }
            _context.Basket.ExecuteDelete();
            await _context.SaveChangesAsync();

            return Ok(new
            {
                status = "success",
                message = $"{order.order_number} sipariş verildi",
                order_number= order.order_number
            });
        }

        // DELETE: api/Orders/5
       

        private bool OrderExists(int id)
        {
            return (_context.Order?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
