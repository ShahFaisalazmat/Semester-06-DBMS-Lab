// ============================================================
// Lab 12: Connection of C# Application Forms with SQL Server
// File: Program.cs
// ============================================================

using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentEnrollmentSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // Enable visual styles for modern UI
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Optional: Test database connection before launching form
                // Uncomment if you want to verify database connectivity first
                /*
                if (!TestDatabaseConnection())
                {
                    DialogResult result = MessageBox.Show(
                        "Unable to connect to the database. Do you want to continue anyway?",
                        "Database Connection Error",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    
                    if (result == DialogResult.No)
                        return;
                }
                */

                // Launch the Student Registration Form
                Application.Run(new StudentForm());
            }
            catch (Exception ex)
            {
                // Handle any unhandled exceptions at application startup
                MessageBox.Show(
                    $"Application failed to start:\n{ex.Message}\n\n{ex.StackTrace}",
                    "Startup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Optional method to test database connection before launching the application
        /// </summary>
        /// <returns>True if connection successful, false otherwise</returns>
        private static bool TestDatabaseConnection()
        {
            // Update this connection string with your actual database details
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; " +
                                      "Initial Catalog=StudentEnrollmentDB; " +
                                      "Integrated Security=True; " +
                                      "Connect Timeout=5";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}