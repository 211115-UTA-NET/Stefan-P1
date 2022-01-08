namespace DigitalStoreAPI.Models
{
    public class Catalog
    {
        public int ItemID { get; set; }
        public string? ItemName { get; set; }
        public string? Location { get; set; }
        public decimal? Price { get; set; }
        public int quantity { get; set; }
    }
}
