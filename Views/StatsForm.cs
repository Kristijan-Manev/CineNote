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
using System.Windows.Forms.DataVisualization.Charting;

namespace CineNote.Views
{
    public partial class StatsForm : Form
    {
        public StatsForm()
        {
            InitializeComponent();
            LoadStats();
        }

        private void LoadStats()
        {
            var allMovies = MovieService.LoadMovies();
            var watched = allMovies.Where(m=>m.Watched).ToList();

            lblTotal.Text = $"🎬 Movies watched: {watched.Count}";

            double avg = watched.Any() ? watched.Average(m => m.Rating):0;
            lblAverage.Text = $"⭐ Average rating: {avg:F1}";

            var favGenre = watched.GroupBy(m=>m.Genre)
                .OrderByDescending(g=>g.Count())
                .FirstOrDefault()?.Key ?? "N/A";
            lblFavorite.Text = $"🏆 Favourite genre: {favGenre}";

            chartGenres.Series.Clear();
            var series = new Series
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true
            };
            chartGenres.Series.Add(series);
            chartGenres.ChartAreas[0].AxisX.Interval = 1;

            foreach (var g in watched.GroupBy(m => m.Watched).OrderByDescending(g => g.Count()))
            {
                series.Points.AddXY(g.Key,g.Count());
            }


        }


        private void StatsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
