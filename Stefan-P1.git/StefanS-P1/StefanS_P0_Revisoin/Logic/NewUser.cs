using System;
using Dtos;
using SQLLogic;
using StefanS_P0_Revisoin.HttpRequests;

namespace DigitalStore
{
    public class NewUser
    {
        public bool response;
        public static void CreateUser()
        {

        }
        //---------------------------------------------------
        public static async void UserEntry()
        {
            string exit = "";
            bool moveOn = false;
            string user = null;

            while (user != exit)
            {
                Console.WriteLine("Enter Username: ");
                user = Console.ReadLine();

                //verify if the user exists already or not
                var CurrentID = await LoginTasks.GetUser(user);

                if (CurrentID.FirstOrDefault().Username != null)
                {
                    Console.WriteLine("User Exists, choose another username or type (0) = exit");
                }
                else if (user == "0")
                {
                    exit = "exit";
                }
                else
                {
                    moveOn = true;
                    exit = "exit";
                }
            }
            
            if (exit == "continue")
            {
                Console.WriteLine("Enter First name: ");
                string First = Console.ReadLine();
                Console.WriteLine("Enter Last name: ");
                string Last = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                string Pass = Console.ReadLine();
            }

            try
            {

                Console.WriteLine("User Account Created: ");
            }
            catch (Exception ex)
            {
                Consle.WriteLine("User Account Creation Failed. -Exiting-");
            }

            
        }
    }
}