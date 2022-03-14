namespace Shop.Data.Models
{
    public class Images
    {
        public int imagesId { get; set; }
        public string imageName { get; set; }
        public virtual Detail Detail { get; set; }
    }
}
