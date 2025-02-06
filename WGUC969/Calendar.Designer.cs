namespace WGUC969
{
    partial class Calendar
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvCalendar = new DataGridView();
            Sunday = new DataGridViewTextBoxColumn();
            Monday = new DataGridViewTextBoxColumn();
            Tuesday = new DataGridViewTextBoxColumn();
            Wednesday = new DataGridViewTextBoxColumn();
            Thursday = new DataGridViewTextBoxColumn();
            Friday = new DataGridViewTextBoxColumn();
            Saturday = new DataGridViewTextBoxColumn();
            lblMonth = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCalendar).BeginInit();
            SuspendLayout();
            // 
            // dgvCalendar
            // 
            dgvCalendar.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvCalendar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCalendar.Columns.AddRange(new DataGridViewColumn[] { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday });
            dgvCalendar.Location = new Point(49, 76);
            dgvCalendar.Name = "dgvCalendar";
            dgvCalendar.RowHeadersWidth = 51;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvCalendar.RowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCalendar.Size = new Size(928, 330);
            dgvCalendar.TabIndex = 0;
            dgvCalendar.CellClick += dgvCalendar_CellClick;
            // 
            // Sunday
            // 
            Sunday.HeaderText = "Sunday";
            Sunday.MinimumWidth = 6;
            Sunday.Name = "Sunday";
            Sunday.Width = 125;
            // 
            // Monday
            // 
            Monday.HeaderText = "Monday";
            Monday.MinimumWidth = 6;
            Monday.Name = "Monday";
            Monday.Width = 125;
            // 
            // Tuesday
            // 
            Tuesday.HeaderText = "Tuesday";
            Tuesday.MinimumWidth = 6;
            Tuesday.Name = "Tuesday";
            Tuesday.Width = 125;
            // 
            // Wednesday
            // 
            Wednesday.HeaderText = "Wednesday";
            Wednesday.MinimumWidth = 6;
            Wednesday.Name = "Wednesday";
            Wednesday.Width = 125;
            // 
            // Thursday
            // 
            Thursday.HeaderText = "Thursday";
            Thursday.MinimumWidth = 6;
            Thursday.Name = "Thursday";
            Thursday.Width = 125;
            // 
            // Friday
            // 
            Friday.HeaderText = "Friday";
            Friday.MinimumWidth = 6;
            Friday.Name = "Friday";
            Friday.Width = 125;
            // 
            // Saturday
            // 
            Saturday.HeaderText = "Saturday";
            Saturday.MinimumWidth = 6;
            Saturday.Name = "Saturday";
            Saturday.Width = 125;
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Font = new Font("Playfair Display", 19.8000011F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblMonth.Location = new Point(371, 7);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(120, 48);
            lblMonth.TabIndex = 1;
            lblMonth.Text = "Month";
            // 
            // btnNext
            // 
            btnNext.Location = new Point(630, 22);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(51, 35);
            btnNext.TabIndex = 2;
            btnNext.Text = "->";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(208, 22);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(51, 35);
            btnPrev.TabIndex = 3;
            btnPrev.Text = "<-";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // Calendar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 703);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
            Controls.Add(lblMonth);
            Controls.Add(dgvCalendar);
            Name = "Calendar";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvCalendar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCalendar;
        private DataGridViewTextBoxColumn Sunday;
        private DataGridViewTextBoxColumn Monday;
        private DataGridViewTextBoxColumn Tuesday;
        private DataGridViewTextBoxColumn Wednesday;
        private DataGridViewTextBoxColumn Thursday;
        private DataGridViewTextBoxColumn Friday;
        private DataGridViewTextBoxColumn Saturday;
        private Label lblMonth;
        private Button btnNext;
        private Button btnPrev;
    }
}
