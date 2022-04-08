using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System.Linq;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllDetails _detailRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllDetails detailRepository, ShopCart shopCart)
        {
            _detailRep = detailRepository;
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            }; 
            return View(obj);
        }

        public RedirectToActionResult addToCart(int id) 
        {
            var item = _detailRep.getVisibleDetails.FirstOrDefault(i => i.detailId == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
