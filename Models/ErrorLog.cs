using System.ComponentModel.DataAnnotations.Schema;

namespace GuestHibajelentesEvvegi.Models
{
    public class ErrorLog
    {
        public int Id { get; set; }

        public string description  { get; set; }

        public DateTime created_at { get; set; }

        public int error_id { get; set; }

        public int machine_id{ get; set; }

        public string user_id { get; set; }

        [ForeignKey("error_id")]
        public virtual Error base_error { get; set; }

        [ForeignKey("machine_id")]
        public virtual Machine Machine { get; set; }

        [ForeignKey("user_id")]
        public virtual User notified_worker { get; set; }
    }
}
