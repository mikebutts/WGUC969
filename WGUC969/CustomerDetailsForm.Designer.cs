namespace WGUC969
{
    partial class CustomerDetailsForm
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
            lblName = new Label();
            lblAddress = new Label();
            lblAddress2 = new Label();
            lblPostal = new Label();
            lblPhone = new Label();
            lblCountry = new Label();
            lblCity = new Label();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Playfair Display", 28.1999989F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblName.Location = new Point(36, 27);
            lblName.Name = "lblName";
            lblName.Size = new Size(0, 66);
            lblName.TabIndex = 0;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddress.Location = new Point(36, 125);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(57, 20);
            lblAddress.TabIndex = 1;
            lblAddress.Text = "label1";
            // 
            // lblAddress2
            // 
            lblAddress2.AutoSize = true;
            lblAddress2.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddress2.Location = new Point(36, 155);
            lblAddress2.Name = "lblAddress2";
            lblAddress2.Size = new Size(0, 20);
            lblAddress2.TabIndex = 2;
            // 
            // lblPostal
            // 
            lblPostal.AutoSize = true;
            lblPostal.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPostal.Location = new Point(36, 188);
            lblPostal.Name = "lblPostal";
            lblPostal.Size = new Size(57, 20);
            lblPostal.TabIndex = 3;
            lblPostal.Text = "label1";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhone.Location = new Point(36, 252);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(57, 20);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "label1";
            // 
            // lblCountry
            // 
            lblCountry.AutoSize = true;
            lblCountry.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCountry.Location = new Point(36, 217);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(57, 20);
            lblCountry.TabIndex = 5;
            lblCountry.Text = "label4";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCity.Location = new Point(36, 155);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(57, 20);
            lblCity.TabIndex = 4;
            lblCity.Text = "label1";
            // 
            // CustomerDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(477, 519);
            Controls.Add(lblPhone);
            Controls.Add(lblCountry);
            Controls.Add(lblCity);
            Controls.Add(lblPostal);
            Controls.Add(lblAddress2);
            Controls.Add(lblAddress);
            Controls.Add(lblName);
            Name = "CustomerDetailsForm";
            Text = "CustomerDetailsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblAddress;
        private Label lblAddress2;
        private Label lblPostal;
        private Label lblPhone;
        private Label lblCountry;
        private Label lblCity;
    }
}