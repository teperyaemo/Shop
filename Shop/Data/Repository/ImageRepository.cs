using System.Collections.Generic;
using System.Linq;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class ImageRepository : IDetailsImages
    {
        private readonly AppDBContent appDBContent;

        public ImageRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Images> AllDetailImages(int detailId) => appDBContent.Images.Where(p => p.Detail.detailId == detailId);

        public Images getDetailImage(int detailId) => appDBContent.Images.FirstOrDefault(p => p.Detail.detailId == detailId);
    }
}
