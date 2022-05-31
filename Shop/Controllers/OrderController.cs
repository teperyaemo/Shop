using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;
        private readonly ILogger<OrderController> logger;

        public OrderController(IAllOrders allOrders, ShopCart shopCart, ILogger<OrderController> logger)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
            this.logger = logger;
        }

        public IActionResult Checkout()
        {
            logger.LogInformation("Checkout [get]");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout([Bind("name,email,phoneNumber")]Order order)
        {
            logger.LogInformation("Checkout [post]");
            shopCart.listShopItems = shopCart.getShopItems();
            if(shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("","Отсутсвуют товары в корзине");
            }

            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Checkout");
            }

            return View(order);
        }
    }
}
