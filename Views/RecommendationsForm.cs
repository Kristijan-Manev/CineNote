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
    public partial class RecommendationsForm : Form
    {
       // private List<Movie> allMovies;
        private List<Movie> _recs;          
        private List<Movie> _catalog;

        public RecommendationsForm()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(25, 25, 35); Font = new Font("Segoe UI", 9f);
            btnClose.Click += (_, __) => Close();

            LoadRecommendations();
        }

        private void LoadRecommendations()
        {
            _catalog = MovieCatalog.All();               
            var userMovies = MovieService.LoadMovies();

            var genreGroups = userMovies
            .Where(m => m.Watched)
            .GroupBy(m => m.Genre)
            .ToList();

            int maxCnt = genreGroups.Any() ? genreGroups.Max(g => g.Count()) : 0;

            var favouriteGenres = genreGroups       
                .Where(g => g.Count() == maxCnt)
                .Select(g => g.Key)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var libraryTitles = userMovies
                .Select(m => m.Title)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var pool = _catalog
                .Where(c => !libraryTitles.Contains(c.Title))
                .ToList();

            var favFirst = pool.Where(c => favouriteGenres.Contains(c.Genre)).ToList();
            var nonFav = pool.Where(c => !favouriteGenres.Contains(c.Genre)).ToList();

            var rnd = new Random();
            nonFav = nonFav.OrderBy(_ => rnd.Next()).ToList();

            _recs = favFirst.Concat(nonFav).Take(50).ToList();
            BindGrid();
        }

        private void BindGrid()
        {
            dataGridViewRecs.DataSource = null;
            dataGridViewRecs.DataSource = _recs;

            dataGridViewRecs.Columns["Watched"].Visible = false;
            dataGridViewRecs.Columns["Comment"].Visible = false;
            dataGridViewRecs.Columns["DateWatched"].Visible = false;
            dataGridViewRecs.Columns["Rating"].Visible = false;
            dataGridViewRecs.Columns["Priority"].Visible = false;

            dataGridViewRecs.Columns["Title"].HeaderText = "Title";
            dataGridViewRecs.Columns["Genre"].HeaderText = "Genre";

            if (!dataGridViewRecs.Columns.Contains("AddBtn"))
                AddWatchListButton();

            StyleDataGridView(dataGridViewRecs);

            dataGridViewRecs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AddWatchListButton()
        {
            var btnCol = new DataGridViewButtonColumn
            {
                Name = "AddBtn",
                HeaderText = "",
                Text = "Add to Watchlist",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };

            dataGridViewRecs.Columns.Add(btnCol);

            var cellStyle = btnCol.DefaultCellStyle;
            cellStyle.BackColor = Color.FromArgb(50, 50, 70);
            cellStyle.ForeColor = Color.Gainsboro;
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cellStyle.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StyleDataGridView(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 60);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            grid.DefaultCellStyle.BackColor = Color.FromArgb(28, 28, 38);
            grid.DefaultCellStyle.ForeColor = Color.Gainsboro;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 100);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;

            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            grid.RowHeadersVisible = false;
            grid.AllowUserToResizeRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly = true;

            grid.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 100);
            grid.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 100);
        }

        private void dataGridViewRecs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridViewRecs.Columns[e.ColumnIndex].Name != "AddBtn") return;

            var movie = (Movie)dataGridViewRecs.Rows[e.RowIndex].DataBoundItem;

            var allMovies = MovieService.LoadMovies();
            bool exists = allMovies.Any(m =>
                               string.Equals(m.Title, movie.Title, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                MessageBox.Show($"“{movie.Title}” is already in your library.");
                return;
            }

            var newMovie = new Movie
            {
                Title = movie.Title,
                Genre = movie.Genre,
                Watched = false,
                Priority = 3,
                DateWatched = DateTime.MinValue,  
                Rating = 1,
                Comment = ""
            };
            MovieService.SaveMovie(newMovie);

            _recs.Remove(movie);
            BindGrid();

            MessageBox.Show($"Added “{newMovie.Title}” to your watchlist.");
        }
    }
}
