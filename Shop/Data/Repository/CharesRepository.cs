using System.Collections.Generic;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class CharesRepository : ICharecs
    {
        private readonly AppDBContent appDBContent;

        public CharesRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Charecs> Charecs => appDBContent.Charecs;
    }
}
