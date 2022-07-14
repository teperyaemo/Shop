using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Authorize]
    public class OrderAdminController : Controller
    {
        private readonly AppDBContent _context;
        private readonly IAllOrders _allOrders;
        private readonly IOrderDetail _orderDetail;

        public OrderAdminController(AppDBContent context, IAllOrders allOrders, IOrderDetail orderDetail)
        {
            _context = context;
            _allOrders = allOrders;
            _orderDetail = orderDetail;
        }
        public IActionResult Index(string orderTime, string searchString)
        {
            IEnumerable<Order> allOrders = _allOrders.GetOrders;

            if (!string.IsNullOrEmpty(searchString))
            {
                allOrders = _allOrders.GetOrders.Where(s => s.name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(orderTime))
            {
                allOrders = _allOrders.GetOrders.Where(i => (System.DateOnly.FromDateTime(i.orderTime)).ToString() == orderTime);
            }

            var ordersVM = new OrdersListViewModel
            {
                allOrders = allOrders
            };

            return View(ordersVM);
        }

        public async Task<IActionResult> OrderReview(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _allOrders.GetObjectorder(id);
            if (order == null)
            {
                return NotFound();
            }
            var orderVM = new OneOrderViewModel
            {
                Order = order,
                orderDetails = _orderDetail.GetOrderDetailsById(id)
            };

            return View(orderVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.id == id);
        }
    }
}
