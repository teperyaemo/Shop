using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IAllDetails
    {
        IEnumerable<Detail> Details { get; }
        IEnumerable<Detail> getVisibleDetails { get; }
        Detail getObjectDetail(int detailId);
    }
}
