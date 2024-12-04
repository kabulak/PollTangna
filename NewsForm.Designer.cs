namespace PollingSystem
{
    partial class NewsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNews;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanelNews = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelNews
            // 
            this.flowLayoutPanelNews.AutoScroll = true;
            this.flowLayoutPanelNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelNews.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelNews.Name = "flowLayoutPanelNews";
            this.flowLayoutPanelNews.Size = new System.Drawing.Size(800, 600);
            this.flowLayoutPanelNews.TabIndex = 0;
            // 
            // NewsForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.flowLayoutPanelNews);
            this.Name = "NewsForm";
            this.Text = "News";
            this.ResumeLayout(false);
        }
    }
}