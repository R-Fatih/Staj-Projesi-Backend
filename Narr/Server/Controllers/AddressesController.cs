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
    public class AddressesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet("address")]
        public async Task<ActionResult<IEnumerable<Basket>>> GetAddressList()
        {
            string userId = Request.Cookies["ci_session"];

            if (_context.Address == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Adres listesi çekildi",
                data = _context.Address.FromSqlRaw("select address.id,name,surname,email,telephone,clear_address,billing_city_id,billing_town_id,billing_cityid,billing_townid,billing_clear_address,billing_name,billing_surname,billing_email,billing_telephone,city_id,town_id,townid,address.cityid,user_id,city.title as 'city2',town.title as 'town2' from address inner join city on address.city_id=city.id inner join town on address.town_id=town.id").Include(c=>c.city).Include(a=>a.town).ToList(),
                error_code = 0
            });
        }
        [HttpPost("address")]
        public async Task<ActionResult<IEnumerable<Basket>>> GetAddressDetail([Required][FromForm] int address_id)
        {
            string userId = Request.Cookies["ci_session"];

            if (_context.Address == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Adres listesi çekildi",
                data = _context.Address.Where(a => a.user_id == userId&&a.id==address_id).ToList(),
                error_code = 0
            });
        }


        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("updateAddress")]
        public async Task<IActionResult> PutAddress(
            [Required][FromForm]   string name,
        [Required][FromForm] string surname ,
        [Required][FromForm] string email ,
        [Required][FromForm] string telephone ,
        [Required][FromForm] string clear_address ,
        [Required][FromForm] int city ,
        [Required][FromForm] int town ,
        [Required][FromForm] string billing_name ,
        [Required][FromForm]
        string billing_surname ,
        [Required][FromForm] string billing_email ,
        [Required][FromForm] string billing_telephone ,
        [Required][FromForm] string billing_clear_address ,
        [Required][FromForm] int billing_city ,
        [Required][FromForm]
        int billing_town , [Required][FromForm] int address_id


                    )
        {
            Address address = new Address
            {
                billing_city_id=billing_city,
                billing_clear_address=billing_clear_address,
                billing_name=billing_name,
                billing_telephone=billing_telephone,
                billing_email=billing_email,
                billing_surname =billing_surname,
                billing_town_id=billing_town,
                city_id=city,
                clear_address=clear_address,
                email=email,
                name=name,
                surname=surname,
                telephone=telephone,
                town_id=town,
                id=address_id
            };
          

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    status = "success",
                    message = "Adres başarıyla güncellendi",
                    error_code = 0
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(address_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

           
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("saveAddress")]
        public async Task<ActionResult<Address>> PostAddress(
            [Required][FromForm] string name,
        [Required][FromForm] string surname,
        [Required][FromForm] string email,
        [Required][FromForm] string telephone,
        [Required][FromForm] string clear_address,
        [Required][FromForm] int city,
        [Required][FromForm] int town,
        [Required][FromForm] string billing_name,
        [Required][FromForm]
        string billing_surname,
        [Required][FromForm] string billing_email,
        [Required][FromForm] string billing_telephone,
        [Required][FromForm] string billing_clear_address,
        [Required][FromForm] int billing_city,
        [Required][FromForm]
        int billing_town


                    )
        {
            string userId = Request.Cookies["ci_session"];

            Address address = new Address
            {
                billing_city_id = billing_city,
                billing_clear_address = billing_clear_address,
                billing_name = billing_name,
                billing_telephone = billing_telephone,
                billing_email = billing_email,
                billing_surname = billing_surname,
                billing_town_id = billing_town,
                city_id = city,
                clear_address = clear_address,
                email = email,
                name = name,
                surname = surname,
                telephone = telephone,
                town_id = town,
                user_id=userId
            };
            if (_context.Address == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Address'  is null.");
          }
            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                status = "success",
                message = "Adres başarıyla eklendi",
                error_code = 0
            });
        }

        // DELETE: api/Addresses/5
        [HttpPost("removeAddress")]
        public async Task<IActionResult> DeleteAddress([Required][FromForm] int address_id)
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            var address = await _context.Address.FindAsync(address_id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                status = "success",
                message = "Adres başarıyla kaldırıldı",
                error_code = 0
            });
        }

        private bool AddressExists(int id)
        {
            return (_context.Address?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
