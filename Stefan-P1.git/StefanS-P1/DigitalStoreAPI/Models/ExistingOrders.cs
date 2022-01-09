namespace DigitalStoreAPI.Models
{
    public class ExistingOrders
    {
        public int customer_id { get; set; }
        public string? first_name { get; set; }
        public int order_id { get; set; }
        public string? location { get; set; }
        public string? item_name { get; set; }
        public int quantity { get; set; }
        public decimal? price { get; set; }
        public DateTime? date { get; set;}
        
    }
}
