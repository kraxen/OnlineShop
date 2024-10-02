namespace OnlineShop.Models
{
    public class PayedOrder
    {
        public List<ProductInOrder> SuccessPayedProducts { get; set; } = new List<ProductInOrder>();
        public List<ErrorPayed> ErrorPayedProducts { get; set; } = new List<ErrorPayed>();
    }
}