namespace PollingSystem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblCreatePoll = new System.Windows.Forms.Label();
            this.lblPollQuestion = new System.Windows.Forms.Label();
            this.lblChoices = new System.Windows.Forms.Label();
            this.txtPollQuestion = new System.Windows.Forms.TextBox();
            this.txtChoice = new System.Windows.Forms.TextBox();
            this.lstChoices = new System.Windows.Forms.ListBox();
            this.btnAddChoice = new System.Windows.Forms.Button();
            this.btnCreatePoll = new System.Windows.Forms.Button();
            this.cmbPolls = new System.Windows.Forms.ComboBox();
            this.grpChoices = new System.Windows.Forms.GroupBox();
            this.btnVote = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResults = new System.Windows.Forms.Label();
            this.pollResultsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnResetResults = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollResultsChart)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCreatePoll
            // 
            this.lblCreatePoll.AutoSize = true;
            this.lblCreatePoll.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCreatePoll.ForeColor = System.Drawing.Color.White;
            this.lblCreatePoll.Location = new System.Drawing.Point(10, 6);
            this.lblCreatePoll.Name = "lblCreatePoll";
            this.lblCreatePoll.Size = new System.Drawing.Size(121, 25);
            this.lblCreatePoll.TabIndex = 0;
            this.lblCreatePoll.Text = "CreatingPoll";
            this.lblCreatePoll.Click += new System.EventHandler(this.lblCreatePoll_Click);
            // 
            // lblPollQuestion
            // 
            this.lblPollQuestion.AutoSize = true;
            this.lblPollQuestion.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPollQuestion.ForeColor = System.Drawing.Color.White;
            this.lblPollQuestion.Location = new System.Drawing.Point(7, 6);
            this.lblPollQuestion.Name = "lblPollQuestion";
            this.lblPollQuestion.Size = new System.Drawing.Size(130, 25);
            this.lblPollQuestion.TabIndex = 1;
            this.lblPollQuestion.Text = "Poll Question";
            // 
            // lblChoices
            // 
            this.lblChoices.AutoSize = true;
            this.lblChoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblChoices.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblChoices.Location = new System.Drawing.Point(663, 70);
            this.lblChoices.Name = "lblChoices";
            this.lblChoices.Size = new System.Drawing.Size(56, 19);
            this.lblChoices.TabIndex = 2;
            this.lblChoices.Text = "Choices";
            // 
            // txtPollQuestion
            // 
            this.txtPollQuestion.Location = new System.Drawing.Point(12, 40);
            this.txtPollQuestion.Name = "txtPollQuestion";
            this.txtPollQuestion.Size = new System.Drawing.Size(211, 20);
            this.txtPollQuestion.TabIndex = 3;
            // 
            // txtChoice
            // 
            this.txtChoice.Location = new System.Drawing.Point(12, 69);
            this.txtChoice.Name = "txtChoice";
            this.txtChoice.Size = new System.Drawing.Size(210, 20);
            this.txtChoice.TabIndex = 4;
            // 
            // lstChoices
            // 
            this.lstChoices.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lstChoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstChoices.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lstChoices.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lstChoices.FormattingEnabled = true;
            this.lstChoices.ItemHeight = 17;
            this.lstChoices.Location = new System.Drawing.Point(13, 137);
            this.lstChoices.Name = "lstChoices";
            this.lstChoices.Size = new System.Drawing.Size(227, 138);
            this.lstChoices.TabIndex = 5;
            // 
            // btnAddChoice
            // 
            this.btnAddChoice.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddChoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddChoice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddChoice.ForeColor = System.Drawing.Color.White;
            this.btnAddChoice.Location = new System.Drawing.Point(76, 100);
            this.btnAddChoice.Name = "btnAddChoice";
            this.btnAddChoice.Size = new System.Drawing.Size(91, 31);
            this.btnAddChoice.TabIndex = 6;
            this.btnAddChoice.Text = "Add Choice";
            this.btnAddChoice.UseVisualStyleBackColor = false;
            this.btnAddChoice.Click += new System.EventHandler(this.btnAddChoice_Click);
            // 
            // btnCreatePoll
            // 
            this.btnCreatePoll.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCreatePoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePoll.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCreatePoll.ForeColor = System.Drawing.Color.White;
            this.btnCreatePoll.Location = new System.Drawing.Point(76, 290);
            this.btnCreatePoll.Name = "btnCreatePoll";
            this.btnCreatePoll.Size = new System.Drawing.Size(97, 27);
            this.btnCreatePoll.TabIndex = 7;
            this.btnCreatePoll.Text = "Create Poll";
            this.btnCreatePoll.UseVisualStyleBackColor = false;
            this.btnCreatePoll.Click += new System.EventHandler(this.btnCreatePoll_Click);
            // 
            // cmbPolls
            // 
            this.cmbPolls.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPolls.FormattingEnabled = true;
            this.cmbPolls.Location = new System.Drawing.Point(617, 40);
            this.cmbPolls.Name = "cmbPolls";
            this.cmbPolls.Size = new System.Drawing.Size(152, 25);
            this.cmbPolls.TabIndex = 8;
            this.cmbPolls.SelectedIndexChanged += new System.EventHandler(this.cmbPolls_SelectedIndexChanged);
            // 
            // grpChoices
            // 
            this.grpChoices.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grpChoices.Location = new System.Drawing.Point(595, 101);
            this.grpChoices.Name = "grpChoices";
            this.grpChoices.Size = new System.Drawing.Size(193, 176);
            this.grpChoices.TabIndex = 9;
            this.grpChoices.TabStop = false;
            this.grpChoices.Enter += new System.EventHandler(this.grpChoices_Enter);
            // 
            // btnVote
            // 
            this.btnVote.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnVote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVote.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnVote.ForeColor = System.Drawing.Color.White;
            this.btnVote.Location = new System.Drawing.Point(644, 287);
            this.btnVote.Name = "btnVote";
            this.btnVote.Size = new System.Drawing.Size(95, 33);
            this.btnVote.TabIndex = 10;
            this.btnVote.Text = "Vote";
            this.btnVote.UseVisualStyleBackColor = false;
            this.btnVote.Click += new System.EventHandler(this.btnVote_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(263, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 37);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(91, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Polling System";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblResults.ForeColor = System.Drawing.Color.White;
            this.lblResults.Location = new System.Drawing.Point(111, 1);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(74, 25);
            this.lblResults.TabIndex = 13;
            this.lblResults.Text = "Results";
            this.lblResults.Click += new System.EventHandler(this.lblResults_Click);
            // 
            // pollResultsChart
            // 
            this.pollResultsChart.BackColor = System.Drawing.Color.Aqua;
            this.pollResultsChart.BorderlineColor = System.Drawing.Color.WhiteSmoke;
            chartArea5.Name = "ChartArea1";
            this.pollResultsChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.pollResultsChart.Legends.Add(legend5);
            this.pollResultsChart.Location = new System.Drawing.Point(263, 137);
            this.pollResultsChart.Name = "pollResultsChart";
            this.pollResultsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.pollResultsChart.Series.Add(series5);
            this.pollResultsChart.Size = new System.Drawing.Size(310, 140);
            this.pollResultsChart.TabIndex = 14;
            this.pollResultsChart.Text = "chart1";
            // 
            // btnResetResults
            // 
            this.btnResetResults.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnResetResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetResults.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetResults.ForeColor = System.Drawing.Color.White;
            this.btnResetResults.Location = new System.Drawing.Point(379, 290);
            this.btnResetResults.Name = "btnResetResults";
            this.btnResetResults.Size = new System.Drawing.Size(64, 32);
            this.btnResetResults.TabIndex = 15;
            this.btnResetResults.Text = "Reset Results";
            this.btnResetResults.UseVisualStyleBackColor = false;
            this.btnResetResults.Click += new System.EventHandler(this.btnResetResults_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.lblResults);
            this.panel2.Location = new System.Drawing.Point(263, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 31);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.lblCreatePoll);
            this.panel3.Location = new System.Drawing.Point(56, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(145, 34);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Controls.Add(this.lblPollQuestion);
            this.panel4.Location = new System.Drawing.Point(617, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(140, 34);
            this.panel4.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 347);
            this.Controls.Add(this.grpChoices);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnResetResults);
            this.Controls.Add(this.pollResultsChart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnVote);
            this.Controls.Add(this.cmbPolls);
            this.Controls.Add(this.btnCreatePoll);
            this.Controls.Add(this.btnAddChoice);
            this.Controls.Add(this.lstChoices);
            this.Controls.Add(this.txtChoice);
            this.Controls.Add(this.txtPollQuestion);
            this.Controls.Add(this.lblChoices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POLLING";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollResultsChart)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCreatePoll;
        private System.Windows.Forms.Label lblPollQuestion;
        private System.Windows.Forms.Label lblChoices;
        private System.Windows.Forms.TextBox txtPollQuestion;
        private System.Windows.Forms.TextBox txtChoice;
        private System.Windows.Forms.ListBox lstChoices;
        private System.Windows.Forms.Button btnAddChoice;
        private System.Windows.Forms.Button btnCreatePoll;
        private System.Windows.Forms.ComboBox cmbPolls;
        private System.Windows.Forms.GroupBox grpChoices;
        private System.Windows.Forms.Button btnVote;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.DataVisualization.Charting.Chart pollResultsChart;
        private System.Windows.Forms.Button btnResetResults;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}

