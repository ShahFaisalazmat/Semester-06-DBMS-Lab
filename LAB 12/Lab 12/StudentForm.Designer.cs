// ============================================================
// Lab 12: Connection of C# Application Forms with SQL Server
// File: StudentForm.Designer.cs  (Auto-generated designer code)
// ============================================================

namespace StudentEnrollmentSystem
{
    partial class StudentForm
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private System.Windows.Forms.Label       lblTitle;
        private System.Windows.Forms.Label       lblName;
        private System.Windows.Forms.Label       lblCourse;
        private System.Windows.Forms.Label       lblEmail;
        private System.Windows.Forms.TextBox     txtName;
        private System.Windows.Forms.TextBox     txtCourse;
        private System.Windows.Forms.TextBox     txtEmail;
        private System.Windows.Forms.Button      btnRegister;
        private System.Windows.Forms.Button      btnOpenSearch;
        private System.Windows.Forms.Panel       pnlHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components     = new System.ComponentModel.Container();
            this.lblTitle       = new System.Windows.Forms.Label();
            this.lblName        = new System.Windows.Forms.Label();
            this.lblCourse      = new System.Windows.Forms.Label();
            this.lblEmail       = new System.Windows.Forms.Label();
            this.txtName        = new System.Windows.Forms.TextBox();
            this.txtCourse      = new System.Windows.Forms.TextBox();
            this.txtEmail       = new System.Windows.Forms.TextBox();
            this.btnRegister    = new System.Windows.Forms.Button();
            this.btnOpenSearch  = new System.Windows.Forms.Button();
            this.pnlHeader      = new System.Windows.Forms.Panel();

            this.SuspendLayout();

            // ---- Form ----
            this.Text            = "Student Course Enrollment System";
            this.Size            = new System.Drawing.Size(480, 400);
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.BackColor       = System.Drawing.Color.WhiteSmoke;
            this.Font            = new System.Drawing.Font("Segoe UI", 9.5f);

            // ---- pnlHeader ----
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.pnlHeader.Bounds    = new System.Drawing.Rectangle(0, 0, 480, 60);
            this.Controls.Add(this.pnlHeader);

            // ---- lblTitle ----
            this.lblTitle.Text      = "Student Registration";
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.Bounds    = new System.Drawing.Rectangle(20, 12, 420, 36);
            this.pnlHeader.Controls.Add(this.lblTitle);

            // ---- lblName ----
            this.lblName.Text   = "Full Name:";
            this.lblName.Bounds = new System.Drawing.Rectangle(40, 90, 100, 24);

            // ---- txtName ----
            this.txtName.Bounds    = new System.Drawing.Rectangle(160, 88, 260, 26);
            this.txtName.MaxLength = 100;

            // ---- lblCourse ----
            this.lblCourse.Text   = "Course:";
            this.lblCourse.Bounds = new System.Drawing.Rectangle(40, 135, 100, 24);

            // ---- txtCourse ----
            this.txtCourse.Bounds    = new System.Drawing.Rectangle(160, 133, 260, 26);
            this.txtCourse.MaxLength = 100;

            // ---- lblEmail ----
            this.lblEmail.Text   = "Email:";
            this.lblEmail.Bounds = new System.Drawing.Rectangle(40, 180, 100, 24);

            // ---- txtEmail ----
            this.txtEmail.Bounds    = new System.Drawing.Rectangle(160, 178, 260, 26);
            this.txtEmail.MaxLength = 150;

            // ---- btnRegister ----
            this.btnRegister.Text      = "Register Student";
            this.btnRegister.Bounds    = new System.Drawing.Rectangle(160, 230, 160, 36);
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(0, 153, 76);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnRegister.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.Click    += new System.EventHandler(this.btnRegister_Click);

            // ---- btnOpenSearch ----
            this.btnOpenSearch.Text      = "Search Students →";
            this.btnOpenSearch.Bounds    = new System.Drawing.Rectangle(130, 285, 200, 32);
            this.btnOpenSearch.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnOpenSearch.ForeColor = System.Drawing.Color.White;
            this.btnOpenSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenSearch.Font      = new System.Drawing.Font("Segoe UI", 9.5f);
            this.btnOpenSearch.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnOpenSearch.Click    += new System.EventHandler(this.btnOpenSearch_Click);

            // ---- Add controls to Form ----
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblName, this.txtName,
                this.lblCourse, this.txtCourse,
                this.lblEmail, this.txtEmail,
                this.btnRegister,
                this.btnOpenSearch
            });

            this.ResumeLayout(false);
        }
    }
}
