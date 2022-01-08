using System;
using Dtos;
using SQLLogic;
using StefanS_P0_Revisoin.Logic;

namespace DigitalStore
{
    public class Login
    {
        public static int SessionID { get; set; }

        //Checks for authentification boolean on username
        public static void IsAuthenticated(string user, out bool response, out int id)
        {
            //create fields for out
            response = false;
            id = 0;

            //initiate check for username and retrieves boolean and id
            SQLCommands.CheckForUser(user, out bool exists, out int ID);
            Customer_Dtos C = new();

            if (exists == false)
            {
                Console.WriteLine("User Does not Exist");
                response = false;
            }
            else if (exists == true)
            {
                Console.WriteLine("User Found");
                response = true;
                //updates the customer Dtos
                C.user = user;
                C.id = ID;
                id = C.id;
                //create the session id
                var random = new Random();
                SessionID = random.Next();
                C.seshId = SessionID;
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        //---------------------------------------------------
        public static void UserEntry()
        {
            //information retriever for username, check username, then retrieves id and check status
            Console.WriteLine("Enter Username: ");
            string user = Console.ReadLine();
            IsAuthenticated(user,out bool exists, out int id);

            //checks statsus of authenticator and sets password check to false as default
            bool check = exists;
            bool check2 = false;

            if(check == true)
            {
                Console.WriteLine("Enter Password: ");
                string password = Console.ReadLine();

                check2 = SQLCommands.CheckPassword(password, id);
            }
            else if (check == false)
            {
                Console.WriteLine("Check Failed");
            }

            //final check for user access
            if(check2 == true)
            {
                Console.WriteLine("Login Sucessful");
                Store S = new();
                S.Access(user,SessionID);
            }
        }
    }
}