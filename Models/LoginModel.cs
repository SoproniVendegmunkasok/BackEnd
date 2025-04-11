namespace GuestHibajelentesEvvegi.Models
{
    public class LoginModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string? ConnectionId { get; set; } //Stores the signalR connectionId
    }
}
