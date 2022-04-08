using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface ICharecs
    {
        IEnumerable<Charecs> AllCharecs { get; }

        Charecs getObjectCharecs(int id);
    }
}
