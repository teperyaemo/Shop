using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data
{
    public class AppDBContent : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<Detail> Detail { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<DetailCharacteristics> DetailCharacteristics { get; set; }
        public DbSet<Charecs> Charecs { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
