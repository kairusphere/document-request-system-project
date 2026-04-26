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
            LoadFilters();
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
            dgvManageRequests.Columns.Add("Purpose", "Purpose");
            dgvManageRequests.Columns.Add("Remarks", "Remarks");
            dgvManageRequests.Columns.Add("AssignedOffice", "Handled By");
            dgvManageRequests.Columns.Add("ProcessingTime", "Processing Time");

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT request_id, student_number, student_name, document_type,
                            purpose, additional_notes, copies, total_amount,
                            assigned_office, processing_time, date_requested, status
                    FROM requests
                    WHERE 1 = 1";

                if (cmbRoleFilter.SelectedItem != null && cmbRoleFilter.SelectedItem.ToString() != "All")
                    query += " AND assigned_office = @assignedOffice";

                if (cmbDocumentTypeFilter.SelectedItem != null && cmbDocumentTypeFilter.SelectedItem.ToString() != "All")
                    query += " AND document_type = @documentType";

                if (cmbStatusFilter.SelectedItem != null && cmbStatusFilter.SelectedItem.ToString() != "All")
                    query += " AND status = @status";

                query += " ORDER BY request_id DESC";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    if (cmbRoleFilter.SelectedItem != null &&
                        cmbRoleFilter.SelectedItem.ToString() != "All")
                    {
                        cmd.Parameters.AddWithValue(
                            "@assignedOffice",
                            cmbRoleFilter.SelectedItem.ToString()
                        );
                    }

                    if (cmbDocumentTypeFilter.SelectedItem != null &&
                        cmbDocumentTypeFilter.SelectedItem.ToString() != "All")
                    {
                        cmd.Parameters.AddWithValue(
                            "@documentType",
                            cmbDocumentTypeFilter.SelectedItem.ToString()
                        );
                    }

                    if (cmbStatusFilter.SelectedItem != null &&
                        cmbStatusFilter.SelectedItem.ToString() != "All")
                    {
                        cmd.Parameters.AddWithValue(
                            "@status",
                            cmbStatusFilter.SelectedItem.ToString()
                        );
                    }

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int requestId = Convert.ToInt32(reader["request_id"]);

                            int rowIndex = dgvManageRequests.Rows.Add(
                                "REQ-" + requestId.ToString("0000"),
                                reader["student_number"].ToString(),
                                reader["student_name"].ToString(),
                                reader["document_type"].ToString(),
                                reader["copies"].ToString(),
                                "₱ " + Convert.ToDecimal(reader["total_amount"]).ToString("0.00"),
                                reader["date_requested"].ToString(),
                                reader["status"].ToString(),
                                reader["purpose"].ToString(),
                                reader["additional_notes"].ToString(),
                                reader["assigned_office"].ToString(),
                                reader["processing_time"].ToString()
                            );

                            dgvManageRequests.Rows[rowIndex].Tag = requestId;
                        }
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

            object tagValue = dgvManageRequests.SelectedRows[0].Tag;

            if (tagValue == null)
            {
                MessageBox.Show("Invalid request selected. Row has no request ID tag.");
                return null;
            }

            return Convert.ToInt32(tagValue);
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

        private void LoadFilters()
        {
            cmbRoleFilter.Items.Clear();
            cmbRoleFilter.Items.Add("All");
            cmbRoleFilter.Items.Add("Admin");
            cmbRoleFilter.Items.Add("Registrar");
            cmbRoleFilter.Items.Add("Guidance Counselor");

            string currentRole = SessionManager.Role;

            if (currentRole == "admin")
                cmbRoleFilter.SelectedItem = "Admin";
            else if (currentRole == "registrar")
                cmbRoleFilter.SelectedItem = "Registrar";
            else if (currentRole == "guidance")
                cmbRoleFilter.SelectedItem = "Guidance Counselor";
            else
                cmbRoleFilter.SelectedItem = "All";

            cmbDocumentTypeFilter.Items.Clear();
            cmbDocumentTypeFilter.Items.Add("All");

            

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query =
                        "SELECT document_name FROM document_types ORDER BY document_name";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbDocumentTypeFilter.Items.Add(
                                reader["document_name"].ToString()
                            );
                        }
                    }
                }

                cmbDocumentTypeFilter.SelectedItem = "All";

            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All");
            cmbStatusFilter.Items.Add("Pending");
            cmbStatusFilter.Items.Add("Approved");
            cmbStatusFilter.Items.Add("Processing");
            cmbStatusFilter.Items.Add("Ready for Pickup");
            cmbStatusFilter.Items.Add("Completed");
            cmbStatusFilter.Items.Add("Rejected");
            cmbStatusFilter.SelectedItem = "All";
        }

        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadManageRequestsTable();
        }

        private void cmbDocumentTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadManageRequestsTable();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadManageRequestsTable();
        }
    }
}