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
    public partial class AdminDashboard : Form
    {
        private ucAdminDashboard adminDashboardPage = new ucAdminDashboard();
        private ucManageRequests manageRequestsPage = new ucManageRequests();
        private ucReports reportsPage = new ucReports();
        private ucAdminProfile adminProfilePage = new ucAdminProfile();

        public AdminDashboard()
        {
            InitializeComponent();
            LoadPage(adminDashboardPage);
        }

        private void LoadPage(UserControl page)
        {
            panelDbdContainer.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelDbdContainer.Controls.Add(page);
        }

        private void btnViewDashboard_Click(object sender, EventArgs e)
        {
            LoadPage(adminDashboardPage);
        }

        private void btnManageRequests_Click(object sender, EventArgs e)
        {
            LoadPage(manageRequestsPage);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            LoadPage(reportsPage);
        }

        private void btnAdminProfile_Click(object sender, EventArgs e)
        {
            LoadPage(adminProfilePage);
        }

        private void btnDbdManageRequests_Click(object sender, EventArgs e)
        {
            LoadPage(new ucManageRequests());
        }

        private void btnDbdDashboard_Click(object sender, EventArgs e)
        {
            LoadPage(new ucAdminDashboard());
        }

        private void btnDbdReports_Click(object sender, EventArgs e)
        {
            LoadPage(new ucReports());
        }

        private void btnDbdAdminProfile_Click(object sender, EventArgs e)
        {
            LoadPage(new ucAdminProfile());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnDbdLogOut_Click(object sender, EventArgs e)
        {
            SessionManager.Clear();

            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnDbdToPortal_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://plmun.edu.ph/employee/system/login/",
                UseShellExecute = true
            });
        }
    }
    }
