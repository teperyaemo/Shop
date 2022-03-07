using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Charecs
    {
        public int charecsId { get; set; }
        public string charecsName { get; set; }
        public List<DetailCharacteristics> detailCharacteristics { set; get; }
    }
}
