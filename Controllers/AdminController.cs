using GuestHibajelentesEvvegi.Data;
using GuestHibajelentesEvvegi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        private readonly AppDbContext _context;

        public AdminController(UserManager<User> userManager, /*SignInManager<User> signInManager,*/ RoleManager<IdentityRole> roleManager, IConfiguration configuration, AppDbContext context)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

        [Route("Registration")]
        [HttpPost]

        public async Task<IActionResult> RegisterUser([FromForm]string username, [FromForm] string password, [FromForm] string email, [FromForm] string roleName)
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

        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<IActionResult> AllRoles() 
        {
            return Ok(await _roleManager.Roles.ToListAsync());
        }

        [HttpGet]
        [Route("GetAllMachines")]
        public async Task<IActionResult> AllMachines()
        {
            return Ok(await _context.Machines.ToListAsync());
        }

        [HttpGet]
        [Route("GetAllErrorLogs")]
        public async Task<IActionResult> AllErrorLogs()
        {
            return Ok(await _context.Error_logs.ToListAsync());
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> AllUsers()
        {
            return Ok(await _userManager.Users.ToListAsync());
        }

    }
}
