using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace WGUC969
{
    public partial class AddUpdateAppointment : Form
    {
        bool updateMode;
        string currentUser;
        bool success = false;
        string connectionString = "Server=localhost;Database=client_schedule;User Id=sqlUser;Password=Passw0rd!";

        public int AppointmentId { get; }
        public string? Title { get; }
        public string? Description { get; }
        public string? Location1 { get; }
        public string? Contact { get; }
        public string? Type { get; }
        public string? Url { get; }
        public DateTime EasternStart { get; }
        public DateTime EasternEnd { get; }

      
        string timeFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern;




        public AddUpdateAppointment(string user)
        {
            InitializeComponent();
            LoadCustomers();
            loadDTP();
            currentUser = user;
            updateMode = false;

            this.Text = "Add Appointment";


        }

        public AddUpdateAppointment(string user, int appointmentId, int customerId, string? title, string? description, string? location, string? contact, string? type, string? url, DateTime easternStart, DateTime easternEnd)
        {

            InitializeComponent();

            LoadCustomers();
            loadDTP();

            currentUser = user;
            updateMode = true;
            AppointmentId = appointmentId;
            comboBoxCustomers.SelectedValue = customerId;
            txtTitle.Text = title;
            txtDesc.Text = description;
            txtLoc.Text = location;
            txtCon.Text = contact;
            txtType.Text = type;
            txtUrl.Text =  url;
            dtpStart.Value = easternStart;
            dtpEnd.Value = easternEnd;

            if (updateMode)
            {
                lblTitle.Text = "Update Appointment";
                lblTitle.Location = new Point(20, 34);
                this.Text = lblTitle.Text;
            }
        }

        private void loadDTP()
        {
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "MM/dd/yyyy HH:mm:ss";  // Forces 24-hour format
            dtpStart.ShowUpDown = true;

            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = dtpStart.CustomFormat; //add time to picker
            dtpEnd.ShowUpDown = true; // make it a up/down button
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string title;
            string desc;
            string loc;
            string con;
            string type = "";
            string url;
            int customerId;
            int userId;
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                { title = "not needed"; }
                else { title = txtTitle.Text; }

                if (string.IsNullOrEmpty(txtDesc.Text))
                { desc = "not needed"; }
                else { desc = txtDesc.Text; }

                if (string.IsNullOrEmpty(txtLoc.Text))
                { loc = "not needed"; }
                else { loc = txtLoc.Text; }

                if (string.IsNullOrWhiteSpace(txtCon.Text))
                { con = "not needed"; }
                else { con = txtCon.Text; }

    
                if (string.IsNullOrEmpty(txtUrl.Text))
                {
                    url = "none";
                }
                if (dtpStart.Value >= dtpEnd.Value)
                {
                    MessageBox.Show("The start time must be before the end time.", "Invalid Appointment Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop execution if validation fails
                }
                else { url = txtUrl.Text; }
                    if (string.IsNullOrEmpty(txtType.Text))
                    {
                        MessageBox.Show("Please enter an appointment type");
                    }
                DateTime startLocal = dtpStart.Value;
                DateTime endLocal = dtpEnd.Value;

                // Define business hours in Eastern Time
                TimeZoneInfo easternTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

                    // Convert local time to Eastern Time
                    DateTime startEastern = TimeZoneInfo.ConvertTimeFromUtc(startLocal.ToUniversalTime(), easternTimeZone);
                    DateTime endEastern = TimeZoneInfo.ConvertTimeFromUtc(endLocal.ToUniversalTime(), easternTimeZone);

                    // Get appointment time in 24-hour format
                    TimeSpan startTime = startEastern.TimeOfDay;
                    TimeSpan endTime = endEastern.TimeOfDay;

                    // Define allowed business hours (9 AM – 5 PM)
                    TimeSpan businessStart = new TimeSpan(9, 0, 0); // 09:00 AM
                    TimeSpan businessEnd = new TimeSpan(17, 0, 0); // 05:00 PM

                    // Check if appointment is outside business hours
                    if (startEastern.DayOfWeek == DayOfWeek.Saturday || startEastern.DayOfWeek == DayOfWeek.Sunday ||
                        startTime < businessStart || endTime > businessEnd)
                    {
                        MessageBox.Show("Appointments must be scheduled between 9:00 AM and 5:00 PM Eastern Time, Monday–Friday.",
                                        "Invalid Appointment Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                   
                    else
                    {
                        type = txtType.Text;
                        customerId = int.Parse(comboBoxCustomers.SelectedValue.ToString());
                        //int userId = int.Parse(comboBoxUser.SelectedValue.ToString()); 
                        userId = 1;
                   
                        string createdBy = currentUser;

                    if (updateMode == false)
                    {
                         success = AddAppointment(customerId, userId, title, desc, loc, con, type, url, startLocal, endLocal, createdBy);
                    }
                    else
                    {
                         success = UpdateAppointment(AppointmentId, customerId, userId, title, desc, loc, con, type, url, startLocal, endLocal);
                    }
                    if (success)
                    {
                        MessageBox.Show("Appointment  successful");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("There was an Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                }
            }catch(Exception ex)
            {
                MessageBox.Show("An error has occurred: "  + ex.Message);
            }
        }

        public bool AddAppointment(
      int customerId,
      int userId,
      string title,
      string desc,
      string loc,
      string con,
      string type,
      string url,
      DateTime startLocal,
      DateTime endLocal,
      string createdBy)
        {
            string query = @"
        INSERT INTO appointment 
        (customerId, 
        userId, 
        title, 
        description, 
        location, 
        contact, 
        type, url, 
        start, 
        end, 
        createDate, 
        createdBy, 
        lastUpdate, 
        lastUpdateBy)
        VALUES 
        (@CustomerId, @UserId, @Title, @Description, @Location, @Contact, @Type, @Url, @Start, @End, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy)"
            ;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Convert local DateTime to UTC
                        DateTime startUtc = startLocal.ToUniversalTime();
                        DateTime endUtc = endLocal.ToUniversalTime();

                        // Add parameters
                        command.Parameters.AddWithValue("@CustomerId", customerId);
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Description", desc ?? string.Empty);
                        command.Parameters.AddWithValue("@Location", loc ?? string.Empty);
                        command.Parameters.AddWithValue("@Contact", con ?? string.Empty);
                        command.Parameters.AddWithValue("@Type", type ?? string.Empty);
                        command.Parameters.AddWithValue("@Url", url ?? string.Empty);
                        command.Parameters.AddWithValue("@Start", startUtc);
                        command.Parameters.AddWithValue("@End", endUtc);
                        command.Parameters.AddWithValue("@CreateDate", DateTime.UtcNow);
                        command.Parameters.AddWithValue("@CreatedBy", createdBy);
                        command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                        command.Parameters.AddWithValue("@LastUpdateBy", createdBy);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding appointment: {ex.Message}");
                return false;
            }
        }
        private void LoadCustomers()
        {
            string query = "SELECT customerId, customerName FROM customer";

            DataTable customersTable = new DataTable();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(customersTable);
                    }
                }

                comboBoxCustomers.DataSource = customersTable;
                comboBoxCustomers.DisplayMember = "CustomerName"; // Column to display
                comboBoxCustomers.ValueMember = "CustomerID";     // Column as value
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        public bool UpdateAppointment(
            int appointmentId,
            int customerId,
            int userId,
            string title,
            string desc,
            string loc,
            string con,
            string type,
            string url,
            DateTime start,
            DateTime end
            )
        {
            // Get system's local time zone
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;

            // Convert UTC times to local times
            DateTime startLocal = TimeZoneInfo.ConvertTimeFromUtc(start, localTimeZone);
            DateTime endLocal = TimeZoneInfo.ConvertTimeFromUtc(end, localTimeZone);

            string updatedBy = currentUser;
            string query = @"
    UPDATE appointment
    SET 
        customerId = @CustomerId, 
        userId = @UserId, 
        title = @Title, 
        description = @Description, 
        location = @Location, 
        contact = @Contact, 
        type = @Type, 
        url = @Url, 
        start = @Start, 
        end = @End, 
        lastUpdate = @LastUpdate, 
        lastUpdateBy = @LastUpdateBy
    WHERE 
        appointmentId = @AppointmentId";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Convert local DateTime to UTC
                        DateTime startUtc = startLocal.ToUniversalTime();
                        DateTime endUtc = endLocal.ToUniversalTime();

                        // Add parameters
                        command.Parameters.AddWithValue("@AppointmentId", appointmentId);
                        command.Parameters.AddWithValue("@CustomerId", customerId);
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Description", desc ?? string.Empty);
                        command.Parameters.AddWithValue("@Location", loc ?? string.Empty);
                        command.Parameters.AddWithValue("@Contact", con ?? string.Empty);
                        command.Parameters.AddWithValue("@Type", type ?? string.Empty);
                        command.Parameters.AddWithValue("@Url", url ?? string.Empty);
                        command.Parameters.AddWithValue("@Start", startUtc);
                        command.Parameters.AddWithValue("@End", endUtc);
                        command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                        command.Parameters.AddWithValue("@LastUpdateBy", updatedBy);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating appointment: {ex.Message}");
                return false;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
