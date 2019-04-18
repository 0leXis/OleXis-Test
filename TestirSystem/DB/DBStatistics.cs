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
    public partial class DBStatistics : Form
    {
        public DBStatistics()
        {
            InitializeComponent();
        }

        public void SetDefault()
        {
            labelBest.Text = "Лучшая оценка: ";
            labelWorst.Text = "Худшая оценка: ";
            labelAverage.Text = "Средняя оценка: ";
        }

        public void SetStatistics(string Best, string Worst, string Average)
        {
            labelBest.Text = "Лучшая оценка: " + Best;
            labelWorst.Text = "Худшая оценка: " + Worst;
            labelAverage.Text = "Средняя оценка: " + Average;
        }
    }
}
