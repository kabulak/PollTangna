using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PollingSystem
{
    public partial class LoginnForm : Form
    {
        // Connection string to LocalDB or any SQL Server database
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Justine\Source\Repos\PollTangna\PollingDatabase.mdf;Integrated Security=True";


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

            // Check if username already exists in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(checkUserQuery, connection);
                command.Parameters.AddWithValue("@Username", username);
                connection.Open();
                int userCount = (int)command.ExecuteScalar();

                if (userCount > 0)
                {
                    MessageBox.Show("Username already exists. Please choose a different one.", "Error");
                }
                else
                {
                    // Insert the new user into the database
                    string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@Username", username);
                    insertCommand.Parameters.AddWithValue("@Password", password);
                    insertCommand.ExecuteNonQuery();

                    MessageBox.Show($"Registration successful for {username}! You can now log in.", "Success");
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
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

            // Check if the username exists and the password matches in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string loginQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(loginQuery, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                connection.Open();

                int userCount = (int)command.ExecuteScalar();

                if (userCount > 0)
                {
                    // User is logged in successfully
                    IsLoggedIn = true;
                    CurrentUser = username;
                    MessageBox.Show($"Welcome back, {username}!", "Success");
                    this.DialogResult = DialogResult.OK; // Close the login form and proceed to the main form
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.", "Error");
                }
            }
        }
    }
}


