using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StefanS_P0_Revisoin.Dtos;
using StefanS_P0_Revisoin.HttpRequests;

namespace StefanS_P0_Revisoin.Logic
{
    public class DisplayCart
    {
        public static void ShowCart()
        {
            foreach(var x in Store.cart)
            {
                Console.WriteLine(string.Format("\t{0,10}|{1,8:N2}|{2,3}|{3,10}",$"{ x.item }",$"${ x.price}",$"{ x.quantity}",$"{ x.location}"));

            }
        }
    }
}
