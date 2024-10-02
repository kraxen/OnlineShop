﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string[] PhotosKeys { get; set; }

        [Timestamp]
        public int CountOnStock { get; set; }
    }
}