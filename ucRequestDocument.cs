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
    public partial class ucRequestDocument : UserControl
    {
        private Dictionary<string, decimal> documentPrices = new Dictionary<string, decimal>();

        public ucRequestDocument()
        {
            InitializeComponent();
            LoadDocumentTypesFromDatabase();
            UpdatePrice();
        }

        private void LoadDocumentTypesFromDatabase()
        {
            cmbDocumentType.Items.Clear();
            documentPrices.Clear();

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "SELECT document_name, price FROM document_types ORDER BY document_name ASC";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string documentName = reader["document_name"].ToString();
                        decimal price = Convert.ToDecimal(reader["price"]);

                        cmbDocumentType.Items.Add(documentName);
                        documentPrices[documentName] = price;
                    }
                }
            }

            if (cmbDocumentType.Items.Count > 0)
                cmbDocumentType.SelectedIndex = 0;
        }


        private void UpdatePrice()
        {
            if (cmbDocumentType.SelectedItem == null) return;

            string selectedDoc = cmbDocumentType.SelectedItem.ToString();
            decimal pricePerCopy = documentPrices[selectedDoc];
            int copies = (int)numCopies.Value;

            decimal total = pricePerCopy * copies;

            lblCopyPrice.Text = "₱ " + pricePerCopy.ToString("0.00");
            lbltotalAmount.Text = "₱ " + total.ToString("0.00");
            lblETA.Text = GetProcessingTime(selectedDoc);
        }



        private void cmbDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void numCopies_ValueChanged_1(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void btnRDSubmit_Click(object sender, EventArgs e)
        {
            if (!chkAgreement.Checked)
            {
                MessageBox.Show("You must agree to the certification before submitting.");
                return;
            }

            if (cmbDocumentType.SelectedItem == null)
            {
                MessageBox.Show("Please select a document type.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPurpose.Text))
            {
                MessageBox.Show("Please enter the purpose of the request.");
                return;
            }

            string docType = cmbDocumentType.SelectedItem.ToString();
            int copies = (int)numCopies.Value;

            decimal price = documentPrices[docType];
            decimal total = price * copies;

            string assignedOffice = GetAssignedOffice(docType);
            string processingTime = GetProcessingTime(docType);
            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
INSERT INTO requests
(
    student_number,
    student_name,
    document_type,
    purpose,
    additional_notes,
    copies,
    price_per_copy,
    total_amount,
    assigned_office,
    processing_time,
    status,
    date_requested
)
VALUES
(
    @studentNumber,
    @studentName,
    @documentType,
    @purpose,
    @additionalNotes,
    @copies,
    @pricePerCopy,
    @totalAmount,
    @assignedOffice,
    @processingTime,
    @status,
    @dateRequested
);";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentNumber", SessionManager.UserID);
                    cmd.Parameters.AddWithValue("@studentName", SessionManager.FullName);
                    cmd.Parameters.AddWithValue("@documentType", docType);
                    cmd.Parameters.AddWithValue("@purpose", txtPurpose.Text.Trim());
                    cmd.Parameters.AddWithValue("@additionalNotes", txtRemarks.Text.Trim());
                    cmd.Parameters.AddWithValue("@copies", copies);
                    cmd.Parameters.AddWithValue("@pricePerCopy", price);
                    cmd.Parameters.AddWithValue("@totalAmount", total);
                    cmd.Parameters.AddWithValue("@status", "Pending");
                    cmd.Parameters.AddWithValue("@dateRequested", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@assignedOffice", assignedOffice);
                    cmd.Parameters.AddWithValue("@processingTime", processingTime);

                    cmd.ExecuteNonQuery();
                }

                // GET ID OF THE REQUEST WE JUST INSERTED
                long insertedRequestId = conn.LastInsertRowId;

                // INSERT FIRST STATUS LOG
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
                    logCmd.Parameters.AddWithValue("@requestId", insertedRequestId);
                    logCmd.Parameters.AddWithValue("@status", "Pending");
                    logCmd.Parameters.AddWithValue("@logMessage", "Request submitted.");
                    logCmd.Parameters.AddWithValue("@dateLogged", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    logCmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Request submitted successfully.");

            ClearFields();
        }

        private void ClearFields()
        {
            cmbDocumentType.SelectedIndex = 0;
            txtPurpose.Clear();
            numCopies.Value = 1;
            txtRemarks.Clear();
            chkAgreement.Checked = false;
        }

        private string GetAssignedOffice(string documentType)
        {
            if (documentType == "Certificate of Good Moral Character")
                return "Guidance Counselor";

            if (documentType == "Transcript of Records" || documentType == "Permit to Transfer")
                return "Admin";

            return "Registrar";
        }

        private string GetProcessingTime(string documentType)
        {
            if (documentType == "Transcript of Records")
                return "5-7 working days";

            if (documentType == "Permit to Transfer" || documentType == "Honorable Dismissal")
                return "3-5 working days";

            return "1-3 working days";
        }
    }
}
