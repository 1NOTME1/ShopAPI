﻿using ShopAPI.Entities;
using System.Collections.Generic;

namespace ShopAPI.Models
{
    public class ShopDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public List<Product> Products { get; set; }
    }
}
