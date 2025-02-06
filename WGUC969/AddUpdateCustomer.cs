using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WGUC969
{
    public partial class AddUpdateCustomer : Form
    {
        string currentUser;
        bool isEditMode;
        int id;
        string connectionString = "Server=localhost;Database=client_schedule;User Id=sqlUser;Password=Passw0rd!";
        public AddUpdateCustomer(string user)
        {
            InitializeComponent();
            currentUser = user;
            isEditMode = false;

            this.Text = "Add Customer";
        }
        public AddUpdateCustomer(bool editMode, string user,int customerId, string customerName, string address, string address2, string city, string postalCode, string country, string phone) {
            InitializeComponent();
           

            currentUser=user;
            isEditMode = editMode; 
            txtName.Text = customerName;
            txtAddress.Text = address;
            txtAddress2.Text = address2;
            txtCity.Text = city;
            txtZip.Text = postalCode;
            txtCountry.Text = country;
            txtPhone.Text = phone;
           id = customerId;

            if (isEditMode)
            {
                lblTitle.Text = "Update Customer";
                this.Text = "Update Customer";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string customerName = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string address2 = txtAddress2.Text.Trim();
            string city = txtCity.Text.Trim();
            string country = txtCountry.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string postalCode = txtZip.Text.Trim();

            if (phone.Length < 10)
            {
                MessageBox.Show("Please enter a valid Phone Number");
            }

            if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(city) ||
                string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(postalCode))
            {
                MessageBox.Show("Please enter all fields in the form");
            }
            else if (isEditMode == false)
            {
                string createdBy = currentUser;

               
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (MySqlTransaction transaction = connection.BeginTransaction())
                        {
                            // Check or Insert Country
                            int countryId = GetOrInsertCountry(connection, transaction, country, createdBy);

                            //  Check or Insert City
                            int cityId = GetOrInsertCity(connection, transaction, city, countryId, createdBy);

                            // 3. Insert Address
                            int addressId = InsertAddress(connection, transaction, address, address2, cityId, postalCode, phone, createdBy);

                            // Insert Customer
                            InsertCustomer(connection, transaction, customerName, addressId, createdBy);

                            // Commit the transaction
                            transaction.Commit();

                            MessageBox.Show("Customer added successfully!");
                            txtName.Clear();
                            txtAddress.Clear();
                            txtAddress2.Clear();
                            txtCity.Clear();
                            txtCountry.Clear();
                            txtZip.Clear();
                            txtPhone.Clear();
                            Close();
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                string updatedBy = currentUser;
                UpdateCustomerRecord(id, customerName, address, address2, city, postalCode, country, phone, updatedBy);
              
                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 
                this.Close();
                
            }

        }
        private void txtPhone_KeyPress_1(object sender, KeyPressEventArgs e)
        {            // Allow digits (0-9), dashes (-), and control keys (like Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignore the input
            }

        }
        private int GetOrInsertCountry(MySqlConnection connection, MySqlTransaction transaction, string country, string createdBy)
        {
            string query = "SELECT countryId FROM country WHERE country = @country";
            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@country", country);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result); // Country exists, return countryId
                }
            }

            
            query = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@country, NOW(), @createdBy, NOW(), @lastUpdateBy)";
            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                
                command.Parameters.AddWithValue("@country", country);
                command.Parameters.AddWithValue("@createdBy", createdBy);
                command.Parameters.AddWithValue("@lastUpdateBy", createdBy);

                command.ExecuteNonQuery();
                return (int)command.LastInsertedId;
            }
        }

        private int GetOrInsertCity(MySqlConnection connection, MySqlTransaction transaction, string city, int countryId, string createdBy)
        {
            string query = "SELECT cityId FROM city WHERE city = @city AND countryId = @countryId";
            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@city", city);
                command.Parameters.AddWithValue("@countryId", countryId);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result); // City exists, return cityId
                }
            }

            
            query = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@city, @countryId, NOW(), @createdBy, NOW(), @lastUpdateBy)";
            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@city", city);
                command.Parameters.AddWithValue("@countryId", countryId);
                command.Parameters.AddWithValue("@createdBy", createdBy);
                command.Parameters.AddWithValue("@lastUpdateBy", createdBy);

                command.ExecuteNonQuery();
                return (int)command.LastInsertedId;
            }
        }

        private int InsertAddress(MySqlConnection connection, MySqlTransaction transaction, string address, string address2, int cityId, string postalCode, string phone, string createdBy)
        {
            string query = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                           "VALUES (@address, @address2, @cityId, @postalCode, @phone, NOW(), @createdBy, NOW(), @lastUpdateBy)";
            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@address2", address2);
                command.Parameters.AddWithValue("@cityId", cityId);
                command.Parameters.AddWithValue("@postalCode", postalCode);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@createdBy", createdBy);
                command.Parameters.AddWithValue("@lastUpdateBy", createdBy);

                command.ExecuteNonQuery();
                return (int)command.LastInsertedId;
            }
        }

        private void InsertCustomer(MySqlConnection connection, MySqlTransaction transaction, string customerName, int addressId, string createdBy)
        {
            string query = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                           "VALUES (@customerName, @addressId, 1, NOW(), @createdBy, NOW(), @lastUpdateBy)";
            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@customerName", customerName);
                command.Parameters.AddWithValue("@addressId", addressId);
                command.Parameters.AddWithValue("@createdBy", createdBy);
                command.Parameters.AddWithValue("@lastUpdateBy", createdBy);

                command.ExecuteNonQuery();
            }
        }
        private void UpdateCustomerRecord(int customerId, string customerName, string address, string address2, string city, string postalCode, string country, string phone, string updatedBy)
        {
 
            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int countryId = GetOrInsertCountry(connection, transaction, country, updatedBy);
                        int cityId = GetOrInsertCity(connection, transaction, city, countryId, updatedBy);

                        string updateAddressQuery = @"
                    UPDATE address
                    SET address = @address, address2 = @address2, cityId = @cityId, postalCode = @postalCode, phone = @phone, 
                        lastUpdate = NOW(), lastUpdateBy = @lastUpdateBy
                    WHERE addressId = (SELECT addressId FROM customer WHERE customerId = @customerId)";
                        using (MySqlCommand addressCommand = new MySqlCommand(updateAddressQuery, connection, transaction))
                        {
                            addressCommand.Parameters.AddWithValue("@address", address);
                            addressCommand.Parameters.AddWithValue("@address2", address2);
                            addressCommand.Parameters.AddWithValue("@cityId", cityId);
                            addressCommand.Parameters.AddWithValue("@postalCode", postalCode);
                            addressCommand.Parameters.AddWithValue("@phone", phone);
                            addressCommand.Parameters.AddWithValue("@lastUpdateBy", updatedBy);
                            addressCommand.Parameters.AddWithValue("@customerId", customerId);

                            addressCommand.ExecuteNonQuery();
                        }

                        string updateCustomerQuery = @"
                    UPDATE customer
                    SET customerName = @customerName, lastUpdate = NOW(), lastUpdateBy = @lastUpdateBy
                    WHERE customerId = @customerId";
                        using (MySqlCommand customerCommand = new MySqlCommand(updateCustomerQuery, connection, transaction))
                        {
                            customerCommand.Parameters.AddWithValue("@customerName", customerName);
                            customerCommand.Parameters.AddWithValue("@lastUpdateBy", updatedBy);
                            customerCommand.Parameters.AddWithValue("@customerId", customerId);

                            customerCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
