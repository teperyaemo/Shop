using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IAllDetails _allDetails;
        private readonly IDetailsCategory _allCategories;
        private readonly IDetailCharecs _detailCharecs;
        private readonly ICharecs _charecs;

        public DetailsController(IAllDetails iAllDetails, IDetailsCategory iDetailsCategory, IDetailCharecs iDetailCharecs, ICharecs iCharecs)
        {
            _allDetails = iAllDetails;
            _allCategories = iDetailsCategory;
            _detailCharecs = iDetailCharecs;
            _charecs = iCharecs;
        }

        [Route("Details/Catalog")]
        [Route("Details/Catalog/{category}")]
        public ViewResult Catalog(string category)
        {
            string _category = category;
            IEnumerable<Detail> details;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                details = _allDetails.getVisibleDetails.OrderBy(i => i.detailId);
            }
            else
            {
                details = _allDetails.getVisibleDetails.Where(i => i.Category.categoryName == _category).OrderBy(i => i.detailId);
                currCategory = _category;            
            }

            var detailObject = new DetailsListViewModel
            {
                allDetails = details,
                currCategory = currCategory
            };

            ViewBag.Title = "Каталог";
            return View(detailObject);
        }

        public ViewResult Review(int id)
        {
            int _id = id;
            Detail detail;
            IEnumerable<DetailCharacteristics> detailCharacteristics;
            IEnumerable<Charecs> charecs;
            
            detail = _allDetails.getObjectDetail(_id);
            detailCharacteristics = _detailCharecs.DetailCharacteristics(_id);
            charecs = _charecs.AllCharecs;

            var OneDetailObject = new OneDetailViewModel
            {
                Detail = detail,
                Charecs = charecs,
                DetailCharacteristics = detailCharacteristics
            };

            return View(OneDetailObject);
        }
    }
}
