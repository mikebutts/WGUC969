namespace WGUC969
{
    partial class Appointments
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
            btnDelete = new MaterialButton();
            btnUpdate = new MaterialButton();
            btnAdd = new MaterialButton();
            dgvApp = new DataGridView();
            lblWelcome = new Label();
            lblCustomerName = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvApp).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(98, 0, 248);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(274, 420);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 31);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(98, 0, 248);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(174, 420);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 31);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(98, 0, 248);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(74, 420);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 31);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvApp
            // 
            dgvApp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApp.Location = new Point(74, 75);
            dgvApp.Name = "dgvApp";
            dgvApp.RowHeadersWidth = 51;
            dgvApp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApp.Size = new Size(1268, 334);
            dgvApp.TabIndex = 11;
            dgvApp.CellClick += dgvApp_CellClick;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Playfair Display", 28.1999989F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(421, 8);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(329, 66);
            lblWelcome.TabIndex = 10;
            lblWelcome.Text = "Appointments";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Roboto", 10.2F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblCustomerName.ForeColor = Color.RoyalBlue;
            lblCustomerName.Location = new Point(808, 460);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(0, 20);
            lblCustomerName.TabIndex = 15;
            lblCustomerName.Click += lblCustomerName_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(808, 420);
            label1.Name = "label1";
            label1.Size = new Size(247, 20);
            label1.TabIndex = 16;
            label1.Text = "Click to view customer info:";
            label1.Click += label1_Click;
            // 
            // Appointments
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1412, 604);
            Controls.Add(label1);
            Controls.Add(lblCustomerName);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(dgvApp);
            Controls.Add(lblWelcome);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            Name = "Appointments";
            Text = "Appointments";
            Load += Appointments_Load;
            ((System.ComponentModel.ISupportInitialize)dgvApp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialButton btnDelete;
        private MaterialButton btnUpdate;
        private MaterialButton btnAdd;
        private DataGridView dgvApp;
        private Label lblWelcome;
        private Label lblCustomerName;
        private Label label1;
    }
}