using System.ComponentModel.DataAnnotations;

namespace GuestHibajelentesEvvegi.Models
{
    public class AddErrorDto
    {
        [Required]
        public string description { get; set; }

        [Required]
        public string submitted_by { get; set; }

        [Required]
        public int machine_id { get; set; }
        

        [Required]
        public string assigned_to { get; set; }
    }
}
