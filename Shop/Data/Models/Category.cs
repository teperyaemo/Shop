using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Category
    {
        public int categoryId { set; get; }
        public string categoryName { set; get; }
        public List<Detail> details { set; get; }

    }
}
