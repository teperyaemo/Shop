namespace Shop.Data.Models
{
    public class DetailCharacteristics
    {
        public int detailCharacteristicsId { get; set; }
        public float value { get; set; }
        public string measure { get; set; }
        public virtual Detail Detail { get; set; }
        public virtual Charecs Charecs { get; set; }
    }
}
