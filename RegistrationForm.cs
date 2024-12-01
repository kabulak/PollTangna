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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            this.KeyPreview = true;  // Make sure this is set to true
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen; // Optional: Center the form on the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Disable resizing
            // Wire the KeyDown event to the handler
            this.KeyDown += new KeyEventHandler(RegistrationForm_KeyDown);
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
        private void RegistrationForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Close the form when the ESC key is pressed
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    


private void btnRegisterSubmit_Click(object sender, EventArgs e)
        {
            string newUsername = txtNewUsername.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();

            // Check if the username or password is empty
            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Username and password cannot be empty!");
                return; // Exit the method if any field is empty
            }

            try
            {
                // Register the new user
                UserManager.RegisterUser(newUsername, newPassword);
                MessageBox.Show("Registration successful! Please log in.");

                // Hide the registration form
                this.Hide();

                // Show the LoginForm
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display any error (like username already exists)
            }
        }
    }
}