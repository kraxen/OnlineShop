namespace OnlineShop.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public string Message { get; set; }
    }
}
