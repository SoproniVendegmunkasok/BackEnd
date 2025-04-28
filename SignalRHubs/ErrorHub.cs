using System.Collections.Concurrent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace GuestHibajelentesEvvegi.SignalRHubs
{
    public class ErrorHub : Hub
    {

        public async Task BroadcastNewErrorTask(object errorTask)
        {
            await Clients.All.SendAsync("ErrorTaskAdded", errorTask);
        }

        public async Task BroadcastUpdatedErrorTask(object updatedErrorTask)
        {
            await Clients.All.SendAsync("ErrorTaskUpdated", updatedErrorTask);
        }
        public async Task BroadcastNewError(object error)
        {
            await Clients.All.SendAsync("ErrorAdded", error);
        }

        public async Task BroadcastNewErrorLog(object errorLog)
        {
            await Clients.All.SendAsync("ErrorLogAdded", errorLog);
        }

        public async Task BroadcastUpdatedError(object updatedError)
        {
            await Clients.All.SendAsync("ErrorUpdated", updatedError);
        }

        //Delete Broadcast only added for future use
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
