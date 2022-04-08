using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Charecs> AllCharecs => appDBContent.Charecs;

        public Charecs getObjectCharecs(int id) => appDBContent.Charecs.Where(x => x.charecsId == id).First();
    }
}
