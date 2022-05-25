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

        // GET: Movies
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
        // GET: Movies/Details/5
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

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("detailId,categoryId,detailName,model,gost,drawingNumber,description,visible")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detail);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }
            return View(detail);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("detailId,categoryId,detailName,model,gost,drawingNumber,description,visible")] Detail detail)
        {
            if (id != detail.detailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(detail.detailId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(detail);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail
                .FirstOrDefaultAsync(m => m.detailId == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detail = await _context.Detail.FindAsync(id);
            _context.Detail.Remove(detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Detail.Any(e => e.detailId == id);
        }
    }
}
