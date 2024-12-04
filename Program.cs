using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollingSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show the Login Form
            LoginnForm loginnForm = new LoginnForm();
            if (loginnForm.ShowDialog() == DialogResult.OK)
            {
                // Proceed to the main form
                Application.Run(new Dashboard());
            }
        }
    }
}
