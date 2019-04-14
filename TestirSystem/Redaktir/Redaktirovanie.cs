using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace TestirSystem
{
    public partial class Editing : Form
    {
        public const int OtstupX = 10;
        public const int OtstupY = 35;

        Test TestForRedakt;

        List<CheckBox> AnswerMulti;
        List<RadioButton> AnswerSingleAlternative;

        public Editing()
        {
            InitializeComponent();
            panel1.AutoScroll = true;
            panel2.AutoScroll = true;

            AnswerMulti = new List<CheckBox>();
            AnswerSingleAlternative = new List<RadioButton>();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Program.menu.Show();
        }

        private void EnableButtons()
        {
            тестToolStripMenuItem.Enabled = true;
            сохранитьТестToolStripMenuItem.Enabled = true;
            buttonCreateSection.Enabled = true;
            buttonCreateVopr.Enabled = true;
            buttonPlaySound.Enabled = true;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TestForRedakt != null)
                if (MessageBox.Show("Вы уверены?" + Environment.NewLine + "Все несохраненные данные текущего теста будут потеряны", "Создание теста", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            EnableButtons();
            TestForRedakt = new Test();
            listBoxQuestionsISections.Items.Clear();
            listBoxQuestionsISections.Items.Add("Без раздела");
            Program.testParams.GetInfoFromTest(TestForRedakt);

            Text = "OleXis Test: Редактор тестов - Безимянный.test";
        }

        private void Editing_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.menu.Show();
        }

        private void параметрыТестаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.testParams.ShowDialog();
        }

        public Test GetTest()
        {
            return this.TestForRedakt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.sectionName.ShowDialog();
        }

        public bool CreateSection(string Name)
        {
            if (TestForRedakt.Sections.Contains(Name) || TestForRedakt.Questions.FindIndex(x => x.Name == Name) != -1)
                return false;
            else
            {
                TestForRedakt.Sections.Add(Name);
                listBoxQuestionsISections.Items.Add(Name);
                return true;
            }
        }

        public bool CreateQuestion(string Name, QuestionType Question_Type, string Text, List<string> Variants, List<int> Answers, string Section = "NONE", Bitmap Image = null, string SoundFileExt = null, byte[] FileSound = null)
        {
            if (TestForRedakt.Questions.FindIndex(x => x.Name == Name) != -1 || TestForRedakt.Sections.FindIndex(x => x == Name) != -1)
                return false;
            else
            {
                TestForRedakt.Questions.Add(new Question(Name, Question_Type, Text, Variants, Answers, Section, Image, SoundFileExt, FileSound));
                var flag = false;
                var index = 0;
                for (var i = 0; i < listBoxQuestionsISections.Items.Count; i++)
                    if (!flag)
                    {
                        if (Section == "NONE")
                            flag = true;
                        else
                        if (listBoxQuestionsISections.Items[i].ToString() == Section)
                            flag = true;
                    }
                    else
                        if (listBoxQuestionsISections.Items[i].ToString().Substring(0, 2) != "  ")
                        {
                            index = i;
                            break;
                        }
                if(listBoxQuestionsISections.Items.Count == 1)
                    index++;
                if(index == 0)
                    listBoxQuestionsISections.Items.Add("  " + Name);
                else
                    listBoxQuestionsISections.Items.Insert(index, "  " + Name);
                return true;
            }
        }

        public bool ChangeVopros(string Name, QuestionType Question_Type, string Text, List<string> Variants, List<int> Answers, string Section = "NONE", Bitmap Image = null, string SoundFileExt = null, byte[] FileSound = null)
        {
            TestForRedakt.Questions.RemoveAt(TestForRedakt.Questions.FindIndex(x => "  " + x.Name == listBoxQuestionsISections.Items[listBoxQuestionsISections.SelectedIndex].ToString()));
            listBoxQuestionsISections.Items.RemoveAt(listBoxQuestionsISections.SelectedIndex);
            if (TestForRedakt.Questions.FindIndex(x => x.Name == Name) != -1 || TestForRedakt.Sections.FindIndex(x => x == Name) != -1)
                return false;
            else
            {
                TestForRedakt.Questions.Add(new Question(Name, Question_Type, Text, Variants, Answers, Section, Image, SoundFileExt, FileSound));
                var flag = false;
                var index = 0;
                for (var i = 0; i < listBoxQuestionsISections.Items.Count; i++)
                    if (!flag)
                    {
                        if (Section == "NONE")
                            flag = true;
                        else
                        if (listBoxQuestionsISections.Items[i].ToString() == Section)
                            flag = true;
                    }
                    else
                        if (listBoxQuestionsISections.Items[i].ToString().Substring(0, 2) != "  ")
                    {
                        index = i;
                        break;
                    }
                if (listBoxQuestionsISections.Items.Count == 1)
                    index++;
                if (index == 0)
                    listBoxQuestionsISections.Items.Add("  " + Name);
                else
                    listBoxQuestionsISections.Items.Insert(index, "  " + Name);
                return true;
            }
        }

        private void listBoxQuestionsISections_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var component in AnswerMulti)
                component.Dispose();
            AnswerMulti.Clear();
            foreach (var component in AnswerSingleAlternative)
                component.Dispose();
            AnswerSingleAlternative.Clear();

            textBoxSvobodn.Visible = false;
            listBoxSequenceEstablishment.Visible = false;
            listBoxSootv.Visible = false;

            buttonPlaySound.Visible = false;
            pictureBox1.Image = null;
            labelVoprText.Text = "Текст вопроса";

            if (listBoxQuestionsISections.SelectedIndex != 0)
            {
                buttonDeleteSection.Enabled = false;
                buttonDeleteVopr.Enabled = false;
                buttonChangeVopr.Enabled = false;
                if(listBoxQuestionsISections.SelectedIndex != -1)
                {
                    if (TestForRedakt.Sections.Contains(listBoxQuestionsISections.SelectedItem))
                    {
                        buttonDeleteSection.Enabled = true;
                    }
                    else
                    {
                        var Vopr = TestForRedakt.Questions.Find(x => "  " + x.Name == listBoxQuestionsISections.SelectedItem.ToString());
                        labelVoprText.Text = Vopr.Text;
                        pictureBox1.Image = Vopr.Image;
                        if (Vopr.SoundFileExt != null)
                            buttonPlaySound.Visible = true;
                        switch (Vopr.Question_Type)
                        {
                            case QuestionType.SingleChoose:
                                for(var i = 0; i < Vopr.Variants.Count; i++)
                                {
                                    var tmp2 = new RadioButton()
                                    {
                                        Parent = panel1,
                                        Top = OtstupY * i,
                                        Left = OtstupX,
                                        Text = Vopr.Variants[i],
                                        Width = 300,
                                        Height = 30,
                                        AutoCheck = false
                                    };
                                    if (Vopr.Answers.Contains(i))
                                        tmp2.Checked = true;
                                    AnswerSingleAlternative.Add(tmp2);
                                }
                                break;
                            case QuestionType.MultiChoose:
                                for (var i = 0; i < Vopr.Variants.Count; i++)
                                {
                                    var tmp2 = new CheckBox()
                                    {
                                        Parent = panel1,
                                        Top = OtstupY * i,
                                        Left = OtstupX,
                                        Text = Vopr.Variants[i],
                                        Width = 300,
                                        Height = 30,
                                        AutoCheck = false
                                    };
                                    if (Vopr.Answers.Contains(i))
                                        tmp2.Checked = true;
                                    AnswerMulti.Add(tmp2);
                                }
                                break;
                            case QuestionType.AlternativeChoose:
                                var tmp = new RadioButton()
                                {
                                    Parent = panel1,
                                    Left = OtstupX,
                                    Text = "Да",
                                    Width = 300,
                                    Height = 30,
                                    AutoCheck = false
                                };
                                AnswerSingleAlternative.Add(tmp);
                                tmp = new RadioButton()
                                {
                                    Parent = panel1,
                                    Top = OtstupY,
                                    Left = OtstupX,
                                    Text = "Нет",
                                    Width = 300,
                                    Height = 30,
                                    AutoCheck = false
                                };
                                AnswerSingleAlternative.Add(tmp);
                                if (Vopr.Answers[0] == 0)
                                    AnswerSingleAlternative[0].Checked = true;
                                else
                                    AnswerSingleAlternative[1].Checked = true;
                                break;
                            case QuestionType.SequenceEstablishment:
                                listBoxSequenceEstablishment.Visible = true;
                                listBoxSequenceEstablishment.Items.Clear();
                                foreach (var elem in Vopr.Variants)
                                    listBoxSequenceEstablishment.Items.Add(elem);
                                break;
                            case QuestionType.AccordanceEstablishment:
                                listBoxSequenceEstablishment.Visible = true;
                                listBoxSootv.Visible = true;
                                listBoxSequenceEstablishment.Items.Clear();
                                listBoxSootv.Items.Clear();
                                var flag = false;
                                foreach (var elem in Vopr.Variants)
                                {
                                    if (flag)
                                    {
                                        listBoxSootv.Items.Add(elem);
                                        flag = false;
                                    }
                                    else
                                    {
                                        listBoxSequenceEstablishment.Items.Add(elem);
                                        flag = true;
                                    }
                                }
                                break;
                            case QuestionType.FreeStatement:
                                textBoxSvobodn.Visible = true;
                                textBoxSvobodn.Text = Vopr.Variants[0];
                                break;
                        }
                        buttonChangeVopr.Enabled = true;
                        buttonDeleteVopr.Enabled = true;
                    }
                }
            }
        }

        private void buttonDeleteSection_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление раздела", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                for (var i = 0; i < TestForRedakt.Questions.Count; i++)
                    if (TestForRedakt.Questions[i].Section == listBoxQuestionsISections.SelectedItem.ToString())
                    {
                        listBoxQuestionsISections.Items.Remove("  " + TestForRedakt.Questions[i].Name);
                        TestForRedakt.Questions.RemoveAt(i);
                        i--;
                    }
                TestForRedakt.Sections.Remove(listBoxQuestionsISections.SelectedItem.ToString());
                listBoxQuestionsISections.Items.Remove(listBoxQuestionsISections.SelectedItem);
            }
        }

        private void buttonCreateVopr_Click(object sender, EventArgs e)
        {
            Program.createQuestion.SetDefault(TestForRedakt);
            Program.createQuestion.ShowDialog();
        }

        private void buttonDeleteVopr_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы уверены?", "Удаление вопроса", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var i = TestForRedakt.Questions.FindIndex(x => "  " + x.Name == listBoxQuestionsISections.SelectedItem.ToString());
                listBoxQuestionsISections.Items.RemoveAt(listBoxQuestionsISections.SelectedIndex);
                TestForRedakt.Questions.RemoveAt(i);
            }
        }

        private void buttonChangeVopr_Click(object sender, EventArgs e)
        {
            Program.createQuestion.SetVopros(TestForRedakt, TestForRedakt.Questions[TestForRedakt.Questions.FindIndex(x => "  " + x.Name == listBoxQuestionsISections.SelectedItem.ToString())]);
            Program.createQuestion.ShowDialog();
        }

        private void сохранитьТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TestForRedakt.Password == "")
                if (MessageBox.Show("Для данного теста не задан пароль" + Environment.NewLine + "Сохранить тест без пароля?", "Сохранение теста", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;

            using (var sf = new SaveFileDialog())
            {
                sf.Filter = "Файлы теста (*.test)|*.test";
                if(sf.ShowDialog() == DialogResult.OK)
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

                    TestForRedakt.SaveToFile(sf.FileName, "tmp");

                    foreach (var fil in Directory.GetFiles("tmp"))
                        File.Delete(fil);
                    Directory.Delete("tmp");
                }

                Text = "OleXis Test: Редактор тестов - " + sf.FileName.Substring(sf.FileName.LastIndexOf('\\') + 1);
            }
        }

        private void buttonPlaySound_Click(object sender, EventArgs e)
        {
            var Question = TestForRedakt.Questions.Find(x => "  " + x.Name == listBoxQuestionsISections.SelectedItem.ToString());
            Program.PlaySound(Question.SoundFile, Question.SoundFileExt);
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TestForRedakt != null)
                if (MessageBox.Show("Вы уверены?" + Environment.NewLine + "Все несохраненные данные текущего теста будут потеряны", "Загрузка теста", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
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

                    var Password = "";
                    var isfirst = true;
                    while (true)
                    {
                        try
                        {
                            TestForRedakt = new Test(op.FileName, "tmp", Password);
                            break;
                        }
                        catch
                        {
                            if (isfirst)
                            {
                                isfirst = false;
                            }
                            else
                            {
                                MessageBox.Show("Ошибка: файл поврежден или введен неверный пароль");
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

                    listBoxQuestionsISections.Items.Clear();
                    listBoxQuestionsISections.Items.Add("Без раздела");
                    Program.testParams.GetInfoFromTest(TestForRedakt);

                    foreach(var Section in TestForRedakt.Sections)
                        listBoxQuestionsISections.Items.Add(Section);

                    foreach(var Questionos in TestForRedakt.Questions)
                    {
                        var flag = false;
                        var index = 0;
                        for (var i = 0; i < listBoxQuestionsISections.Items.Count; i++)
                            if (!flag)
                            {
                                if (Questionos.Section == "NONE")
                                    flag = true;
                                else
                                if (listBoxQuestionsISections.Items[i].ToString() == Questionos.Section)
                                    flag = true;
                            }
                            else
                            if (listBoxQuestionsISections.Items[i].ToString().Substring(0, 2) != "  ")
                            {
                                index = i;
                                break;
                            }
                        if (listBoxQuestionsISections.Items.Count == 1)
                            index++;
                        if (index == 0)
                            listBoxQuestionsISections.Items.Add("  " + Questionos.Name);
                        else
                            listBoxQuestionsISections.Items.Insert(index, "  " + Questionos.Name);
                    }
                    EnableButtons();

                    Text = "OleXis Test: Редактор тестов - " + op.FileName.Substring(op.FileName.LastIndexOf('\\') + 1);
                }
            }
        }

        private void создатьВопросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonCreateVopr_Click(buttonCreateVopr, new EventArgs());
        }

        private void редактироватьВопросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonChangeVopr_Click(buttonChangeVopr, new EventArgs());
        }

        private void создатьРазделToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(buttonChangeVopr, new EventArgs());
        }
    }
}
