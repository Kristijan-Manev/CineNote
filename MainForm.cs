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
        private List<Movie> movies = new List<Movie>();
        public MainForm()
        {
            InitializeComponent();
            SendMessage(comboGenreFilter.Handle, CB_SETCUEBANNER, IntPtr.Zero, "GENRE");
            SendMessage(comboSortBy.Handle, CB_SETCUEBANNER, IntPtr.Zero, "SORT BY");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

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
        }

        private void dataGridViewMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            movies = MovieService.LoadMovies();
            dataGridViewMovies.DataSource = null;
            dataGridViewMovies.DataSource = movies;

            dataGridViewMovies.Columns["Title"].HeaderText ="Title";
            dataGridViewMovies.Columns["Genre"].HeaderText = "Genre";
            dataGridViewMovies.Columns["Rating"].HeaderText = "Rating ★";
            dataGridViewMovies.Columns["Comment"].HeaderText = "Your Review";
            dataGridViewMovies.Columns["DateWatched"].HeaderText = "Date Watched";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a movie to delete!");
                return;
            }

            var selectedRow = dataGridViewMovies.SelectedRows[0];
            var selectedTitle = selectedRow.Cells["Title"].Value.ToString();

            var movies = MovieService.LoadMovies();

            var movieToRemove = movies.FirstOrDefault(m=>m.Title == selectedTitle);
            if(movieToRemove != null)
            {
                movies.Remove(movieToRemove);
                MovieService.SaveAllMovies(movies);
                MessageBox.Show($"Deleted '{selectedTitle}'.");
                btnRefresh.PerformClick();
            }
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

        private void UpdateGrid(List<Movie> movies)
        {
            dataGridViewMovies.DataSource = null;
            dataGridViewMovies.DataSource = movies;

            if (dataGridViewMovies.Columns.Contains("DateWatched"))
                dataGridViewMovies.Columns["DateWatched"].HeaderText = "Date Watched";
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
    }
}
