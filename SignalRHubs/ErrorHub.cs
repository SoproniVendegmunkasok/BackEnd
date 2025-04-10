using Microsoft.AspNetCore.SignalR;

namespace GuestHibajelentesEvvegi.SignalRHubs
{
    public class ErrorHub : Hub
    {
        public async Task SendError(string errorMessage)
        {
            await Clients.All.SendAsync("ReceiveError", errorMessage);
        }
    }
}
