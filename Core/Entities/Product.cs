﻿using System.Collections.Generic;

namespace Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}

