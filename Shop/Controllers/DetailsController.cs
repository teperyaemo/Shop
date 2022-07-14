using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        //[Route("Details/Catalog")]
        //[Route("Details/Catalog/{category}")]
        public ViewResult Catalog(string currCategory, string searchString)
        {
            IEnumerable<Detail> details;

            var categoryQuery = _allCategories.AllCategories.Select(a => new SelectListItem()
            {
                Value = a.categoryId.ToString(),
                Text = a.categoryName
            }).ToList();

            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(currCategory))
            {
                details = _allDetails.getVisibleDetails.Where(s => s.detailName!.Contains(searchString)).Where(i => i.Category.categoryId == int.Parse(currCategory));
            }
            else if (!string.IsNullOrEmpty(searchString))
            {
                details = _allDetails.getVisibleDetails.Where(s => s.detailName!.Contains(searchString));
            }
            else if (!string.IsNullOrEmpty(currCategory))
            {
                details = _allDetails.getVisibleDetails.Where(i => i.Category.categoryId == int.Parse(currCategory));
            }
            else
            {
                details = _allDetails.getVisibleDetails;
            }

            var detailsList = new DetailsListViewModel
            {
                Categories = categoryQuery,
                allDetails = details,
                currCategory = currCategory
            };

            ViewBag.Title = "Каталог";
            return View(detailsList);
            
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
