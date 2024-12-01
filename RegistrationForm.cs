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
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRegisterSubmit_Click(object sender, EventArgs e)
        {
            string newUsername = txtNewUsername.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();

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