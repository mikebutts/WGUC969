namespace WGUC969
{
    partial class AddUpdateCustomer
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            lblTitle = new Label();
            btnSubmit = new MaterialButton();
            btnCancel = new MaterialButton();
            txtAddress2 = new TextBox();
            label5 = new Label();
            txtCity = new TextBox();
            label6 = new Label();
            txtZip = new TextBox();
            label7 = new Label();
            txtCountry = new TextBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 164);
            label1.Name = "label1";
            label1.Size = new Size(139, 20);
            label1.TabIndex = 0;
            label1.Text = "Customer Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(47, 197);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 1;
            label2.Text = "Address:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(40, 362);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 2;
            label3.Text = "Phone Number:";
            // 
            // txtName
            // 
            txtName.Location = new Point(185, 157);
            txtName.Name = "txtName";
            txtName.Size = new Size(244, 27);
            txtName.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(185, 355);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(244, 27);
            txtPhone.TabIndex = 4;
            txtPhone.KeyPress += txtPhone_KeyPress_1;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(185, 190);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(244, 27);
            txtAddress.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Playfair Display", 28.1999989F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(63, 34);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(334, 66);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Add Customer";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(98, 0, 248);
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(85, 423);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(98, 0, 248);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(232, 423);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtAddress2
            // 
            txtAddress2.Location = new Point(185, 223);
            txtAddress2.Name = "txtAddress2";
            txtAddress2.Size = new Size(244, 27);
            txtAddress2.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(47, 230);
            label5.Name = "label5";
            label5.Size = new Size(92, 20);
            label5.TabIndex = 9;
            label5.Text = "Address 2:";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(185, 256);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(244, 27);
            txtCity.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(47, 263);
            label6.Name = "label6";
            label6.Size = new Size(45, 20);
            label6.TabIndex = 11;
            label6.Text = "City:";
            // 
            // txtZip
            // 
            txtZip.Location = new Point(185, 289);
            txtZip.Name = "txtZip";
            txtZip.Size = new Size(244, 27);
            txtZip.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(47, 296);
            label7.Name = "label7";
            label7.Size = new Size(83, 20);
            label7.TabIndex = 13;
            label7.Text = "Zip Code:";
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(185, 322);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(244, 27);
            txtCountry.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(47, 329);
            label8.Name = "label8";
            label8.Size = new Size(76, 20);
            label8.TabIndex = 15;
            label8.Text = "Country:";
            // 
            // AddUpdateCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(477, 519);
            Controls.Add(txtCountry);
            Controls.Add(label8);
            Controls.Add(txtZip);
            Controls.Add(label7);
            Controls.Add(txtCity);
            Controls.Add(label6);
            Controls.Add(txtAddress2);
            Controls.Add(label5);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(lblTitle);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddUpdateCustomer";
            Text = "AddUpdateCustomer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private Label lblTitle;
        private MaterialButton btnSubmit;
        private MaterialButton btnCancel;
        private TextBox txtAddress2;
        private Label label5;
        private TextBox txtCity;
        private Label label6;
        private TextBox txtZip;
        private Label label7;
        private TextBox txtCountry;
        private Label label8;
    }
}