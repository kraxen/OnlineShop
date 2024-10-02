using OnlineShop.Models;
using OnlineShop.ServiceInterfaces;

namespace OnlineShop.NotificationService
{
    public class NotificationService : INotificationService
    {
        public void Send(Notification notification)
        {
            Console.WriteLine(notification.Message);
        }

        public async Task SendAsync(Notification notification)
        {
            Console.WriteLine(notification.Message);
        }
    }
}