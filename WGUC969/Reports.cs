using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WGUC969
{
    public partial class Reports : Form
    {
        string connectionString = "Server=localhost;Database=client_schedule;User Id=sqlUser;Password=Passw0rd!";
        public class Appointment
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public string Type { get; set; }
            public string UserName { get; set; }
            public string CustomerName { get; set; }
            public string Title { get; set; }
        }


        public Reports()
        {
            InitializeComponent();
        }

        private List<Appointment> GetAppointments()
        {
            string query = @"
        SELECT 
            a.start, 
            a.end, 
            a.type, 
            u.userName, 
            c.customerName, 
            a.title
        FROM appointment a
        LEFT JOIN user u ON a.userId = u.userId
        LEFT JOIN customer c ON a.customerId = c.customerId";

            DataTable dataTable = ExecuteQuery(query);
            var appointments = new List<Appointment>();

            foreach (DataRow row in dataTable.Rows)
            {
                appointments.Add(new Appointment
                {
                    Start = Convert.ToDateTime(row["start"]),
                    End = Convert.ToDateTime(row["end"]),
                    Type = row["type"].ToString(),
                    UserName = row["userName"].ToString(),
                    CustomerName = row["customerName"].ToString(),
                    Title = row["title"].ToString(),
                });
            }

            return appointments;
        }

        private void btnReport1_Click(object sender, EventArgs e)
        {

            var appointments = GetAppointments();

            var report = appointments
                .GroupBy(a => new { Month = a.Start.ToString("yyyy-MM"), a.Type })
                .Select(group => new
                {
                    Month = group.Key.Month,
                    AppointmentType = group.Key.Type,
                    Count = group.Count()
                })
                .OrderBy(r => r.Month)
                .ThenBy(r => r.AppointmentType)
                .ToList();

            dgvReports.DataSource = report;
        }

        private void btnReport2_Click(object sender, EventArgs e)
        {
            var appointments = GetAppointments();

            var report = appointments
                .GroupBy(a => a.UserName)
                .Select(group => new
                {
                    User = group.Key,
                    Schedule = group.Select(a => new
                    {
                        a.Title,
                        StartTime = a.Start,
                        EndTime = a.End
                    }).OrderBy(a => a.StartTime).ToList()
                })
                .ToList();

            // Flatten the result for DataGridView
            var flattenedReport = report.SelectMany(r => r.Schedule, (r, schedule) => new
            {
                r.User,
                schedule.Title,
                schedule.StartTime,
                schedule.EndTime
            }).ToList();

            dgvReports.DataSource = flattenedReport;
        }

        private void btnReport3_Click(object sender, EventArgs e)
        {
            var appointments = GetAppointments();

            var report = appointments
                .GroupBy(a => a.CustomerName)
                .Select(group => new
                {
                    Customer = group.Key,
                    AppointmentCount = group.Count()
                })
                .OrderByDescending(r => r.AppointmentCount)
                .ToList();

            dgvReports.DataSource = report;
        }
        private DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing query: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }
    }
}
