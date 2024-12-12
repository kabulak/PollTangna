﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
namespace PollingSystem
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PollingDatabase.mdf;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;  // Make sure this is set to true
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen; // Optional: Center the form on the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Disable resizing
            this.FormClosing += Form1_FormClosing;

            // Wire the KeyDown event to the handler
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Show the Dashboard form when Form1 is closed
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
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
                // Create a new poll and add choices
                Poll poll = new Poll(question);
                foreach (string choice in lstChoices.Items)
                {
                    poll.AddChoice(choice);  // Add each choice to the poll
                }

                // Add the poll to PollManager and the ComboBox
                PollManager.Polls.Add(poll);
                cmbPolls.Items.Add(question);  // Add the question to ComboBox

                MessageBox.Show("Poll created successfully!");

                // Clear inputs
                txtPollQuestion.Clear();
                lstChoices.Items.Clear();
            }
        }



        private void cmbPolls_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear existing radio buttons in the GroupBox
            grpChoices.Controls.Clear();

            // Get the selected poll based on the selected index of the ComboBox
            int selectedIndex = cmbPolls.SelectedIndex;
            if (selectedIndex >= 0)
            {
                // Get the selected poll from PollManager
                Poll selectedPoll = PollManager.Polls[selectedIndex];

                // Add the choices as radio buttons to the grpChoices GroupBox
                int y = 20;  // Starting Y position for radio buttons
                foreach (string choice in selectedPoll.Choices)
                {
                    // Create a new radio button for each choice
                    RadioButton rb = new RadioButton
                    {
                        Text = choice,
                        Location = new System.Drawing.Point(10, y),
                        AutoSize = true
                    };

                    // Add the radio button to the GroupBox
                    grpChoices.Controls.Add(rb);
                    y += 30;  // Move the next radio button down for better spacing
                }
            }
        }

        private void btnVote_Click(object sender, EventArgs e)
        {
            int selectedIndex = cmbPolls.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Poll selectedPoll = PollManager.Polls[selectedIndex];

                foreach (RadioButton rb in grpChoices.Controls)
                {
                    if (rb.Checked)
                    {
                        // Update the vote count for the selected choice in the database
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string updateVoteQuery = "UPDATE Votes SET VoteCount = VoteCount + 1 WHERE PollID = @PollID AND VoteChoice = @VoteChoice";
                            SqlCommand command = new SqlCommand(updateVoteQuery, connection);
                            command.Parameters.AddWithValue("@PollID", selectedPoll.PollID); // Replace with actual PollID
                            command.Parameters.AddWithValue("@VoteChoice", rb.Text);
                            connection.Open();
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Vote submitted successfully!");

                        // Update the chart with new data
                        UpdatePollResultsChart(selectedPoll);
                        break;
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

                // Reset votes in the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string resetVotesQuery = "UPDATE Votes SET VoteCount = 0 WHERE PollID = @PollID";
                    SqlCommand command = new SqlCommand(resetVotesQuery, connection);
                    command.Parameters.AddWithValue("@PollID", selectedPoll.PollID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Poll results have been reset.");

                // Update the chart with reset data
                UpdatePollResultsChart(selectedPoll);
            }
        }

        private void LoadPolls()
        {
            string query = "SELECT PollQuestion FROM Polls";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Populate the ComboBox with Poll questions
                cmbPolls.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    cmbPolls.Items.Add(row["PollQuestion"].ToString());
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
