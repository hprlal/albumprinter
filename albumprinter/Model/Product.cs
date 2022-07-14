using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumPrinter.Model
{
    public class Product
    {
        public ProductType Type { get; set; }

        public int Quantity { get; set; }

        public static Dictionary<ProductType, double> WidthMapper;
        public Product()
        {
            WidthMapper = new Dictionary<ProductType, double>
            {
                {ProductType.PhotoBook,19 },
                {ProductType.Canvas,16 },
                {ProductType.Calendar,10 },
                {ProductType.Cards,4.7 },
                {ProductType.Mug,94 }
            };
        }
    }
}
