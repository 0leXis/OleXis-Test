namespace TestirSystem
{
    partial class DBStatistics
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
            this.labelWorst = new System.Windows.Forms.Label();
            this.labelBest = new System.Windows.Forms.Label();
            this.labelAverage = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWorst
            // 
            this.labelWorst.AutoSize = true;
            this.labelWorst.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorst.ForeColor = System.Drawing.Color.DarkRed;
            this.labelWorst.Location = new System.Drawing.Point(12, 55);
            this.labelWorst.Name = "labelWorst";
            this.labelWorst.Size = new System.Drawing.Size(127, 23);
            this.labelWorst.TabIndex = 8;
            this.labelWorst.Text = "Худшая оценка:";
            // 
            // labelBest
            // 
            this.labelBest.AutoSize = true;
            this.labelBest.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBest.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelBest.Location = new System.Drawing.Point(12, 32);
            this.labelBest.Name = "labelBest";
            this.labelBest.Size = new System.Drawing.Size(127, 23);
            this.labelBest.TabIndex = 7;
            this.labelBest.Text = "Лучшая оценка:";
            // 
            // labelAverage
            // 
            this.labelAverage.AutoSize = true;
            this.labelAverage.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAverage.Location = new System.Drawing.Point(12, 9);
            this.labelAverage.Name = "labelAverage";
            this.labelAverage.Size = new System.Drawing.Size(133, 23);
            this.labelAverage.TabIndex = 6;
            this.labelAverage.Text = "Средняя оценка:";
            // 
            // buttonExit
            // 
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonExit.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(133, 84);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(260, 31);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.Text = "ОК";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // DBStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 127);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelWorst);
            this.Controls.Add(this.labelBest);
            this.Controls.Add(this.labelAverage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DBStatistics";
            this.Text = "OleXis Test: Статистика";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWorst;
        private System.Windows.Forms.Label labelBest;
        private System.Windows.Forms.Label labelAverage;
        private System.Windows.Forms.Button buttonExit;
    }
}