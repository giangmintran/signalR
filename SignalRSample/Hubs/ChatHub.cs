using Microsoft.AspNetCore.SignalR;

namespace SignalRSample.Hubs
{
    public class ChatHub : Hub
    {
        public async Task BroadcastMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
