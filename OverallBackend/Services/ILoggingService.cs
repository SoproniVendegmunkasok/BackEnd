using Microsoft.AspNetCore.Mvc;

namespace GuestHibajelentesEvvegi.Services
{
    public interface ILoggingService
    {
        Task<IActionResult> createErrorLog(int errorId);
    }
}
