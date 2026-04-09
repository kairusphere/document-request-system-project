
namespace Cachero_Group___Document_Request_System_Project
{
    partial class ucRequestStatus
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvRequestStatus = new System.Windows.Forms.DataGridView();
            this.RequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Copies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateRequested = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.AutoSize = true;
            this.panel4.BackColor = System.Drawing.Color.LimeGreen;
            this.panel4.Location = new System.Drawing.Point(44, 95);
            this.panel4.MaximumSize = new System.Drawing.Size(941, 2);
            this.panel4.MinimumSize = new System.Drawing.Size(0, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(941, 2);
            this.panel4.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(34, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 58);
            this.label2.TabIndex = 5;
            this.label2.Text = "Request Status";
            // 
            // dgvRequestStatus
            // 
            this.dgvRequestStatus.AllowUserToAddRows = false;
            this.dgvRequestStatus.AllowUserToDeleteRows = false;
            this.dgvRequestStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRequestStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequestStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequestStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RequestID,
            this.DocumentType,
            this.Copies,
            this.DateRequested,
            this.TotalAmount,
            this.Status});
            this.dgvRequestStatus.Location = new System.Drawing.Point(44, 118);
            this.dgvRequestStatus.MultiSelect = false;
            this.dgvRequestStatus.Name = "dgvRequestStatus";
            this.dgvRequestStatus.ReadOnly = true;
            this.dgvRequestStatus.RowHeadersWidth = 51;
            this.dgvRequestStatus.RowTemplate.Height = 24;
            this.dgvRequestStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequestStatus.Size = new System.Drawing.Size(941, 539);
            this.dgvRequestStatus.TabIndex = 7;
            this.dgvRequestStatus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequestStatus_CellContentClick);
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
            // ucRequestStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(35)))));
            this.Controls.Add(this.dgvRequestStatus);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label2);
            this.Name = "ucRequestStatus";
            this.Size = new System.Drawing.Size(1037, 706);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvRequestStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Copies;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateRequested;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}
