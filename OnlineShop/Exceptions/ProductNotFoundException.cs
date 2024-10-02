namespace OnlineShop
{
    [Serializable]
    public class ProductNotFoundException : Exception
    {
        public override string Message => "Товар не найден";

        public ProductNotFoundException()
        {
        }
    }
}