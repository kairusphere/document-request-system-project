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
    public partial class DeveloperAccounts : Form
    {
        public DeveloperAccounts()
        {
            InitializeComponent();
            LoadRoles();
            LoadUsers();
        }

        private void LoadRoles()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("student");
            cmbRole.Items.Add("admin");
            cmbRole.Items.Add("registrar");
            cmbRole.Items.Add("guidance");
            cmbRole.SelectedIndex = 0;
        }

        private void LoadUsers()
        {
            dgvUsers.Columns.Clear();
            dgvUsers.Rows.Clear();

            dgvUsers.Columns.Add("user_db_id", "DB ID");
            dgvUsers.Columns.Add("username", "User ID");
            dgvUsers.Columns.Add("password", "Password");
            dgvUsers.Columns.Add("role", "Role");
            dgvUsers.Columns.Add("student_number", "Student Number");
            dgvUsers.Columns.Add("full_name", "Full Name");

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT user_id, username, password, role, student_number, full_name
                    FROM users
                    ORDER BY user_id DESC";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvUsers.Rows.Add(
                            reader["user_id"].ToString(),
                            reader["username"].ToString(),
                            reader["password"].ToString(),
                            reader["role"].ToString(),
                            reader["student_number"].ToString(),
                            reader["full_name"].ToString()
                        );
                    }
                }
            }
        }

        private void ClearFields()
        {
            txtFullName.Clear();
            txtStudentNumber.Clear();
            txtPassword.Clear();
            txtStudentNumber.Clear();
            cmbRole.SelectedIndex = 0;
            dgvUsers.ClearSelection();
        }

        private int? GetSelectedDbId()
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user first.");
                return null;
            }

            return Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["user_db_id"].Value);
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

            txtStudentNumber.Text = row.Cells["username"].Value.ToString();
            txtPassword.Text = row.Cells["password"].Value.ToString();
            cmbRole.Text = row.Cells["role"].Value.ToString();
            txtStudentNumber.Text = row.Cells["student_number"].Value.ToString();
            txtFullName.Text = row.Cells["full_name"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtStudentNumber.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please complete the required fields.");
                return;
            }

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    INSERT INTO users (username, password, role, student_number, full_name)
                    VALUES (@username, @password, @role, @studentNumber, @fullName)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", txtStudentNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@studentNumber",
                        string.IsNullOrWhiteSpace(txtStudentNumber.Text)
                            ? (object)DBNull.Value
                            : txtStudentNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@fullName", txtFullName.Text.Trim());

                    cmd.ExecuteNonQuery();
                }
            }

            LoadUsers();
            ClearFields();
            MessageBox.Show("User added successfully.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int? selectedDbId = GetSelectedDbId();
            if (selectedDbId == null) return;

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    UPDATE users
                    SET username = @username,
                        password = @password,
                        role = @role,
                        student_number = @studentNumber,
                        full_name = @fullName
                    WHERE user_id = @userId";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", txtStudentNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@studentNumber",
                        string.IsNullOrWhiteSpace(txtStudentNumber.Text)
                            ? (object)DBNull.Value
                            : txtStudentNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@fullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@userId", selectedDbId.Value);

                    cmd.ExecuteNonQuery();
                }
            }

            LoadUsers();
            ClearFields();
            MessageBox.Show("User updated successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? selectedDbId = GetSelectedDbId();
            if (selectedDbId == null) return;

            DialogResult result = MessageBox.Show(
                "Delete this user?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM users WHERE user_id = @userId";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", selectedDbId.Value);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadUsers();
            ClearFields();
            MessageBox.Show("User deleted successfully.");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}