namespace OnlineShop.OrderService
{
    [Serializable]
    public class NotSuccessOperationException : Exception
    {
        public override string Message => "Не удалось совершить операцию";

        public NotSuccessOperationException()
        {
        }
    }
}