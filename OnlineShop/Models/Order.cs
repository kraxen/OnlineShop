﻿namespace OnlineShop.Models
{
    public class Order
    {
        public long Id { get; set; }
        public List<Product> Products { get; set; }
        public OrderPaymentStatus PaymentStatus { get; set; }
        public OrderDeliveryStatus DeliveryStatus { get; set; }
        public int UserId { get; set; }
    }
}
