﻿using System;
using System.IO;
using System.Data.SqlClient;
using System.Net.Http.Json;
using System.Text.Json;


namespace DigitalStore
{
    public class Program
    { 
        public static readonly HttpClient HttpClient = new();
        public static void Main(string[] args)
        {
            //connection to api
            Uri server = new("https://localhost:7146");

            //Initial system start, displays user options and grabs response as int
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("Welcome To 3d Refills Online Store");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("New or Returning User?\n\t(1) = New User\n\t(2) = Returning User\n");

            int input = Int32.Parse(Console.ReadLine());
            
            
            //checks for user input. (integers only)
            if (input == 1)
            {
                Login.UserEntry();
            }
            else if (input == 2)
            {
                NewUser.UserEntry();
            }
        }
    }
}