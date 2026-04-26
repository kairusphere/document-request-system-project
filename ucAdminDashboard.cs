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
    public partial class ucAdminDashboard : UserControl
    {
        public ucAdminDashboard()
        {
            InitializeComponent();

            LoadRecentRequests();
            LoadRequestCounts();
        }

        private void LoadRecentRequests()
        {
            flpRecentRequests.Controls.Clear();

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
        SELECT request_id, document_type, student_name, date_requested
        FROM requests
        ORDER BY request_id DESC
        LIMIT 20";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int requestId = Convert.ToInt32(reader["request_id"]);
                        string documentType = reader["document_type"].ToString();
                        string studentName = reader["student_name"].ToString();
                        string dateRequested = reader["date_requested"].ToString();

                        Panel card = CreateRecentRequestCard(
                            $"{documentType} (#{requestId:0000})",
                            studentName,
                            dateRequested
                        );

                        flpRecentRequests.Controls.Add(card);
                    }
                }
            }
        }

        private Panel CreateRecentRequestCard(string title, string studentName, string dateRequested)
        {
            Panel card = new Panel();
            card.Width = flpRecentRequests.ClientSize.Width - 25;
            card.Height = 75;
            card.BackColor = Color.FromArgb(40, 44, 52);
            card.Margin = new Padding(0, 0, 0, 10);
            card.Padding = new Padding(10);

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(10, 8);

            Label lblStudent = new Label();
            lblStudent.Text = "Student: " + studentName;
            lblStudent.ForeColor = Color.Gainsboro;
            lblStudent.Font = new Font("Segoe UI", 9);
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(10, 32);

            Label lblDate = new Label();
            lblDate.Text = dateRequested;
            lblDate.ForeColor = Color.Silver;
            lblDate.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            lblDate.AutoSize = true;
            lblDate.Location = new Point(10, 52);

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblStudent);
            card.Controls.Add(lblDate);

            return card;
        }


        private void LoadRequestCounts()
        {
            flpRequestCount.Controls.Clear();

            AddCountCard("Pending", GetRequestCountByStatus("Pending"));
            AddCountCard("Approved", GetRequestCountByStatus("Approved"));
            AddCountCard("Processing", GetRequestCountByStatus("Processing"));
            AddCountCard("Ready for Pickup", GetRequestCountByStatus("Ready for Pickup"));
        }

        private int GetRequestCountByStatus(string status)
        {
            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM requests WHERE status = @status";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void AddCountCard(string status, int count)
        {
            Panel card = new Panel();
            card.Width = flpRequestCount.ClientSize.Width - 25;
            card.Height = 65;
            card.BackColor = Color.FromArgb(40, 44, 52);
            card.Margin = new Padding(0, 0, 0, 10);
            card.Padding = new Padding(10);

            Label lblStatus = new Label();
            lblStatus.Text = status;
            lblStatus.ForeColor = GetStatusColor(status);
            lblStatus.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(10, 8);

            Label lblCount = new Label();
            lblCount.Text = "Total: " + count;
            lblCount.ForeColor = Color.White;
            lblCount.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            lblCount.AutoSize = true;
            lblCount.Location = new Point(10, 32);

            card.Controls.Add(lblStatus);
            card.Controls.Add(lblCount);

            flpRequestCount.Controls.Add(card);
        }

        private Color GetStatusColor(string status)
        {
            switch (status)
            {
                case "Pending":
                    return Color.Gold;
                case "Approved":
                    return Color.DeepSkyBlue;
                case "Processing":
                    return Color.Orange;
                case "Ready for Pickup":
                    return Color.LimeGreen;
                default:
                    return Color.WhiteSmoke;
            }
        }




        private void lblNotification_Click(object sender, EventArgs e)
        {

        }
    }
}
