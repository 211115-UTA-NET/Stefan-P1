using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace StefanS_P0_Revisoin.Dtos
{
    public class ExistingOrders_Dtos
    {
        [JsonPropertyName("item_id")]
        public int item_id { get; set; }

        [JsonPropertyName("customer_id")]
        public int customer_id { get; set; }
        [JsonPropertyName("first_name")]
        public string? first_name { get; set; }
        [JsonPropertyName("order_id")]
        public int order_id { get; set; }
        [JsonPropertyName("location")]
        public string? location { get; set; }
        [JsonPropertyName("item_name")]
        public string? item_name { get; set; }
        [JsonPropertyName("quantity")]
        public int quantity { get; set; }
        [JsonPropertyName("price")]
        public decimal? price { get; set; }
        [JsonPropertyName("date")]
        public DateTime? date { get; set; }
    }
}
