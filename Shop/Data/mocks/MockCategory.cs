using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.mocks
{
    public class MockCategory : IDetailsCategory
    {
        public IEnumerable<Category> AllCategories 
        {
            get 
            {
                return new List<Category>
                {
                    new Category { categoryName = "Колёсные пары"},
                    new Category { categoryName = "Рама" }
                };
            }
        }
    }
}
