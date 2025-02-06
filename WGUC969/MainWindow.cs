using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WGUC969
{
    public partial class MainWindow : Form
    {
        private int childFormNumber = 0;
        private System.Windows.Forms.Timer alertTimer;
        private List<DateTime> appointments;
        private string connectionString = "Server=localhost;Database=client_schedule;User Id=sqlUser;Password=Passw0rd!";


        string currentUser;

        public MainWindow(string username)
        {
            InitializeComponent();
            InitializeClock();

            //set the current app user
            currentUser = username;

            // Load appointments from the database
            appointments = LoadAppointments();

            // Initialize the timer to check every minute
            alertTimer = new System.Windows.Forms.Timer { Interval = 15000 }; // 1 minute
            alertTimer.Tick += AlertTimer_Tick;
            alertTimer.Start();


        }


        private void AlertTimer_Tick(object sender, EventArgs e)
        {
    

            DateTime now = DateTime.Now; // Local system time
            var upcomingAppointments = appointments
                .Where(appt => appt > now && appt <= now.AddMinutes(15)) // Compare in local time
                .ToList();
     
            foreach (var appt in upcomingAppointments)
            {
                MessageBox.Show($"You have an appointment at {appt:hh:mm tt}.",
                                "Upcoming Appointment",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Prevent duplicate alerts
                appointments.Remove(appt);
            }
        }


        private List<DateTime> LoadAppointments()
        {
            List<DateTime> appointmentList = new List<DateTime>();
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local; // Get the local time zone

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                SELECT start 
                FROM appointment
                WHERE start >= @Now AND start <= @NextHour"; // Fetch appointments for the next hour

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Now", DateTime.UtcNow); // Querying UTC range
                        command.Parameters.AddWithValue("@NextHour", DateTime.UtcNow.AddMinutes(60));

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime utcStart = reader.GetDateTime("start"); // Read UTC time from DB
                                DateTime localStart = TimeZoneInfo.ConvertTimeFromUtc(utcStart, localTimeZone); // Convert to local time
                                appointmentList.Add(localStart);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading appointments: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return appointmentList;
        }








        private void customerRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm is CustomerRecords)
                {
                    childForm.Activate();
                    return;
                }
            }

            CustomerRecords customerRecords = new CustomerRecords(currentUser);
            {
                customerRecords.MdiParent = this;
            };
            customerRecords.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void appointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is Appointments)
                {
                    openForm.BringToFront();
                    return;
                }
            }
            // If not open, create a new instance and show it
            Appointments appointments = new Appointments(currentUser);
            appointments.MdiParent = this;
            appointments.Show();
        }

        private void calendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is Calendar)
                {
                    openForm.BringToFront();
                    return;
                }
            }

            // If not open, create a new instance and show it
            Calendar calendar = new Calendar();
            calendar.MdiParent = this;
            calendar.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is Reports)
                {
                    openForm.BringToFront();
                    return;
                }
            }

            // If not open, create a new instance and show it
            Reports reports = new Reports();
            reports.MdiParent = this;
            reports.Show();
        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void InitializeClock()
        {
            // Create a StatusStrip
            StatusStrip statusStrip = new StatusStrip();
            this.Controls.Add(statusStrip);
            statusStrip.Dock = DockStyle.Bottom;

            // Create a ToolStripStatusLabel to show time
            ToolStripStatusLabel timeLabel = new ToolStripStatusLabel();
            statusStrip.Items.Add(timeLabel);

            // Create a Timer
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += (s, e) =>
            {
                timeLabel.Text ="Time: " +  DateTime.Now.ToString("HH:mm:ss") + "   " +  DateTime.Now.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern); ;  
            };

            // Start the timer
            timer.Start();
        }
    }
}
