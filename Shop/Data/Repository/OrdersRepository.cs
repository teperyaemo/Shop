using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.listShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    detailId = el.detail.detailId,
                    orderId = order.id
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
        public IEnumerable<Order> GetOrders => appDBContent.Order.Include(p => p.orderDetails);

        public IEnumerable<Order> GetOrdersByTime(DateOnly dateTime) => appDBContent.Order.Where(i => DateOnly.FromDateTime(i.orderTime) == dateTime);

        public Order GetObjectorder(int OrderId) => appDBContent.Order.FirstOrDefault(s => s.id == OrderId);
    }
}
