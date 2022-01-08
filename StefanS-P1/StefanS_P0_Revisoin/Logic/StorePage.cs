using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefanS_P0_Revisoin.Logic
{
    public class StorePage
    {
        private bool check = false;
        public void Access(string user, int orderID)
        {
            Console.WriteLine("---------------------\n3d Refills Store Page\n---------------------");


            while (check != true)
            {
                Console.WriteLine("Select from the following options:\n\t(1) = Place an Order\n\t(2) = Shopping Cart\n\t(3) = Check Order History.\n\t(4) = EXIT.");

                int input = Int32.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Store S = new Store();
                        S.Shop(user, orderID);
                        break;
                    case 2:
                        ShoppingCart sc = new ShoppingCart();
                        sc.showCart(orderID);
                        break;
                    case 3:
                        checkOrders O = new checkOrders();
                        O.history(user);
                        break;
                    case 4:
                        check = true;
                        break;
                    default:
                        Console.WriteLine("\nNot a valid choice, try again.");
                        break;
                }
            }

        }
    }
}
