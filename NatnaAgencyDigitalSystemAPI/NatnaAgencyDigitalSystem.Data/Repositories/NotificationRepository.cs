
using Microsoft.EntityFrameworkCore;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Api.Repositories;
using NatnaAgencyDigitalSystem.Core.Models;
using NatnaAgencyDigitalSystem.Core.Repositories;

namespace NatnaAgencyDigitalSystem.Data.Repositories
{
    public class NotificationRepository :  INotificationRepository
    {
        private NatnaAgencyDbContext _context;

        public NotificationRepository(NatnaAgencyDbContext context)
        {
            _context = context;
                }

        public async Task AddNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }


    }
}