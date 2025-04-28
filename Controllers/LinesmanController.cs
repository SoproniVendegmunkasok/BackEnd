using GuestHibajelentesEvvegi.Data;
using GuestHibajelentesEvvegi.Models;
using GuestHibajelentesEvvegi.Services;
using GuestHibajelentesEvvegi.SignalRHubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace GuestHibajelentesEvvegi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinesmanController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHubContext<ErrorHub> _hubContext;
        private readonly ILoggingService _loggingService;

        public LinesmanController(AppDbContext context, UserManager<User> userManager, IHubContext<ErrorHub> hubContext, ILoggingService loggingService)
        {
            _context = context;
            _userManager = userManager;
            _hubContext = hubContext;
            _loggingService = loggingService;
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
                created_at = DateTime.Now
            };

            await _context.Errors.AddAsync(error);

            //Set the status of the machine to hibas
            var hibasMachine = await _context.Machines.FindAsync(model.machine_id);
            if (hibasMachine != null)
            {
                hibasMachine.status = Status_machine.faulty; 
            }

            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("ErrorAdded", error);

            //Function makes an errorLog
            await _loggingService.createErrorLog(error.Id);

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

        [Route("ChangeErrorStatus/{id}")]
        [HttpPut]

        public async Task<IActionResult> ChangeErrorStatus(int id)
        {
            var error = await _context.Errors.FindAsync(id);

            if (error == null)
            {
                return NotFound(new { Message = "Error not found." });
            }

            var associatedMachine = await _context.Machines.FindAsync(error.machine_id);

            if (associatedMachine == null)
            {
                return NotFound(new { Message = "Associated machine not found." });
            }

            switch(error.status)
            {
                case Status_error.Unbegun:
                    error.status = Status_error.UnderRepair; 
                    break;
                case Status_error.UnderRepair:
                    error.status = Status_error.Finished;
                    // Used to set the machines status to functional when they are finished with the error
                    associatedMachine.status = Status_machine.functional;
                    break;
                default:
                    return BadRequest(new { Message = "Invalid status." });
            }

            try
            {
                _context.Errors.Update(error);
                _context.Machines.Update(associatedMachine);

                await _context.SaveChangesAsync();

                //Function makes an errorLog
                await _loggingService.createErrorLog(error.Id);
            }
            catch(Exception ex)
            {

               return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Error updating error status.", Error = ex.Message });
            }


            return Ok(new { Message = "Error status updated successfully.", UpdatedStatus = error.status });
        }



        [Route("GetErrorTasks/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetErrorTasks(int id)
        {
            var error = await _context.Errors.FindAsync(id);
            if (error == null)
            {
                return NotFound(new { Message = "Error not found." });
            }


            var ErrorTasks = await _context.Tasks.Where(x=>x.associated_error.Id==id).Include(x=>x.assigned_worker).ToListAsync();

            return Ok(ErrorTasks);
        }


        [Route("AddErrorTask")]
        [HttpPost]

        public async Task<IActionResult> AddErrorTask([FromBody] AddErrorTaskDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignedUser = await _userManager.FindByNameAsync(model.assigned_to);
            if (assignedUser == null)
            {
                return BadRequest("Assigned user not found.");
            }

            var errorTask = new ErrorTask
            {
                status = 0,
                description = model.description,
                assigned_to = assignedUser.Id,
                error_id = Int32.Parse(model.error_id),
                created_at = DateTime.Now,
            };

            await _context.Tasks.AddAsync(errorTask);

            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("ErrorTaskAdded", errorTask);

            //Function makes an errorLog
            await _loggingService.createErrorLog(int.Parse(model.error_id));
            

            return Ok(new { Message = "Task added successfully.", ErrorTaskId = errorTask.Id });
        }

        [Route("ChangeErrorTaskToFunctioned/{id}")]
        [HttpPut]

        public async Task<IActionResult> ChangeErrorTaskToFunctioned(int id)
        {
            var errorTask = await _context.Tasks.FindAsync(id);

            if (errorTask == null)
            {
                return NotFound(new { Message = "Task not found." });
            }

            errorTask.status = Status_ErrorTask.Functioned;

            try
            {
                _context.Tasks.Update(errorTask);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Error updating task status.", Error = ex.Message });
            }

            await _hubContext.Clients.All.SendAsync("ErrorTaskUpdated", errorTask);

            //Function makes an errorLog
            await _loggingService.createErrorLog(id);

            return Ok(new { Message = "Task status updated successfully.", UpdatedStatus = errorTask.status });
        }

        [Route("ChangeErrorTaskToCausedIssue/{id}")]
        [HttpPut]

        public async Task<IActionResult> ChangeErrorTaskToCausedIssue(int id)
        {
            var errorTask = await _context.Tasks.FindAsync(id);

            if (errorTask == null)
            {
                return NotFound(new { Message = "Task not found." });
            }

            errorTask.status = Status_ErrorTask.CausedIssue;

            try
            {
                _context.Tasks.Update(errorTask);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Error updating task status.", Error = ex.Message });
            }

            await _hubContext.Clients.All.SendAsync("ErrorTaskUpdated", errorTask);

            //Function makes an errorLog
            try
            {
                await _loggingService.createErrorLog(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Error creating error log.", Error = ex.Message  });
            }
            return Ok(new { Message = "Task status updated successfully.", UpdatedStatus = errorTask.status });
        }


    }
}
