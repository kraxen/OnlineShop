using OnlineShop.Models;

namespace OnlineShop.ServiceInterfaces
{
    public interface IOrderService
    {
        INotificationService NotificationService { get; set; }
        IEnumerable<Order> Orders { get; set; }
        IEnumerable<Product> Products { get; set; }
        long CreateOrder(Order order);
        Task<long> CreateOrderAsync(Order order);
        Product GetProduct(int id);
        Task<Product> GetProductAsync(int id);
        IEnumerable<Product> GetProducts();
        Task<IEnumerable<Product>> GetProductsAsync();
        bool PayOrder(Order order);
        Task<bool> PayOrderAsync(IPayedService PayedService, Order order);
    }
}