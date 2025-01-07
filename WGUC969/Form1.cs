using System.Windows.Forms;

namespace WGUC969
{
    public partial class Form1 : Form
    {
        int monthDisplayCount = 0;
        public Form1()
        {
            InitializeComponent();
            dgvCalendar.RowTemplate.Height = 50;

            PopulateCalendar(dgvCalendar);


        }


        private void PopulateCalendar(DataGridView dgv)
        {
            // Clear existing rows
            dgv.Rows.Clear();

            // Ensure columns represent the days of the week
            string[] daysOfWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            dgv.ColumnCount = daysOfWeek.Length;

            for (int i = 0; i < daysOfWeek.Length; i++)
            {
                dgv.Columns[i].Name = daysOfWeek[i];
            }

            // Get the first and last day of the month
            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            firstDayOfMonth = firstDayOfMonth.AddMonths(monthDisplayCount);
            lblMonth.Text = firstDayOfMonth.ToString("MMMM");
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // Start day of the week
            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            // Total days in the month
            int totalDays = lastDayOfMonth.Day;

            // Fill rows with dates
            int currentDay = 1;
            while (currentDay <= totalDays)
            {
                // Create a new row
                object[] weekRow = new object[7];

                // Populate the row
                for (int i = 0; i < 7; i++)
                {
                    if (currentDay <= totalDays && (currentDay == 1 && i >= startDayOfWeek || currentDay > 1))
                    {
                        weekRow[i] = currentDay.ToString();
                        currentDay++;
                    }
                    else
                    {
                        weekRow[i] = ""; // Empty cell for non-calendar dates
                    }
                }

                // Add row to the DataGridView
                dgv.Rows.Add(weekRow);
            }
        }

        private void dgvCalendar_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            monthDisplayCount--;
            PopulateCalendar(dgvCalendar);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            monthDisplayCount++;
            PopulateCalendar(dgvCalendar);
        }
    }
}
