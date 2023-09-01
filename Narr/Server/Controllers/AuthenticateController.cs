using Azure;
using GuessBender.Client.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Narevim.Server.Data;
using Narevim.Server.Models;
using Narevim.Shared;
using Narr.Server.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Response = GuessBender.Client.Auth.Response;

namespace GuessBender.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public AuthenticateController(UserManager<ApplicationUser> userManager, IConfiguration configuration, ApplicationDbContext context)
        {
            this.userManager = userManager;
            _configuration = configuration;
            _context = context;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([Required][FromForm] string email, [Required][FromForm] string password)
        {
            LoginModel model = new LoginModel { Email=email,Password=password};
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                        new Claim(JwtRegisteredClaimNames.Sub,user.Id)

                };

               

            //    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    //issuer: _configuration["JWT:ValidIssuer"],
                    //audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims
                    //signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                var id = userManager.GetUserIdAsync(user);

                CookieOptions option = new CookieOptions();

               
                
                    option.Expires = DateTime.Now.AddDays(10);

                Response.Cookies.Append("ci_session", id.Result, option);
                return new JsonResult(new
                {
                    status="success",
                    message="Giriş işlemi başarılıdır !",
                    data=_context.Users.Where(a=>a.Id==id.Result).ToListAsync().Result,
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    id = id.Result
                });
            }
            return Unauthorized();
        }

        [HttpGet("memberInfo")]
        public async Task<ActionResult<IEnumerable<Basket>>> GetmemberInfo()
        {
            if (_context.Slider == null)
            {
                return NotFound();
            }
            string userId = Request.Cookies["ci_session"];

            return new JsonResult(new
            {
                status = "success",
                message = "Kullancı bilgileri başarılı bir şekilde getirildi.",
                data =  JsonConvert.SerializeObject( _context.Users.Where(a=>a.Id==userId).ToList())
            });
        }


        [Consumes("application/x-www-form-urlencoded")]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([Required] [FromForm] string email, [Required][FromForm] string password, [Required][FromForm] string telephone, [Required][FromForm] string name)
        {
            RegisterModel model = new RegisterModel { Email=email,Password=password,Name=name,Telephone= telephone };
            var userExists = await userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Client.Auth.Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
               ,name = model.Name,
                telephone=model.Telephone
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return Ok( new{ Status = "Error", Message = result.Errors });
            return Ok(new Response { Status = "Success", Message = "Başarıyla üye olundu" });
        }

        //[HttpPost]
        //[Route("register-admin")]
        //public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        //{
        //    var userExists = await userManager.FindByNameAsync(model.Username);
        //    if (userExists != null)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

        //    ApplicationUser user = new ApplicationUser()
        //    {
        //        Email = model.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = model.Username
        //    };
        //    var result = await userManager.CreateAsync(user, model.Password);
        //    if (!result.Succeeded)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        //    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //    if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //    if (await roleManager.RoleExistsAsync(UserRoles.Admin))
        //    {
        //        await userManager.AddToRoleAsync(user, UserRoles.Admin);
        //    }

        //    return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        //}
    
    }
}
