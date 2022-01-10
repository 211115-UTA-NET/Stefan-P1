using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace StefanS_P0_Revisoin.Dtos
{
    public class Customer_Dtos
    {
        [JsonPropertyName("id")]
        public int CustomerID { get; set; }

        [JsonPropertyName("username")]
        public string? Username { get; set; }
        [JsonPropertyName("firstname")]
        public string? firstname { get; set; }
    }

    public class NewCustomer_Dtos
    {
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("firstname")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastname")]
        public string? LastName { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }


    }

    public class Password_Dtos
    {
        [JsonPropertyName("id")]
        public int CustomerID { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }
    }
}