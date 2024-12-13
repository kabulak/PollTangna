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
using System.Data.SqlClient;
namespace PollingSystem
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Justine\Source\Repos\PollTangna\PollingDatabase.mdf;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;  
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog; 
            this.FormClosing += Form1_FormClosing;

            
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
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
               
                if (!lstChoices.Items.Contains(choice))
                {
                    lstChoices.Items.Add(choice);
                    txtChoice.Clear();
                }
                else
                {
                    MessageBox.Show("This choice has already been added.");
                }
            }
            else
            {
                MessageBox.Show("Choice cannot be empty.");
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

                
                txtPollQuestion.Clear();
                lstChoices.Items.Clear();

                // Reset the chart and choices group box
                pollResultsChart.Series.Clear();
                pollResultsChart.ChartAreas.Clear();
                grpChoices.Controls.Clear();
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
            int selectedIndex = cmbPolls.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Poll selectedPoll = PollManager.Polls[selectedIndex];

                foreach (RadioButton rb in grpChoices.Controls)
                {
                    if (rb.Checked)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string updateVoteQuery = "UPDATE Votes SET VoteCount = VoteCount + 1 WHERE PollID = @PollID AND VoteChoice = @VoteChoice";
                            using (SqlCommand command = new SqlCommand(updateVoteQuery, connection))
                            {
                                command.Parameters.AddWithValue("@PollID", selectedPoll.PollID);
                                command.Parameters.AddWithValue("@VoteChoice", rb.Text);
                                command.ExecuteNonQuery();
                            }

                          
                               
                               
                            }
                        }

                     
                        if (selectedPoll.Votes.ContainsKey(rb.Text))
                        {
                            selectedPoll.Votes[rb.Text]++;
                        }
                        else
                        {
                            selectedPoll.Votes[rb.Text] = 1; 
                        }

                       
                        MessageBox.Show("Vote submitted successfully!");

                      
                        UpdatePollResultsChart(selectedPoll);
                        break; 
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
                int voteCount = selectedPoll.Votes.ContainsKey(choice) ? selectedPoll.Votes[choice] : 0;
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

                // Reset the local Votes dictionary for the selected poll
                foreach (var choice in selectedPoll.Choices)
                {
                    selectedPoll.Votes[choice] = 0;  // Reset each choice's vote count to 0
                }

                MessageBox.Show("Poll results have been reset.");

                // Update the chart with the reset data
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
            // Reset the poll list and other components
            cmbPolls.Items.Clear();
            grpChoices.Controls.Clear();
            pollResultsChart.Series.Clear();
            pollResultsChart.ChartAreas.Clear();

            // Repopulate the poll list (cmbPolls)
            foreach (var poll in PollManager.Polls)
            {
                cmbPolls.Items.Add(poll.Question);
            }
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
