using System.Data.SqlClient;

namespace SQLLogic
{
    class SQLCommands
    {
        private string connect = File.ReadAllText("C:/Users/schwe/Revature/StefanS_P0_Revisoin/connection.txt");           
     
        public static void CheckForUser(string user, out bool exists, out int ID)
        {
            var cn = new SQLCommands();
            SqlConnection connection = new(cn.@connect);
            exists = false;
            ID = 0;

            string checkExist = $"SELECT COUNT(*) FROM ExistingCustomers WHERE Username = '{user}'";
            string grabID = $"SELECT CustomerID FROM ExistingCustomers WHERE Username = '{user}'";

            
            //Set constructors for command strings
            SqlCommand step0 = new(checkExist, connection);
            SqlCommand step1 = new(grabID, connection);

            //Opens connection
            connection.Open();
            //Creates integer to check if there are values in the customer query
            int isData = (int)step0.ExecuteScalar();

            if (isData > 0)
            {
                try
                {
                    exists = true;
                    SqlDataReader reader = step1.ExecuteReader();
                    reader.Read();
                    ID = reader.GetInt32(0);
                    reader.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                    connection.Close();
                }

            }
           connection.Close();

        }

        //-------------------------------------------------------------------------------------

        public static bool CheckPassword(string pass, int ID)
        {
            var cn = new SQLCommands();
            SqlConnection connection = new(cn.@connect);
            string SqlPass;

            string getPass = $"SELECT Password FROM CustomerPasswords WHERE CustomerID = {ID}";

            SqlCommand step1 = new(getPass, connection);
            connection.Open();

            try
            {
                SqlDataReader readPass = step1.ExecuteReader();
                readPass.Read();
                SqlPass = readPass.GetString(0);
                readPass.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
                SqlPass = null;
            }
            finally
            {
                connection.Close();
            }

            //validate if the entered password matches the database
            if (pass == SqlPass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

