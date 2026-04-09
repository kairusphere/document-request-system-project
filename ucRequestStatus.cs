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
    public partial class ucRequestStatus : UserControl
    {
        public ucRequestStatus()
        {
            InitializeComponent();
            LoadRequestStatusTable();
        }
        public void RefreshRequestStatus()
        {
            LoadRequestStatusTable();
        }
        private void LoadRequestStatusTable()
        {
            dgvRequestStatus.Columns.Clear();
            dgvRequestStatus.Rows.Clear();

            dgvRequestStatus.Columns.Add("request_id", "Request ID");
            dgvRequestStatus.Columns.Add("document_type", "Document Type");
            dgvRequestStatus.Columns.Add("copies", "Copies");
            dgvRequestStatus.Columns.Add("total_amount", "Total Amount");
            dgvRequestStatus.Columns.Add("date_requested", "Date Requested");
            dgvRequestStatus.Columns.Add("status", "Status");

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT request_id, document_type, copies, total_amount, date_requested, status
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
                            dgvRequestStatus.Rows.Add(
                                "REQ-" + Convert.ToInt32(reader["request_id"]).ToString("0000"),
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
        }
        private void dgvRequestStatus_CellContentClick(object sender, DataGridViewCellEventArgs e){}


    }
}
