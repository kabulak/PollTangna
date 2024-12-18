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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Dashboard_KeyDown);
            this.KeyPreview = true;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeCategories();
        }

        private void InitializeCategories()
        {

            cmbCategories.Items.Add("News");
            cmbCategories.Items.Add("About");
            cmbCategories.Items.Add("Poll");
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void Dashboard_KeyDown(object sender, KeyEventArgs e)
        {
            // Close the form when the ESC key is pressed
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }




        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Show the Dashboard form when Form1 is closed
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Optionally, you can show a confirmation message before closing.
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                LoginnForm loginForm = new LoginnForm();
                loginForm.Show();
            }
            else
            {
                e.Cancel = true;  // Cancel the form close if the user selects "No"
            }
        }

        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Show the Dashboard form when Form1 is closed
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Display information based on the selected category
            string selectedCategory = cmbCategories.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedCategory))
            {
                MessageBox.Show("Please select a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the "Poll" category is selected
            if (selectedCategory == "Poll")
            {
                // Create and show Form1
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();  // Optionally, hide the current Dashboard form
            }
            else if (selectedCategory == "About")
            {
                // Open the About form as a modal dialog
                AboutForm aboutForm = new AboutForm();
                aboutForm.ShowDialog();
            }
            else if (selectedCategory == "News")
            {
                // Show NewsForm when "News" category is selected
                NewsForm newsForm = new NewsForm();
                newsForm.Show();  // Show NewsForm
                this.Hide();  // Optionally, hide the current Dashboard form
            }
            else
            {

                MessageBox.Show($"Displaying content for {selectedCategory} category.");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            // Close the current Dashboard
            this.Close();

            // Ensure LoginnForm is reopened from a single instance
            Application.Restart(); // Restarts the application, returning to the initial state
        }
    }
}