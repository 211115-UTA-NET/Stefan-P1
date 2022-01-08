using System;
using Dtos;
using SQLLogic;

namespace DigitalStore
{
    public class NewUser
    {
        public bool response;
        public static bool CreateUser()
        {
            bool response = false;
            return response;
        }
        //---------------------------------------------------
        public static void UserEntry()
        {
            Customer_Dtos C = new();

            Console.WriteLine("Enter Username: ");
            C.user = Console.ReadLine();
        }
    }
}