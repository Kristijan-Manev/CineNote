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
        public AddMovieForm()
        {
            InitializeComponent();
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
                Rating = (int)nudRating.Value,
                Comment = txtComment.Text,
                Watched = checkBoxWatched.Checked
            };

            MovieService.SaveMovie(movie);

            MessageBox.Show("Movie saved!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
