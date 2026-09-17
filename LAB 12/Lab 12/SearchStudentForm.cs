// ============================================================
// Lab 12: Connection of C# Application Forms with SQL Server
// File: SearchStudentForm.cs  (Student Search Form)
// ============================================================

using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentEnrollmentSystem
{
    public partial class SearchStudentForm : Form
    {
        // Same connection string – keep both forms in sync if you change the server.
        private readonly string connectionString =
            "Server=.\\SQLEXPRESS; Database=StudentDB; Integrated Security=True;";

        public SearchStudentForm()
        {
            InitializeComponent();
        }

        // ----------------------------------------------------------------
        // BUTTON: Search
        // ----------------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtSearchName.Text.Trim();

            // --- Validate ---
            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show(
                    "Please enter a student name to search.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // --- Clear previous results ---
            ClearResultFields();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Case-insensitive partial match (LIKE) so users can search by
                    // first name only, full name, etc.
                    string query = @"
                        SELECT TOP 1 Name, Course, Email
                        FROM   Students
                        WHERE  Name LIKE @Name";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Wrap with wildcards for partial matching
                        cmd.Parameters.AddWithValue("@Name", "%" + searchName + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Student found – populate result labels
                                lblResultName.Text   = "Name:   " + reader["Name"].ToString();
                                lblResultCourse.Text = "Course: " + reader["Course"].ToString();
                                lblResultEmail.Text  = "Email:  " + reader["Email"].ToString();
                                pnlResult.Visible    = true;
                            }
                            else
                            {
                                // Student not found
                                MessageBox.Show(
                                    $"No student found with the name \"{searchName}\".",
                                    "Student Not Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                pnlResult.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(
                    "Database error:\n" + sqlEx.Message,
                    "SQL Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // --- Clear input field after search (as per requirement) ---
            txtSearchName.Clear();
            txtSearchName.Focus();
        }

        // ----------------------------------------------------------------
        // BUTTON: Clear / Reset
        // ----------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchName.Clear();
            ClearResultFields();
            pnlResult.Visible = false;
            txtSearchName.Focus();
        }

        // ----------------------------------------------------------------
        // Helper: reset result display labels
        // ----------------------------------------------------------------
        private void ClearResultFields()
        {
            lblResultName.Text   = string.Empty;
            lblResultCourse.Text = string.Empty;
            lblResultEmail.Text  = string.Empty;
        }
    }
}
