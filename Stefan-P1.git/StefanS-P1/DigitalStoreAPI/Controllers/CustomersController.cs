#nullable disable
using Microsoft.AspNetCore.Mvc;
using DigitalStoreAPI.Models;
using System.Data.SqlClient;

namespace DigitalStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CustomersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Customers
        [HttpGet]

        public ActionResult<List<Customer>> GetAll()
        {
            string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
            using SqlConnection connection = new(connect);
            return CustomerContext.GetAll(connection);
        }

        //Getting a specific customer from the database
        [HttpGet("{username}")]
        public ActionResult<List<Customer>> Get(string user)
        {
            string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
            using SqlConnection connection = new(connect);
            return CustomerContext.Get(user, connection);
        }
    }
}
