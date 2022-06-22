using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;


namespace Shop.Data.Repository
{
    public class DetailCharacteristicsRepository : IDetailCharecs
    {
        private readonly AppDBContent appDBContent;

        public DetailCharacteristicsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<DetailCharacteristics> DetailCharacteristics(int detailId) => appDBContent.DetailCharacteristics.Where(p => p.Detail.detailId == detailId).Include(b => b.Charecs);
        
    }
}
