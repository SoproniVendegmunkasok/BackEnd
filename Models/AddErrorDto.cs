using System.ComponentModel.DataAnnotations;

namespace GuestHibajelentesEvvegi.Models
{
    public class AddErrorDto
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string SubmittedBy { get; set; }

        [Required]
        public int MachineId { get; set; }

        [Required]
        public string AssignedTo { get; set; }
    }
}
