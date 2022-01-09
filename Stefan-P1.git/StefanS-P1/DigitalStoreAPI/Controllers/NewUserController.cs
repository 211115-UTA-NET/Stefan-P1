using Microsoft.AspNetCore.Mvc;
using DigitalStoreAPI.Models;
using System.Data.SqlClient;

namespace DigitalStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewUserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public NewUserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //Getting a specific customer from the database
        [HttpPost]
        public async void CreateUser(NewUser newUser)
        {
            string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
            await using SqlConnection connection = new(connect);
            NewUserService.CreateUser(newUser, connection);
        }
    }
}