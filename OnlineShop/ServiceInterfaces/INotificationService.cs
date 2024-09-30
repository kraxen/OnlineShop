using OnlineShop.Models;

namespace OnlineShop.ServiceInterfaces
{
    public interface INotificationService
    {
        void Send(Notification notification);
        Task SendAsync(Notification notification);
    }
}