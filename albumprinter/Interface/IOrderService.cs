using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbumPrinter.Model;

namespace AlbumPrinter.Interface
{
    public interface IOrderService
    {
        public void CreateOrder(Order r);

        public Order GetOrder(int OrderId);
    }
}
