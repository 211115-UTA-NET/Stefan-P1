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
    public class Store : StorePage
    {
        static List<Inventory_Dtos>? stock { get; set; }
        public static List<ShoppingCart_Dtos> cart { get; set; }
        static Store()
        {
            stock = new List<Inventory_Dtos>();
            cart = new List<ShoppingCart_Dtos>();
        }


        public static async Task Shop(int orderID)
        {
            bool check = false;
            string located = null;

            while (check != true)
            {
                Console.WriteLine("Choose Store Location:\n\t(1) = North St.\n\t(2) = Southern Rd.");
                int input = Int32.Parse(Console.ReadLine());

                //converts input to response for SQL server parsing
                switch (input)
                {
                    case 1:
                        located = "North St.";
                        check = true;
                        break;
                    case 2:
                        located = "Southern Rd.";
                        check = true;
                        break;
                    case 3:
                        check = true;
                        break;
                    default:
                        Console.WriteLine("Not a valid input, try again\n");
                        break;
                }
            }

            //http request
            var storeInventory = await StoreInventoryTask.GetInventory();
 

            foreach (var I in storeInventory)
            {
                if(I.location == located)
                {
                    Console.WriteLine($"\t({I.item_id}) = {I.item_name} | ${I.price} | In Stock: {I.quantity}");
                    stock.Add(new Inventory_Dtos(I.item_id,I.item_name,I.location,I.price,I.quantity));
                }
            }

            //while loop to add items to cart
            bool shopping = true;

            while (shopping == true)
            {
                

                //ask for item to change
                Console.WriteLine("Select items you wish to select or type 'Exit'");
                string item = Console.ReadLine();
                item = item.ToLower();

                if (item == "exit")
                {
                    shopping = false;
                    break;
                }

                //Ask for quanity of item order
                Console.WriteLine("Select quantity:");
                int quantity = Int32.Parse(Console.ReadLine());
                int id = Int32.Parse(item);
                int inStock = 0;

                //sets cart Dtos to selected item
                foreach(var I in stock)
                { 
                    if (I.item_id == id)
                    {
                        if (quantity > I.quantity)
                        {
                            Console.WriteLine("Not enough items in stock to fufill that order.");
                        }
                        else
                        {
                            cart.Add(new ShoppingCart_Dtos(I.item_id, orderID, I.item_name, I.location, I.price, quantity));
                            Console.WriteLine("Added to cart");

                        }
                    }
                }
            }
        }
    }
}
