using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart (Detail detail)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                shopCartId = ShopCartId,
                detail = detail
            });

            appDBContent.SaveChanges();
        }

        public void deleteFromCart(ShopCartItem shopCartItem)
        {
            appDBContent.Remove(shopCartItem);
            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.shopCartId == ShopCartId).Include(s => s.detail).ToList();
        }

        public ShopCartItem GetShopCartItem(int id) => appDBContent.ShopCartItem.Find(id);
    }
}
