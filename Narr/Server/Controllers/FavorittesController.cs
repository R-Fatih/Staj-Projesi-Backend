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
    public class FavorittesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FavorittesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Favorittes
        [HttpPost("favoritte")]
        public async Task<ActionResult<IEnumerable<Basket>>> GetFavoritte([FromForm] string userId)
        {
            //string userId = Request.Cookies["ci_session"];

            if (_context.Favoritte == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Favori listesi getirildi",
                data = _context.Product.FromSqlRaw($"SELECT product.[id],[url]\r\n      ,[code_url]\r\n      ,[code]\r\n      ,[title]\r\n      ,[description]\r\n      ,[product_description]\r\n      ,[product_keywords]\r\n      ,[summary]\r\n      ,[features]\r\n      ,[prodcut_number]\r\n      ,[price]\r\n      ,[discount_price]\r\n      ,[money_unit]\r\n      ,[design_url]\r\n      ,[brand_id]\r\n      ,[first_group_id]\r\n      ,[second_group_id]\r\n      ,[third_group_id]\r\n      ,[desi]\r\n      ,[video_url]\r\n      ,[rank]\r\n      ,[homeRank]\r\n      ,[stock]\r\n      ,[isColor]\r\n      ,[isSize]\r\n      ,[isDiscount]\r\n      ,[isActive]\r\n      ,[isNew]\r\n      ,[isHome]\r\n      ,[isOpportunity]\r\n      ,[isFreeCargo]\r\n      ,[isBanner]\r\n      ,[isWeekStar]\r\n      ,[isMostSeller]\r\n      ,[createdAt]\r\n      ,[campaign_rank]\r\n      ,[img_url]\r\n      ,[brand]\r\n      ,[point]\r\n      ,[review]\r\n      ,[discountRatio] from Favoritte inner join Product on Favoritte.product_id=Product.id where Favoritte.user_id='{userId}'  ").ToList(),
                error_code = 0
            });
        }
        [HttpPost("toggleFavoritte")]
        public async Task<ActionResult<Favoritte>> PostFavoritte([Required][FromForm] int product_id)
        {
            string userId = Request.Cookies["ci_session"];
            Favoritte favoritte = new Favoritte { product_id = product_id, user_id = userId };
            bool toggle = false;
            if (_context.Favoritte == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Favoritte'  is null.");
          }
            var favoritte2 =  _context.Favoritte.Where(a=>a.product_id==product_id&&a.user_id==userId).ToList();
            Console.WriteLine(favoritte2);
            if (favoritte2.Count == 0)
            {

                toggle = true;
            _context.Favoritte.Add(favoritte);
            await _context.SaveChangesAsync();
                return Ok(new
                {
                    status = "success",
                    message = "Ürün favori listenize eklendi",
                    operation_status = 1
                });
            }
            else
            {
                toggle = false;

                _context.Favoritte.Remove(favoritte2.First());
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    status = "success",
                    message = "Ürün favori listenizden çıkarıldı",
                    operation_status = 0
                });
            }
           
               

        }

        // DELETE: api/Favorittes/5
     

        private bool FavoritteExists(int id)
        {
            return (_context.Favoritte?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
