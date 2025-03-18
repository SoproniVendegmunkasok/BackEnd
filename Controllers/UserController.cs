using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using GuestHibajelentesEvvegi.Data;
using GuestHibajelentesEvvegi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GuestHibajelentesEvvegi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _Automapper;
        private readonly AppDbContext _context;

        RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper automapper, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _Automapper = automapper;
            _context = context;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromForm] string name, [FromForm] string password)
        {
            User user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (result.Succeeded)
            {
                //_logger.LogDebug("Kész");
                return Ok(new {token= await GenerateJwtToken(user) , user=_Automapper.Map<UserDto>(user)});
            }
            else
            {
                return Unauthorized();
            }
        }

        [Route("Logout")]
        [HttpPost]

        public async Task<IActionResult> LogoutUser()
        {
            _signInManager.SignOutAsync();
            
            return RedirectToAction("Login", "User");
        }

        [Route("Show_Errors")]
        [HttpGet]

        public List<Error> ShowErrors()
        {
            List<Error> Error_list = _context.Errors.ToList();

            return Error_list;

        }

        //Token generation

        private async Task<string> GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            List<Claim> userClaims = new List<Claim>();

            foreach (var role in roles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, role));
            }


            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}


    

   

    
    


   