using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSample.Dtos;
using SignalRSample.Hubs;

namespace SignalRSample.Controllers
{
    [Route("api/Test")]
    public class TestController : Controller
    {
        private IHubContext<ChatHub> _signalrHub;

        public TestController(IHubContext<ChatHub> signalrHub)
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
                await _signalrHub.Clients.All.SendAsync("ReceiveMessage", msg.From, msg.Message);
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
