using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IAllDetails _allDetails;
        private readonly IDetailsCategory _allCategories;
        private readonly IDetailCharecs _detailCharecs;

        public DetailsController(IAllDetails iAllDetails, IDetailsCategory iDetailsCategory, IDetailCharecs iDetailCharecs)
        {
            _allDetails = iAllDetails;
            _allCategories = iDetailsCategory;
            _detailCharecs = iDetailCharecs;
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
            
            detail = _allDetails.getObjectDetail(_id);
            detailCharacteristics = _detailCharecs.DetailCharacteristics(id);

            var OneDetailObject = new OneDetailViewModel
            {
                Detail = detail,
                DetailCharacteristics = detailCharacteristics
            };

            return View(OneDetailObject);
        }
    }
}
