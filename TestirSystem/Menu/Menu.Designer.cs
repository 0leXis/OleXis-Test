namespace TestirSystem
{
    partial class Menu
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonBD = new System.Windows.Forms.Button();
            this.buttonSozdanie = new System.Windows.Forms.Button();
            this.buttonPassing = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(12, 123);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(260, 31);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonBD
            // 
            this.buttonBD.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBD.Location = new System.Drawing.Point(12, 86);
            this.buttonBD.Name = "buttonBD";
            this.buttonBD.Size = new System.Drawing.Size(260, 31);
            this.buttonBD.TabIndex = 6;
            this.buttonBD.Text = "Просмотреть БД ответов";
            this.buttonBD.UseVisualStyleBackColor = true;
            // 
            // buttonSozdanie
            // 
            this.buttonSozdanie.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSozdanie.Location = new System.Drawing.Point(12, 49);
            this.buttonSozdanie.Name = "buttonSozdanie";
            this.buttonSozdanie.Size = new System.Drawing.Size(260, 31);
            this.buttonSozdanie.TabIndex = 5;
            this.buttonSozdanie.Text = "Создать/Редактировать тест";
            this.buttonSozdanie.UseVisualStyleBackColor = true;
            this.buttonSozdanie.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonPassing
            // 
            this.buttonPassing.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPassing.Location = new System.Drawing.Point(12, 12);
            this.buttonPassing.Name = "buttonPassing";
            this.buttonPassing.Size = new System.Drawing.Size(260, 31);
            this.buttonPassing.TabIndex = 4;
            this.buttonPassing.Text = "Пройти тест";
            this.buttonPassing.UseVisualStyleBackColor = true;
            this.buttonPassing.Click += new System.EventHandler(this.buttonPassing_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 164);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonBD);
            this.Controls.Add(this.buttonSozdanie);
            this.Controls.Add(this.buttonPassing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Menu";
            this.Text = "OleXis Test: Меню";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonBD;
        private System.Windows.Forms.Button buttonSozdanie;
        private System.Windows.Forms.Button buttonPassing;
    }
}

