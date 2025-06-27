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

            this.BackColor = Color.FromArgb(25, 25, 35);
            this.Font = new Font("Segoe UI", 9f, FontStyle.Regular);

            LoadStats();
        }

        private void StyleLabel(Label label)
        {
            label.ForeColor = Color.Gainsboro;
            label.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            label.BackColor = Color.Transparent;
        }

        private void StyleChart(Chart chart)
        {
            chart.BackColor = Color.FromArgb(25, 25, 35);
            chart.ChartAreas[0].BackColor = Color.FromArgb(28, 28, 38);
            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Gainsboro;
            chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Gainsboro;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(50, 50, 70);
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(50, 50, 70);
            chart.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 9, FontStyle.Bold);
            chart.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 9, FontStyle.Bold);
            chart.BorderlineColor = Color.FromArgb(60, 60, 80);
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineWidth = 1;

            chart.Legends.Clear(); 
        }

        private void LoadStats()
        {
            var allMovies = MovieService.LoadMovies();
            var watched = allMovies.Where(m=>m.Watched).ToList();

            StyleLabel(lblTotal);
            StyleLabel(lblAverage);
            StyleLabel(lblFavorite);

            lblTotal.Text = $"🎬 Movies watched: {watched.Count}";

            double avg = watched.Any() ? watched.Average(m => m.Rating):0;
            lblAverage.Text = $"⭐ Average rating: {avg:F1}";

            var favGenre = watched.GroupBy(m=>m.Genre)
                .OrderByDescending(g=>g.Count())
                .FirstOrDefault()?.Key ?? "N/A";
            lblFavorite.Text = $"🏆 Favourite genre: {favGenre}";

            chartGenres.Series.Clear();
            StyleChart(chartGenres);
            var series = new Series
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true
            };

            chartGenres.Series.Add(series);
            chartGenres.ChartAreas[0].AxisX.Interval = 1;

            foreach (var g in watched.GroupBy(m => m.Genre).OrderByDescending(g => g.Count()))
            {
                series.Points.AddXY(g.Key, g.Count());
            }


        }

        private void StatsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
