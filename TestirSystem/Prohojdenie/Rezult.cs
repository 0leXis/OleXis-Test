using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestirSystem
{
    public partial class Rezult : Form
    {
        public Rezult()
        {
            InitializeComponent();
        }

        public void SetResult(int Ocenka, int ColVoPravOtvetov, int ColVoOtvetov, string FIO, string Class, int Minutes, int Seconds, int TimeForTest)
        {
            labelFIO.Text = "ФИО: " + FIO;
            labelClass.Text = @"Класс\Группа: " + Class;
            if (Ocenka > 4)
                labelOcenka.ForeColor = Color.Green;
            else
                labelOcenka.ForeColor = Color.Red;
            labelOcenka.Text = "Оценка: " + Ocenka;
            labelProcPrav.Text = "% правильных ответов: " + (Math.Round((double)ColVoPravOtvetov / ColVoOtvetov * 100)).ToString();
            var MinTmp = TimeForTest - Minutes;
            var SecTmp = 0;
            if(Seconds != 0)
            {
                SecTmp = 60 - Seconds;
                if (MinTmp != 0)
                    MinTmp--;
            }
            labelTime.Text = "Время: " + MinTmp + ":" + SecTmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.answerList.ShowDialog();
        }
    }
}
