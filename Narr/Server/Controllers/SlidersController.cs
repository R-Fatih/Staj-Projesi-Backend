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

    public class SlidersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SlidersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sliders
        [HttpGet("sliders")]
        public async Task<ActionResult<IEnumerable<Slider>>> GetSliders()
        {
            if (_context.Slider == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                status = "success",
                message = "Sliderlar Başarıyla Listelendi !",
                data = _context.Slider.ToList(),
                image_path = "https://www.demo.pigasoft.com/eticaret/panel/uploads/slides_v/1970x500/"
            });
        }


        // GET: api/Sliders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Slider>> GetSlider(int id)
        {
          if (_context.Slider == null)
          {
              return NotFound();
          }
            var slider = await _context.Slider.FindAsync(id);

            if (slider == null)
            {
                return NotFound();
            }

            return slider;
        }

        // PUT: api/Sliders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSlider(int id, Slider slider)
        {
            if (id != slider.id)
            {
                return BadRequest();
            }

            _context.Entry(slider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SliderExists(id))
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

        // POST: api/Sliders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Slider>> PostSlider(Slider slider)
        {
          if (_context.Slider == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Slider'  is null.");
          }
            _context.Slider.Add(slider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSlider", new { id = slider.id }, slider);
        }

        // DELETE: api/Sliders/5
 

        private bool SliderExists(int id)
        {
            return (_context.Slider?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
