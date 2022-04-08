using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class OneDetailViewModel
    {
        public Detail Detail { get; set; }
        public IEnumerable<Charecs> Charecs { get; set; }
        public IEnumerable<DetailCharacteristics> DetailCharacteristics { get; set; }
    }
}
