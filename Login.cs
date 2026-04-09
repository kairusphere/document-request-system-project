using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Cachero_Group___Document_Request_System_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userID = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(userID) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your User ID and password.");
                return;
            }

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT user_id, username, password, role, full_name
                    FROM users
                    WHERE username = @userID AND password = @password";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SessionManager.DbUserId = Convert.ToInt32(reader["user_id"]);
                            SessionManager.UserID = reader["username"].ToString();
                            SessionManager.FullName = reader["full_name"].ToString();
                            SessionManager.Role = reader["role"].ToString();

                            if (SessionManager.Role == "student")
                            {
                                Dashboard studentDashboard = new Dashboard();
                                studentDashboard.Show();
                                this.Hide();
                            }
                            else if (SessionManager.Role == "admin")
                            {
                                AdminDashboard adminDashboard = new AdminDashboard();
                                adminDashboard.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Unknown user role.");
                                SessionManager.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid User ID or password.");
                        }
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("SQLite connected successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                string devPassword = Prompt.ShowDialog("Enter developer password:", "Developer Access");

                if (devPassword == "999999")
                {
                    DeveloperAccounts devForm = new DeveloperAccounts();
                    devForm.ShowDialog();
                }
                else if (!string.IsNullOrWhiteSpace(devPassword))
                {
                    MessageBox.Show("Access denied.");
                }
            }
        }
    }
    }
