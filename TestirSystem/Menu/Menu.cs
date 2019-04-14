using System;
using System.Windows.Forms;

namespace TestirSystem
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        //Выход
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Создание/Редактирование тестов
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Hide();
            Program.editing.Show();
        }

        //Прохождение тестов
        private void buttonPassing_Click(object sender, EventArgs e)
        {
            Program.studentData.ShowDialog();
        }
    }
}
