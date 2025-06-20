namespace CineNote.Views
{
    partial class StatsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblAverage = new System.Windows.Forms.Label();
            this.lblFavorite = new System.Windows.Forms.Label();
            this.chartGenres = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartGenres)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(0, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(50, 20);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "label1";
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAverage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverage.Location = new System.Drawing.Point(0, 20);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(50, 20);
            this.lblAverage.TabIndex = 1;
            this.lblAverage.Text = "label1";
            // 
            // lblFavorite
            // 
            this.lblFavorite.AutoSize = true;
            this.lblFavorite.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFavorite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFavorite.Location = new System.Drawing.Point(0, 40);
            this.lblFavorite.Name = "lblFavorite";
            this.lblFavorite.Size = new System.Drawing.Size(50, 20);
            this.lblFavorite.TabIndex = 2;
            this.lblFavorite.Text = "label1";
            // 
            // chartGenres
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGenres.ChartAreas.Add(chartArea1);
            this.chartGenres.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartGenres.Legends.Add(legend1);
            this.chartGenres.Location = new System.Drawing.Point(0, 60);
            this.chartGenres.Name = "chartGenres";
            this.chartGenres.Size = new System.Drawing.Size(800, 390);
            this.chartGenres.TabIndex = 3;
            this.chartGenres.Text = "chart1";
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartGenres);
            this.Controls.Add(this.lblFavorite);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.lblTotal);
            this.Name = "StatsForm";
            this.Text = "StatsForm";
            this.Load += new System.EventHandler(this.StatsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartGenres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Label lblFavorite;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGenres;
    }
}