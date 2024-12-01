using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingSystem
{
    public static class User
    {
        // Property to track if the user is logged in or not
        public static bool IsLoggedIn { get; set; } = false;

        // Property to store the current logged-in user's username
        public static string CurrentUsername { get; set; } = string.Empty;
    }
}