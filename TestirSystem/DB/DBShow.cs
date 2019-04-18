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
    public partial class DBShow : Form
    {
        DataSet Data;

        public DBShow()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Program.dbProcessor.CloseConnection();
            Hide();
            Program.menu.Show();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Program.dbConnection.DBconnstr = "";
            if (Program.dbConnection.ShowDialog() == DialogResult.OK)
            {
                Program.dbProcessor = new DBProcessor(Program.dbConnection.DBconnstr);
                var Error = "";
                var flag = false;
                if (Program.dbProcessor.OpenConnection(ref Error))
                {
                    if (!Program.dbProcessor.GetTestTable(out Data, ref Error))
                        flag = true;
                }
                else
                    flag = true;
                if(flag)
                    MessageBox.Show("Подключение не установлено!" + Environment.NewLine + Error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    buttonCalculate.Enabled = true;
                    dataGridView1.DataSource = Data.Tables[0];
                }
                Program.dbProcessor.CloseConnection();
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            Program.dbStatistics.SetDefault();
            if (Data != null)
            {
                var Average = 0d;
                var Rows = Data.Tables[0].Select();
                var i = 0;
                var Max = (int)Rows[0][3];
                var Min = (int)Rows[0][3];
                var MaxStud = (string)Rows[0][1] + " Группа: " + (string)Rows[0][2] + " Оценка: " + Max;
                var MinStud = (string)Rows[0][1] + " Группа: " + (string)Rows[0][2] + " Оценка: " + Min;
                while (i < Rows.Length)
                {
                    Average += (int)Rows[i][3];
                    if((int)Rows[i][3] > Max)
                    {
                        Max = (int)Rows[i][3];
                        MaxStud = (string)Rows[i][1] + " Группа: " + (string)Rows[i][2] + " Оценка: " + Max;
                    }
                    if ((int)Rows[i][3] < Min)
                    {
                        Min = (int)Rows[i][3];
                        MinStud = (string)Rows[i][1] + " Группа: " + (string)Rows[i][2] + " Оценка: " + Min;
                    }
                    i++;
                }
                Average = Average / i;
                Program.dbStatistics.SetStatistics(MaxStud, MinStud, Average.ToString());
                Program.dbStatistics.ShowDialog();
            }
        }
    }
}
