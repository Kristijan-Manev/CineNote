﻿namespace CineNote.Views
{
    partial class RecommendationsForm
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
            this.lableIntro = new System.Windows.Forms.Label();
            this.dataGridViewRecs = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecs)).BeginInit();
            this.SuspendLayout();
            // 
            // lableIntro
            // 
            this.lableIntro.AutoSize = true;
            this.lableIntro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableIntro.ForeColor = System.Drawing.Color.Gainsboro;
            this.lableIntro.Location = new System.Drawing.Point(12, 9);
            this.lableIntro.Name = "lableIntro";
            this.lableIntro.Size = new System.Drawing.Size(290, 20);
            this.lableIntro.TabIndex = 0;
            this.lableIntro.Text = "We recommend these based on your taste:";
            // 
            // dataGridViewRecs
            // 
            this.dataGridViewRecs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecs.Location = new System.Drawing.Point(16, 33);
            this.dataGridViewRecs.Name = "dataGridViewRecs";
            this.dataGridViewRecs.ReadOnly = true;
            this.dataGridViewRecs.RowHeadersWidth = 51;
            this.dataGridViewRecs.RowTemplate.Height = 24;
            this.dataGridViewRecs.Size = new System.Drawing.Size(671, 268);
            this.dataGridViewRecs.TabIndex = 1;
            this.dataGridViewRecs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRecs_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(586, 306);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(16, 306);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // RecommendationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 395);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridViewRecs);
            this.Controls.Add(this.lableIntro);
            this.Name = "RecommendationsForm";
            this.Text = "RecommendationsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lableIntro;
        private System.Windows.Forms.DataGridView dataGridViewRecs;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
    }
}