using Microsoft.AspNetCore.SignalR;
using SignalRSample.Dtos;

namespace SignalRSample.Hubs
{
    public class ChatHub : Hub<IHubClient>
    {
        public async Task BroadcastMessage(MessageInstance msg)
        {
            await Clients.All.BroadcastMessage(msg);
        }
    }
}
