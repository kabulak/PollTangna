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

            // For Exit 
            this.KeyDown += new KeyEventHandler(LoginnForm_KeyDown);
            this.KeyPreview = true;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            this.txtPassword.Name = "txtPassword";
            this.txtPassword.TabIndex = 2;
            this.txtPassword.PasswordChar = '*';
            this.Controls.Add(this.txtPassword);
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Username", username);
                int userExists = (int)checkCommand.ExecuteScalar();

                if (userExists > 0)
                {
                    MessageBox.Show("Username already exists.", "Error");
                }
                else
                {

                    string insertQuery = "INSERT INTO Users (Username, Password, IsAdmin) VALUES (@Username, @Password, 0)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@Username", username);
                    insertCommand.Parameters.AddWithValue("@Password", password);
                    insertCommand.ExecuteNonQuery();

                    MessageBox.Show($"Registration successful for {username}!", "Success");
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
                    IsLoggedIn = true;
                    CurrentUser = username;
                    MessageBox.Show($"Welcome back, {username}!", "Success");

                  
                    this.Hide();

                    Dashboard dashboard = new Dashboard();
                    dashboard.ShowDialog(); 

                    
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.", "Error");
                }
            }
        }

        private void btnOpenAdmin_Click(object sender, EventArgs e)
        {
            LoginAdminForm adminForm = new LoginAdminForm();
            adminForm.Show();
        }
        private void LoginnForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Close the form when the ESC key is pressed
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

