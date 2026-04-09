using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Cachero_Group___Document_Request_System_Project
{
    public partial class ucManageRequests : UserControl
    {
        public ucManageRequests()
        {
            InitializeComponent();
            LoadManageRequestsTable();
        }

        public void RefreshManageRequests()
        {
            LoadManageRequestsTable();
        }

        private void LoadManageRequestsTable()
        {
            dgvManageRequests.Columns.Clear();
            dgvManageRequests.Rows.Clear();

            dgvManageRequests.Columns.Add("request_id", "Request ID");
            dgvManageRequests.Columns.Add("student_number", "Student Number");
            dgvManageRequests.Columns.Add("student_name", "Student Name");
            dgvManageRequests.Columns.Add("document_type", "Document Type");
            dgvManageRequests.Columns.Add("copies", "Copies");
            dgvManageRequests.Columns.Add("total_amount", "Total Amount");
            dgvManageRequests.Columns.Add("date_requested", "Date Requested");
            dgvManageRequests.Columns.Add("status", "Status");

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT request_id, student_number, student_name, document_type,
                           copies, total_amount, date_requested, status
                    FROM requests
                    ORDER BY request_id DESC";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvManageRequests.Rows.Add(
                            "REQ-" + Convert.ToInt32(reader["request_id"]).ToString("0000"),
                            reader["student_number"].ToString(),
                            reader["student_name"].ToString(),
                            reader["document_type"].ToString(),
                            reader["copies"].ToString(),
                            "₱ " + Convert.ToDecimal(reader["total_amount"]).ToString("0.00"),
                            reader["date_requested"].ToString(),
                            reader["status"].ToString()
                        );
                    }
                }
            }
        }

        private int? GetSelectedRequestId()
        {
            if (dgvManageRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request first.");
                return null;
            }

            string selectedRequestText = dgvManageRequests.SelectedRows[0].Cells["request_id"].Value.ToString();

            if (selectedRequestText.StartsWith("REQ-"))
            {
                selectedRequestText = selectedRequestText.Replace("REQ-", "");
            }

            if (int.TryParse(selectedRequestText, out int requestId))
            {
                return requestId;
            }

            MessageBox.Show("Invalid request selected.");
            return null;
        }

        private void UpdateSelectedRequestStatus(string newStatus)
        {
            int? selectedRequestId = GetSelectedRequestId();

            if (selectedRequestId == null)
                return;

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string updateQuery = "UPDATE requests SET status = @status WHERE request_id = @requestId";

                using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@requestId", selectedRequestId.Value);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        string logMessage = "Request status updated to " + newStatus + ".";

                        string logQuery = @"
                    INSERT INTO request_status_logs
                    (
                        request_id,
                        status,
                        log_message,
                        date_logged
                    )
                    VALUES
                    (
                        @requestId,
                        @status,
                        @logMessage,
                        @dateLogged
                    );";

                        using (SQLiteCommand logCmd = new SQLiteCommand(logQuery, conn))
                        {
                            logCmd.Parameters.AddWithValue("@requestId", selectedRequestId.Value);
                            logCmd.Parameters.AddWithValue("@status", newStatus);
                            logCmd.Parameters.AddWithValue("@logMessage", logMessage);
                            logCmd.Parameters.AddWithValue("@dateLogged", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                            logCmd.ExecuteNonQuery();
                        }

                        LoadManageRequestsTable();
                        MessageBox.Show("Request status updated to " + newStatus + ".");
                    }
                    else
                    {
                        MessageBox.Show("No request was updated.");
                    }
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            UpdateSelectedRequestStatus("Approved");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            UpdateSelectedRequestStatus("Rejected");
        }

        private void btnMarkProcessing_Click(object sender, EventArgs e)
        {
            UpdateSelectedRequestStatus("Processing");
        }

        private void btnReadyForPickup_Click(object sender, EventArgs e)
        {
            UpdateSelectedRequestStatus("Ready for Pickup");
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            UpdateSelectedRequestStatus("Completed");
        }
    }
}