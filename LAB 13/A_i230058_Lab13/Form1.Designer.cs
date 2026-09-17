namespace LibraryManagementSystem
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblBookID;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblBookID = new System.Windows.Forms.Label();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();

            // lblBookID
            this.lblBookID.AutoSize = true;
            this.lblBookID.Location = new System.Drawing.Point(12, 15);
            this.lblBookID.Text = "Book ID:";
            // txtBookID
            this.txtBookID.Location = new System.Drawing.Point(100, 12);
            this.txtBookID.ReadOnly = true;
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 45);
            this.lblTitle.Text = "Title:";
            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(100, 42);
            this.txtTitle.Width = 200;
            // lblAuthor
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(12, 75);
            this.lblAuthor.Text = "Author:";
            // txtAuthor
            this.txtAuthor.Location = new System.Drawing.Point(100, 72);
            this.txtAuthor.Width = 200;
            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(12, 105);
            this.lblCategory.Text = "Category:";
            // cmbCategory
            this.cmbCategory.Location = new System.Drawing.Point(100, 102);
            this.cmbCategory.Width = 200;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] { "Fiction", "Non-Fiction", "Classic", "Romance", "Dystopian", "Science", "History" });
            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 135);
            this.lblQuantity.Text = "Quantity:";
            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(100, 132);
            this.txtQuantity.Width = 100;
            // Buttons
            this.btnAdd.Location = new System.Drawing.Point(100, 170);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Location = new System.Drawing.Point(180, 170);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Location = new System.Drawing.Point(260, 170);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnView.Location = new System.Drawing.Point(340, 170);
            this.btnView.Text = "View All";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            this.btnGenerateReport.Location = new System.Drawing.Point(440, 170);
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // dgvBooks
            this.dgvBooks.Location = new System.Drawing.Point(12, 210);
            this.dgvBooks.Size = new System.Drawing.Size(780, 200);
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellClick);
            // reportViewer
            this.reportViewer.Location = new System.Drawing.Point(12, 420);
            this.reportViewer.Size = new System.Drawing.Size(780, 350);
            this.reportViewer.Visible = false;
            // Form1
            this.ClientSize = new System.Drawing.Size(810, 790);
            this.Controls.Add(this.lblBookID);
            this.Controls.Add(this.txtBookID);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.dgvBooks);
            this.Controls.Add(this.reportViewer);
            this.Text = "Library Management System";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}