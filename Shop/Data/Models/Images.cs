using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Images
    {
        public int imagesId { get; set; }
        public string imageName { get; set; }
        public virtual Detail Detail { get; set; }
    }
}
