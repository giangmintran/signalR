using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSample.Dtos;
using SignalRSample.Hubs;

namespace SignalRSample.Controllers
{
    [Route("api/Test")]
    public class TestController : Controller
    {
        private IHubContext<ChatHub, IHubClient> _signalrHub;

        public TestController(IHubContext<ChatHub, IHubClient> signalrHub)
        {
            _signalrHub = signalrHub;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] MessageInstance msg)
        {
            var retMessage = string.Empty;
            try
            {
                msg.Timestamp = DateTime.Now.ToString();
                await _signalrHub.Clients.All.BroadcastMessage(msg);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }
    }

}
