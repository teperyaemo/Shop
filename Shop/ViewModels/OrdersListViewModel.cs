using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.ViewModels
{
    public class OrdersListViewModel
    {
        public IEnumerable<Order> allOrders { get; set; }
        public System.DateTime OrderTime { get; set; }
        public string? SearchString { get; set; }

    }
}