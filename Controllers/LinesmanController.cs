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
        private readonly UserManager<IdentityUser> _userManager;
        public LinesmanController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Route("AddError")]
        [HttpPost]
        
        public async Task<IActionResult> AddNewError([FromForm] AddErrorDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var submittingUser = await _userManager.FindByNameAsync(model.SubmittedBy);
            if (submittingUser == null)
            {
                return BadRequest("Submitting user not found.");
            }

            var assignedUser = await _userManager.FindByNameAsync(model.AssignedTo);
            if (assignedUser == null)
            {
                return BadRequest("Assigned user not found.");
            }

            var error = new Error
            {
                status = 0,
                description = model.Description,
                submitted_by = submittingUser.Id,
                machine_id = model.MachineId,
                assigned_to = assignedUser.Id,
                created_at = DateTime.UtcNow
            };

            _context.Errors.Add(error);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Error added successfully.", ErrorId = error.Id });

        }
    }
}
