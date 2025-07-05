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

namespace CineNote.Views
{
    public partial class AddMovieForm : Form
    {
        public bool MovieAdded { get; private set; } = false;

        public AddMovieForm()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(25, 25, 35);
            Font = new Font("Segoe UI", 9f, FontStyle.Regular);

            dtpWatched.SkinColor = Color.FromArgb(35, 35, 50);
            dtpWatched.TextColor = Color.Gainsboro;
            dtpWatched.BorderColor = Color.FromArgb(60, 60, 80);
            dtpWatched.BorderSize = 1;

            StyleButton(btnSave);
            StyleButton(btnCancel);

            StyleInput(txtTitle);
            StyleComboBox(cmbGenre);
            StyleInput(nudRating);
            StyleInput(numericPriority);
            StyleInput(txtComment);

            PopulateGenreCombo();

            dtpWatched.Enabled = false;
            nudRating.Enabled = false;
            txtComment.Enabled = false;
            numericPriority.Enabled = true;
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

        public void StyleComboBox(ComboBox cb)
        {
            cb.BackColor = Color.FromArgb(35, 35, 50);
            cb.ForeColor = Color.Gainsboro;
            cb.FlatStyle = FlatStyle.Flat;
            cb.Font = new Font("Segoe UI", 9f, FontStyle.Regular);

            cb.Paint += (_, e) =>
            {
                var r = cb.ClientRectangle; r.Inflate(-1, -1);
                var p = new Pen(Color.FromArgb(60, 60, 80));
                e.Graphics.DrawRectangle(p, r);
            };
        }

        private static void StyleInput(Control ctl)
        {
            var bg = Color.FromArgb(35, 35, 50);
            ctl.BackColor = bg;
            ctl.ForeColor = Color.Gainsboro;

            ctl.Paint += (_, pe) =>
            {
                var r = ctl.ClientRectangle;
                r.Inflate(-1, -1);
                pe.Graphics.DrawRectangle(new Pen(Color.FromArgb(60, 60, 80)), r);
            };
        }

        private static readonly string[] _starterGenres =
        {
            "Action", "Comedy", "Drama", "Fantasy",
            "Horror", "Romance", "Sci‑Fi", "Thriller"
        };

        private void PopulateGenreCombo()
        {
            var current = cmbGenre.Text;

            cmbGenre.Items.Clear();
            cmbGenre.Items.AddRange(_starterGenres);

            cmbGenre.Text = current;
        }

        private void AddMovieForm_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string genre = cmbGenre.Text.Trim();       
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || genre == "")
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }

            var movie = new Movie
            {
                Title = txtTitle.Text.Trim(),
                Genre = genre,
                DateWatched = dtpWatched.Value,
                Rating = (int)nudRating.Value,
                Comment = txtComment.Text.Trim(),
                Watched = checkBoxWatched.Checked,
                Priority = (int)numericPriority.Value
            };

            MovieService.SaveMovie(movie);
            MovieAdded = true;

            if (!cmbGenre.Items.Contains(genre))
                cmbGenre.Items.Add(genre);

            MessageBox.Show($"Movie \"{movie.Title}\" saved!");
            DialogResult = DialogResult.OK;   
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxWatched_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBoxWatched.Checked;

            if (!isChecked)
            {
                nudRating.Value = 1;
                dtpWatched.Value = DateTime.Today;
                txtComment.Text = string.Empty;
            }

            dtpWatched.Enabled = isChecked;
            nudRating.Enabled = isChecked;
            txtComment.Enabled = isChecked;

            numericPriority.Enabled = !isChecked;
        }
    }
}
