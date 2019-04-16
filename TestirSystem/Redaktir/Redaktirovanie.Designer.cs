namespace TestirSystem
{
    partial class Editing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editing));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьТестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьВопросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьВопросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьРазделToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыТестаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCreateVopr = new System.Windows.Forms.Button();
            this.buttonDeleteSection = new System.Windows.Forms.Button();
            this.listBoxQuestionsAndSections = new System.Windows.Forms.ListBox();
            this.buttonChangeVopr = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxSvobodn = new System.Windows.Forms.TextBox();
            this.listBoxSootv = new System.Windows.Forms.ListBox();
            this.listBoxSequenceEstablishment = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonPlaySound = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelVoprText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonDeleteVopr = new System.Windows.Forms.Button();
            this.buttonCreateSection = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.тестToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.загрузитьToolStripMenuItem,
            this.сохранитьТестToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.создатьToolStripMenuItem.Text = "Создать тест";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить тест";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // сохранитьТестToolStripMenuItem
            // 
            this.сохранитьТестToolStripMenuItem.Enabled = false;
            this.сохранитьТестToolStripMenuItem.Name = "сохранитьТестToolStripMenuItem";
            this.сохранитьТестToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.сохранитьТестToolStripMenuItem.Text = "Сохранить тест";
            this.сохранитьТестToolStripMenuItem.Click += new System.EventHandler(this.сохранитьТестToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // тестToolStripMenuItem
            // 
            this.тестToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьВопросToolStripMenuItem,
            this.редактироватьВопросToolStripMenuItem,
            this.создатьРазделToolStripMenuItem,
            this.параметрыТестаToolStripMenuItem});
            this.тестToolStripMenuItem.Enabled = false;
            this.тестToolStripMenuItem.Name = "тестToolStripMenuItem";
            this.тестToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.тестToolStripMenuItem.Text = "Тест";
            // 
            // создатьВопросToolStripMenuItem
            // 
            this.создатьВопросToolStripMenuItem.Name = "создатьВопросToolStripMenuItem";
            this.создатьВопросToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.создатьВопросToolStripMenuItem.Text = "Создать вопрос";
            this.создатьВопросToolStripMenuItem.Click += new System.EventHandler(this.создатьВопросToolStripMenuItem_Click);
            // 
            // редактироватьВопросToolStripMenuItem
            // 
            this.редактироватьВопросToolStripMenuItem.Name = "редактироватьВопросToolStripMenuItem";
            this.редактироватьВопросToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.редактироватьВопросToolStripMenuItem.Text = "Редактировать вопрос";
            this.редактироватьВопросToolStripMenuItem.Click += new System.EventHandler(this.редактироватьВопросToolStripMenuItem_Click);
            // 
            // создатьРазделToolStripMenuItem
            // 
            this.создатьРазделToolStripMenuItem.Name = "создатьРазделToolStripMenuItem";
            this.создатьРазделToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.создатьРазделToolStripMenuItem.Text = "Создать раздел";
            this.создатьРазделToolStripMenuItem.Click += new System.EventHandler(this.создатьРазделToolStripMenuItem_Click);
            // 
            // параметрыТестаToolStripMenuItem
            // 
            this.параметрыТестаToolStripMenuItem.Name = "параметрыТестаToolStripMenuItem";
            this.параметрыТестаToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.параметрыТестаToolStripMenuItem.Text = "Параметры теста";
            this.параметрыТестаToolStripMenuItem.Click += new System.EventHandler(this.параметрыТестаToolStripMenuItem_Click);
            // 
            // buttonCreateVopr
            // 
            this.buttonCreateVopr.Enabled = false;
            this.buttonCreateVopr.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateVopr.Location = new System.Drawing.Point(349, 366);
            this.buttonCreateVopr.Name = "buttonCreateVopr";
            this.buttonCreateVopr.Size = new System.Drawing.Size(151, 31);
            this.buttonCreateVopr.TabIndex = 18;
            this.buttonCreateVopr.Text = "Создать вопрос";
            this.buttonCreateVopr.UseVisualStyleBackColor = true;
            this.buttonCreateVopr.Click += new System.EventHandler(this.buttonCreateVopr_Click);
            // 
            // buttonDeleteSection
            // 
            this.buttonDeleteSection.Enabled = false;
            this.buttonDeleteSection.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteSection.Location = new System.Drawing.Point(12, 366);
            this.buttonDeleteSection.Name = "buttonDeleteSection";
            this.buttonDeleteSection.Size = new System.Drawing.Size(155, 31);
            this.buttonDeleteSection.TabIndex = 17;
            this.buttonDeleteSection.Text = "Удалить раздел";
            this.buttonDeleteSection.UseVisualStyleBackColor = true;
            this.buttonDeleteSection.Click += new System.EventHandler(this.buttonDeleteSection_Click);
            // 
            // listBoxQuestionsAndSections
            // 
            this.listBoxQuestionsAndSections.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxQuestionsAndSections.FormattingEnabled = true;
            this.listBoxQuestionsAndSections.ItemHeight = 23;
            this.listBoxQuestionsAndSections.Location = new System.Drawing.Point(12, 27);
            this.listBoxQuestionsAndSections.Name = "listBoxQuestionsAndSections";
            this.listBoxQuestionsAndSections.Size = new System.Drawing.Size(155, 280);
            this.listBoxQuestionsAndSections.TabIndex = 16;
            this.listBoxQuestionsAndSections.SelectedIndexChanged += new System.EventHandler(this.listBoxQuestionsISections_SelectedIndexChanged);
            // 
            // buttonChangeVopr
            // 
            this.buttonChangeVopr.Enabled = false;
            this.buttonChangeVopr.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangeVopr.Location = new System.Drawing.Point(506, 366);
            this.buttonChangeVopr.Name = "buttonChangeVopr";
            this.buttonChangeVopr.Size = new System.Drawing.Size(292, 31);
            this.buttonChangeVopr.TabIndex = 15;
            this.buttonChangeVopr.Text = "Редактировать вопрос";
            this.buttonChangeVopr.UseVisualStyleBackColor = true;
            this.buttonChangeVopr.Click += new System.EventHandler(this.buttonChangeVopr_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(173, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(631, 169);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ответы";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxSvobodn);
            this.panel1.Controls.Add(this.listBoxSootv);
            this.panel1.Controls.Add(this.listBoxSequenceEstablishment);
            this.panel1.Location = new System.Drawing.Point(10, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 135);
            this.panel1.TabIndex = 0;
            // 
            // textBoxSvobodn
            // 
            this.textBoxSvobodn.Location = new System.Drawing.Point(7, 3);
            this.textBoxSvobodn.Name = "textBoxSvobodn";
            this.textBoxSvobodn.Size = new System.Drawing.Size(596, 29);
            this.textBoxSvobodn.TabIndex = 2;
            this.textBoxSvobodn.Text = "Введите ответ";
            this.textBoxSvobodn.Visible = false;
            // 
            // listBoxSootv
            // 
            this.listBoxSootv.FormattingEnabled = true;
            this.listBoxSootv.ItemHeight = 23;
            this.listBoxSootv.Location = new System.Drawing.Point(323, 3);
            this.listBoxSootv.Name = "listBoxSootv";
            this.listBoxSootv.Size = new System.Drawing.Size(280, 119);
            this.listBoxSootv.TabIndex = 1;
            this.listBoxSootv.Visible = false;
            // 
            // listBoxSequenceEstablishment
            // 
            this.listBoxSequenceEstablishment.FormattingEnabled = true;
            this.listBoxSequenceEstablishment.ItemHeight = 23;
            this.listBoxSequenceEstablishment.Location = new System.Drawing.Point(7, 3);
            this.listBoxSequenceEstablishment.Name = "listBoxSequenceEstablishment";
            this.listBoxSequenceEstablishment.Size = new System.Drawing.Size(280, 119);
            this.listBoxSequenceEstablishment.TabIndex = 0;
            this.listBoxSequenceEstablishment.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.buttonPlaySound);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(173, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 160);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вопрос";
            // 
            // buttonPlaySound
            // 
            this.buttonPlaySound.Enabled = false;
            this.buttonPlaySound.Location = new System.Drawing.Point(10, 124);
            this.buttonPlaySound.Name = "buttonPlaySound";
            this.buttonPlaySound.Size = new System.Drawing.Size(287, 30);
            this.buttonPlaySound.TabIndex = 2;
            this.buttonPlaySound.Text = "Проиграть вложенный аудио-файл";
            this.buttonPlaySound.UseVisualStyleBackColor = true;
            this.buttonPlaySound.Visible = false;
            this.buttonPlaySound.Click += new System.EventHandler(this.buttonPlaySound_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelVoprText);
            this.panel2.Location = new System.Drawing.Point(10, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 97);
            this.panel2.TabIndex = 3;
            // 
            // labelVoprText
            // 
            this.labelVoprText.AutoSize = true;
            this.labelVoprText.Location = new System.Drawing.Point(3, 3);
            this.labelVoprText.Name = "labelVoprText";
            this.labelVoprText.Size = new System.Drawing.Size(122, 23);
            this.labelVoprText.TabIndex = 0;
            this.labelVoprText.Text = "Текст вопроса";
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(486, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buttonDeleteVopr
            // 
            this.buttonDeleteVopr.Enabled = false;
            this.buttonDeleteVopr.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteVopr.Location = new System.Drawing.Point(183, 366);
            this.buttonDeleteVopr.Name = "buttonDeleteVopr";
            this.buttonDeleteVopr.Size = new System.Drawing.Size(156, 31);
            this.buttonDeleteVopr.TabIndex = 19;
            this.buttonDeleteVopr.Text = "Удалить вопрос";
            this.buttonDeleteVopr.UseVisualStyleBackColor = true;
            this.buttonDeleteVopr.Click += new System.EventHandler(this.buttonDeleteVopr_Click);
            // 
            // buttonCreateSection
            // 
            this.buttonCreateSection.Enabled = false;
            this.buttonCreateSection.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateSection.Location = new System.Drawing.Point(12, 325);
            this.buttonCreateSection.Name = "buttonCreateSection";
            this.buttonCreateSection.Size = new System.Drawing.Size(155, 31);
            this.buttonCreateSection.TabIndex = 20;
            this.buttonCreateSection.Text = "Создать раздел";
            this.buttonCreateSection.UseVisualStyleBackColor = true;
            this.buttonCreateSection.Click += new System.EventHandler(this.button2_Click);
            // 
            // Editing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 406);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCreateSection);
            this.Controls.Add(this.buttonDeleteVopr);
            this.Controls.Add(this.buttonCreateVopr);
            this.Controls.Add(this.buttonDeleteSection);
            this.Controls.Add(this.listBoxQuestionsAndSections);
            this.Controls.Add(this.buttonChangeVopr);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Editing";
            this.Text = "OleXis Test: Редактор тестов";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьТестToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьВопросToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьВопросToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьРазделToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыТестаToolStripMenuItem;
        private System.Windows.Forms.Button buttonCreateVopr;
        private System.Windows.Forms.Button buttonDeleteSection;
        private System.Windows.Forms.ListBox listBoxQuestionsAndSections;
        private System.Windows.Forms.Button buttonChangeVopr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonPlaySound;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelVoprText;
        private System.Windows.Forms.Button buttonDeleteVopr;
        private System.Windows.Forms.Button buttonCreateSection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxSvobodn;
        private System.Windows.Forms.ListBox listBoxSootv;
        private System.Windows.Forms.ListBox listBoxSequenceEstablishment;
    }
}