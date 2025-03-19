using GuestHibajelentesEvvegi.Data;
using GuestHibajelentesEvvegi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuestHibajelentesEvvegi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinesmanController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LinesmanController(AppDbContext context)
        {
            _context = context;
        }

        [Route("AddError")]
        [HttpPost]
        
        public async Task<IActionResult> AddNewError()
        {
            var error = new Error
            {

            };

            if (error != null)
            {
                _context.Errors.Add(error);
                await _context.SaveChangesAsync();
                return Ok();
            }
            
            return BadRequest();
            
        }
    }
}
