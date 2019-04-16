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
    public partial class SectionName : Form
    {
        public SectionName()
        {
            InitializeComponent();
        }
        //Отмена
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
        //ОК
        private void buttonCreateVopr_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Поле \"Название\" должно быть заполнено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Program.editing.CreateSection(textBox1.Text))
                Hide();
            else
                MessageBox.Show("Раздел или вопрос с таким именем уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SectionName_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
