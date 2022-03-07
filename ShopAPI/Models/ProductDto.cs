﻿namespace ShopAPI.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
