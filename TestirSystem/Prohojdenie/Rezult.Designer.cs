namespace TestirSystem
{
    partial class Rezult
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
            this.labelClass = new System.Windows.Forms.Label();
            this.labelFIO = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelProcPrav = new System.Windows.Forms.Label();
            this.labelOcenka = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelClass.Location = new System.Drawing.Point(12, 33);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(114, 23);
            this.labelClass.TabIndex = 12;
            this.labelClass.Text = "Класс\\Группа:";
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFIO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelFIO.Location = new System.Drawing.Point(12, 9);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(49, 23);
            this.labelFIO.TabIndex = 11;
            this.labelFIO.Text = "ФИО:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 30);
            this.button1.TabIndex = 10;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTime.Location = new System.Drawing.Point(12, 104);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(61, 23);
            this.labelTime.TabIndex = 9;
            this.labelTime.Text = "Время:";
            // 
            // labelProcPrav
            // 
            this.labelProcPrav.AutoSize = true;
            this.labelProcPrav.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProcPrav.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelProcPrav.Location = new System.Drawing.Point(12, 81);
            this.labelProcPrav.Name = "labelProcPrav";
            this.labelProcPrav.Size = new System.Drawing.Size(193, 23);
            this.labelProcPrav.TabIndex = 8;
            this.labelProcPrav.Text = "% правильных ответов:";
            // 
            // labelOcenka
            // 
            this.labelOcenka.AutoSize = true;
            this.labelOcenka.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOcenka.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelOcenka.Location = new System.Drawing.Point(11, 56);
            this.labelOcenka.Name = "labelOcenka";
            this.labelOcenka.Size = new System.Drawing.Size(77, 25);
            this.labelOcenka.TabIndex = 7;
            this.labelOcenka.Text = "Оценка:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(223, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 30);
            this.button2.TabIndex = 13;
            this.button2.Text = "Список ответов";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Rezult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 173);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelClass);
            this.Controls.Add(this.labelFIO);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelProcPrav);
            this.Controls.Add(this.labelOcenka);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Rezult";
            this.Text = "OleXis Test: Результат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelProcPrav;
        private System.Windows.Forms.Label labelOcenka;
        private System.Windows.Forms.Button button2;
    }
}