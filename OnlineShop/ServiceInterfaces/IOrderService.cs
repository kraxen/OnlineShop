using OnlineShop.Models;

namespace OnlineShop.ServiceInterfaces
{
    public interface IOrderService
    {
        INotificationService NotificationService { get; set; }

        long CreateOrder(Order order);

        Task<long> CreateOrderAsync(Order order);

        Product GetProduct(int id);

        Task<Product> GetProductAsync(int id);

        IEnumerable<Product> GetProducts();

        Task<IEnumerable<Product>> GetProductsAsync();

        PayedOrder PayOrder(IPayedService payedService, Order order);
    }
}