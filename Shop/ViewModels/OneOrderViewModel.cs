using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class OneOrderViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<OrderDetail> orderDetails { get; set; }
    }
}
