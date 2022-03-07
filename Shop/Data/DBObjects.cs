using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(IApplicationBuilder app)
        {
            AppDBContent content = app.ApplicationServices.GetRequiredService<AppDBContent>();

            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));
        }
        private static Dictionary<int, string> category;
        public static Dictionary<int, string> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{categoryId = 1, categoryName = "Колёсные пары" },
                    };

                    category = new Dictionary<int, string>();
                    foreach (Category el in list)
                        category.Add(el.categoryId, el.categoryName);
                }
                return category;
            }
        }

    }
}
