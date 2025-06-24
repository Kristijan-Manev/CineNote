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
        private enum SortDir { Asc, Desc }

        private sealed class ComboItem
        {
            public string Display { get; }
            public SortDir Direction { get; }

            public ComboItem(string display, SortDir dir)
            {
                Display = display;
                Direction = dir;
            }

            public override string ToString() => Display;   // what ComboBox shows
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
        public WatchlistForm()
        {
            InitializeComponent();
            comboSortPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSortPriority.Items.Clear();

            comboSortPriority.Items.Add(new ComboItem("Priority (High - Low)", SortDir.Desc));
            comboSortPriority.Items.Add(new ComboItem("Priority (Low - High)", SortDir.Asc));
            comboSortPriority.SelectedIndex = -1; 
            LoadWatchlist();
        }

        private void LoadWatchlist()
        {
            watchlist=MovieService.LoadMovies().Where(m=>!m.Watched).OrderByDescending(m=>m.Priority).ToList();

            RefreshGrid();
        }

        private void dataGridViewWatchlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridViewWatchlist.Columns[e.ColumnIndex].Name == "MarkWatched")
            {
                var movie = watchlist[e.RowIndex];

                movie.Watched = true;
                movie.DateWatched = DateTime.Today;

                MovieService.UpdateMovie(movie);
                watchlist.RemoveAt(e.RowIndex);
                RefreshGrid();

                this.DialogResult = DialogResult.OK;
            }
        }

        private void ApplyPriorityCombo()
        {
            if (comboSortPriority.SelectedItem is ComboItem item)
            {
                if (item.Direction == SortDir.Asc)
                    watchlist = watchlist.OrderBy(m => m.Priority).ToList();
                else                // SortDir.Desc
                    watchlist = watchlist.OrderByDescending(m => m.Priority).ToList();

                RefreshGrid();
            }
        }

        private void RefreshGrid()
        {

            dataGridViewWatchlist.DataSource = null;
            dataGridViewWatchlist.DataSource = watchlist;

            StyleDataGridView(dataGridViewWatchlist);

            dataGridViewWatchlist.Columns["Watched"].Visible = false;
            dataGridViewWatchlist.Columns["Rating"].Visible = false;
            dataGridViewWatchlist.Columns["Comment"].Visible = false;
            dataGridViewWatchlist.Columns["DateWatched"].Visible = false;

            dataGridViewWatchlist.Columns["Title"].HeaderText = "Title";
            dataGridViewWatchlist.Columns["Genre"].HeaderText = "Genre";
            dataGridViewWatchlist.Columns["Priority"].HeaderText = "Priority";

            if (dataGridViewWatchlist.Columns.Contains("MarkWatched"))
                dataGridViewWatchlist.Columns.Remove("MarkWatched");

            var btn = new DataGridViewButtonColumn
            {
                Name = "MarkWatched",
                HeaderText = "",
                Text = "Watched",
                UseColumnTextForButtonValue = true
            };
            dataGridViewWatchlist.Columns.Add(btn);

            dataGridViewWatchlist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewWatchlist.ReadOnly = true;

            labelCount.Text = $"You want to see {watchlist.Count} movies.";
        }


        private void comboSortPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyPriorityCombo();
        }
    }
}
