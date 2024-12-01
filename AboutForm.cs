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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.KeyPreview = true;  // Ensure KeyPreview is enabled
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            // Wire the KeyDown event to the handler
            this.KeyDown += new KeyEventHandler(AboutForm_KeyDown);
        }




        private void AboutForm_Load(object sender, EventArgs e)
        {
            // You can set up the text about the application here, if needed
            lblAbout.Text = "Welcome to the Polling System!\n\n" +
                            "in this polling you can create polls with multiple options.\n\n" +
                            "You can vote on the poll, and the system updates the results immediately.\n\n" +
                            "*****************____________****************.\n\n" +
                            "Enjoy using the Polling System!";
        }


        private void AboutForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Close the form when the ESC key is pressed
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}