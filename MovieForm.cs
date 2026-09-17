// ============================================================
// Lab 12: Connection of C# Application Forms with SQL Server
// File: StudentForm.cs  (Registration Form)
// ============================================================

using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentEnrollmentSystem
{
    public partial class StudentForm : Form
    {
        // ------------------------------------------------------------------
        // Connection string – update the server name to match your machine.
        // Examples:
        //   "Server=.\SQLEXPRESS; ..."   (SQL Server Express, default instance)
        //   "Server=localhost; ..."       (default SQL Server instance)
        // ------------------------------------------------------------------
        private readonly string connectionString =
            "Server=.\\SQLEXPRESS; Database=StudentDB; Integrated Security=True;";

        // ctor
        public StudentForm()
        {
            InitializeComponent();
        }

        // ----------------------------------------------------------------
        // BUTTON: Register
        // ----------------------------------------------------------------
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // --- 1. Trim inputs ---
            string MovieID = txtMovieID.Text.Trim();
            string Title = txtTitle.Text.Trim();
            string Genre  = txtGenre.Text.Trim();
	    string ReleaseYear  = txtRealeaseYear.Text.Trim();
	    string Rating  = txtRating.Text.Trim();

            // --- 2. Validate: no field empty ---
            if (string.IsNullOrEmpty(MovieID) ||
                string.IsNullOrEmpty(Title) ||
                string.IsNullOrEmpty(Genre))
            {
                MessageBox.Show(
                    "All fields are required. Please fill in MovieId, Title, Genre, ReleaseYear, and Rating.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // --- 3. Insert into database ---
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Parameterised query prevents SQL injection
                    string query = @"
                        INSERT INTO movie (MovieID, Title, Genre, ReleaseYear, Rating)
                        VALUES (@MovieID, @Title, @Genre, @ReleaseYear, @Rating)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MovieID",   MovieID);
                        cmd.Parameters.AddWithValue("@Title", Title);
                        cmd.Parameters.AddWithValue("@Genre",  Genre);
		 	cmd.Parameters.AddWithValue("@ReleaseYear",  ReleaseYear);
 			cmd.Parameters.AddWithValue("@rating",  rating);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                $"movie \"{movieID}\" has been registered successfully!",
                                "Registration Successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Registration failed. No record was inserted.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
        }
