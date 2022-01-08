#nullable disable
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalStoreAPI.Models;
using DigitalStoreAPI.Services;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DigitalStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        

        private readonly IConfiguration _configuration;
        private readonly CustomerContext _context;

        public CustomersController(CustomerContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Customers
        [HttpGet]

        public IEnumerable<Customer> Get()
        {
            var customers = GetCustomers();
            return customers;
        }

        private IEnumerable<Customer> GetCustomers()
        {

            var customers = new List<Customer>();

            string connect = _configuration.GetSection("ConnectionString").GetSection("PrintShopDB").Value;
            using SqlConnection connection = new(connect);
            {
                var sql = "SELECT Username,CustomerID,Firstname FROM ExistingCustomers";



                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var customer = new Customer()
                    {
                        id = (int)reader["CustomerID"],
                        name = reader["Username"].ToString(),
                    };
                    customers.Add(customer);

                }
                reader.Close();
                connection.Close();
            }

            return customers;
        }

        //Getting a specific customer from the database
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = CustomerContext.Get(id);

            if (customer == null) return NotFound();

            return customer;
        }
    }
}
