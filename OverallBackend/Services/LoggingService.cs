using GuestHibajelentesEvvegi.Data;
using GuestHibajelentesEvvegi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuestHibajelentesEvvegi.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly AppDbContext _context;
        public LoggingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> createErrorLog(int errorId)
        {
            
            var associatedError = await _context.Errors
                .Where(e => e.Id == errorId)
                .FirstOrDefaultAsync();

            if (associatedError == null)
            {
                return new NotFoundResult();
            }

            var associatedMachine = await _context.Machines
                .Where(m => m.Id == associatedError.machine_id)
                .FirstOrDefaultAsync();
           
            var associatedUser = await _context.Users
                .Where(u => u.Id == associatedError.assigned_to)
                .FirstOrDefaultAsync();

            var taskList = await _context.Tasks
                .Where(t => t.error_id == errorId)
                .ToListAsync();

            var desc = "";

            desc += $"Error description: {associatedError.description}\n";

            desc += $"Machine: {associatedMachine.name}\n";
            
            desc += $"Error status: {associatedError.status.ToString()}\n";

            desc += $"Machine status: {associatedMachine.status.ToString()}\n";

            if (associatedUser == null)
            {
                desc += "Worker no longer works for the company\n";
            }
            else
            {
                desc += $"Worker: {associatedUser.UserName}\n";
            }

            desc += "\nTasks: \n";

            foreach (var item in taskList)
            {
                desc += $"{item.description} | status: {item.status.ToString()}  | user: {item.assigned_worker.UserName} \n";
            }

            var errorLog = new ErrorLog
            {
                description = desc,
                created_at = DateTime.Now,
                error_id = errorId,
                user_id = associatedUser.Id,
                machine_id = associatedMachine.Id,
            };

            if (associatedUser == null)
            {
                errorLog.user_id = "Worker no longer works for the company";
            }

            await _context.Error_logs.AddAsync(errorLog);

            await _context.SaveChangesAsync();

            //If time let's it, add signalR for errorLog page on the admin page 

            return new OkResult();
        }
    }
}
