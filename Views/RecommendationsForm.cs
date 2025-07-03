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
            var recommended = RecommendationService.GetRecommendations();

            dataGridViewRecs.DataSource = null;
            dataGridViewRecs.DataSource = recommended;

            if (!dataGridViewRecs.Columns.Contains("AddBtn"))
            {
                var btn = new DataGridViewButtonColumn
                {
                    Name = "AddBtn",
                    HeaderText = "",
                    Text = "Add to Watchlist",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat
                };
                dataGridViewRecs.Columns.Add(btn);
                btn.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 70);
                btn.DefaultCellStyle.ForeColor = Color.Gainsboro;
                btn.DefaultCellStyle.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
            }

            dataGridViewRecs.Columns["Watched"].Visible = false;
            dataGridViewRecs.Columns["Comment"].Visible = false;
            dataGridViewRecs.Columns["DateWatched"].Visible = false;
            dataGridViewRecs.Columns["Rating"].Visible = false;

            dataGridViewRecs.Columns["Title"].HeaderText = "Title";
            dataGridViewRecs.Columns["Genre"].HeaderText = "Genre";
           // dataGridViewRecs.Columns["Priority"].HeaderText = "Priority";

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
