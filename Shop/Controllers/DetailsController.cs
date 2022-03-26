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

        public DetailsController(IAllDetails iAllDetails, IDetailsCategory iDetailsCategory)
        {
            _allDetails = iAllDetails;
            _allCategories = iDetailsCategory;
        }

        [Route("Details/List")]
        [Route("Details/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Detail> details;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                details = _allDetails.Details.OrderBy(i => i.detailId);
            }
            else
            {
                details = _allDetails.Details.Where(i => i.Category.categoryName == _category).OrderBy(i => i.detailId);
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
    }
}
