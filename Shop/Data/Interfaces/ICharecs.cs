using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    interface ICharecs
    {
        IEnumerable<Charecs> Charecs { get; }
    }
}
