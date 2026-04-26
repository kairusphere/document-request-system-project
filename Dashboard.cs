using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Cachero_Group___Document_Request_System_Project
{
    public partial class Dashboard : Form
    {
        // Constructors
        public Dashboard()
        {
            InitializeComponent();
            LoadPage(new ucDashboard());
            txtDbdStudentName.Text = SessionManager.FullName;
            txtDbdStudentNum.Text = SessionManager.UserID;
        }

        // Element Loading Page
        private void LoadPage(UserControl page)
        {
            panelDbdContainer.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelDbdContainer.Controls.Add(page);
        }

        // UI Function
        private void btnViewDashboard_Click(object sender, EventArgs e)
        {
            LoadPage(new ucDashboard());
        }

        private void btnDbdRequestDoc_Click(object sender, EventArgs e)
        {
            LoadPage(new ucRequestDocument());
        }

        private void btnDbdRequestStatus_Click(object sender, EventArgs e)
        {
            LoadPage(new ucRequestStatus());
        }

        private void btnDbdProfile_Click(object sender, EventArgs e)
        {
            LoadPage(new ucProfile());
        }

        private bool isLoggingOut = false;
        private void btnDbdLogOut_Click(object sender, EventArgs e)
        {
            isLoggingOut = true;
            SessionManager.Clear();

            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnDbdToPortal_Click(object sender, EventArgs e)
        {
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://plmun.edu.ph/student-portal/system/main/",
                    UseShellExecute = true
                });
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isLoggingOut)
            {
                Application.Exit();
            }

        }
    }
}
