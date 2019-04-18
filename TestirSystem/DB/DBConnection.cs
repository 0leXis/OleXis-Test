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
    public partial class DBConnection : Form
    {
        public string DBconnstr
        {
            get
            {
                return textBoxDBConnection.Text;
            }
            set
            {
                textBoxDBConnection.Text = value;
            }
        }

        public DBConnection()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void buttonDBCheck_Click(object sender, EventArgs e)
        {
            if(DBconnstr == "")
            {
                MessageBox.Show("Строка подключения пуста!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.dbProcessor = new DBProcessor(DBconnstr);
            var Error = "";
            if(Program.dbProcessor.OpenConnection(ref Error))
                MessageBox.Show("Подключение успешно установлено!", "БД", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Подключение не установлено!" + Environment.NewLine + Error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Program.dbProcessor.CloseConnection();
        }
    }
}
