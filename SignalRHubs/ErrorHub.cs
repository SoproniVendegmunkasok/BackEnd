using System.Collections.Concurrent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace GuestHibajelentesEvvegi.SignalRHubs
{
    public class ErrorHub : Hub
    {
        public async Task BroadcastNewError(object error)
        {
            await Clients.All.SendAsync("ErrorAdded", error);
        }

        public async Task BroadcastNewErrorTask(object errorTask)
        {
            await Clients.All.SendAsync("ErrorTaskAdded", errorTask);
        }

        //Update and Delete Broadcasts only added for future use
        public async Task BroadcastUpdatedError(object updatedError)
        {
            await Clients.All.SendAsync("ErrorUpdated", updatedError);
        }

        public async Task BroadcastDeletedError(int errorId)
        {
            await Clients.All.SendAsync("ErrorDeleted", errorId);
        }
        public override Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier ?? Context.ConnectionId;
            Console.WriteLine($"User {userId} connected.");
            Clients.All.SendAsync("UserConnected", userId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.UserIdentifier;
            Console.WriteLine($"User {userId} disconnected.");
            return base.OnDisconnectedAsync(exception);
        }

    }
}
