using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAllNotification();
        Task<Notification> GetNotificationById(int id);
        Task<Notification> AddNotification(Notification acc);
        Task<IEnumerable<Notification>> GetNotificationByReceiveIdDESC(int receiverId);
        Task<bool> DeleteNotification(int doctype, int docId);
    }
}
