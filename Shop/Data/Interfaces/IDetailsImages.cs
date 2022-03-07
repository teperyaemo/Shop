using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    interface IDetailsImages
    {
        IEnumerable<Images> AllDetailImages(int detailId);
        Images getDetailImage(int detailId);
    }
}
