using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TestirSystem
{
    public partial class StudentData : Form
    {
        public StudentData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Валидация
            if (textBoxClass.Text == "" || textBoxFIO.Text == "")
            {
                MessageBox.Show("Поля \"ФИО\" и \"Класс\\Группа\" должны быть заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rnd = new Random();
            using (var op = new OpenFileDialog())
            {
                op.Filter = "Файлы теста (*.test)|*.test";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists("tmp"))
                        Directory.CreateDirectory("tmp");
                    else
                    {
                        foreach (var fil in Directory.GetFiles("tmp"))
                            File.Delete(fil);
                        Directory.Delete("tmp");
                        Directory.CreateDirectory("tmp");
                    }

                    Test Test;
                    var Password = "";
                    var isfirst = true;
                    while (true)
                    {
                        try
                        {
                            Test = new Test(op.FileName, "tmp", Password);
                            break;
                        }
                        catch
                        {
                            if (isfirst)
                            {
                                isfirst = false;
                                MessageBox.Show("Файл защищен паролем." + Environment.NewLine + "Преподаватель должен ввести пароль, чтобы открыть тест", "Требуется пароль", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Файл поврежден или введен неверный пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            if (Program.passwordDialog.ShowDialog() == DialogResult.OK)
                                Password = Program.passwordDialog.Password;
                            else
                                return;
                        }
                    }

                    foreach (var fil in Directory.GetFiles("tmp"))
                        File.Delete(fil);
                    Directory.Delete("tmp");

                    var VoprList = new List<Question>();
                    switch (Test.QuestionAllocation)
                    {
                        case QuestionAllocation.One_Variant:
                            VoprList = new List<Question>(Test.Questions);
                            break;
                        case QuestionAllocation.Section_Variant:
                            var Variant = Test.Sections[rnd.Next(0, Test.Sections.Count)];
                            VoprList = new List<Question>(from elem in Test.Questions where elem.Section == Variant select elem);
                            break;
                        case QuestionAllocation.Generate:
                            for (var i = 0; i < Test.Sections.Count; i++)
                            {
                                Variant = Test.Sections[i];
                                var TmpLst = new List<Question>(from elem in Test.Questions where elem.Section == Variant select elem);
                                var TmpVoprList = new List<Question>();
                                var Set = new HashSet<int>();
                                while (TmpVoprList.Count < Test.CountForGenerate)
                                {
                                    var rndnum = rnd.Next(0, TmpLst.Count);
                                    if (!Set.Contains(rndnum))
                                    {
                                        TmpVoprList.Add(TmpLst[rndnum]);
                                        Set.Add(rndnum);
                                    }
                                }
                                VoprList.AddRange(TmpVoprList);
                            }
                            break;
                    }
                    Hide();
                    Program.menu.Hide();
                    Program.passing.StartTest(VoprList, Test.TimeForTest, textBoxFIO.Text, textBoxClass.Text,Test.DBConnectionRequest);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void textBoxFIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '\b' || e.KeyChar == ' '))
                e.Handled = true;
        }

        private void textBoxClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '\b'))
                e.Handled = true;
        }
    }
}
