namespace OnlineShop.ServiceInterfaces
{
    public interface IPayedService
    {
        bool Pay(decimal cost);

        Task<bool> PayAsync(decimal cost);
    }
}