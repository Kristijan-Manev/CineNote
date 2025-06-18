using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CineNote.Models;
using CineNote.Services;


namespace CineNote.Views
{
    public partial class WatchlistForm : Form
    {
        private List<Movie> watchlist;
        public WatchlistForm()
        {
            InitializeComponent();
            LoadWatchlist();
        }

        private void LoadWatchlist()
        {
            watchlist=MovieService.LoadMovies().Where(m=>!m.Watched).OrderByDescending(m=>m.Priority).ToList();

            labelCount.Text = $"You want to see {watchlist.Count} movies";

            dataGridViewWatchlist.DataSource = null;
            dataGridViewWatchlist.DataSource = watchlist;

            dataGridViewWatchlist.Columns["Watched"].Visible = false;
            dataGridViewWatchlist.Columns["Rating"].Visible = false;
            dataGridViewWatchlist.Columns["Comment"].Visible = false;
            dataGridViewWatchlist.Columns["DateWatched"].Visible = false;

            dataGridViewWatchlist.Columns["Title"].HeaderText = "Title";
            dataGridViewWatchlist.Columns["Genre"].HeaderText = "Genre";
            dataGridViewWatchlist.Columns["Priority"].HeaderText = "Priority";

            if (!dataGridViewWatchlist.Columns.Contains("MarkWatched"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "MarkWatched";
                btn.HeaderText = "";
                btn.Text = "Watched";
                btn.UseColumnTextForButtonValue = true;
                dataGridViewWatchlist.Columns.Add(btn);
            }
        }

        private void dataGridViewWatchlist_CellContentClick(object sender,DataGridViewCellEventArgs e)
        {
            if (dataGridViewWatchlist.Columns[e.ColumnIndex].Name == "MarkWatched")
            {
                var movie = watchlist[e.RowIndex];
                movie.Watched = true;
                movie.DateWatched = DateTime.Today;

                MovieService.UpdateMovie(movie);

                MessageBox.Show($"Marked '{movie.Title}' as watched.");
                LoadWatchlist();
            }
        }

    }
}
