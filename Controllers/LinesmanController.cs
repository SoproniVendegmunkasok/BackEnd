using GuestHibajelentesEvvegi.Data;
using GuestHibajelentesEvvegi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GuestHibajelentesEvvegi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinesmanController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        public LinesmanController(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Route("AddError")]
        [HttpPost]
        
        public async Task<IActionResult> AddNewError([FromBody] AddErrorDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var submittingUser = await _userManager.FindByNameAsync(model.submitted_by);
            if (submittingUser == null)
            {
                return BadRequest("Submitting user not found.");
            }

            var assignedUser = await _userManager.FindByNameAsync(model.assigned_to);
            if (assignedUser == null)
            {
                return BadRequest("Assigned user not found.");
            }

            var error = new Error
            {
                status = 0,
                description = model.description,
                submitted_by = submittingUser.Id,
                machine_id = model.machine_id,
                assigned_to = assignedUser.Id,
                created_at = DateTime.UtcNow
            };

            await _context.Errors.AddAsync(error);

            //Set the status of the machine to hibas
            var hibasMachine = await _context.Machines.FindAsync(model.machine_id);
            if (hibasMachine != null)
            {
                hibasMachine.status = Status_machine.hibas; // Update the machine status
            }

            await _context.SaveChangesAsync();

            return Ok(new { Message = "Error added successfully.", ErrorId = error.Id });

        }

        [Route("GetErrorDetails/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetErrorDetails(int id)
        {
            var error = await _context.Errors.FindAsync(id);
            if (error == null)
            {
                return NotFound(new { Message = "Error not found." });
            }

            var submittingUser = await _userManager.FindByIdAsync(error.submitted_by);
            var assignedUser = await _userManager.FindByIdAsync(error.assigned_to);
            var machine = await _context.Machines.FindAsync(error.machine_id);

            var errorDetails = new
            {
                error.Id,
                error.status,
                error.description,
                SubmittedBy = submittingUser?.UserName,
                Machine = machine?.name,
                AssignedTo = assignedUser?.UserName,
                error.created_at
            };

            return Ok(errorDetails);
        }
    }
}
