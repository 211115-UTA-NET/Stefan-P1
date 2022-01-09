using DigitalStoreAPI.Models;
using System.Data.SqlClient;

namespace DigitalStoreAPI.Services
{
    public class CatalogService
    {
        static List<Catalog> Inventory { get; }
        static CatalogService()
        {
            Inventory = new List<Catalog>
            {
                //if you would like to manually add a custom item
                //new Catalog {ItemID = 18, ItemName = "SuperPrint 1000", Location = "North St.", Price = 1000, quantity = 10}
            };
        }
        //get all
        public static List<Catalog> GetAll(SqlConnection connection)
        {
            string sql = "SELECT * FROM _Catalog";

            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var catalog = new Catalog()
                {
                    ItemID = (int)reader[0],
                    ItemName = reader[1].ToString(),
                    Location = reader[2].ToString(),
                    Price = (decimal)reader[3],
                    quantity = (int)reader[4]
                };
                Inventory.Add(catalog);
            }
            reader.Close();
            connection.Close();
            return Inventory;
        }
        //get specific
        public static List<Catalog> Get(int id, SqlConnection connection)
        {

            string sql = $"SELECT * FROM _Catalog WHERE ItemID = {id}";

            connection.Open();
            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var catalog = new Catalog()
                {
                    ItemID = (int)reader[0],
                    ItemName = reader[1].ToString(),
                    Location = reader[2].ToString(),
                    Price = (decimal)reader[3],
                    quantity = (int)reader[4]
                };
                Inventory.Add(catalog);
            }
            reader.Close();
            connection.Close();
            return Inventory;
        }

        public static void Update(Catalog catalog)
        {
            var index = Inventory.FindIndex(p => p.ItemID == catalog.ItemID);
            if(index == -1) return;

            Inventory[index] = catalog;
        }
    }
}
