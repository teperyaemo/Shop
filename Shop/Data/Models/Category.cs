using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Category
    {
        public int categoryId { set; get; }
        public string categoryName { set; get; }
        public List<Detail> details { set; get; }

    }
}
