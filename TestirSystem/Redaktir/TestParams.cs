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
    public partial class TestParams : Form
    {
        //Время на прохождение
        public int TestTime
        {
            get
            {
                if (comboBoxTime.Text == "Не ограничено")
                    return 0;
                else
                    return Convert.ToInt32(comboBoxTime.Text);
            }
            set
            {
                if (value == 0)
                    comboBoxTime.Text = "Не ограничено";
                else
                    comboBoxTime.Text = value.ToString();
            }
        }
        //Способ формирования варианта
        public QuestionAllocation Allocation
        {
            get
            {
                if (radioButton1Variant.Checked)
                    return QuestionAllocation.One_Variant;
                else
                    if (radioButtonEachSection.Checked)
                        return QuestionAllocation.Section_Variant;
                    else
                        return QuestionAllocation.Generate;
            }
            set
            {
                if (value == QuestionAllocation.One_Variant)
                    radioButton1Variant.Checked = true;
                else
                    if (value == QuestionAllocation.Section_Variant)
                        radioButtonEachSection.Checked = true;
                    else
                        radioButtonRandom.Checked = true;
            }
        }
        //Кол-во вопросов из каждого раздела для случ варианта
        public int QuestionsToGenerate
        {
            get
            {
                return Convert.ToInt32(textBoxQuestions.Text);
            }
            set
            {
                textBoxQuestions.Text = value.ToString();
            }
        }
        //Пароль
        public string Password
        {
            get
            {
                return textBoxPassword.Text;
            }
            set
            {
               textBoxPassword.Text = value;
            }
        }

        public TestParams()
        {
            InitializeComponent();
            comboBoxTime.SelectedIndex = 0;
        }
        //Загрузить данные на форму
        public void GetInfoFromTest(Test test)
        {
            TestTime = test.TimeForTest;
            Allocation = test.QuestionAllocation;
            if (test.QuestionAllocation == QuestionAllocation.Generate)
                QuestionsToGenerate = test.CountForGenerate;
            else
                QuestionsToGenerate = 1;
            Password = test.Password;
        }
        //Сохранить данные в тест
        public void SetInfoToTest(Test test)
        {
            test.TimeForTest = TestTime;
            test.QuestionAllocation = Allocation;
            if (test.QuestionAllocation == QuestionAllocation.Generate)
                test.CountForGenerate = QuestionsToGenerate;
            else
                test.CountForGenerate = 1;
            test.Password = Password;
        }
        //Отмена
        private void button1_Click(object sender, EventArgs e)
        {
            GetInfoFromTest(Program.editing.GetTest());
            Hide();
        }
        //ОК
        private void button4_Click(object sender, EventArgs e)
        {
            SetInfoToTest(Program.editing.GetTest());
            Hide();
        }
        //Генерация пароля
        private void button1_Click_1(object sender, EventArgs e)
        {
            textBoxPassword.Text = "";
            var rndforPassword = new Random();
            for(var i = 0; i < 10; i++)
            {
                textBoxPassword.Text += Convert.ToChar(rndforPassword.Next(48, 90));
            }
        }
    }
}
