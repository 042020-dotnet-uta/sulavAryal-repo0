using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShopper.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int StoreLocationId { get; set; }
        public StoreLocation StoreLocation { get; set; }
    }
}