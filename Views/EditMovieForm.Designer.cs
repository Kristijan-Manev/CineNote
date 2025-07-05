namespace CineNote.Views
{
    partial class EditMovieForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.labelReview = new System.Windows.Forms.Label();
            this.nudRating = new System.Windows.Forms.NumericUpDown();
            this.labelRating = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.labelDateWatched = new System.Windows.Forms.Label();
            this.labelGenre = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.labelText = new System.Windows.Forms.Label();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.dtpWatched = new CustomControls.RJControls.RJDatePicker();
            ((System.ComponentModel.ISupportInitialize)(this.nudRating)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(109, 403);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 38);
            this.label6.TabIndex = 28;
            this.label6.Text = "Edit Movie";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(117, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 28);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.Location = new System.Drawing.Point(12, 278);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(99, 27);
            this.btnSaveChanges.TabIndex = 26;
            this.btnSaveChanges.Text = "Save ";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // labelReview
            // 
            this.labelReview.AutoSize = true;
            this.labelReview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReview.Location = new System.Drawing.Point(8, 220);
            this.labelReview.Name = "labelReview";
            this.labelReview.Size = new System.Drawing.Size(56, 20);
            this.labelReview.TabIndex = 25;
            this.labelReview.Text = "Review";
            // 
            // nudRating
            // 
            this.nudRating.Location = new System.Drawing.Point(12, 195);
            this.nudRating.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudRating.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRating.Name = "nudRating";
            this.nudRating.Size = new System.Drawing.Size(208, 22);
            this.nudRating.TabIndex = 24;
            this.nudRating.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelRating
            // 
            this.labelRating.AutoSize = true;
            this.labelRating.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRating.Location = new System.Drawing.Point(8, 172);
            this.labelRating.Name = "labelRating";
            this.labelRating.Size = new System.Drawing.Size(88, 20);
            this.labelRating.TabIndex = 23;
            this.labelRating.Text = "Rating (1-5)";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(12, 243);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(208, 22);
            this.txtComment.TabIndex = 21;
            // 
            // labelDateWatched
            // 
            this.labelDateWatched.AutoSize = true;
            this.labelDateWatched.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateWatched.Location = new System.Drawing.Point(8, 111);
            this.labelDateWatched.Name = "labelDateWatched";
            this.labelDateWatched.Size = new System.Drawing.Size(103, 20);
            this.labelDateWatched.TabIndex = 20;
            this.labelDateWatched.Text = "Date Watched";
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGenre.Location = new System.Drawing.Point(11, 63);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(48, 20);
            this.labelGenre.TabIndex = 18;
            this.labelGenre.Text = "Genre";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(12, 38);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(208, 22);
            this.txtTitle.TabIndex = 17;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText.Location = new System.Drawing.Point(11, 14);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(38, 20);
            this.labelText.TabIndex = 16;
            this.labelText.Text = "Title";
            // 
            // cmbGenre
            // 
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Items.AddRange(new object[] {
            "Action",
            "Animation",
            "Comedy",
            "Drama",
            "Fantasy",
            "Horror",
            "Romance",
            "Sci‑Fi",
            "Thriller"});
            this.cmbGenre.Location = new System.Drawing.Point(12, 84);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(208, 24);
            this.cmbGenre.TabIndex = 29;
            // 
            // dtpWatched
            // 
            this.dtpWatched.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dtpWatched.BorderSize = 0;
            this.dtpWatched.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpWatched.Location = new System.Drawing.Point(12, 134);
            this.dtpWatched.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpWatched.Name = "dtpWatched";
            this.dtpWatched.Size = new System.Drawing.Size(208, 35);
            this.dtpWatched.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.dtpWatched.TabIndex = 30;
            this.dtpWatched.TextColor = System.Drawing.Color.White;
            // 
            // EditMovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 450);
            this.Controls.Add(this.dtpWatched);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.labelReview);
            this.Controls.Add(this.nudRating);
            this.Controls.Add(this.labelRating);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.labelDateWatched);
            this.Controls.Add(this.labelGenre);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.labelText);
            this.Name = "EditMovieForm";
            this.Text = "EditMovieForm";
            this.Load += new System.EventHandler(this.EditMovieForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label labelReview;
        private System.Windows.Forms.NumericUpDown nudRating;
        private System.Windows.Forms.Label labelRating;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label labelDateWatched;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.ComboBox cmbGenre;
        private CustomControls.RJControls.RJDatePicker dtpWatched;
    }
}