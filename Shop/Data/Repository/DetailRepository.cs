using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class DetailRepository : IAllDetails
    {

        private readonly AppDBContent appDBContent;

        public DetailRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Detail> AllDetails => appDBContent.Detail.Include(c => c.Category);

        public IEnumerable<Detail> getVisibleDetails => appDBContent.Detail.Where(p => p.visible).Include(c => c.Category);

        public Detail getObjectDetail(int detailId) => appDBContent.Detail.FirstOrDefault(p => p.detailId == detailId);
    }
}
