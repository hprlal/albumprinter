using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumPrinter.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        public double RequiredBinWidth { get; set; }

        public List<Product> Products { get; set; }

        public Order(int orderId, List<Product> products)
        {
            OrderId = orderId;
            Products = products;
        }

        public Order()
        {
        }
    }
}
