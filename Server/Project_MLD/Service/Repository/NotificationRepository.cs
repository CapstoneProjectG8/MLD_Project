using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;

namespace Project_MLD.Service.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly MldDatabaseContext _context;
        public async Task<Notification> AddNotification(Notification noti)
        {
            _context.Notifications.Add(noti);
            await _context.SaveChangesAsync();
            return noti;
        }

        public async Task<IEnumerable<Notification>> GetAllNotification()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task<Notification> GetNotificationById(int id)
        {
            return await _context.Notifications.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
