using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Models;

namespace Shop.ViewModels
{
    public class DetailsListViewModel
    {
        public IEnumerable<Detail> allDetails { get; set; }

        public string currCategory { get; set; }

    }
}
