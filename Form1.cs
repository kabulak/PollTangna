using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PollingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;  // Make sure this is set to true
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen; // Optional: Center the form on the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Disable resizing

            // Wire the KeyDown event to the handler
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void lblCreatePoll_Click(object sender, EventArgs e)
        {

        }

        private void btnAddChoice_Click(object sender, EventArgs e)
        {
            string choice = txtChoice.Text.Trim();
            if (!string.IsNullOrEmpty(choice))
            {
                lstChoices.Items.Add(choice);
                txtChoice.Clear();
            }
        }

        private void btnCreatePoll_Click(object sender, EventArgs e)
        {
            string question = txtPollQuestion.Text.Trim();
            if (!string.IsNullOrEmpty(question) && lstChoices.Items.Count > 0)
            {
                Poll poll = new Poll(question);
                foreach (string choice in lstChoices.Items)
                {
                    poll.AddChoice(choice);
                }
                PollManager.Polls.Add(poll);
                cmbPolls.Items.Add(question);
                MessageBox.Show("Poll created successfully!");

                // Clear inputs
                txtPollQuestion.Clear();
                lstChoices.Items.Clear();
            }
        }



        private void cmbPolls_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpChoices.Controls.Clear();
            int selectedIndex = cmbPolls.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Poll selectedPoll = PollManager.Polls[selectedIndex];
                int y = 20;
                foreach (string choice in selectedPoll.Choices)
                {
                    RadioButton rb = new RadioButton
                    {
                        Text = choice,
                        Location = new System.Drawing.Point(10, y),
                        AutoSize = true
                    };
                    grpChoices.Controls.Add(rb);
                    y += 30;
                }
            }
        }

        private void btnVote_Click(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (!User.IsLoggedIn)
            {
                MessageBox.Show("You must log in to perform this action.");

                // Open the LoginForm if the user is not logged in
                LoginForm loginForm = new LoginForm();
                loginForm.Show(); // Show the login form

                return; // Exit the method so that the vote action does not happen
            }

            // Proceed with voting functionality if the user is logged in
            int selectedIndex = cmbPolls.SelectedIndex;

            if (selectedIndex >= 0)
            {
                // Get the selected poll from PollManager
                Poll selectedPoll = PollManager.Polls[selectedIndex];

                // Loop through the radio buttons in the group box (choices for the poll)
                foreach (RadioButton rb in grpChoices.Controls)
                {
                    // Check if this radio button is selected
                    if (rb.Checked)
                    {
                        // Register the vote for the selected choice
                        selectedPoll.Vote(rb.Text);
                        MessageBox.Show("Vote submitted successfully!");

                        // Update the chart with new data after the vote
                        UpdatePollResultsChart(selectedPoll);
                        break; // Exit the loop once a vote is submitted
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a poll to vote on.");
            }
        }

        private void UpdatePollResultsChart(Poll selectedPoll)
        {
            // Clear the existing chart series and data
            pollResultsChart.Series.Clear();
            pollResultsChart.ChartAreas.Clear();

            // Create a new chart area for the chart
            ChartArea chartArea = new ChartArea();
            pollResultsChart.ChartAreas.Add(chartArea);

            // Create a new series for displaying the results
            Series series = new Series
            {
                Name = "Poll Results",
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Bar
            };
            pollResultsChart.Series.Add(series);

            // Add the choices and their corresponding vote counts to the chart
            foreach (var choice in selectedPoll.Choices)
            {
                int voteCount = selectedPoll.Votes[choice];
                series.Points.AddXY(choice, voteCount);
            }

            // Set chart labels and title
            pollResultsChart.Titles.Clear();
            pollResultsChart.Titles.Add($"Results for: {selectedPoll.Question}");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }







        private void lblResults_Click(object sender, EventArgs e)
        {
            int selectedIndex = cmbPolls.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Poll selectedPoll = PollManager.Polls[selectedIndex];

                // Clear existing chart series and data
                pollResultsChart.Series.Clear();
                pollResultsChart.ChartAreas.Clear();

                // Create a new chart area for the chart
                ChartArea chartArea = new ChartArea();
                pollResultsChart.ChartAreas.Add(chartArea);

                // Create a new series for displaying the results
                Series series = new Series
                {
                    Name = "Poll Results",
                    IsValueShownAsLabel = true,
                    ChartType = SeriesChartType.Bar
                };
                pollResultsChart.Series.Add(series);

                // Add the choices and their corresponding vote counts to the chart
                foreach (var choice in selectedPoll.Choices)
                {
                    int voteCount = selectedPoll.Votes[choice];
                    series.Points.AddXY(choice, voteCount);
                }

                // Set chart labels and title
                pollResultsChart.Titles.Clear();
                pollResultsChart.Titles.Add($"Results for: {selectedPoll.Question}");
            }
        }

        private void grpChoices_Enter(object sender, EventArgs e)
        {

        }

        private void btnResetResults_Click(object sender, EventArgs e)
        {
            int selectedIndex = cmbPolls.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Poll selectedPoll = PollManager.Polls[selectedIndex];

                // Reset votes for the selected poll
                selectedPoll.ResetVotes();

                // Update the chart to reflect the reset
                UpdatePollResultsChart(selectedPoll);

                MessageBox.Show("Poll results have been reset.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            // Open the About form when the About button is clicked
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();  // Display Form3 as a modal dialog
        }
    



private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Close the form when the ESC key is pressed
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
