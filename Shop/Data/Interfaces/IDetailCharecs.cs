using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IDetailCharecs
    {
        IEnumerable<DetailCharacteristics> DetailCharacteristics(int detailId);
    }
}
