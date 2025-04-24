using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GuestHibajelentesEvvegi.Models
{
    public enum Status_error { Unbegun, UnderRepair, Finished }
    public class Error
    {
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
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
