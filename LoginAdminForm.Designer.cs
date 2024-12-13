
namespace PollingSystem
{
    partial class LoginAdminForm
    {
  
        private System.ComponentModel.IContainer components = null;
        
        

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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnAdminLogin = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnResfresh = new System.Windows.Forms.Button();
            this.btnAddChoice = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(28, 76);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(152, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // btnAdminLogin
            // 
            this.btnAdminLogin.BackColor = System.Drawing.Color.Olive;
            this.btnAdminLogin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnAdminLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdminLogin.Location = new System.Drawing.Point(52, 102);
            this.btnAdminLogin.Name = "btnAdminLogin";
            this.btnAdminLogin.Size = new System.Drawing.Size(105, 32);
            this.btnAdminLogin.TabIndex = 1;
            this.btnAdminLogin.Text = "Admin Login";
            this.btnAdminLogin.UseVisualStyleBackColor = false;
            this.btnAdminLogin.Click += new System.EventHandler(this.btnAdminLogin_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvUsers.Location = new System.Drawing.Point(19, 140);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(429, 150);
            this.dgvUsers.TabIndex = 2;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVotesLog_CellContentClick);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(233, 76);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(148, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.Olive;
            this.btnDeleteUser.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnDeleteUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteUser.Location = new System.Drawing.Point(246, 102);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(113, 32);
            this.btnDeleteUser.TabIndex = 4;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnResfresh
            // 
            this.btnResfresh.BackColor = System.Drawing.Color.Olive;
            this.btnResfresh.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnResfresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnResfresh.Location = new System.Drawing.Point(153, 322);
            this.btnResfresh.Name = "btnResfresh";
            this.btnResfresh.Size = new System.Drawing.Size(100, 52);
            this.btnResfresh.TabIndex = 5;
            this.btnResfresh.Text = "Refresh";
            this.btnResfresh.UseVisualStyleBackColor = false;
            this.btnResfresh.Click += new System.EventHandler(this.btnResfresh_Click);
            // 
            // btnAddChoice
            // 
            this.btnAddChoice.BackColor = System.Drawing.Color.Gray;
            this.btnAddChoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddChoice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddChoice.ForeColor = System.Drawing.Color.White;
            this.btnAddChoice.Location = new System.Drawing.Point(52, 38);
            this.btnAddChoice.Name = "btnAddChoice";
            this.btnAddChoice.Size = new System.Drawing.Size(105, 31);
            this.btnAddChoice.TabIndex = 8;
            this.btnAddChoice.Text = "Username";
            this.btnAddChoice.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(254, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 31);
            this.button1.TabIndex = 9;
            this.button1.Text = "Password";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // LoginAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(800, 506);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddChoice);
            this.Controls.Add(this.btnResfresh);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnAdminLogin);
            this.Controls.Add(this.txtUsername);
            this.Name = "LoginAdminForm";
            this.Text = "LoginAdminForm";
            this.Load += new System.EventHandler(this.LoginAdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnAdminLogin;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnResfresh;
        private System.Windows.Forms.Button btnAddChoice;
        private System.Windows.Forms.Button button1;
    }
}