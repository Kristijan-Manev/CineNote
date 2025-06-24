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
        private List<Movie> allMovies;

        public RecommendationsForm()
        {
            InitializeComponent();
            LoadRecommendations();
        }

        private void LoadRecommendations()
        {
            allMovies = MovieService.LoadMovies();

            var watched = allMovies.Where(m => m.Watched).ToList();
            var watchlist = allMovies.Where(m => !m.Watched).ToList();

            // Favorite genre based on watch count
            var favoriteGenre = watched
                .GroupBy(m => m.Genre)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault()?.Key;

            // Top rated genre
            var topRatedGenre = watched
                .GroupBy(m => m.Genre)
                .OrderByDescending(g => g.Average(m => m.Rating))
                .FirstOrDefault()?.Key;

            // High-priority watchlist
            var highPriority = watchlist
                .Where(m => m.Priority >= 3)
                .OrderByDescending(m => m.Priority)
                .Take(5)
                .ToList();

            // Compile recommendation list
            var recommended = watchlist
                .Where(m => m.Genre == favoriteGenre || m.Genre == topRatedGenre)
                .Union(highPriority)
                .Distinct()
                .Take(10)
                .ToList();

            dataGridViewRecs.DataSource = null;
            dataGridViewRecs.DataSource = recommended;

            dataGridViewRecs.Columns["Watched"].Visible = false;
            dataGridViewRecs.Columns["Comment"].Visible = false;
            dataGridViewRecs.Columns["DateWatched"].Visible = false;
            dataGridViewRecs.Columns["Rating"].Visible = false;

            dataGridViewRecs.Columns["Title"].HeaderText = "Title";
            dataGridViewRecs.Columns["Genre"].HeaderText = "Genre";
            dataGridViewRecs.Columns["Priority"].HeaderText = "Priority";

            // Style it
            StyleDataGridView(dataGridViewRecs);
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
        }

    }
}
