﻿namespace CineNote.Views
{
    partial class WatchlistForm
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
            this.labelCount = new System.Windows.Forms.Label();
            this.dataGridViewWatchlist = new System.Windows.Forms.DataGridView();
            this.comboSortPriority = new System.Windows.Forms.ComboBox();
            this.labelPage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWatchlist)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCount.Location = new System.Drawing.Point(8, 9);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(136, 23);
            this.labelCount.TabIndex = 0;
            this.labelCount.Text = "You want to see ";
            // 
            // dataGridViewWatchlist
            // 
            this.dataGridViewWatchlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWatchlist.Location = new System.Drawing.Point(12, 38);
            this.dataGridViewWatchlist.Name = "dataGridViewWatchlist";
            this.dataGridViewWatchlist.ReadOnly = true;
            this.dataGridViewWatchlist.RowHeadersWidth = 51;
            this.dataGridViewWatchlist.RowTemplate.Height = 24;
            this.dataGridViewWatchlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWatchlist.Size = new System.Drawing.Size(532, 232);
            this.dataGridViewWatchlist.TabIndex = 1;
            this.dataGridViewWatchlist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWatchlist_CellContentClick);
            // 
            // comboSortPriority
            // 
            this.comboSortPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSortPriority.FormattingEnabled = true;
            this.comboSortPriority.Items.AddRange(new object[] {
            "Default",
            "Priority (High - Low)",
            "Priority (Low - High)"});
            this.comboSortPriority.Location = new System.Drawing.Point(423, 8);
            this.comboSortPriority.Name = "comboSortPriority";
            this.comboSortPriority.Size = new System.Drawing.Size(121, 24);
            this.comboSortPriority.TabIndex = 2;
            this.comboSortPriority.SelectedIndexChanged += new System.EventHandler(this.comboSortPriority_SelectedIndexChanged);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPage.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelPage.Location = new System.Drawing.Point(476, 326);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(139, 38);
            this.labelPage.TabIndex = 3;
            this.labelPage.Text = "Watchlist";
            // 
            // WatchlistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 373);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.comboSortPriority);
            this.Controls.Add(this.dataGridViewWatchlist);
            this.Controls.Add(this.labelCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "WatchlistForm";
            this.Text = "WatchlistForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWatchlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.DataGridView dataGridViewWatchlist;
        private System.Windows.Forms.ComboBox comboSortPriority;
        private System.Windows.Forms.Label labelPage;
    }
}