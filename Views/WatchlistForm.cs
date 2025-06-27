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
        private List<Movie> originalOrder;
        private enum SortDir { Asc, Desc }

        public WatchlistForm()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(25, 25, 35); 

            StyleLabel(labelCount);
            StyleComboBox(comboSortPriority);

            comboSortPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSortPriority.Items.Clear();

            comboSortPriority.Items.Add(new ComboItem("Priority (High - Low)", SortDir.Desc));
            comboSortPriority.Items.Add(new ComboItem("Priority (Low - High)", SortDir.Asc));
            comboSortPriority.SelectedIndex = -1;

            LoadWatchlist();
        }

        private void StyleLabel(Label label)
        {
            label.ForeColor = Color.Gainsboro;
            label.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            label.BackColor = Color.Transparent;
        }

        private void StyleComboBox(ComboBox combo)
        {
            combo.BackColor = Color.FromArgb(35, 35, 50);
            combo.ForeColor = Color.Gainsboro;
            combo.FlatStyle = FlatStyle.Flat;
            combo.Font = new Font("Segoe UI", 9f, FontStyle.Regular);

            combo.Paint += (_, pe) =>
            {
                var r = combo.ClientRectangle;
                r.Inflate(-1, -1);
                pe.Graphics.DrawRectangle(new Pen(Color.FromArgb(60, 60, 80)), r);
            };
        }

        private sealed class ComboItem
        {
            public string Display { get; }
            public SortDir Direction { get; }

            public ComboItem(string display, SortDir dir)
            {
                Display = display;
                Direction = dir;
            }

            public override string ToString() => Display;   
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

            var selBack = Color.FromArgb(60, 60, 90);   
            var selFore = Color.White;
            grid.DefaultCellStyle.SelectionBackColor = selBack;
            grid.DefaultCellStyle.SelectionForeColor = selFore;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = selBack;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = selFore;

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grid.RowHeadersVisible = false;
            grid.AllowUserToResizeRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly = true;
        }
        
        private void LoadWatchlist()
        {
            watchlist = MovieService.LoadMovies()
                 .Where(m => !m.Watched)
                 .ToList();

            originalOrder = new List<Movie>(watchlist);

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
            if (comboSortPriority.SelectedIndex < 0)
            {
               watchlist = new List<Movie>(originalOrder);
            }
            else if (comboSortPriority.SelectedItem is ComboItem item)
            {
               watchlist = item.Direction == SortDir.Asc
                         ? originalOrder.OrderBy(m => m.Priority).ToList()
                         : originalOrder.OrderByDescending(m => m.Priority).ToList();
            }
            
            RefreshGrid();
        }

        private void RefreshGrid()
        {

            dataGridViewWatchlist.DataSource = null;
            dataGridViewWatchlist.DataSource = watchlist;

            StyleDataGridView(dataGridViewWatchlist);
            if (dataGridViewWatchlist.Columns.Contains("Priority"))
                dataGridViewWatchlist.Columns["Priority"].Visible = false;

            dataGridViewWatchlist.Columns["Watched"].Visible = false;
            dataGridViewWatchlist.Columns["Rating"].Visible = false;
            dataGridViewWatchlist.Columns["Comment"].Visible = false;
            dataGridViewWatchlist.Columns["DateWatched"].Visible = false;

            dataGridViewWatchlist.Columns["Title"].HeaderText = "Title";
            dataGridViewWatchlist.Columns["Genre"].HeaderText = "Genre";
       
            if (dataGridViewWatchlist.Columns.Contains("MarkWatched"))
                dataGridViewWatchlist.Columns.Remove("MarkWatched");

            var btn = new DataGridViewButtonColumn
            {
                Name = "MarkWatched",
                HeaderText = "",
                Text = "✓ Watched",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };

            dataGridViewWatchlist.Columns.Add(btn);

            dataGridViewWatchlist.Columns["Title"].FillWeight = 45;
            dataGridViewWatchlist.Columns["Genre"].FillWeight = 35;
            dataGridViewWatchlist.Columns["MarkWatched"].FillWeight = 20;
            dataGridViewWatchlist.Columns["MarkWatched"].MinimumWidth = 90;

            dataGridViewWatchlist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewWatchlist.ReadOnly = true;
            dataGridViewWatchlist.Columns["MarkWatched"].DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 70);
            dataGridViewWatchlist.Columns["MarkWatched"].DefaultCellStyle.ForeColor = Color.Gainsboro;
            dataGridViewWatchlist.Columns["MarkWatched"].DefaultCellStyle.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            dataGridViewWatchlist.Columns["MarkWatched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            labelCount.Text = $"You want to see {watchlist.Count} movies.";
        }


        private void comboSortPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyPriorityCombo();
        }
    }
}
