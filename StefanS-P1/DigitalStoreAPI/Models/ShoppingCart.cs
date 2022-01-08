namespace DigitalStoreAPI.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public string? ItemName { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
    }
}
