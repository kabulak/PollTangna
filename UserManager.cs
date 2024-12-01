using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingSystem
{
    internal class UserManager
    {

     // Dictionary to hold registered users (username, password)
        private static Dictionary<string, string> users = new Dictionary<string, string>();

        // Method to register a new user
        public static void RegisterUser(string username, string password)
        {
            // Add the user to the dictionary
            if (!users.ContainsKey(username))
            {
                users.Add(username, password);
            }
            else
            {
                throw new Exception("Username already exists.");
            }
        }

        // Method to check if the user exists and the password is correct
        public static bool ValidateUser(string username, string password)
        {
            return users.ContainsKey(username) && users[username] == password;
        }
    }
}
