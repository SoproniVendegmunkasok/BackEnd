using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using GuestHibajelentesEvvegi.Data;
using GuestHibajelentesEvvegi.Models;
using GuestHibajelentesEvvegi.Services;
using GuestHibajelentesEvvegi.SignalRHubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IAuthService _AuthService;
        private readonly IHubContext<ErrorHub> _hubContext;

        RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper automapper, AppDbContext context, IAuthService AuthService, IHubContext<ErrorHub> hubContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _Automapper = automapper;
            _context = context;
            _AuthService = AuthService;
            _hubContext = hubContext;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel model)
        {

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized();
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var (accessToken, refreshToken) = _AuthService.GenerateTokens(user.Id, model.Username, userRoles);

            Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.Now.AddDays(7)
            });

            return Ok(new
            {
                AccessToken = accessToken,
                ExpiresIn = 900,
            });

        }

        [Route("Logout")]
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> LogoutUser()
        {
            await _signInManager.SignOutAsync();
            Response.Cookies.Delete("refreshToken");

            await _hubContext.Clients.All.SendAsync("UserLoggedOut", new
            {
                Message = "A user has logged out.",
                UserId = User.Identity?.Name
            });
            return Ok();
        }

        [Route("Show_Errors")]
        [HttpGet]

        public async Task<IActionResult> ShowErrors()
        {
            var errors = await _context.Errors.ToListAsync();
            var machines = await _context.Machines.ToListAsync();
            var workers = await _context.Users.ToListAsync();

            var errorsWithTasks = new List<object>();
            foreach (var error_ in errors)
            {
                var tasks_ = await _context.Tasks.Where(t => t.associated_error.Id == error_.Id).ToListAsync();
                var machine_ = await _context.Machines.Where(m => m.Id == error_.machine_id).ToListAsync();
                var worker_ = await _context.Users.Where(w => w.Id == error_.submitted_by).ToListAsync();
                errorsWithTasks.Add(new
                {
                    error = error_,
                    tasks = tasks_,
                    machine = machine_,
                    worker = worker_,
                });
            }

            if (errorsWithTasks == null || errorsWithTasks.Count == 0)
            {
                return NotFound(new { Message = "No errors found." });
            }

            return Ok(errorsWithTasks);

        }

        [Route("refresh-token")]
        [HttpPost]
        public IActionResult RefreshToken()
        {
            // Get refresh token from cookie
            var refreshToken = Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(refreshToken))
            {
                return BadRequest("Refresh token is required");
            }

            // Get access token from Authorization header
            var accessToken = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(accessToken))
            {
                return BadRequest("Access token is required");
            }

            // Validate refresh token
            if (!_AuthService.ValidateRefreshToken(refreshToken))
            {
                return Unauthorized("Invalid refresh token");
            }

            try
            {
                var principal = _AuthService.GetPrincipalFromExpiredToken(accessToken);
                var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var username = principal.FindFirst(ClaimTypes.Name)?.Value;
                var roles = principal.FindAll(ClaimTypes.Role).Select(c => c.Value);

                var newTokens = _AuthService.GenerateTokens(userId, username, roles);

                // Set new refresh token in cookie
                Response.Cookies.Append("refreshToken", newTokens.refreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.Now.AddDays(7)
                }); 

                return Ok(new
                {
                    AccessToken = newTokens.accessToken,
                    ExpiresIn = 900 
                });
            }
            catch (Exception)
            {
                return Unauthorized("Invalid token");
            }
        }
    }
}


    

   

    
    


   