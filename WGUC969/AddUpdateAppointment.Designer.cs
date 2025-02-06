namespace WGUC969
{
    partial class AddUpdateAppointment
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
            txtUrl = new TextBox();
            label8 = new Label();
            txtType = new TextBox();
            label7 = new Label();
            txtCon = new TextBox();
            label6 = new Label();
            txtLoc = new TextBox();
            label5 = new Label();
            btnCancel = new MaterialButton();
            btnSubmit = new MaterialButton();
            lblTitle = new Label();
            txtDesc = new TextBox();
            txtTitle = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBoxCustomers = new ComboBox();
            label9 = new Label();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(185, 322);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(244, 27);
            txtUrl.TabIndex = 33;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(47, 329);
            label8.Name = "label8";
            label8.Size = new Size(45, 20);
            label8.TabIndex = 32;
            label8.Text = "URL:";
            // 
            // txtType
            // 
            txtType.Location = new Point(185, 289);
            txtType.Name = "txtType";
            txtType.Size = new Size(244, 27);
            txtType.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(47, 296);
            label7.Name = "label7";
            label7.Size = new Size(52, 20);
            label7.TabIndex = 30;
            label7.Text = "Type:";
            // 
            // txtCon
            // 
            txtCon.Location = new Point(185, 256);
            txtCon.Name = "txtCon";
            txtCon.Size = new Size(244, 27);
            txtCon.TabIndex = 29;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(47, 263);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 28;
            label6.Text = "Contact:";
            // 
            // txtLoc
            // 
            txtLoc.Location = new Point(185, 223);
            txtLoc.Name = "txtLoc";
            txtLoc.Size = new Size(244, 27);
            txtLoc.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(47, 230);
            label5.Name = "label5";
            label5.Size = new Size(82, 20);
            label5.TabIndex = 26;
            label5.Text = "Location:";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(98, 0, 248);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(239, 455);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(98, 0, 248);
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(110, 455);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 24;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.White;
            lblTitle.Font = new Font("Playfair Display", 28.1999989F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(42, 34);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(402, 66);
            lblTitle.TabIndex = 23;
            lblTitle.Text = "Add Appointment";
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(185, 190);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(244, 27);
            txtDesc.TabIndex = 22;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(185, 157);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(244, 27);
            txtTitle.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(47, 197);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 18;
            label2.Text = "Description:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 164);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 17;
            label1.Text = "Title:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(44, 396);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 36;
            label3.Text = "End Time:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(47, 365);
            label4.Name = "label4";
            label4.Size = new Size(95, 20);
            label4.TabIndex = 37;
            label4.Text = "Start Time:";
            // 
            // comboBoxCustomers
            // 
            comboBoxCustomers.FormattingEnabled = true;
            comboBoxCustomers.Location = new Point(185, 123);
            comboBoxCustomers.Name = "comboBoxCustomers";
            comboBoxCustomers.Size = new Size(244, 28);
            comboBoxCustomers.TabIndex = 38;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(42, 131);
            label9.Name = "label9";
            label9.Size = new Size(90, 20);
            label9.TabIndex = 39;
            label9.Text = "Customer:";
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(185, 358);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(244, 27);
            dtpStart.TabIndex = 40;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(185, 391);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(244, 27);
            dtpEnd.TabIndex = 41;
            // 
            // AddUpdateAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 523);
            Controls.Add(dtpEnd);
            Controls.Add(dtpStart);
            Controls.Add(label9);
            Controls.Add(comboBoxCustomers);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtUrl);
            Controls.Add(label8);
            Controls.Add(txtType);
            Controls.Add(label7);
            Controls.Add(txtCon);
            Controls.Add(label6);
            Controls.Add(txtLoc);
            Controls.Add(label5);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(lblTitle);
            Controls.Add(txtDesc);
            Controls.Add(txtTitle);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddUpdateAppointment";
            Text = "AddUpdateAppointment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUrl;
        private Label label8;
        private TextBox txtType;
        private Label label7;
        private TextBox txtCon;
        private Label label6;
        private TextBox txtLoc;
        private Label label5;
        private MaterialButton btnCancel;
        private MaterialButton btnSubmit;
        private Label lblTitle;
        private TextBox txtDesc;
        private TextBox txtTitle;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxCustomers;
        private Label label9;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
    }
}