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
            this.txtUsername.Location = new System.Drawing.Point(40, 25);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(123, 20);
            this.txtUsername.TabIndex = 0;
            this.btnAdminLogin.Location = new System.Drawing.Point(40, 81);
            this.btnAdminLogin.Name = "btnAdminLogin";
            this.btnAdminLogin.Size = new System.Drawing.Size(100, 23);
            this.btnAdminLogin.TabIndex = 1;
            this.btnAdminLogin.UseVisualStyleBackColor = true;
            this.btnAdminLogin.Click += new System.EventHandler(this.btnAdminLogin_Click);
          
        }

        private void LoginAdminForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT UserID, Username FROM Users WHERE IsAdmin = 0"; // Exclude admin accounts
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable usersTable = new DataTable();
                    adapter.Fill(usersTable);

                    dgvUsers.DataSource = usersTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading users: {ex.Message}", "Error");
            }
        }



        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string enteredPassword = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Please enter both username and password.", "Error");
                return;
            }

            // Hardcoded admin credentials
            string adminUsername = "Justine";
            string adminPassword = "velskud";

            if (username == adminUsername && enteredPassword == adminPassword)
            {
                MessageBox.Show("Admin login successful!", "Success");

                // Keep the form open and load the voting log
                
            }
            else
            {
                MessageBox.Show("Invalid admin credentials.", "Error");
            }
        }
        

        private void dgvVotesLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Warning");
                return;
            }

            var selectedRow = dgvUsers.SelectedRows[0];
            int userId = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
            string username = selectedRow.Cells["Username"].Value.ToString();

            var confirmResult = MessageBox.Show($"Are you sure you want to delete the user '{username}'?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                DeleteUser(userId);
                LoadUsers(); // Refresh the list
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
    }
}