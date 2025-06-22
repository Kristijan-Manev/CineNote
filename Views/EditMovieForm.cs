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
    public partial class EditMovieForm : Form
    {
        private Movie _movie;
        public EditMovieForm(Movie movie)
        {
            InitializeComponent();
            _movie = movie;

            txtTitle.Text = _movie.Title;
            txtGenre.Text = _movie.Genre;
            nudRating.Value = _movie.Rating;
            txtComment.Text = _movie.Comment;
            dtpWatched.Value = _movie.DateWatched;
          //  checkBoxWatched.Checked = _movie.Watched;
        }
        private void EditMovieForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            _movie.Title = txtTitle.Text;
            _movie.Genre = txtGenre.Text;
            _movie.Rating = (int)nudRating.Value;
            _movie.Comment = txtComment.Text;
            _movie.DateWatched = dtpWatched.Value;
         //   _movie.Watched = chkWatched.Checked;
 
            DialogResult = DialogResult.OK; 
            Close();
        }
    }
}
