namespace OnlineShop.OrderService
{
    [Serializable]
    public class FailedToPayOrderException : Exception
    {
        public override string Message => "Не удалось оплатить заказ";

        public FailedToPayOrderException()
        {
        }
    }
}