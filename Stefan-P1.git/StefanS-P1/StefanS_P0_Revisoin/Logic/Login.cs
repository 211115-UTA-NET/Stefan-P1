using System;
using StefanS_P0_Revisoin.Dtos;
using SQLLogic;
using StefanS_P0_Revisoin.Logic;
using StefanS_P0_Revisoin.HttpRequests;

namespace StefanS_P0_Revisoin
{
    public class Login
    {
        private int CurrentCustomerID { get; set; }

        //Checks for authentification boolean on username
        public static async Task<bool> IsAuthenticated(string user, Login checker)
        {
            bool auth;
            var CurrentCustomer = await LoginTasks.GetUser(user);
            //Console.WriteLine(CurrentCustomer.First().Username); //prints out selected user


            if (CurrentCustomer.FirstOrDefault().Username == null)
            {
                Console.WriteLine("No User Found");
                auth = false;
            }
            else if (CurrentCustomer.FirstOrDefault().Username == user)
            {    
                checker.CurrentCustomerID = CurrentCustomer.FirstOrDefault().CustomerID;
                auth = true;
            }
            else
            {
                Console.WriteLine("User Query Error, try again.");
                auth = false;
                }
            
            return auth;
        }

        //------------------------------------------
        public static async Task<bool> PasswordAuthenticator(string pass, Login checker)
        {
            bool auth;
            var CurrentID = await LoginTasks.GetPass(checker.CurrentCustomerID);

            if (CurrentID.FirstOrDefault().Password == pass)
            {
                auth = true;
            }
            else
            {
                Console.WriteLine("Password does not match");
                auth = false;
            }
            return auth;
        }

        //---------------------------------------------------
        public static async Task UserEntry()
        {
            Login checker = new();
            //information retriever for username, check username, then retrieves id and check status
            Console.WriteLine("Enter Username: ");
            string? user = Console.ReadLine();


            bool validationCheck = await IsAuthenticated(user,checker);
            bool passwordCheck = false;

            if(validationCheck == true)
            {
                Console.WriteLine("Enter Password: ");
                string password = Console.ReadLine();

                passwordCheck = await PasswordAuthenticator(password, checker);
            }
            else if (validationCheck == false)
            {
                Console.WriteLine("User Not Found");
            }

            //final check for user access
            if(passwordCheck == true)
            {
                //creates random number for session id
                var rand = new Random();
                int SessionID = rand.Next();

                //brings us into the application
                Console.WriteLine("Login Sucessful");

                await StorePage.Access(user,SessionID);
            }
        }
    }
}