using System.ComponentModel.DataAnnotations;

namespace GuestHibajelentesEvvegi.Models
{
    public class AddErrorTaskDto
    {
        [Required]
        public string description { get; set; }

        [Required]
        public string assigned_to { get; set; }

        [Required]
        public int error_id { get; set; }
    }
}
