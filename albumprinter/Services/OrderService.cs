using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbumPrinter.Model;
using AlbumPrinter.Uitility;
using AlbumPrinter.Interface;

namespace AlbumPrinter.Services
{
    public class OrderService : IOrderService
    {
        private static List<Order> orders;

        public OrderService()
        {
            orders = new List<Order>();
        }

        public void CreateOrder(Order r)
        {
            var order = Utility.CalcSize(r);
            orders.Add(order);
        }

        public Order GetOrder(int OrderId)
        {
            var order = orders.Find(x => x.OrderId == OrderId);
            return order;
        }
    }
}
