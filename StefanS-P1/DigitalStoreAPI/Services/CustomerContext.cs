using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;
using DigitalStoreAPI.Controllers;

namespace DigitalStoreAPI.Models
{
    public class CustomerContext : DbContext
    {
        static List<Customer> customer { get; }


        //get all
        public static List<Customer> GetAll()
        {
            return customer;
        }
        //get specific
        public static Customer? Get(int id) => customer.FirstOrDefault(p => p.id == id);
    }
}
