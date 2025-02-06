using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Collections;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WGUC969
{
    public partial class Login : Form
    {
        private ResourceManager resourceManager;
        CultureInfo cultureInfo = CultureInfo.CurrentCulture;

        public Login()
        {
            InitializeComponent();

            resourceManager = new ResourceManager("WGUC969.Login", typeof(Login).Assembly);

            RegionInfo regionInfo = new RegionInfo(cultureInfo.Name);
            lblLocale.Text = cultureInfo.Name;
            lblRegion.Text = regionInfo.EnglishName;

            // Update UI text
            lblUser.Text = resourceManager.GetString("Username", cultureInfo);
            lblPass.Text = resourceManager.GetString("Password", cultureInfo);
            lblWelcome.Text = resourceManager.GetString("Welcome", cultureInfo);
            btnLogin.Text = resourceManager.GetString("Login", cultureInfo);
            btnExit.Text = resourceManager.GetString("Exit", cultureInfo);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUser.Text;
            string password = tbxPass.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblWarning.Text = resourceManager.GetString("LoginEmpty", cultureInfo);

                return;
            }
            string connectionString = "Server=localhost;Database=client_schedule;User Id=root;Password=admin;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Since i dont need to keep the user info just see if it exists
                    string query = "SELECT COUNT(*) FROM user WHERE username = @username AND password = @password";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int userCount = Convert.ToInt32(command.ExecuteScalar());

                        if (userCount > 0)
                        {
                            UpdateLog(username);
                            this.Hide();
                           MainWindow mainWindow = new MainWindow("username");  
                            mainWindow.ShowDialog();

                            this.Show();
                        }
                        else
                        {
                            lblWarning.Text = resourceManager.GetString("InvalidLogin", cultureInfo);
                           
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error:" + ex);
                }
            }


        }

        void UpdateLog(string logUsername)
        {
            string logFilePath = "Login_History.txt";
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"Timestamp: {timestamp}, Username: {logUsername}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while recording login: " + ex.Message);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
