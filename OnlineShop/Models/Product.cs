namespace OnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string[] PhotosKeys { get; set; }
        public int Count { get; set; }
    }
}
