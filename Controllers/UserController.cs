using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using GuestHibajelentesEvvegi.Data;
using GuestHibajelentesEvvegi.Models;
using GuestHibajelentesEvvegi.Services;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAuthService _AuthService;

        RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper automapper, AppDbContext context, IAuthService AuthService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _Automapper = automapper;
            _context = context;
            _AuthService = AuthService;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel model)
        {
            if (model.Username != "user" || model.Password != "password")
            {
                return Unauthorized();
            }

            // For demo purposes - in a real app, get this from your user management system
            var userId = "123";
            var roles = new[] { "User" };

            // Generate tokens
            var (accessToken, refreshToken) = _AuthService.GenerateTokens(userId, model.Username, roles);

            // Set refresh token in HTTP-only cookie
            Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Set to true in production with HTTPS
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7) // Refresh token with longer lifetime
            });

            // Return access token in response body
            return Ok(new
            {
                AccessToken = accessToken,
                ExpiresIn = 900 // 15 minutes in seconds
            });


            //Régi kód

            //User user = await _userManager.FindByNameAsync(name);
            //if (user == null)
            //{
            //    return NotFound();
            //}

            //var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            //if (result.Succeeded)
            //{
            //    //_logger.LogDebug("Kész");
            //    return Ok(new {token= await GenerateJwtToken(user) , refreshToken = "xd", user=_Automapper.Map<UserDto>(user)});
            //}
            //else
            //{
            //    return Unauthorized();
            //}
        }

        [Route("Logout")]
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> LogoutUser()
        {
            _signInManager.SignOutAsync();
            Response.Cookies.Delete("refreshToken");
            
            return Ok(RedirectToAction("Login", "User"));
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
                // Extract claims from the expired access token
                var principal = _AuthService.GetPrincipalFromExpiredToken(accessToken);
                var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var username = principal.FindFirst(ClaimTypes.Name)?.Value;
                var roles = principal.FindAll(ClaimTypes.Role).Select(c => c.Value);

                // Generate new tokens
                var newTokens = _AuthService.GenerateTokens(userId, username, roles);

                // Set new refresh token in cookie
                Response.Cookies.Append("refreshToken", newTokens.refreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7)
                });

                // Return new access token
                return Ok(new
                {
                    AccessToken = newTokens.accessToken,
                    ExpiresIn = 900 // 15 minutes in seconds
                });
            }
            catch (Exception)
            {
                return Unauthorized("Invalid token");
            }
        }

        //Old Token generation

        //private async Task<string> GenerateJwtToken(User user)
        //{
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var roles = await _userManager.GetRolesAsync(user);
        //    List<Claim> userClaims = new List<Claim>();

        //    foreach (var role in roles)
        //    {
        //        userClaims.Add(new Claim(ClaimTypes.Role, role));
        //    }


        //    var token = new JwtSecurityToken(
        //        issuer: _configuration["JWT:Issuer"],
        //        audience: _configuration["JWT:Audience"],
        //        claims: userClaims,
        //        expires: DateTime.Now.AddMinutes(30),
        //        signingCredentials: creds);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        //Function for finding tasks from the id of an error

        //public async Task<IActionResult> FindTasks(int errorId)
        //{
        //    var errorTasks = await _context.Tasks.Where(t => t.associated_error.Id == errorId).ToListAsync();
        //    return Ok(errorTasks);
        //}
    }
}


    

   

    
    


   