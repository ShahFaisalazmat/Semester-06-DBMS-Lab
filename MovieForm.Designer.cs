namespace MovieManagementSystem
{
    partial class MovieForm
    {
        private System.ComponentModel.IContainer components = null;
        
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMovieID = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblReleaseYear = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.txtMovieID = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.txtReleaseYear = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // Form
            this.Text = "Movie Management System";
            this.Size = new System.Drawing.Size(400, 350);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            
            // lblMovieID
            this.lblMovieID.AutoSize = true;
            this.lblMovieID.Location = new System.Drawing.Point(50, 40);
            this.lblMovieID.Name = "lblMovieID";
            this.lblMovieID.Size = new System.Drawing.Size(54, 17);
            this.lblMovieID.TabIndex = 0;
            this.lblMovieID.Text = "Movie ID:";
            
            // txtMovieID
            this.txtMovieID.Location = new System.Drawing.Point(140, 37);
            this.txtMovieID.Name = "txtMovieID";
            this.txtMovieID.Size = new System.Drawing.Size(200, 22);
            this.txtMovieID.TabIndex = 1;
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(50, 80);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(39, 17);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title:";
            
            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(140, 77);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 22);
            this.txtTitle.TabIndex = 3;
            
            // lblGenre
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(50, 120);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(48, 17);
            this.lblGenre.TabIndex = 4;
            this.lblGenre.Text = "Genre:";
            
            // txtGenre
            this.txtGenre.Location = new System.Drawing.Point(140, 117);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(200, 22);
            this.txtGenre.TabIndex = 5;
            
            // lblReleaseYear
            this.lblReleaseYear.AutoSize = true;
            this.lblReleaseYear.Location = new System.Drawing.Point(50, 160);
            this.lblReleaseYear.Name = "lblReleaseYear";
            this.lblReleaseYear.Size = new System.Drawing.Size(87, 17);
            this.lblReleaseYear.TabIndex = 6;
            this.lblReleaseYear.Text = "Release Year:";
            
            // txtReleaseYear
            this.txtReleaseYear.Location = new System.Drawing.Point(140, 157);
            this.txtReleaseYear.Name = "txtReleaseYear";
            this.txtReleaseYear.Size = new System.Drawing.Size(200, 22);
            this.txtReleaseYear.TabIndex = 7;
            
            // lblRating
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(50, 200);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(49, 17);
            this.lblRating.TabIndex = 8;
            this.lblRating.Text = "Rating:";
            
            // txtRating
            this.txtRating.Location = new System.Drawing.Point(140, 197);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(200, 22);
            this.txtRating.TabIndex = 9;
            
            // btnInsert
            this.btnInsert.Location = new System.Drawing.Point(80, 250);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 35);
            this.btnInsert.TabIndex = 10;
            this.btnInsert.Text = "Insert Movie";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            
            // btnClear
            this.btnClear.Location = new System.Drawing.Point(210, 250);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            
            // Add controls to form
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.txtReleaseYear);
            this.Controls.Add(this.lblReleaseYear);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtMovieID);
            this.Controls.Add(this.lblMovieID);
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMovieID;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblReleaseYear;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox txtMovieID;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtReleaseYear;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClear;
    }
}