namespace WGUC969
{
    partial class Login
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
            lblLocale = new Label();
            lblRegion = new Label();
            lblUser = new Label();
            lblPass = new Label();
            lblWelcome = new Label();
            tbxUser = new TextBox();
            tbxPass = new TextBox();
            btnLogin = new MaterialButton();
            btnExit = new MaterialButton();
            lblWarning = new Label();
            SuspendLayout();
            // 
            // lblLocale
            // 
            lblLocale.AutoSize = true;
            lblLocale.Location = new Point(226, 493);
            lblLocale.Name = "lblLocale";
            lblLocale.Size = new Size(66, 20);
            lblLocale.TabIndex = 0;
            lblLocale.Text = "lbllocale";
            // 
            // lblRegion
            // 
            lblRegion.AutoSize = true;
            lblRegion.Location = new Point(353, 493);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new Size(50, 20);
            lblRegion.TabIndex = 1;
            lblRegion.Text = "label1";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUser.Location = new Point(128, 194);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(92, 20);
            lblUser.TabIndex = 2;
            lblUser.Text = "Username:";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPass.Location = new Point(129, 278);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(91, 20);
            lblPass.TabIndex = 3;
            lblPass.Text = "Password:";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Playfair Display", 28.1999989F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(169, 75);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(220, 66);
            lblWelcome.TabIndex = 4;
            lblWelcome.Text = "Welcome";
            // 
            // tbxUser
            // 
            tbxUser.Location = new Point(226, 187);
            tbxUser.Name = "tbxUser";
            tbxUser.Size = new Size(208, 27);
            tbxUser.TabIndex = 5;
            // 
            // tbxPass
            // 
            tbxPass.Location = new Point(226, 271);
            tbxPass.Name = "tbxPass";
            tbxPass.Size = new Size(209, 27);
            tbxPass.TabIndex = 6;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(98, 0, 248);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(141, 383);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(98, 0, 248);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(275, 383);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 9;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWarning.ForeColor = Color.Red;
            lblWarning.Location = new Point(101, 339);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(0, 18);
            lblWarning.TabIndex = 10;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(590, 522);
            Controls.Add(lblWarning);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(tbxPass);
            Controls.Add(tbxUser);
            Controls.Add(lblWelcome);
            Controls.Add(lblPass);
            Controls.Add(lblUser);
            Controls.Add(lblRegion);
            Controls.Add(lblLocale);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLocale;
        private Label lblRegion;
        private Label lblUser;
        private Label lblPass;
        private Label lblWelcome;
        private TextBox tbxUser;
        private TextBox tbxPass;
        private MaterialButton btnLogin;
        private MaterialButton btnExit;
        private Label lblWarning;
    }
}