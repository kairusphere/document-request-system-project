
namespace Cachero_Group___Document_Request_System_Project
{
    partial class ucManageRequests
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvManageRequests = new System.Windows.Forms.DataGridView();
            this.RequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Copies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateRequested = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnMarkProcessing = new System.Windows.Forms.Button();
            this.btnReadyForPickup = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.lblText1 = new System.Windows.Forms.Label();
            this.cmbDocumentTypeFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRoleFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvManageRequests
            // 
            this.dgvManageRequests.AllowUserToAddRows = false;
            this.dgvManageRequests.AllowUserToDeleteRows = false;
            this.dgvManageRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManageRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvManageRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RequestID,
            this.DocumentType,
            this.Copies,
            this.DateRequested,
            this.TotalAmount,
            this.Status});
            this.dgvManageRequests.Location = new System.Drawing.Point(55, 174);
            this.dgvManageRequests.MultiSelect = false;
            this.dgvManageRequests.Name = "dgvManageRequests";
            this.dgvManageRequests.ReadOnly = true;
            this.dgvManageRequests.RowHeadersVisible = false;
            this.dgvManageRequests.RowHeadersWidth = 51;
            this.dgvManageRequests.RowTemplate.Height = 24;
            this.dgvManageRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManageRequests.Size = new System.Drawing.Size(941, 448);
            this.dgvManageRequests.TabIndex = 10;
            // 
            // RequestID
            // 
            this.RequestID.HeaderText = "Request ID";
            this.RequestID.MinimumWidth = 6;
            this.RequestID.Name = "RequestID";
            this.RequestID.ReadOnly = true;
            // 
            // DocumentType
            // 
            this.DocumentType.HeaderText = "Document Type";
            this.DocumentType.MinimumWidth = 6;
            this.DocumentType.Name = "DocumentType";
            this.DocumentType.ReadOnly = true;
            // 
            // Copies
            // 
            this.Copies.HeaderText = "Copies";
            this.Copies.MinimumWidth = 6;
            this.Copies.Name = "Copies";
            this.Copies.ReadOnly = true;
            // 
            // DateRequested
            // 
            this.DateRequested.HeaderText = "Date Requested";
            this.DateRequested.MinimumWidth = 6;
            this.DateRequested.Name = "DateRequested";
            this.DateRequested.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "TotalAmount";
            this.TotalAmount.MinimumWidth = 6;
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.AutoSize = true;
            this.panel4.BackColor = System.Drawing.Color.LimeGreen;
            this.panel4.Location = new System.Drawing.Point(55, 124);
            this.panel4.MaximumSize = new System.Drawing.Size(941, 2);
            this.panel4.MinimumSize = new System.Drawing.Size(0, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(941, 2);
            this.panel4.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(45, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 58);
            this.label2.TabIndex = 8;
            this.label2.Text = "Manage Requests";
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(59)))));
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(55, 628);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(127, 33);
            this.btnApprove.TabIndex = 11;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(59)))));
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(188, 628);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(127, 33);
            this.btnReject.TabIndex = 11;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnMarkProcessing
            // 
            this.btnMarkProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMarkProcessing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(59)))));
            this.btnMarkProcessing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkProcessing.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarkProcessing.ForeColor = System.Drawing.Color.White;
            this.btnMarkProcessing.Location = new System.Drawing.Point(514, 628);
            this.btnMarkProcessing.Name = "btnMarkProcessing";
            this.btnMarkProcessing.Size = new System.Drawing.Size(138, 33);
            this.btnMarkProcessing.TabIndex = 11;
            this.btnMarkProcessing.Text = "Processing";
            this.btnMarkProcessing.UseVisualStyleBackColor = false;
            this.btnMarkProcessing.Click += new System.EventHandler(this.btnMarkProcessing_Click);
            // 
            // btnReadyForPickup
            // 
            this.btnReadyForPickup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadyForPickup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(59)))));
            this.btnReadyForPickup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadyForPickup.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadyForPickup.ForeColor = System.Drawing.Color.White;
            this.btnReadyForPickup.Location = new System.Drawing.Point(658, 628);
            this.btnReadyForPickup.Name = "btnReadyForPickup";
            this.btnReadyForPickup.Size = new System.Drawing.Size(205, 33);
            this.btnReadyForPickup.TabIndex = 11;
            this.btnReadyForPickup.Text = "Ready for pick-up";
            this.btnReadyForPickup.UseVisualStyleBackColor = false;
            this.btnReadyForPickup.Click += new System.EventHandler(this.btnReadyForPickup_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(59)))));
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(869, 628);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(127, 33);
            this.btnComplete.TabIndex = 11;
            this.btnComplete.Text = "Complete";
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // lblText1
            // 
            this.lblText1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText1.AutoSize = true;
            this.lblText1.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText1.ForeColor = System.Drawing.SystemColors.Control;
            this.lblText1.Location = new System.Drawing.Point(50, 141);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(165, 30);
            this.lblText1.TabIndex = 12;
            this.lblText1.Text = "Sort by Document:";
            // 
            // cmbDocumentTypeFilter
            // 
            this.cmbDocumentTypeFilter.Font = new System.Drawing.Font("Myanmar Text", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDocumentTypeFilter.FormattingEnabled = true;
            this.cmbDocumentTypeFilter.Location = new System.Drawing.Point(221, 137);
            this.cmbDocumentTypeFilter.Name = "cmbDocumentTypeFilter";
            this.cmbDocumentTypeFilter.Size = new System.Drawing.Size(139, 31);
            this.cmbDocumentTypeFilter.TabIndex = 13;
            this.cmbDocumentTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cmbDocumentTypeFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(409, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 30);
            this.label1.TabIndex = 12;
            this.label1.Text = "Role:";
            // 
            // cmbRoleFilter
            // 
            this.cmbRoleFilter.Font = new System.Drawing.Font("Myanmar Text", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoleFilter.FormattingEnabled = true;
            this.cmbRoleFilter.Location = new System.Drawing.Point(468, 136);
            this.cmbRoleFilter.Name = "cmbRoleFilter";
            this.cmbRoleFilter.Size = new System.Drawing.Size(138, 31);
            this.cmbRoleFilter.TabIndex = 13;
            this.cmbRoleFilter.SelectedIndexChanged += new System.EventHandler(this.cmbRoleFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(651, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 30);
            this.label3.TabIndex = 12;
            this.label3.Text = "Status:";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.Font = new System.Drawing.Font("Myanmar Text", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(725, 136);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(138, 31);
            this.cmbStatusFilter.TabIndex = 13;
            this.cmbStatusFilter.SelectionChangeCommitted += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);
            // 
            // ucManageRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(35)))));
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbRoleFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDocumentTypeFilter);
            this.Controls.Add(this.lblText1);
            this.Controls.Add(this.btnMarkProcessing);
            this.Controls.Add(this.btnReadyForPickup);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.dgvManageRequests);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label2);
            this.Name = "ucManageRequests";
            this.Size = new System.Drawing.Size(1040, 746);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvManageRequests;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Copies;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateRequested;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnMarkProcessing;
        private System.Windows.Forms.Button btnReadyForPickup;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.ComboBox cmbDocumentTypeFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRoleFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
    }
}
