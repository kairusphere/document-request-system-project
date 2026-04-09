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
    public partial class ucDashboard : UserControl
    {
        public ucDashboard()
        {
            InitializeComponent();

            lblWelcome.Text = "Welcome, " + SessionManager.FullName + "!";
            // txtDbdStudentName.Text = SessionManager.FullName;
            // txtDbdStudentNum.Text = SessionManager.UserID;

            LoadNotifications();
            LoadCurrentStatus();
        }

        // ========================================
        private Panel CreateNotificationCard(string title, string message, string dateText)
        {
            Panel card = new Panel();
            card.Width = flpNotifications.ClientSize.Width - 25;
            card.Height = 85;
            card.BackColor = Color.FromArgb(40, 44, 52);
            card.Margin = new Padding(0, 0, 0, 10);
            card.Padding = new Padding(10);

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(10, 8);

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.ForeColor = Color.Gainsboro;
            lblMessage.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(10, 32);

            Label lblDate = new Label();
            lblDate.Text = dateText;
            lblDate.ForeColor = Color.Silver;
            lblDate.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            lblDate.AutoSize = true;
            lblDate.Location = new Point(10, 56);

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblMessage);
            card.Controls.Add(lblDate);

            return card;
        }
        private Panel CreateStatusCard(string documentType, string status)
        {
            Panel card = new Panel();
            card.Width = flpStatus.ClientSize.Width - 25;
            card.Height = 65;
            card.BackColor = Color.FromArgb(40, 44, 52);
            card.Margin = new Padding(0, 0, 0, 10);
            card.Padding = new Padding(10);

            Label lblDoc = new Label();
            lblDoc.Text = documentType;
            lblDoc.ForeColor = Color.White;
            lblDoc.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblDoc.AutoSize = true;
            lblDoc.Location = new Point(10, 8);

            Label lblStatus = new Label();
            lblStatus.Text = status;
            lblStatus.ForeColor = GetStatusColor(status);
            lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(10, 34);

            card.Controls.Add(lblDoc);
            card.Controls.Add(lblStatus);

            return card;
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
                case "Completed":
                    return Color.MediumSeaGreen;
                case "Rejected":
                    return Color.IndianRed;
                default:
                    return Color.WhiteSmoke;
            }
        }
        // ===================
        private void LoadNotifications()
        {
            flpNotifications.Controls.Clear();

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
        SELECT r.request_id, r.document_type, l.status, l.date_logged
        FROM request_status_logs l
        JOIN requests r ON r.request_id = l.request_id
        WHERE r.student_number = @studentNumber
        ORDER BY l.date_logged DESC
        LIMIT 20";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentNumber", SessionManager.UserID);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        int readyCount = 0;

                        while (reader.Read())
                        {
                            int requestId = Convert.ToInt32(reader["request_id"]);
                            string documentType = reader["document_type"].ToString();
                            string status = reader["status"].ToString();
                            string dateLogged = reader["date_logged"].ToString();

                            string title = $"{documentType} (#{requestId:0000})";
                            string message = GetNotificationMessage(status);

                            Panel card = CreateNotificationCard(title, message, dateLogged);
                            flpNotifications.Controls.Add(card);

                            if (status == "Ready for Pickup")
                                readyCount++;
                        }

                        if (readyCount > 0)
                            lblNotification.Text = $"You have {readyCount} document request(s) ready to claim!";
                        else
                            lblNotification.Text = "No documents ready for pickup.";
                    }
                }
            }
        }

        private string GetNotificationMessage(string status)
        {
            switch (status)
            {
                case "Approved":
                    return "has been Approved";
                case "Processing":
                    return "is now Processing";
                case "Ready for Pickup":
                    return "is now Ready for Pickup";
                case "Completed":
                    return "has been Completed";
                case "Rejected":
                    return "has been Rejected";
                case "Pending":
                    return "has been Submitted";
                default:
                    return "status updated";
            }
        }
        private void LoadCurrentStatus()
        {
            flpStatus.Controls.Clear();

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
        SELECT request_id, document_type, status
        FROM requests
        WHERE student_number = @studentNumber
        ORDER BY request_id DESC";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentNumber", SessionManager.UserID);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string documentType = reader["document_type"].ToString();
                            string status = reader["status"].ToString();

                            Panel card = CreateStatusCard(documentType, status);
                            flpStatus.Controls.Add(card);
                        }
                    }
                }
            }
        }
        private void label1_Click(object sender, EventArgs e){}

        private void ucDashboard_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in flpNotifications.Controls)
            {
                ctrl.Width = flpNotifications.ClientSize.Width - 25;
            }

            foreach (Control ctrl in flpStatus.Controls)
            {
                ctrl.Width = flpStatus.ClientSize.Width - 25;
            }
        }
    }
}
