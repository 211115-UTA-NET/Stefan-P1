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
    public class CheckOut
    {
        public static void buy(string name, int userID, int seshID)
        {
            bool check = false;

            Console.WriteLine("Your Current Cart");
            DisplayCart.ShowCart();
            Console.WriteLine("Confirm Checkout?\n\t(1) = Yes\n\t(2) = No");
            string purchase = Console.ReadLine();

            switch(purchase)
            {
                case "1":
                    check = true;
                    break;
                default:
                    Console.WriteLine("Returning to Store Menu");
                    break;
            }

            if (check == true)
            {
                List<ExistingOrders_Dtos> checkoutCart = new();

                foreach(var I in Store.cart)
                {
                    var build = new ExistingOrders_Dtos()
                    {
                        item_id = I.item_id,
                        customer_id = userID,
                        first_name = name,
                        order_id = seshID,
                        location = I.location,
                        item_name = I.item,
                        quantity = I.quantity,
                        price = I.price,
                    };
                    checkoutCart.Add(build);
                }
                CheckoutTask.AddToCart(checkoutCart);
                Console.WriteLine("Purchase Complete");
                Store.cart.Clear();
            }
                
            
        }
    }
}