using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.ViewModels
{
    public class DetailsListViewModel
    {
        public IEnumerable<Detail> allDetails { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public string? currCategory { get; set; }
        public string? SearchString { get; set; }

    }
}
