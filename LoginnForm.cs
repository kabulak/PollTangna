using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollingSystem
{
    public partial class LoginnForm : Form
    {
        // Dictionary to store user credentials (username and password)
        private static Dictionary<string, string> registeredUsers = new Dictionary<string, string>();

        public static bool IsLoggedIn { get; private set; } = false;
        public static string CurrentUser { get; private set; } = "Guest";
        public LoginnForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cannot be empty.", "Error");
                return;
            }

            if (registeredUsers.ContainsKey(username))
            {
                MessageBox.Show("Username already exists. Please choose a different one.", "Error");
            }
            else
            {
                registeredUsers.Add(username, password);
                MessageBox.Show($"Registration successful for {username}! You can now log in.", "Success");
                txtUsername.Clear();
                txtPassword.Clear();

                // Debugging log
                Console.WriteLine($"Registered Users: {string.Join(", ", registeredUsers.Keys)}");
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error");
                return;
            }

            // Check if the username exists and the password matches
            if (registeredUsers.ContainsKey(username))
            {
                if (registeredUsers[username] == password)
                {
                    IsLoggedIn = true;
                    CurrentUser = username;
                    MessageBox.Show($"Welcome back, {username}!", "Success");
                    this.DialogResult = DialogResult.OK; // Close the login form and proceed to the main form
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid password. Please try again.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Username not found. Please register or try again.", "Error");
            }
        }
        

        private void btnSkip_Click(object sender, EventArgs e)
        {
            IsLoggedIn = false;
            CurrentUser = "Guest";
            MessageBox.Show("Continuing as Guest.", "Info");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
