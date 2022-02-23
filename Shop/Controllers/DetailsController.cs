using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Interfaces;
using Shop.ViewModels;

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

        public ViewResult List()
        {
            ViewBag.Title = "Каталог";
            DetailsListViewModel obj = new DetailsListViewModel();
            obj.allDetails = _allDetails.Details;
            obj.currCategory = "Колёсные пары";
            return View(obj);
        }
    }
}
