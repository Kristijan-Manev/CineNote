using CineNote.Models;
using CineNote.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CineNote.Views
{
    public partial class EditMovieForm : Form
    {
        private Movie _movie;
        public EditMovieForm(Movie movie)
        {
            InitializeComponent();

            BackColor = Color.FromArgb(25, 25, 35);
            Font = new Font("Segoe UI", 9f, FontStyle.Regular);

            dtpWatched.SkinColor = Color.FromArgb(35, 35, 50);
            dtpWatched.TextColor = Color.Gainsboro;
            dtpWatched.BorderColor = Color.FromArgb(60, 60, 80);
            dtpWatched.BorderSize = 1;

            StyleButton(btnSaveChanges);
            StyleButton(btnCancel);

            StyleLabel(labelText);
            StyleLabel(labelGenre);
            StyleLabel(labelDateWatched);
            StyleLabel(labelRating);
            StyleLabel(labelReview);

            StyleInput(txtTitle);
            StyleInput(cmbGenre);        
            StyleInput(nudRating);
            StyleInput(txtComment);

            cmbGenre.DropDownStyle = ComboBoxStyle.DropDown;  
            cmbGenre.Items.AddRange(GenreService.LoadAllGenres().ToArray());

            _movie = movie;
            txtTitle.Text = movie.Title;
            cmbGenre.Text = movie.Genre;    
            nudRating.Value = movie.Rating;
            txtComment.Text = movie.Comment;
            dtpWatched.Value = movie.DateWatched;

        }

        void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(40, 40, 55);
            btn.ForeColor = Color.Gainsboro;
            btn.Font = new Font("Segoe UI", 8f, FontStyle.Bold);

            btn.AutoSize = false;
            btn.Size = new Size(88, 26);
            btn.Padding = Padding.Empty;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.AutoEllipsis = true;

            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 80);

            btn.MouseEnter += (_, __) =>
            {
                btn.BackColor = Color.FromArgb(60, 60, 75);
                btn.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 130);
            };
            btn.MouseLeave += (_, __) =>
            {
                btn.BackColor = Color.FromArgb(40, 40, 55);
                btn.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 80);
            };
        }

        void StyleLabel(Label lbl)
        {
            lbl.ForeColor = Color.Gainsboro;
            lbl.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lbl.BackColor = Color.Transparent;
        }
        void StyleInput(Control ctl)
        {
            ctl.BackColor = Color.FromArgb(35, 35, 50);   
            ctl.ForeColor = Color.Gainsboro;

            ctl.Paint += (s, e) =>
            {
                Rectangle r = ctl.ClientRectangle; r.Inflate(-1, -1);
                using (Pen p = new Pen(Color.FromArgb(60, 60, 80)))
                    e.Graphics.DrawRectangle(p, r);
            };
        }

        private static readonly string[] _starterGenres =
{
    "Action", "Comedy", "Drama", "Fantasy",
    "Horror", "Romance", "Sci‑Fi", "Thriller"
};



        private void EditMovieForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            _movie.Title = txtTitle.Text;
            _movie.Genre = cmbGenre.Text.Trim();
            _movie.Rating = (int)nudRating.Value;
            _movie.Comment = txtComment.Text;
            _movie.DateWatched = dtpWatched.Value;

            GenreService.EnsureGenreExists(_movie.Genre);

            DialogResult = DialogResult.OK; 
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;   
            Close();
        }
    }
}
