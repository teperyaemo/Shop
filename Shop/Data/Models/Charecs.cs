using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Charecs
    {
        public int charecsId { get; set; }
        public string charecsName { get; set; }
        public List<DetailCharacteristics> detailCharacteristics { set; get; }
    }
}
