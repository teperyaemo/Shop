using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IOrderDetail
    {
        IEnumerable<OrderDetail> AllOrderDetails { get; }
        IEnumerable<OrderDetail> GetOrderDetailsById(int orderId);
    }
}
