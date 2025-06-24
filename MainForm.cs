using CineNote.Models;
using CineNote.Services;
using CineNote.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineNote
{
    public partial class MainForm : Form
    {
        private Color sidebarBg = Color.FromArgb(30, 30, 40);
        private Color sidebarBtnBg = Color.FromArgb(40, 40, 55);
        private Color sidebarTextColor = Color.Gainsboro;
        private Font sidebarFont = new Font("Segoe UI", 10, FontStyle.Bold);
        private List<Movie> movies = new List<Movie>();
        public MainForm()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(25, 25, 35);

            StyleSidebar();
            StyleMainActionButtons();

            SendMessage(comboGenreFilter.Handle, CB_SETCUEBANNER, IntPtr.Zero, "GENRE");
            SendMessage(comboSortBy.Handle, CB_SETCUEBANNER, IntPtr.Zero, "SORT BY");
            
            LoadAllMovies();
            UpdateGrid(movies.Where(m=>m.Watched).ToList());
        }

        private void StyleSidebar()
        {
            panelSidebar.BackColor = sidebarBg;

            foreach (var btn in panelSidebar.Controls.OfType<Button>())
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = sidebarBtnBg;
                btn.ForeColor = sidebarTextColor;
                btn.Font = sidebarFont;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Padding = new Padding(10, 0, 0, 0);

                btn.MouseEnter += (s, e) => { btn.BackColor = Color.FromArgb(60, 60, 80); };
                btn.MouseLeave += (s, e) => { btn.BackColor = sidebarBtnBg; };
            }
        }

        private void StyleMainActionButtons()
        {
            var buttons = new List<Button> { btnAddMovie, btnEditMovie, btnDeleteSelected, btnApplyFilter };

            foreach (var btn in buttons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.FromArgb(50, 50, 65); 
                btn.ForeColor = Color.Gainsboro;
                btn.Font = new Font("Segoe UI", 8f, FontStyle.Regular); 
                btn.Padding = new Padding(8, 3, 8, 3); 
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Cursor = Cursors.Hand;
                btn.AutoSize = false;
                btn.Height = 25; 
                btn.Width = 80;

                btn.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
                btn.FlatAppearance.BorderSize = 1;

                btn.MouseEnter += (s, e) => { btn.BackColor = Color.FromArgb(60, 60, 75); };
                btn.MouseLeave += (s, e) => { btn.BackColor = Color.FromArgb(50, 50, 65); };
                btn.MouseEnter += (s, e) =>
                {
                    btn.BackColor = Color.FromArgb(60, 60, 75);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 130);
                };

                btn.MouseLeave += (s, e) =>
                {
                    btn.BackColor = Color.FromArgb(50, 50, 65);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
                };
            }
        }

        private void StyleDataGridView(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 60);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            var backColor = Color.FromArgb(28, 28, 38);
            var foreColor = Color.Gainsboro;
            var selBack = Color.FromArgb(70, 70, 100);
            var selFore = Color.White;

            // 🌑 Apply to all necessary styles
            grid.DefaultCellStyle.BackColor = backColor;
            grid.DefaultCellStyle.ForeColor = foreColor;
            grid.DefaultCellStyle.SelectionBackColor = selBack;
            grid.DefaultCellStyle.SelectionForeColor = selFore;

            grid.RowsDefaultCellStyle.BackColor = backColor;
            grid.RowsDefaultCellStyle.ForeColor = foreColor;
            grid.RowsDefaultCellStyle.SelectionBackColor = selBack;
            grid.RowsDefaultCellStyle.SelectionForeColor = selFore;

            grid.AlternatingRowsDefaultCellStyle.BackColor = backColor;
            grid.AlternatingRowsDefaultCellStyle.ForeColor = foreColor;
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = selBack;
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = selFore;

            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.DefaultCellStyle.SelectionBackColor = selBack;
                col.DefaultCellStyle.SelectionForeColor = selFore;
            }

            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.RowHeadersVisible = false;
            grid.AllowUserToResizeRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetHeaders();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private const int CB_SETCUEBANNER = 0x1703;

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            var addMovieForm = new AddMovieForm();
            addMovieForm.ShowDialog();

            if (addMovieForm.MovieAdded)
            {
                LoadAllMovies();
                var watchedOnly = movies.Where(m=>m.Watched).ToList();
                UpdateGrid(watchedOnly);
            }
        }

        private void dataGridViewMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a movie to delete!");
                return;
            }

            string title = dataGridViewMovies.SelectedRows[0].Cells["Title"].Value.ToString();
            string genre = dataGridViewMovies.SelectedRows[0].Cells["Genre"].Value.ToString();

            movies = MovieService.LoadMovies();

            var target = movies.FirstOrDefault(m=>m.Title==title && m.Genre==genre);
            if (target == null) return;

            movies.Remove(target);
            MovieService.SaveAllMovies(movies);

            UpdateGrid(movies.Where(m=>m.Watched).ToList());
            MessageBox.Show($"Deleted '{title}'.");

        }

        private void ApplyFilter()
        {
            string filter = comboBoxFilter.SelectedItem.ToString();

            List<Movie> filtered;

            if (filter == "Watched")
            {
                filtered = movies.Where(m => m.Watched).ToList();
            }
            else if (filter == "Watchlist")
            {
                filtered = movies.Where(m => !m.Watched).ToList();
            }
            else
                filtered = movies;

            dataGridViewMovies.DataSource = null;
            dataGridViewMovies.DataSource = filtered;

        }

        private void SetHeaders()
        {
              if (dataGridViewMovies.Columns.Contains("Watched"))
                dataGridViewMovies.Columns.Remove("Watched");
            
            if (dataGridViewMovies.Columns.Contains("Priority"))
                dataGridViewMovies.Columns["Priority"].Visible =false;

            if (dataGridViewMovies.Columns.Contains("Title"))
                dataGridViewMovies.Columns["Title"].HeaderText = "Title";
            if (dataGridViewMovies.Columns.Contains("Genre"))
                dataGridViewMovies.Columns["Genre"].HeaderText = "Genre";
            if (dataGridViewMovies.Columns.Contains("Rating"))
                dataGridViewMovies.Columns["Rating"].HeaderText = "Rating ★";
            if (dataGridViewMovies.Columns.Contains("Comment"))
                dataGridViewMovies.Columns["Comment"].HeaderText = "Your Review";
            if (dataGridViewMovies.Columns.Contains("DateWatched"))
                dataGridViewMovies.Columns["DateWatched"].HeaderText = "Date Watched";

        }

        private void UpdateGrid(List<Movie> list)
        {
            dataGridViewMovies.DataSource = null;
            dataGridViewMovies.DataSource = list;

            StyleDataGridView(dataGridViewMovies);
            SetHeaders();

            dataGridViewMovies.CurrentCell = null;
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            var filtered = movies;

            string status = comboBoxFilter.SelectedItem?.ToString()??"All";
            if (status == "Watched")
                filtered = filtered.Where(m => m.Watched).ToList();
            else if(status=="Watchlist")
                filtered=filtered.Where(m=>!m.Watched).ToList();

            string selectedGenre = comboGenreFilter.SelectedItem?.ToString();   
            if(!string.IsNullOrWhiteSpace(selectedGenre) && selectedGenre!="All") 
            { 
                filtered=filtered.Where(m=>m.Genre==selectedGenre).ToList();
            }

            string sortOption = comboSortBy.SelectedItem?.ToString();
            switch(sortOption)
            {
                case "Title (A-Z)":
                    filtered = filtered.OrderBy(m=>m.Title).ToList();
                    break;
                case "Title (Z-A)":
                    filtered = filtered.OrderByDescending(m => m.Title).ToList();
                    break;
                case "Rating (High to Low)":
                    filtered = filtered.OrderByDescending(m => m.Rating).ToList();
                    break;
                case "Rating (Low to High)":
                    filtered = filtered.OrderBy(m => m.Rating).ToList();
                    break;
                case "Date Watched (Newest First)":
                    filtered = filtered.OrderByDescending(m => m.DateWatched).ToList();
                    break;
                case "Date Watched (Oldest First)":
                    filtered = filtered.OrderBy(m => m.DateWatched).ToList();
                    break;
                default:
                    break;

            }

            UpdateGrid(filtered);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadAllMovies();
            var watchedOnly = movies.Where(m => m.Watched).ToList();
            UpdateGrid(watchedOnly);
        }

        private void LoadAllMovies()
        {
            movies = MovieService.LoadMovies();
        }

        private void btnWatchlist_Click(object sender, EventArgs e)
        {
            var watchlistForm = new WatchlistForm();
            var result = watchlistForm.ShowDialog();

            if(result== DialogResult.OK)
            {
                LoadAllMovies();
                UpdateGrid(movies.Where(m=>m.Watched).ToList());
            }
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            using (var sf = new StatsForm())
            { sf.ShowDialog(); }
        }

        private void dataGridViewMovies_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditMovie_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a movie to edit.");
                return;
            }

            var selectedRow = dataGridViewMovies.SelectedRows[0];
            string selectedTitle = selectedRow.Cells["Title"].Value.ToString();

            var movies = MovieService.LoadMovies();
            var movieToEdit = movies.FirstOrDefault(m => m.Title == selectedTitle);

            if (movieToEdit != null)
            {
                var editForm = new EditMovieForm(movieToEdit);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    MovieService.SaveAllMovies(movies);
                    MessageBox.Show("Movie updated successfully!");
                    UpdateGrid(movies);
                }
            }
        }

        private void btnRecommendations_Click(object sender, EventArgs e)
        {
            var recsForm = new RecommendationsForm();
            recsForm.ShowDialog();
        }


    }
}
