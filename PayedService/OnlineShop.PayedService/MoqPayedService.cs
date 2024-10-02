using OnlineShop.ServiceInterfaces;

namespace OnlineShop.PayedService
{
    public class MoqPayedService : IPayedService
    {
        public bool Pay(decimal cost)
        {
            return true;
        }

        public async Task<bool> PayAsync(decimal cost)
        {
            return Pay(cost);
        }
    }
}