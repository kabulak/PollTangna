using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
namespace PollingSystem
{
    public partial class NewsForm : Form
    {
        private readonly string apiKey = "6af71f0a08a746c69fdead2109c5dbef";  // Replace with your actual API key
        private readonly string apiUrl = "https://newsapi.org/v2/top-headlines?country=us&apiKey=";

        public NewsForm()
        {
            InitializeComponent();
            this.KeyPreview = true;  // Make sure this is set to true
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen; // Optional: Center the form on the screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Disable resizing
           

            // Wire the KeyDown event to the handler
            this.KeyDown += new KeyEventHandler(NewsForm_KeyDown);
            LoadNewsContent();
        }

        private async void LoadNewsContent()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Build the full URL with the API key
                    string requestUrl = apiUrl + apiKey;

                    // Log the URL for debugging
                    MessageBox.Show("Request URL: " + requestUrl);

                    // Send the GET request
                    HttpResponseMessage response = await client.GetAsync(requestUrl);

                    // Check if the request was successful
                    response.EnsureSuccessStatusCode();

                    // Read the response body
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject newsData = JObject.Parse(responseBody);

                    // Extract news articles from the response
                    var articles = newsData["articles"];
                    flowLayoutPanelNews.Controls.Clear(); // Clear previous news items

                    foreach (var article in articles)
                    {
                        // Create a panel for each news article
                        Panel newsPanel = new Panel();
                        newsPanel.Width = flowLayoutPanelNews.ClientSize.Width - 20;
                        newsPanel.Height = 150;
                        newsPanel.Margin = new Padding(10);

                        // Create and set the image
                        PictureBox picBox = new PictureBox();
                        string imageUrl = article["urlToImage"]?.ToString();
                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            picBox.LoadAsync(imageUrl);  // Load the image asynchronously
                            picBox.SizeMode = PictureBoxSizeMode.Zoom;
                            picBox.Width = 120;
                            picBox.Height = 100;
                        }
                        else
                        {
                            picBox.Width = 120;
                            picBox.Height = 100;
                            picBox.BackColor = Color.Gray; // Placeholder for missing images
                        }

                        // Create and set the headline label
                        Label titleLabel = new Label();
                        titleLabel.Text = article["title"].ToString();
                        titleLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                        titleLabel.AutoSize = true;
                        titleLabel.Click += (sender, e) => System.Diagnostics.Process.Start(article["url"].ToString()); // Open the full article in browser

                        // Create and set the description label
                        Label descriptionLabel = new Label();
                        descriptionLabel.Text = article["description"]?.ToString() ?? "No description available.";
                        descriptionLabel.Font = new Font("Arial", 10);
                        descriptionLabel.AutoSize = true;

                        // Add controls to the panel
                        newsPanel.Controls.Add(picBox);
                        newsPanel.Controls.Add(titleLabel);
                        newsPanel.Controls.Add(descriptionLabel);

                        // Set label positioning
                        titleLabel.Location = new Point(130, 10);
                        descriptionLabel.Location = new Point(130, 40);

                        // Add the panel to the FlowLayoutPanel
                        flowLayoutPanelNews.Controls.Add(newsPanel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching news: " + ex.Message);
            }
        }

            private void NewsForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Close the form and go back to the DashboardForm when the ESC key is pressed
            if (e.KeyCode == Keys.Escape)
            {
                // Show the DashboardForm and close the NewsForm
                Dashboard dashboardForm = new Dashboard();
                dashboardForm.Show(); // Show the DashboardForm
                this.Close(); // Close the current NewsForm
            }
        }
    }
}