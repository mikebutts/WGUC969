using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WGUC969
{
    public partial class Calendar : Form
    {
        int monthDisplayCount = 0;

        string connectionString = "Server=localhost;Database=client_schedule;User Id=sqlUser;Password=Passw0rd!";

        public Calendar()
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
            lblMonth.Text = firstDayOfMonth.ToString("MMMM yyyy");
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // Start day of the week
            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            // Total days in the month
            int totalDays = lastDayOfMonth.Day;

            // Fetch appointments from the database
            Dictionary<DateTime, List<string>> appointments = FetchAppointments(firstDayOfMonth, lastDayOfMonth);

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
                        DateTime currentDate = firstDayOfMonth.AddDays(currentDay - 1);

                        if (appointments.ContainsKey(currentDate))
                        {
                            weekRow[i] = currentDay.ToString() + " *"; // Add an asterisk to denote an appointment
                        }
                        else
                        {
                            weekRow[i] = currentDay.ToString();
                        }

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

            // Highlight dates with appointments
            HighlightAppointments(dgv, firstDayOfMonth, appointments);
        }

        private Dictionary<DateTime, List<string>> FetchAppointments(DateTime startDate, DateTime endDate)
        {
            var appointments = new Dictionary<DateTime, List<string>>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT appointmentId, title, start 
                        FROM appointment 
                        WHERE start >= @StartDate AND start <= @EndDate";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate.ToUniversalTime());
                        command.Parameters.AddWithValue("@EndDate", endDate.ToUniversalTime());

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime appointmentDate = reader.GetDateTime("start").ToLocalTime();
                                string title = reader.GetString("title");

                                if (!appointments.ContainsKey(appointmentDate.Date))
                                {
                                    appointments[appointmentDate.Date] = new List<string>();
                                }

                                appointments[appointmentDate.Date].Add(title);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching appointments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return appointments;
        }

        private void HighlightAppointments(DataGridView dgv, DateTime firstDayOfMonth, Dictionary<DateTime, List<string>> appointments)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int col = 0; col < dgv.ColumnCount; col++)
                {
                    if (int.TryParse(row.Cells[col].Value?.ToString()?.TrimEnd('*'), out int day))
                    {
                        DateTime date = firstDayOfMonth.AddDays(day - 1);

                        if (appointments.ContainsKey(date))
                        {
                            row.Cells[col].Style.BackColor = Color.LightBlue; // Highlight cell
                            row.Cells[col].ToolTipText = string.Join(", ", appointments[date]); // Show appointment details in a tooltip
                        }
                    }
                }
            }
        }

        private void dgvCalendar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cellValue = dgvCalendar.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()?.TrimEnd('*');
                if (int.TryParse(cellValue, out int day))
                {
                    DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(monthDisplayCount);
                    DateTime selectedDate = firstDayOfMonth.AddDays(day - 1);
                    DateTime endOfDay = selectedDate.AddDays(1).AddTicks(-1);
                    

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            string query = @"
                                SELECT title, type, start, end 
                                FROM appointment 
                                WHERE start >= @SelectedDate AND start <= @endOfDay";

                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@SelectedDate", selectedDate.ToUniversalTime()); // Convert date to UTC for quer
                                command.Parameters.AddWithValue("@endOfDay", endOfDay.ToUniversalTime());

                                using (MySqlDataReader reader = command.ExecuteReader())
                                { 
                                    if (reader.HasRows)
                                    {
                                        string message = $"Appointments on {selectedDate:MMMM dd, yyyy}:\n";

                                        while (reader.Read())
                                        {
                                            string title = reader.GetString("title");
                                            string type = reader.GetString("type");
                                            DateTime start = reader.GetDateTime("start").ToLocalTime();
                                            DateTime end = reader.GetDateTime("end").ToLocalTime();

                                            message += $"\n- {type}: {start:hh:mm tt} - {end:hh:mm tt}\n  {title}";
                                        }

                                        MessageBox.Show(message, $"Appointments on {selectedDate:MMMM dd, yyyy}");
                                    }
                                    else
                                    {
                                        MessageBox.Show("No appointments on this date.", $"Appointments on {selectedDate:MMMM dd, yyyy}");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error fetching appointment details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
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
