using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using OnlineShop.ServiceInterfaces;

namespace OnlineShop.OrderService
{
    public class OrderServiceEF(DbContextOptions<OrderServiceEF> options) : DbContext(options), IOrderService
    {
        public INotificationService NotificationService { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public long CreateOrder(Order order)
        {
            order.DeliveryStatus = OrderDeliveryStatus.New;
            order.PaymentStatus = OrderPaymentStatus.New;

            Orders.Add(order);

            SaveChanges();

            return order.Id;
        }

        public async Task<long> CreateOrderAsync(Order order)
        {
            order.DeliveryStatus = OrderDeliveryStatus.New;
            order.PaymentStatus = OrderPaymentStatus.New;

            await Orders.AddAsync(order);

            await SaveChangesAsync();

            return order.Id;
        }

        public Product GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);

            if (product is null) throw new ProductNotFoundException();

            return product;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var product = await Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) throw new ProductNotFoundException();

            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return Products;
        }

        public PayedOrder PayOrder(IPayedService payedService, Order order)
        {
            var result = new PayedOrder();
            decimal cost = 0;

            var transaction = Database.BeginTransaction();
            try
            {
                foreach (var p in order.Products)
                {
                    if (p.Product.CountOnStock - p.Count >= 0)
                    {
                        cost += p.Product.Cost * p.Count;
                        p.Product.CountOnStock = p.Product.CountOnStock - p.Count;
                        SaveChangesAsync();
                        result.SuccessPayedProducts.Add(p);
                    }
                    else
                    {
                        result.ErrorPayedProducts.Add(new ErrorPayed()
                        {
                            Product = p,
                            ErrorMessage = "Недостаточно товаров на складе"
                        });
                    }
                }

                var isPayed = payedService.Pay(cost);

                if (!isPayed)
                {
                    transaction.RollbackAsync();
                    throw new FailedToPayOrderException();
                }

                NotificationService.SendAsync(new Notification()
                {
                    Order = result,
                    Message = "Заказ успешно оплачен"
                });

                return result;
            }
            catch (DbUpdateConcurrencyException)
            {
                transaction.RollbackAsync();
                throw new NotSuccessOperationException();
            }
        }
    }
}