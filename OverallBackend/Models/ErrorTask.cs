using System.ComponentModel.DataAnnotations.Schema;

namespace GuestHibajelentesEvvegi.Models
{
    public enum Status_ErrorTask { UnderChecking, Functioned, CausedIssue }
    public class ErrorTask
    {
        public int Id { get; set; }
        public Status_ErrorTask status { get; set; }

        public string description { get; set; }

        public string assigned_to { get; set; }

        public int error_id { get; set; }

        public DateTime created_at { get; set; }

        public DateTime resolved_at { get; set; }

        [ForeignKey("assigned_to")]
        public virtual User assigned_worker { get; set; }

        [ForeignKey("error_id")]
        public virtual Error associated_error { get; set; }
    }
}
