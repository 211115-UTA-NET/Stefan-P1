using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StefanS_P0_Revisoin.Logic
{
    interface Checkout
    {
        void showCart(int orderID);
    }
    public class ShoppingCart : Checkout
    {
        public void showCart(int orderID)
        {
            string connect = File.ReadAllText("C:/Users/schwe/Revature/Stefan-P1.git/StefanS-P1/StefanS_P0_Revisoin/connection.txt");
            SqlConnection connection = new(@connect);

            string checkExist = $"SELECT COUNT(*) FROM ShoppingCart WHERE OrderID = {orderID}";
            string command = $"SELECT * FROM ShoppingCart WHERE OrderID = {orderID}";

            SqlCommand step0 = new(checkExist, connection);
            SqlCommand step1 = new(command, connection);

            connection.Open();
            int isData = (int)step0.ExecuteScalar();
            if (isData == 0)
            {
                Console.WriteLine("Shopping Cart is empty.");
            }
            else
            {
                SqlDataReader reader = step1.ExecuteReader();
                while (reader.Read())
                {
                    string item = reader.GetString(3);
                    decimal price = reader.GetDecimal(4);
                    int quantity = reader.GetInt32(5);

                    Console.WriteLine($"{item} | {price} | {quantity}");
                }
                reader.Close();
            }
            connection.Close();
        }
    }
}
