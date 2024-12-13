using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollingSystem
{
    public partial class LoginAdminForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Justine\Source\Repos\PollTangna\PollingDatabase.mdf;Integrated Security=True";

        public LoginAdminForm()
        {
            InitializeComponent();

            this.btnAdminLogin.TabIndex = 1;
            this.btnAdminLogin.Click += new System.EventHandler(this.btnAdminLogin_Click);
           
            this.txtPassword.Name = "txtPassword";
          
            this.txtPassword.TabIndex = 1;
            this.txtPassword.PasswordChar = '*'; 

            
            this.Controls.Add(this.txtPassword);

        }

        private void LoginAdminForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            dgvUsers.Visible = false; 
        
        }

        private void LoadUsers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                   
                    string query = "SELECT Username FROM Users";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable usersTable = new DataTable();
                    adapter.Fill(usersTable);

                    dgvUsers.DataSource = usersTable;

                   
                    dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error");
            }
        }



        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string enteredPassword = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Please enter both username and password.", "Error");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Password, IsAdmin FROM Users WHERE Username = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string storedPassword = reader["Password"].ToString();
                        bool isAdmin = Convert.ToBoolean(reader["IsAdmin"]);

                        
                        if (isAdmin && storedPassword == enteredPassword)
                        {
                            MessageBox.Show("Admin login successful!", "Success");

                          
                            dgvUsers.Visible = true;

                           
                            LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show("Invalid admin credentials.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("User not found.", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }


        private void dgvVotesLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0) 
            {
               
                string username = dgvUsers.SelectedRows[0].Cells[0].Value.ToString();

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Users WHERE Username = @Username";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Username", username);
                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show($"User '{username}' deleted successfully.", "Success");
                        LoadUsers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.", "Error");
            }
        }


        private void DeleteUser(int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Users WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("User deleted successfully.", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the user: {ex.Message}", "Error");
            }
        }

        private void btnResfresh_Click(object sender, EventArgs e)
        {
            LoadUsers(); 
        }
    }
}