using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Category
    {
        public int categoryId { set; get; }

        [Display(Name = "Категория")]
        public string categoryName { set; get; }
        public List<Detail> details { set; get; }

    }
}
