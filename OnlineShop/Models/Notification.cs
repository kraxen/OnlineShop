namespace OnlineShop.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public PayedOrder Order { get; set; }
        public string Message { get; set; }
    }
}