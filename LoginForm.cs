﻿using System;
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
    public partial class LoginForm : Form
    {
        // Example user list (in a real scenario, you would query a database)
        public static Dictionary<string, string> users = new Dictionary<string, string>
        {
            { "user1", "password123" }, // Example user
            { "user2", "password456" }
        };



        public LoginForm()
        {
            InitializeComponent();
            this.KeyPreview = true;  // Make sure this is set to true
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen; // Optional: Center the form on the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Disable resizing
            // Wire the KeyDown event to the handler
            this.KeyDown += new KeyEventHandler(LoginForm_KeyDown);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Close the form when the ESC key is pressed
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validate user credentials
            if (UserManager.ValidateUser(username, password))
            {
                // Successful login
                MessageBox.Show("Login successful!");

                // Set user session details
                User.IsLoggedIn = true;
                User.CurrentUsername = username;

                // Hide the login form and show the main form (Form1)
                this.Hide(); // Hide the LoginForm
                Form1 mainForm = new Form1();
                mainForm.Show(); // Show the main form
            }
            else
            {
                // Invalid login attempt
                MessageBox.Show("Invalid username or password!");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Open the Registration Form
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show(); // Show the registration form

            // Hide the login form until registration is complete
            this.Hide();
        }

        // Method to check if a user exists
        public static bool UserExists(string username)
        {
            return users.ContainsKey(username);
        }

        // Method to add a new user
        public static void AddUser(string username, string password)
        {
            users.Add(username, password);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblErrorMessage_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
