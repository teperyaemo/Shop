using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    interface IDetailCharecs
    {
        IEnumerable<DetailCharacteristics> DetailCharacteristics(int detailId);
    }
}
