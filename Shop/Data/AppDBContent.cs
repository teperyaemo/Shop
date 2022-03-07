using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<Detail> Detail { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<DetailCharacteristics> DetailCharacteristics { get; set; }
        public DbSet<Charecs> Charecs { get; set; }
    }
}
