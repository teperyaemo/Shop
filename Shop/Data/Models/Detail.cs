using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Detail
    {
        public int detailId { get; set; }

        [Display(Name = "Номер категории")]
        public int categoryId { get; set; }

        [Display(Name = "Название")]
        public string detailName { get; set; }

        [Display(Name = "Модель")]
        public string model { get; set; }

        [Display(Name = "ГОСТ")]
        public string gost { get; set; }

        [Display(Name = "Номер чертежа")]
        public string drawingNumber { get; set; }

        public string Image { get; set; }

        [Display(Name = "Описание")]
        public string description { get; set; }

        [Display(Name = "Видимость")]
        public bool visible { get; set; }

        public virtual Category Category { get; set; }
        public List<DetailCharacteristics> detailCharacteristics { set; get; }
        public List<Images> images { set; get; }

    }
}
