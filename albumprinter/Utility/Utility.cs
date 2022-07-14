using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbumPrinter.Model;

namespace AlbumPrinter.Uitility
{
    public static class Utility
    {
        public static Order CalcSize(Order or)
        {
            var size = 0.0;
            foreach (Product p in or.Products)
            {
                if (p.Type == ProductType.Mug)
                {
                    size = size + (Product.WidthMapper[ProductType.Mug] * Math.Ceiling((double)p.Quantity / 4));
                }
                else
                {
                    size = size + (Product.WidthMapper[p.Type] * p.Quantity);
                }
            }
            or.RequiredBinWidth = size;
            return or;
        }
    }
}
