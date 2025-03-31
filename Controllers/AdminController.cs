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

        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel registerModel)
        {
            User user = new User
            {
                UserName = registerModel.Username,
                Email = registerModel.Email,
            };

            IdentityResult user_result = await _userManager.CreateAsync(user, registerModel.Password);
            IdentityResult role_result = await _userManager.AddToRoleAsync(user, registerModel.RoleName);
            if (user_result.Succeeded && role_result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(user_result.Errors);
            }
        }

        // Role API's

        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<IActionResult> AllRoles() 
        {
            return Ok(await _roleManager.Roles.ToListAsync());
        }

        //---API to add Role's if needed in future use

        [HttpPost]
        [Route("AddRole")]

        public async Task<IActionResult> AddRole([FromBody] IdentityRole role)
        {
            IdentityResult result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Role added successfully." });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPut]
        [Route("UpdateRole")]

        public async Task<IActionResult> UpdateRole([FromBody] IdentityRole role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingRole = await _roleManager.FindByIdAsync(role.Id);
            if (existingRole == null)
            {
                return NotFound(new { Message = "Role not found." });
            }
            
            existingRole.Name = role.Name;
            
            IdentityResult result = await _roleManager.UpdateAsync(existingRole);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Role updated successfully." });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpDelete]
        [Route("DeleteRole/{id}")]

        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound(new { Message = "Role not found." });
            }

            IdentityResult result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Role deleted successfully." });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        // Machine API's

        [HttpGet]
        [Route("GetAllMachines")]
        public async Task<IActionResult> AllMachines()
        {
            return Ok(await _context.Machines.ToListAsync());
        }

        [HttpPost]
        [Route("AddMachine")]

        public async Task<IActionResult> AddMachine([FromBody] Machine machine)
        {
            machine.created_at = DateTime.Now;
            _context.Machines.Add(machine);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while adding the machine." });
            }

            return Ok(new { Message = "Machine added successfully." });
        }

        [HttpPut]
        [Route("UpdateMachine")]

        public async Task<IActionResult> UpdateMachine([FromBody] Machine machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingMachine = await _context.Machines.FindAsync(machine.Id);
            if (existingMachine == null)
            {
                return NotFound(new { Message = "Machine not found." });
            }

            existingMachine.name = machine.name;
            existingMachine.status = machine.status;
            existingMachine.hall = machine.hall;
            existingMachine.created_at = machine.created_at;

            _context.Machines.Update(existingMachine);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating the machine." });
            }

            return Ok(new { Message = "Machine updated successfully." });

        }

        [HttpDelete]
        [Route("DeleteMachine/{id}")]

        public async Task<IActionResult> DeleteMachine(int id)
        {
            var machine = await _context.Machines.FindAsync(id);
            if (machine == null)
            {
                return NotFound(new { Message = "Machine not found." });
            }

            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Machine deleted successfully." });
        }

        // Error log API's

        [HttpGet]
        [Route("GetAllErrorLogs")]
        public async Task<IActionResult> AllErrorLogs()
        {
            return Ok(await _context.Error_logs.ToListAsync());
        }

        [Route("GetErrorLogDetails/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetErrorLogDetails(int id)
        {
            var errorLog = await _context.Error_logs.FindAsync(id);
            if (errorLog == null)
            {
                return NotFound(new { Message = "Error not found." });
            }

            var baseError = await _context.Errors.FindAsync(errorLog.base_error);
            var notifiedUser = await _userManager.FindByIdAsync(errorLog.user_id);
            

            var errorLogDetails = new
            {
                errorLog.Id,
                errorLog.description,
                base_error = baseError,
                notified_worker = notifiedUser.UserName,
                errorLog.created_at
            };

            return Ok(errorLog);
        }

        // User API's
        //The adding of users is done in the registration API

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> AllUsers()
        {
            return Ok(await _userManager.Users.ToListAsync());
        }


        [HttpGet]
        [Route("GetAllLinesman")]
        public async Task<IActionResult> AllLinesman()
        {

            var linesmans = await _userManager.GetUsersInRoleAsync("Linesman");
            return Ok(linesmans);
        }


        [HttpGet]
        [Route("GetAllRepairman")]
        public async Task<IActionResult> AllRepairman()
        {

            var repairman = await _userManager.GetUsersInRoleAsync("Repairman");
            return Ok(repairman);
        }

        //The updating of users doesn't seem to be necessary for now, but can be added in the future if needed
        [HttpDelete]
        [Route("DeleteUser/{id}")]

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            IdentityResult result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok(new { Message = "User deleted successfully." });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        // Error API's

        [HttpPut]
        [Route("UpdateError")]

        public async Task<IActionResult> UpdateError([FromBody] Error error)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingError = await _context.Errors.FindAsync(error.Id);
            if (existingError == null)
            {
                return NotFound(new { Message = "Error not found." });
            }

            // Update the existing error with the new values
            existingError.description = error.description;
            existingError.status = error.status;
            existingError.assigned_to = error.assigned_to;
            existingError.machine_id = error.machine_id;
            // Update other fields as necessary

            _context.Errors.Update(existingError);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating the error." });
            }

            return Ok(new { Message = "Error updated successfully." });
        }

        [HttpDelete]
        [Route("DeleteError/{id}")]

        public async Task<IActionResult> DeleteError(int id)
        {
            var error = await _context.Errors.FindAsync(id);
            if (error == null)
            {
                return NotFound(new { Message = "Error not found." });
            }

            _context.Errors.Remove(error);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Error deleted successfully." });
        }

    }
}
