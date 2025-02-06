namespace WGUC969
{
    partial class Reports
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
            btnReport3 = new MaterialButton();
            btnReport2 = new MaterialButton();
            btnReport1 = new MaterialButton();
            dgvReports = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            SuspendLayout();
            // 
            // btnReport3
            // 
            btnReport3.BackColor = Color.FromArgb(98, 0, 248);
            btnReport3.FlatAppearance.BorderSize = 0;
            btnReport3.FlatStyle = FlatStyle.Flat;
            btnReport3.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnReport3.ForeColor = Color.White;
            btnReport3.Location = new Point(562, 56);
            btnReport3.Name = "btnReport3";
            btnReport3.Size = new Size(120, 29);
            btnReport3.TabIndex = 9;
            btnReport3.Text = "Appt / Cust";
            btnReport3.UseVisualStyleBackColor = false;
            btnReport3.Click += btnReport3_Click;
            // 
            // btnReport2
            // 
            btnReport2.BackColor = Color.FromArgb(98, 0, 248);
            btnReport2.FlatAppearance.BorderSize = 0;
            btnReport2.FlatStyle = FlatStyle.Flat;
            btnReport2.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnReport2.ForeColor = Color.White;
            btnReport2.Location = new Point(386, 56);
            btnReport2.Name = "btnReport2";
            btnReport2.Size = new Size(120, 29);
            btnReport2.TabIndex = 8;
            btnReport2.Text = "User Schedule";
            btnReport2.UseVisualStyleBackColor = false;
            btnReport2.Click += btnReport2_Click;
            // 
            // btnReport1
            // 
            btnReport1.BackColor = Color.FromArgb(98, 0, 248);
            btnReport1.FlatAppearance.BorderSize = 0;
            btnReport1.FlatStyle = FlatStyle.Flat;
            btnReport1.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnReport1.ForeColor = Color.White;
            btnReport1.Location = new Point(211, 56);
            btnReport1.Name = "btnReport1";
            btnReport1.Size = new Size(110, 29);
            btnReport1.TabIndex = 7;
            btnReport1.Text = "Appt / Month";
            btnReport1.UseVisualStyleBackColor = false;
            btnReport1.Click += btnReport1_Click;
            // 
            // dgvReports
            // 
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(72, 209);
            dgvReports.Name = "dgvReports";
            dgvReports.RowHeadersWidth = 51;
            dgvReports.Size = new Size(1295, 527);
            dgvReports.TabIndex = 6;
            // 
            // Reports
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1439, 806);
            Controls.Add(btnReport3);
            Controls.Add(btnReport2);
            Controls.Add(btnReport1);
            Controls.Add(dgvReports);
            Name = "Reports";
            Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialButton btnReport3;
        private MaterialButton btnReport2;
        private MaterialButton btnReport1;
        private DataGridView dgvReports;
    }
}