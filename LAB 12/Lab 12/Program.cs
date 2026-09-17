// ============================================================
// Lab 12: Connection of C# Application Forms with SQL Server
// File: Program.cs
// ============================================================

using System;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Launch the Student Registration Form first
            Application.Run(new StudentForm());
        }
    }
}
