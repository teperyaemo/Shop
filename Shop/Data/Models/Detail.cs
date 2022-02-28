using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Detail
    {
        public int detailId { get; set; }
        public int categoryId { get; set; }
        public string detailName { get; set; }
        public string model { get; set; }
        public string gost { get; set; }
        public string drawingNumber { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        public bool visible { get; set; }

        public virtual Category Category { get; set; }
    }
}
