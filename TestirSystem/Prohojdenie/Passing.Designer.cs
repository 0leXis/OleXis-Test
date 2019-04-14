namespace TestirSystem
{
    partial class Passing
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Passing));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxSvobodn = new System.Windows.Forms.TextBox();
            this.listBoxSootv = new System.Windows.Forms.ListBox();
            this.listBoxSequenceEstablishment = new System.Windows.Forms.ListBox();
            this.groupBoxQuestion = new System.Windows.Forms.GroupBox();
            this.buttonPlaySound = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelVoprText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonStopTest = new System.Windows.Forms.Button();
            this.buttonNextQuestion = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxQuestion.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(631, 169);
            this.groupBox2.TabIndex = 16;
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
            this.textBoxSvobodn.TextChanged += new System.EventHandler(this.textBoxSvobodn_TextChanged);
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
            this.listBoxSequenceEstablishment.AllowDrop = true;
            this.listBoxSequenceEstablishment.FormattingEnabled = true;
            this.listBoxSequenceEstablishment.ItemHeight = 23;
            this.listBoxSequenceEstablishment.Location = new System.Drawing.Point(7, 3);
            this.listBoxSequenceEstablishment.Name = "listBoxSequenceEstablishment";
            this.listBoxSequenceEstablishment.Size = new System.Drawing.Size(280, 119);
            this.listBoxSequenceEstablishment.TabIndex = 0;
            this.listBoxSequenceEstablishment.Visible = false;
            this.listBoxSequenceEstablishment.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxSequenceEstablishment_DragDrop);
            this.listBoxSequenceEstablishment.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxSequenceEstablishment_DragEnter);
            this.listBoxSequenceEstablishment.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxSequenceEstablishment_MouseMove);
            // 
            // groupBoxQuestion
            // 
            this.groupBoxQuestion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBoxQuestion.Controls.Add(this.buttonPlaySound);
            this.groupBoxQuestion.Controls.Add(this.panel2);
            this.groupBoxQuestion.Controls.Add(this.pictureBox1);
            this.groupBoxQuestion.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxQuestion.Location = new System.Drawing.Point(12, 12);
            this.groupBoxQuestion.Name = "groupBoxQuestion";
            this.groupBoxQuestion.Size = new System.Drawing.Size(631, 160);
            this.groupBoxQuestion.TabIndex = 15;
            this.groupBoxQuestion.TabStop = false;
            this.groupBoxQuestion.Text = "Вопрос";
            // 
            // buttonPlaySound
            // 
            this.buttonPlaySound.Location = new System.Drawing.Point(10, 124);
            this.buttonPlaySound.Name = "buttonPlaySound";
            this.buttonPlaySound.Size = new System.Drawing.Size(287, 30);
            this.buttonPlaySound.TabIndex = 2;
            this.buttonPlaySound.Text = "Проиграть вложенный аудио-файл";
            this.buttonPlaySound.UseVisualStyleBackColor = true;
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
            this.pictureBox1.Location = new System.Drawing.Point(484, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 139);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buttonStopTest
            // 
            this.buttonStopTest.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStopTest.Location = new System.Drawing.Point(12, 347);
            this.buttonStopTest.Name = "buttonStopTest";
            this.buttonStopTest.Size = new System.Drawing.Size(182, 30);
            this.buttonStopTest.TabIndex = 17;
            this.buttonStopTest.Text = "Закончить тест";
            this.buttonStopTest.UseVisualStyleBackColor = true;
            this.buttonStopTest.Click += new System.EventHandler(this.buttonStopTest_Click);
            // 
            // buttonNextQuestion
            // 
            this.buttonNextQuestion.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNextQuestion.Location = new System.Drawing.Point(461, 347);
            this.buttonNextQuestion.Name = "buttonNextQuestion";
            this.buttonNextQuestion.Size = new System.Drawing.Size(182, 30);
            this.buttonNextQuestion.TabIndex = 18;
            this.buttonNextQuestion.Text = "Следующий вопрос";
            this.buttonNextQuestion.UseVisualStyleBackColor = true;
            this.buttonNextQuestion.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Arial Narrow", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(200, 351);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(169, 23);
            this.labelTime.TabIndex = 19;
            this.labelTime.Text = "Времени осталось:";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Passing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 383);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.buttonNextQuestion);
            this.Controls.Add(this.buttonStopTest);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxQuestion);
            this.Name = "Passing";
            this.Text = "OleXis Test: Прохождение";
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxQuestion.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxSvobodn;
        private System.Windows.Forms.ListBox listBoxSootv;
        private System.Windows.Forms.ListBox listBoxSequenceEstablishment;
        private System.Windows.Forms.GroupBox groupBoxQuestion;
        private System.Windows.Forms.Button buttonPlaySound;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelVoprText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonStopTest;
        private System.Windows.Forms.Button buttonNextQuestion;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer;
    }
}