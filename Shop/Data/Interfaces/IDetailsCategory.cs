using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IDetailsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
