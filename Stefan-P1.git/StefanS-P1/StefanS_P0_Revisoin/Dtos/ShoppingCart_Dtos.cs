using System.Text.Json.Serialization;

namespace StefanS_P0_Revisoin.Dtos
{
    public class ShoppingCart_Dtos
    {
        public ShoppingCart_Dtos(int item_id, int order_id, string? item_name, string? location, decimal price, int quantity)
        {
            this.item_id = item_id;
            this.order_id = order_id;
            this.item = item_name;
            this.location = location;
            this.price = price;
            this.quantity = quantity;
        }
        [JsonPropertyName("id")]
        public int item_id { get; set; }
        [JsonPropertyName("orderID")]
        public int order_id { get; set; }
        [JsonPropertyName("itemName")]
        public string? item { get; set;}
        [JsonPropertyName("price")]
        public decimal price { get; set;}
        [JsonPropertyName("quantity")]
        public int quantity { get; set;}
        [JsonPropertyName("location")]
        public string? location { get; set; }
    }
}