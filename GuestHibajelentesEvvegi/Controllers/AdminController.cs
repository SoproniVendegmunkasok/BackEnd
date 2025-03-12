using GuestHibajelentesEvvegi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GuestHibajelentesEvvegi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;

        RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AdminController(UserManager<User> userManager, /*SignInManager<User> signInManager,*/ RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [Route("Registration")]
        [HttpPost]

        public async Task<IActionResult> RegisterUser(string username, string password, string email, string roleName)
        {
            User user = new User
            {
                UserName = username,
                Email = email,
            };

            IdentityResult user_result = await _userManager.CreateAsync(user, password);
            IdentityResult role_result = await _userManager.AddToRoleAsync(user, roleName);
            if (user_result.Succeeded && role_result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(user_result.Errors);
            }
        }

    }
}
