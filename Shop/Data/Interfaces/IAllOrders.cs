using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order);

        IEnumerable<Order> GetOrders { get; }
        IEnumerable<Order> GetOrdersByTime(DateOnly dateTime);
        Order GetObjectorder(int OrderId);
    }
}
