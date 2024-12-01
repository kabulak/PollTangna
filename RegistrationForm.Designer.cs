namespace PollingSystem
{
    partial class RegistrationForm
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
            this.lblNewPass = new System.Windows.Forms.Label();
            this.lblNewUser = new System.Windows.Forms.Label();
            this.btnRegisterSubmit = new System.Windows.Forms.Button();
            this.lblRegErrorMessage = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtNewUsername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Location = new System.Drawing.Point(12, 49);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(56, 13);
            this.lblNewPass.TabIndex = 17;
            this.lblNewPass.Text = "Password:";
            // 
            // lblNewUser
            // 
            this.lblNewUser.AutoSize = true;
            this.lblNewUser.Location = new System.Drawing.Point(12, 19);
            this.lblNewUser.Name = "lblNewUser";
            this.lblNewUser.Size = new System.Drawing.Size(58, 13);
            this.lblNewUser.TabIndex = 16;
            this.lblNewUser.Text = "Username:";
            // 
            // btnRegisterSubmit
            // 
            this.btnRegisterSubmit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRegisterSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterSubmit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRegisterSubmit.ForeColor = System.Drawing.Color.White;
            this.btnRegisterSubmit.Location = new System.Drawing.Point(85, 80);
            this.btnRegisterSubmit.Name = "btnRegisterSubmit";
            this.btnRegisterSubmit.Size = new System.Drawing.Size(78, 30);
            this.btnRegisterSubmit.TabIndex = 15;
            this.btnRegisterSubmit.Text = "Register";
            this.btnRegisterSubmit.UseVisualStyleBackColor = false;
            this.btnRegisterSubmit.Click += new System.EventHandler(this.btnRegisterSubmit_Click);
            // 
            // lblRegErrorMessage
            // 
            this.lblRegErrorMessage.AutoSize = true;
            this.lblRegErrorMessage.Location = new System.Drawing.Point(167, 126);
            this.lblRegErrorMessage.Name = "lblRegErrorMessage";
            this.lblRegErrorMessage.Size = new System.Drawing.Size(13, 13);
            this.lblRegErrorMessage.TabIndex = 14;
            this.lblRegErrorMessage.Text = "  ";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(85, 42);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(211, 20);
            this.txtNewPassword.TabIndex = 12;
            // 
            // txtNewUsername
            // 
            this.txtNewUsername.Location = new System.Drawing.Point(85, 12);
            this.txtNewUsername.Name = "txtNewUsername";
            this.txtNewUsername.Size = new System.Drawing.Size(211, 20);
            this.txtNewUsername.TabIndex = 11;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(416, 151);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.lblNewUser);
            this.Controls.Add(this.btnRegisterSubmit);
            this.Controls.Add(this.lblRegErrorMessage);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtNewUsername);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.Label lblNewUser;
        private System.Windows.Forms.Button btnRegisterSubmit;
        private System.Windows.Forms.Label lblRegErrorMessage;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtNewUsername;
    }
}