using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {

        private readonly TwitterCloneDbContext _context;

        public NotificationRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Notification AddNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();

            return notification;
        }

        public Notification UpdateNotification(Notification notification)
        {
            var existingNotification = _context.Notifications.SingleOrDefault(n => n.Id == notification.Id);
            if (existingNotification != null)
            {
                _context.Entry(existingNotification).CurrentValues.SetValues(notification);
                _context.SaveChanges();
            }           
            return notification;
        }

        public bool DeleteNotification(Notification notification)
        {
            _context.Notifications.Remove(notification);
            _context.SaveChanges();
            return true;
        }

        public int DeleteNotificationsByUserId(Guid userId)
        {
            var notifications = _context.Notifications.Where(n => n.UserId == userId).ToList();
            _context.Notifications.RemoveRange(notifications);
            _context.SaveChanges();
            return notifications.Count;
        }

        public Notification? GetNotificationById(Guid id)
        {
            return _context.Notifications.SingleOrDefault(n => n.Id == id);
        }

        public List<Notification> GetNotifications(Guid? userId, string? type, bool? isRead)
        {
            return _context.Notifications   
                .Where(n => (userId == null || n.UserId == userId) &&
                            (type == null || string.Equals(n.Type, type, StringComparison.OrdinalIgnoreCase)) &&
                            (isRead == null || n.IsRead == isRead))
                .ToList();
        }
    }
}
