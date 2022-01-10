using Microsoft.AspNetCore.Mvc;
using DigitalStoreAPI.Models;
using System.Data.SqlClient;

namespace DigitalStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PasswordController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //Getting a specific customer from the database
        [HttpGet("{password}")]
        public ActionResult<List<Password>> Get(int id)
        {
            string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
            using SqlConnection connection = new(connect);
            return PasswordContext.Get(id, connection);
        }
    }
}
