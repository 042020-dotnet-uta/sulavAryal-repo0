using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleShopper.Domain
{
    public class Order
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }
}
