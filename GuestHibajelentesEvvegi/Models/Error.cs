using System.ComponentModel.DataAnnotations.Schema;

namespace GuestHibajelentesEvvegi.Models
{
    public enum Status_error { uj, javitas_alatt, elvegzett }
    public class Error
    {
        public int Id { get; set; }

        public Status_error status { get; set; }

        public string description { get; set; }

        public string submitted_by { get; set; }

        public int machine_id { get; set; }

        public string assigned_to { get; set; }

        public DateTime created_at { get; set; }

        public DateTime resolved_at { get; set; }

        [ForeignKey("assigned_to")]
        public virtual User assigned_worker { get; set; }

        [ForeignKey("submitted_by")]
        public virtual User submitting_worker { get; set; }

        [ForeignKey("machine_id")]
        public virtual Machine machine { get; set; }
    }
}
