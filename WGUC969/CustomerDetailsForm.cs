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
    public partial class CustomerDetailsForm : Form
    {
        string connectionString = "Server=localhost;Database=client_schedule;User Id=sqlUser;Password=Passw0rd!";
        private int _customerId;
        public CustomerDetailsForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            LoadCustomerDetails();
        }

        private void LoadCustomerDetails()
        {

            //string query = "SELECT CustomerName, FROM customer WHERE CustomerID = @CustomerID";
            string query = "Select  customerId,customerName, phone, address,address2,postalCode,city, country,active,customer.createDate\r\nFROM customer INNER JOIN address  ON customer.addressId = address.addressId\r\nINNER JOIN city ON address.cityID = city.cityID\r\nINNER JOIN country ON city.countryId = country.countryId WHERE CustomerID = @CustomerID";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", _customerId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblName.Text = reader["CustomerName"].ToString();
                                lblAddress.Text = reader["Address"].ToString();
                                lblAddress2.Text = reader["Address2"].ToString();
                                lblPhone.Text = reader["Phone"].ToString();
                                lblCity.Text = reader["City"].ToString();
                                lblPostal.Text = reader["postalCode"].ToString();

                                lblCountry.Text = reader["Country"].ToString();
                                

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer details: " + ex.Message);
            }
        }
    }
}
