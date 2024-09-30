using OnlineShop.Models;

namespace OnlineShop.ServiceInterfaces
{
    public interface INotificationService
    {
        void Send(Notification notification);
    }
}