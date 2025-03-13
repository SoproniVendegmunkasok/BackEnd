namespace GuestHibajelentesEvvegi.Models
{
    public enum Status_machine { funkcionalis, hibas }
    public class Machine
    {
        public int Id { get; set; }

        public string name { get; set; }

        public Status_machine status { get; set; }

        public string hall { get; set; }

        public DateTime created_at { get; set; }
    }
}
