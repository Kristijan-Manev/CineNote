namespace CineNote.Views
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecs)).BeginInit();
            this.SuspendLayout();
            // 
            // lableIntro
            // 
            this.lableIntro.AutoSize = true;
            this.lableIntro.Location = new System.Drawing.Point(13, 9);
            this.lableIntro.Name = "lableIntro";
            this.lableIntro.Size = new System.Drawing.Size(263, 16);
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
            this.dataGridViewRecs.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewRecs.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(16, 190);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // RecommendationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}