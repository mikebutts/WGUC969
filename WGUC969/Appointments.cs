using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace WGUC969
{
    public partial class Appointments : Form
    {
        string currentUser;
        int customerId;
        public Appointments(string user)
        {

            InitializeComponent();
            currentUser = user;
        }

        private void Appointments_Load(object sender, EventArgs e)
        {
            loadAppointmentData();
        }

        private void loadAppointmentData()
        {
            string connectionString = "Server=localhost;Database=client_schedule;User Id=sqlUser;Password=Passw0rd!";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT appointment.customerID,appointmentId, customerName, title, description, location, contact, type, url, start, end  " +
                                             "FROM appointment JOIN customer ON appointment.customerID = customer.customerId";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable customerTable = new DataTable();
                    adapter.Fill(customerTable);


                    // Convert 'start' and 'end' columns to local time
                    foreach (DataRow row in customerTable.Rows)
                    {
                        if (row["start"] != DBNull.Value)
                        {
                            DateTime utcStart = (DateTime)row["start"];
                            DateTime localStart = TimeZoneInfo.ConvertTimeFromUtc(utcStart, TimeZoneInfo.Local); // Convert to local time
                            row["start"] = localStart;
                        }

                        if (row["end"] != DBNull.Value)
                        {
                            DateTime utcEnd = (DateTime)row["end"];
                            DateTime localEnd = TimeZoneInfo.ConvertTimeFromUtc(utcEnd, TimeZoneInfo.Local); // Convert to local time
                            row["end"] = localEnd;
                        }
                    }

                    dgvApp.DataSource = customerTable;
                    dgvApp.Columns["customerID"].Visible = false;
                    dgvApp.Columns["AppointmentId"].Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);

                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUpdateAppointment addAppt = new AddUpdateAppointment(currentUser);
            addAppt.ShowDialog();
            loadAppointmentData();
        }

        private void dgvApp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                try
                {
                    DataGridViewRow selectedRow = dgvApp.Rows[e.RowIndex];
                    string customerName = selectedRow.Cells["customerName"].Value.ToString();
                    customerId = Convert.ToInt32(selectedRow.Cells["CustomerId"].Value);

                    // Show the customer name in the label
                    lblCustomerName.Text = $"Customer: {customerName}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("OOPs" + ex.Message);
                }

            }
        }
        private void lblCustomerName_Click(object sender, EventArgs e)
        {
            CustomerDetailsForm detailsForm = new CustomerDetailsForm(customerId);
            detailsForm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(dgvApp.SelectedRows[0].Cells["customerID"].Value);
            int appointmentId = Convert.ToInt32(dgvApp.SelectedRows[0].Cells["appointmentId"].Value);


            string title = dgvApp.SelectedRows[0].Cells["title"].Value.ToString();
            string description = dgvApp.SelectedRows[0].Cells["description"].Value.ToString();
            string location = dgvApp.SelectedRows[0].Cells["location"].Value.ToString();
            string contact = dgvApp.SelectedRows[0].Cells["contact"].Value.ToString();
            string type = dgvApp.SelectedRows[0].Cells["type"].Value.ToString();
            string url = dgvApp.SelectedRows[0].Cells["url"].Value.ToString();
            DateTime utcStart = Convert.ToDateTime(dgvApp.SelectedRows[0].Cells["start"].Value);
            DateTime utcEnd = Convert.ToDateTime(dgvApp.SelectedRows[0].Cells["end"].Value);

            // Get the computer's local time zone
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;

            // Convert UTC times to the system's local time zone (accounts for DST automatically)
            DateTime localStart = TimeZoneInfo.ConvertTimeFromUtc(utcStart, localTimeZone);
            DateTime localEnd = TimeZoneInfo.ConvertTimeFromUtc(utcEnd, localTimeZone);

            AddUpdateAppointment addAppt = new AddUpdateAppointment(currentUser,
              appointmentId, customerId, title, description, location, contact, type, url, localStart, localEnd
            );
            addAppt.ShowDialog();
            loadAppointmentData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvApp.SelectedRows.Count > 0)
            {
                // Get selected appointment ID
                int appointmentId = Convert.ToInt32(dgvApp.SelectedRows[0].Cells["appointmentId"].Value);

                // Confirm deletion
                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this appointment?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        DeleteAppointment(appointmentId);
                        MessageBox.Show("Appointment successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh DataGridView after deletion
                        loadAppointmentData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DeleteAppointment(int appointmentId)
        {
            string connectionString = "Server=localhost;Database=client_schedule;User Id=sqlUser;Password=Passw0rd!";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteQuery = "DELETE FROM appointment WHERE appointmentId = @appointmentId";

                        using (MySqlCommand command = new MySqlCommand(deleteQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@appointmentId", appointmentId);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw; // Re-throw the exception for error handling
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
