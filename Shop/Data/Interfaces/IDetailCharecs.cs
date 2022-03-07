using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    interface IDetailCharecs
    {
        IEnumerable<DetailCharacteristics> DetailCharacteristics(int detailId);
    }
}
