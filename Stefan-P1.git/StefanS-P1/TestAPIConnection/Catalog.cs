using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TestAPIConnection
{
    public class Catalog
    {
        [JsonPropertyName("itemID")]
        public int ItemID { get; set; }

        [JsonPropertyName("itemName")]
        public string? ItemName { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        [JsonPropertyName("quantity")]
        public int quantity { get; set; }
    }
}
