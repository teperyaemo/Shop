using System.Collections.Generic;

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
        public bool visible { get; set; }

        public virtual Category Category { get; set; }
        public List<DetailCharacteristics> detailCharacteristics { set; get; }
        public List<Images> images { set; get; }

    }
}
