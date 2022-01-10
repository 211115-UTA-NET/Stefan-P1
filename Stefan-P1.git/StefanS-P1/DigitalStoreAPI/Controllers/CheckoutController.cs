using Microsoft.AspNetCore.Mvc;
using DigitalStoreAPI.Models;
using System.Data.SqlClient;

namespace DigitalStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CheckoutController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //Getting a specific customer from the database
        [HttpPost]
        public async void BuyStuff(List<ExistingOrders> cart)
        {
            string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
            await using SqlConnection connection = new(connect);
            CheckoutService.BuyStuff(cart, connection);
        }
    }
}