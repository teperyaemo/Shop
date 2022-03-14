using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    interface IDetailsImages
    {
        IEnumerable<Images> AllDetailImages(int detailId);
        Images getDetailImage(int detailId);
    }
}
