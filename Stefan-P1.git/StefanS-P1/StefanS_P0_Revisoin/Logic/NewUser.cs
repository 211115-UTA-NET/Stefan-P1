using System;
using Dtos;
using SQLLogic;
using StefanS_P0_Revisoin.HttpRequests;

namespace DigitalStore
{
    public class NewUser
    {
        public static async Task UserEntry()
        {
            string exit = "";
            bool moveOn = false;
            string user = "default";

            while (moveOn == false)
            {
                Console.WriteLine("Enter Username: ");
                user = Console.ReadLine();

                //verify if the user exists already or not
                var CurrentID = await LoginTasks.GetUser(user);

                if (CurrentID.FirstOrDefault().Username == user)
                {
                    Console.WriteLine("User Exists, choose another username or type (0) = exit");
                    
                }
                else if (user == "0")
                {
                    exit = "exit";
                    break;
                }
                else
                {
                    moveOn = true;
                    exit = "exit";
                }
            }
            
            if (moveOn == true)
            {
                Console.WriteLine("Enter First name: ");
                string First = Console.ReadLine();
                Console.WriteLine("Enter Last name: ");
                string Last = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                string Pass = Console.ReadLine();

                try
                {
                    NewUserRequests.CreateUser(user, First, Last, Pass);
                    Console.WriteLine("User Account Created: ");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("User Account Creation Failed. -Exiting-" + ex);
                }
            }



            
        }
    }
}