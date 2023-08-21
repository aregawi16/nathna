using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;
using NatnaAgencyDigitalSystem.Core.Models;
using NatnaAgencyDigitalSystem.Service;

namespace NatnaAgencyDigitalSystem.Api.Controllers
{
    [ApiController]
        [Route("api/[controller]")]
        public class NotificationController : ControllerBase
        {
            private readonly IHubContext<NotificationHub> _hubContext;

            public NotificationController(IHubContext<NotificationHub> hubContext)
            {
                _hubContext = hubContext;
            }

            [HttpPost]
            public async Task<IActionResult> SendNotification(Notification notification)
            {
                //await _hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
                return Ok();
            }
        
    }
}
