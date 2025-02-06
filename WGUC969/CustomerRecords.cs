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
    public partial class CustomerRecords : Form
    {
        string currentUser;
        public CustomerRecords(string user)
        {
            InitializeComponent();

            // Passsing the current app user
            currentUser = user;

        }



        // Load the grid with Customer Data
        private void LoadCustomerData()
        {
            string connectionString = "Server=localhost;Database=client_schedule;User Id=sqlUser;Password=Passw0rd!";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "Select  customerId,customerName, phone, address,address2,postalCode,city, country,active,customer.createDate\r\nFROM customer INNER JOIN address  ON customer.addressId = address.addressId\r\nINNER JOIN city ON address.cityID = city.cityID\r\nINNER JOIN country ON city.countryId = country.countryId";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable customerTable = new DataTable();
                    adapter.Fill(customerTable);

                    dgvCustomer.DataSource = customerTable;
                   
                    dgvCustomer.Columns["customerName"].HeaderText = "Full Name";

                    dgvCustomer.Columns["active"].HeaderText = "Active";
                    dgvCustomer.Columns["createDate"].HeaderText = "Created";
                    dgvCustomer.Columns["createDate"].DefaultCellStyle.Format = "d";

                    dgvCustomer.Columns["customerId"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }


        }

        private void CustomerRecords_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUpdateCustomer addcust = new AddUpdateCustomer(currentUser);
            addcust.ShowDialog();
            LoadCustomerData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                // Get selected customer data
                int customerId = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells["customerId"].Value);
                string customerName = dgvCustomer.SelectedRows[0].Cells["customerName"].Value.ToString();
                string address = dgvCustomer.SelectedRows[0].Cells["address"].Value.ToString();
                string address2 = dgvCustomer.SelectedRows[0].Cells["address2"].Value.ToString();
                string city = dgvCustomer.SelectedRows[0].Cells["city"].Value.ToString();
                string postalCode = dgvCustomer.SelectedRows[0].Cells["postalCode"].Value.ToString();
                string country = dgvCustomer.SelectedRows[0].Cells["country"].Value.ToString();
                string phone = dgvCustomer.SelectedRows[0].Cells["phone"].Value.ToString();

                // Open the update form and pass the data
                AddUpdateCustomer updateForm = new AddUpdateCustomer(true, currentUser, customerId, customerName, address, address2, city, postalCode, country, phone);
                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the DataGridView after update
                    LoadCustomerData();
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                // Get selected customer ID
                int customerId = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells["customerId"].Value);
                string customerName = dgvCustomer.SelectedRows[0].Cells["customerName"].Value.ToString();

                // Confirm deletion
                DialogResult confirm = MessageBox.Show(
                    $"Are you sure you want to delete customer '{customerName}', their appointments, and possibly their address?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        DeleteCustomerAndAppointments(customerId);
                        MessageBox.Show($"Customer '{customerName}' and their related records were successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh DataGridView
                        LoadCustomerData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteCustomerAndAppointments(int customerId)
        {
            string connectionString = "Server=localhost;Database=client_schedule;User Id=sqlUser;Password=Passw0rd!";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        //  Retrieve the addressId linked to the customer
                        int addressId = -1;
                        string getAddressQuery = "SELECT addressId FROM customer WHERE customerId = @customerId";
                        using (MySqlCommand cmd = new MySqlCommand(getAddressQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@customerId", customerId);
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                addressId = Convert.ToInt32(result);
                            }
                        }

                        // Delete appointments linked to the customer
                        string deleteAppointmentsQuery = "DELETE FROM appointment WHERE customerId = @customerId";
                        using (MySqlCommand cmd = new MySqlCommand(deleteAppointmentsQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@customerId", customerId);
                            cmd.ExecuteNonQuery();
                        }

                        // Delete the customer record
                        string deleteCustomerQuery = "DELETE FROM customer WHERE customerId = @customerId";
                        using (MySqlCommand cmd = new MySqlCommand(deleteCustomerQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@customerId", customerId);
                            cmd.ExecuteNonQuery();
                        }

                        // Check if the address is still being used by another customer
                        string checkAddressQuery = "SELECT COUNT(*) FROM customer WHERE addressId = @addressId";
                        using (MySqlCommand cmd = new MySqlCommand(checkAddressQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@addressId", addressId);
                            int addressUsageCount = Convert.ToInt32(cmd.ExecuteScalar());

                            // If no other customer is using this address, delete it
                            if (addressUsageCount == 0)
                            {
                                string deleteAddressQuery = "DELETE FROM address WHERE addressId = @addressId";
                                using (MySqlCommand cmdDelete = new MySqlCommand(deleteAddressQuery, connection, transaction))
                                {
                                    cmdDelete.Parameters.AddWithValue("@addressId", addressId);
                                    cmdDelete.ExecuteNonQuery();
                                }
                            }
                        }

                        // Commit transaction if all deletions succeed
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






    }
}
