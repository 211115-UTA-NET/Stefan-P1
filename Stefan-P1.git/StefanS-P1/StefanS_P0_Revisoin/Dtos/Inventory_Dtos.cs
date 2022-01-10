using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace StefanS_P0_Revisoin.Dtos
{
    public class Inventory_Dtos
    {
        public Inventory_Dtos(int item_id, string? item_name, string? location, decimal price, int quantity)
        {
            this.item_id = item_id;
            this.item_name = item_name;
            this.location = location;
            this.price = price;
            this.quantity = quantity;
        }

        [JsonPropertyName("itemID")]
        public int item_id { get; set; }
        [JsonPropertyName("itemName")]
        public string? item_name { get; set; }
        [JsonPropertyName("location")]
        public string? location { get; set; }
        [JsonPropertyName("price")]
        public decimal price { get; set; }
        [JsonPropertyName("quantity")]
        public int quantity { get; set; }
        
    }
}
