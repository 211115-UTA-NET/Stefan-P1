using DigitalStoreAPI.Models;
using DigitalStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DigitalStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ShoppingCartController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ShoppingCartController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Post to shopping cart
        [HttpPost]
        public async void AddToCart(ShoppingCart cart)
        {
            string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
            await using SqlConnection connection = new(connect);
            ShoppingCartContext.AddToCart(cart, connection);
        }

    }
}



