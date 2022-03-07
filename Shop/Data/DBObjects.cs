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
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Detail.Any())
                content.Detail.AddRange(
                    new Detail
                    {
                        detailName = "Колёсная пара",
                        model="РУ-1245",
                        gost="ГО-57342",
                        drawingNumber="3463.12367.23",
                        description= "Колёсная пара — элемент ходовой части рельсовых транспортных средств, представляющий собой пару колёс, жёстко посаженных на ось и всегда вращающихся вместе с осью как единое целое.",
                        visible= true,
                        Category = Categories["Колёсные пары"]
                    }
                    );
            try
            {

                content.SaveChanges();
            }
            catch
            {

            }
        }
       
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{categoryName = "Колёсные пары" },
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }
                return category;
            }
        }

    }
}
