namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Detail detail { get; set; }
        public string shopCartId { get; set; }
    }
}
