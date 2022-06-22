using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class OrderDetailRepository : IOrderDetail
    {
        private readonly AppDBContent appDBContent;

        public OrderDetailRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<OrderDetail> AllOrderDetails => appDBContent.OrderDetail.Include(c => c.orderId);

        public IEnumerable<OrderDetail> GetOrderDetailsById(int orderId) => appDBContent.OrderDetail.Where(c => c.orderId == orderId).Include(b => b.detail);
    }
}
