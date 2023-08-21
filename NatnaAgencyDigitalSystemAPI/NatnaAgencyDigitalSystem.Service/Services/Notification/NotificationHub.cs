using NatnaAgencyDigitalSystem.Api;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Service.Services;
using NatnaAgencyDigitalSystem.Core.Models;
using NatnaAgencyDigitalSystem.Core.Repositories;
using Microsoft.AspNet.SignalR;

namespace NatnaAgencyDigitalSystem.Service
{

    public class NotificationHub : Hub
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationHub(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

      

        public async Task SendNotification(Notification notification)
        {
            await _notificationRepository.AddNotification(notification);
            await Clients.All.SendAsync("ReceiveNotification", notification);
        }
    }


}
