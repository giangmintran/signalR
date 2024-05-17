using SignalRSample.Dtos;

namespace SignalRSample.Hubs
{
    public interface IHubClient
    {
        Task BroadcastMessage(MessageInstance msg);
    }

}
