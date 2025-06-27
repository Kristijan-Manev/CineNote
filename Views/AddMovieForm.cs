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
            StyleFormButton(btnSave);
            StyleFormButton(btnCancel);

            StyleInput(txtTitle);
            StyleInput(txtGenre);
            StyleInput(nudRating);
            StyleInput(numericPriority);
            StyleInput(txtComment);
            StyleInput(dtpWatched);


            dtpWatched.Enabled = false;
            nudRating.Enabled = false;  
            txtComment.Enabled = false;

            numericPriority.Enabled = true;
        }

        void StyleFormButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(40, 40, 55);   
            btn.ForeColor = Color.Gainsboro;
            btn.Font = new Font("Segoe UI", 7, FontStyle.Bold);

            btn.Padding = new Padding(10, 4, 10, 4);    
            btn.Height = 22;                       
            btn.Width = 100;                       
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 80);

            btn.MouseEnter += (_, __) => btn.BackColor = Color.FromArgb(60, 60, 75);
            btn.MouseLeave += (_, __) => btn.BackColor = Color.FromArgb(50, 50, 65);
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

        private void AddMovieForm_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtGenre.Text)) {
                MessageBox.Show("Please fill in all fields!");
                return;
            }

            var movie = new Movie
            {
                Title = txtTitle.Text,
                Genre = txtGenre.Text,
                DateWatched = dtpWatched.Value,
                Rating = (int) nudRating.Value,
                Comment = txtComment.Text,
                Watched = checkBoxWatched.Checked,
                Priority = (int) numericPriority.Value

            };

            MovieService.SaveMovie(movie);
            MovieAdded = true;

            MessageBox.Show("Movie saved!");
            this.Close();
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
