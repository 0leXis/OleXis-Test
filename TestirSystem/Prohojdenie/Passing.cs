using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TestirSystem
{

    public partial class Passing : Form
    {
        //Отступы для элементов
        public const int OtstupX = 10;
        public const int OtstupY = 35;

        //Информация вопросов
        List<Question> Questions;
        List<bool> Answers;
        byte[] SoundFile;
        string SoundExt;
        //Номер вопроса
        int Question;
        //Время на тест
        int TimeForTest;
        //Время до конца теста
        int Minutes;
        int Seconds;
        //Строка подключения к БД
        string DBConnection;
        //Данные о студенте
        string FullName;
        string Group;
        //Компоненты, отображающие варианты ответа
        List<CheckBox> answerMulti;
        List<RadioButton> answerSingleAlternative;
        //Рандом генератор
        Random Rnd;

        public Passing()
        {
            InitializeComponent();
            answerMulti = new List<CheckBox>();
            answerSingleAlternative = new List<RadioButton>();
            Rnd = new Random();
        }

        //Начинает прохождение теста
        public void StartTest(List<Question> Questions, int Time, string FullName, string Group, string DBConnection = "")
        {
            //Установка начального состояния
            Program.answerList.ClearAnswers();
            Answers = new List<bool>();
            Show();
            Question = 0;
            this.Questions = Questions;
            TimeForTest = Time;
            Minutes = Time;
            Seconds = 0;
            this.DBConnection = DBConnection;
            this.FullName = FullName;
            this.Group = Group;
            //Отобразить первый вопрос
            ShowNextVopr(true);
            //Запустить таймер, если время ограничено
            if (TimeForTest != 0)
                timer.Start();
            else
                labelTime.Text = "Временя не ограничено";
        }

        //Отображает следующий вопрос
        public void ShowNextVopr(bool first)
        {
            //Получить ответ на текущий вопрос
            if (!first)
            {
                switch(Questions[Question].Question_Type)
                {
                    case QuestionType.AlternativeChoose:
                    case QuestionType.SingleChoose:
                        if (answerSingleAlternative[Questions[Question].Answers[0]].Checked == true)
                            Answers.Add(true);
                        else
                            Answers.Add(false);

                        var lsttmp = new List<int>();
                        for (var i = 0; i < answerSingleAlternative.Count; i++)
                            if (answerSingleAlternative[i].Checked)
                                lsttmp.Add(i);

                        List<string> lsttmp1;
                        if(Questions[Question].Question_Type == QuestionType.AlternativeChoose)
                        {
                            lsttmp1 = new List<string>();
                            lsttmp1.Add("Да");
                            lsttmp1.Add("Нет");
                            Program.answerList.AddAnswerSingleMultiAlternative(Questions[Question].Text, lsttmp1, lsttmp, Questions[Question].Answers);
                        }
                        else
                        {
                            Program.answerList.AddAnswerSingleMultiAlternative(Questions[Question].Text, Questions[Question].Variants, lsttmp, Questions[Question].Answers);
                        }

                        break;
                    case QuestionType.MultiChoose:
                        var flag = true;
                        foreach(var otv in Questions[Question].Answers)
                            if (answerMulti[otv].Checked != true)
                            {
                                flag = false;
                                break;
                            }
                        if(flag)
                            Answers.Add(true);
                        else
                            Answers.Add(false);

                        lsttmp = new List<int>();
                        for (var i = 0; i < answerMulti.Count; i++)
                            if (answerMulti[i].Checked)
                                lsttmp.Add(i);
                        Program.answerList.AddAnswerSingleMultiAlternative(Questions[Question].Text, Questions[Question].Variants, lsttmp, Questions[Question].Answers);

                        break;
                    case QuestionType.SequenceEstablishment:
                        flag = true;
                        for (var i = 0; i < listBoxSequenceEstablishment.Items.Count; i++)
                            if (listBoxSequenceEstablishment.Items[i].ToString() != Questions[Question].Variants[i])
                            {
                                flag = false;
                                break;
                            }
                        if(flag)
                            Answers.Add(true);
                        else
                            Answers.Add(false);

                        var lsttmp2 = new List<string>();
                        foreach (var elem in listBoxSequenceEstablishment.Items)
                            lsttmp2.Add(elem.ToString());
                        Program.answerList.AddAnswerSequence(Questions[Question].Text, lsttmp2, Questions[Question].Variants);

                        break;
                    case QuestionType.AccordanceEstablishment:
                        flag = true;
                        for (var i = 0; i < listBoxSequenceEstablishment.Items.Count; i++)
                        {
                            var sootv = Questions[Question].Variants.FindIndex(x => x == listBoxSequenceEstablishment.Items[i].ToString()) + 1;
                            if (listBoxSootv.Items[i].ToString() != Questions[Question].Variants[sootv])
                            {
                                flag = false;
                                break;
                            }
                        }
                        if(flag)
                            Answers.Add(true);
                        else
                            Answers.Add(false);

                        lsttmp2 = new List<string>();
                        foreach (var elem in listBoxSequenceEstablishment.Items)
                            lsttmp2.Add(elem.ToString());

                        var lsttmp3 = new List<string>();
                        foreach (var elem in listBoxSootv.Items)
                            lsttmp3.Add(elem.ToString());

                        var lsttmp4 = new List<string>();
                        for(var i = 0; i < lsttmp3.Count; i++)
                           lsttmp4.Add(Questions[Question].Variants[Questions[Question].Variants.FindIndex(x => x == lsttmp3[i]) - 1]);

                        Program.answerList.AddAnswerAccordance(Questions[Question].Text, lsttmp3, lsttmp2, lsttmp4);

                        break;
                    case QuestionType.FreeStatement:
                        if (textBoxSvobodn.Text == Questions[Question].Variants[0])
                            Answers.Add(true);
                        else
                            Answers.Add(false);

                        Program.answerList.AddAnswerFree(Questions[Question].Text, Questions[Question].Variants[0], textBoxSvobodn.Text);

                        break;
                }
                Question++;
                if (Question == Questions.Count)
                {
                    ShowResults();
                    return;
                }
            }

            //////////////////////////////////////
            groupBoxQuestion.Text = "Вопрос " + (Question + 1).ToString() + @"\" + Questions.Count;

            foreach (var component in answerMulti)
                component.Dispose();
            answerMulti.Clear();
            foreach (var component in answerSingleAlternative)
                component.Dispose();
            answerSingleAlternative.Clear();

            textBoxSvobodn.Visible = false;
            listBoxSequenceEstablishment.Visible = false;
            listBoxSootv.Visible = false;

            buttonPlaySound.Visible = false;
            pictureBox1.Image = null;

            buttonNextQuestion.Enabled = true;

            labelVoprText.Text = Questions[Question].Text;
            pictureBox1.Image = Questions[Question].Image;
            if (Questions[Question].SoundFileExt != null)
            {
                SoundFile = Questions[Question].SoundFile;
                SoundExt = Questions[Question].SoundFileExt;
                buttonPlaySound.Visible = true;
            }
            switch (Questions[Question].Question_Type)
            {
                case QuestionType.SingleChoose:
                    buttonNextQuestion.Enabled = false;
                    var set = new HashSet<int>();
                    for (var i = 0; i < Questions[Question].Variants.Count; i++)
                    {
                        var Rndnum = Rnd.Next(0, Questions[Question].Variants.Count);
                        while(set.Contains(Rndnum))
                            Rndnum = Rnd.Next(0, Questions[Question].Variants.Count);
                        set.Add(Rndnum);
                        var tmp2 = new RadioButton()
                        {
                            Parent = panel1,
                            Top = OtstupY * Rndnum,
                            Left = OtstupX,
                            Text = Questions[Question].Variants[i],
                            Width = 300,
                            Height = 30,
                        };
                        tmp2.Click += radioButton_Click;
                        answerSingleAlternative.Add(tmp2);
                        groupBox2.Text = "Выберите один вариант ответа";
                    }
                    break;
                case QuestionType.MultiChoose:
                    set = new HashSet<int>();
                    for (var i = 0; i < Questions[Question].Variants.Count; i++)
                    {
                        var Rndnum = Rnd.Next(0, Questions[Question].Variants.Count);
                        while (set.Contains(Rndnum))
                            Rndnum = Rnd.Next(0, Questions[Question].Variants.Count);
                        set.Add(Rndnum);
                        var tmp2 = new CheckBox()
                        {
                            Parent = panel1,
                            Top = OtstupY * Rndnum,
                            Left = OtstupX,
                            Text = Questions[Question].Variants[i],
                            Width = 300,
                            Height = 30,
                        };
                        answerMulti.Add(tmp2);
                        groupBox2.Text = "Выберите один или несколько вариантов ответа";
                    }
                    break;
                case QuestionType.AlternativeChoose:
                    buttonNextQuestion.Enabled = false;
                    var tmp = new RadioButton()
                    {
                        Parent = panel1,
                        Left = OtstupX,
                        Text = "Да",
                        Width = 300,
                        Height = 30,
                    };
                    tmp.Click += radioButton_Click;
                    answerSingleAlternative.Add(tmp);
                    tmp = new RadioButton()
                    {
                        Parent = panel1,
                        Top = OtstupY,
                        Left = OtstupX,
                        Text = "Нет",
                        Width = 300,
                        Height = 30,
                    };
                    tmp.Click += radioButton_Click;
                    answerSingleAlternative.Add(tmp);
                    groupBox2.Text = "Выберите один вариант ответа";
                    break;
                case QuestionType.SequenceEstablishment:
                    set = new HashSet<int>();
                    listBoxSequenceEstablishment.Visible = true;
                    listBoxSequenceEstablishment.Items.Clear();
                    for(var i = 0; i < Questions[Question].Variants.Count; i++)
                    {
                        var Rndnum = Rnd.Next(0, Questions[Question].Variants.Count);
                        while (set.Contains(Rndnum))
                            Rndnum = Rnd.Next(0, Questions[Question].Variants.Count);
                        set.Add(Rndnum);
                        listBoxSequenceEstablishment.Items.Add(Questions[Question].Variants[Rndnum]);
                    }
                    groupBox2.Text = "Перетаскивайте элементы списка для составления последовательности";
                    break;
                case QuestionType.AccordanceEstablishment:
                    set = new HashSet<int>();
                    listBoxSequenceEstablishment.Visible = true;
                    listBoxSootv.Visible = true;
                    listBoxSequenceEstablishment.Items.Clear();
                    listBoxSootv.Items.Clear();
                    for (var i = 0; i < Questions[Question].Variants.Count; i++)
                    {
                        var Rndnum = Rnd.Next(0, Questions[Question].Variants.Count);
                        while (set.Contains(Rndnum))
                            Rndnum = Rnd.Next(0, Questions[Question].Variants.Count);
                        set.Add(Rndnum);
                        if(Rndnum % 2 == 0)
                            listBoxSequenceEstablishment.Items.Add(Questions[Question].Variants[Rndnum]);
                        else
                            listBoxSootv.Items.Add(Questions[Question].Variants[Rndnum]);
                    }
                    groupBox2.Text = "Перетаскивайте элементы первого списка для установления соответствий";
                    break;
                case QuestionType.FreeStatement:
                    buttonNextQuestion.Enabled = false;
                    textBoxSvobodn.Visible = true;
                    textBoxSvobodn.Text = "";
                    groupBox2.Text = "Введите ответ";
                    break;
            }
        }

        public void ShowResults()
        {
            timer.Stop();
            var ocenka = (int)Math.Round(10 - (double)Answers.Count(x => x == false) * Answers.Count / 10);
            Program.rezult.SetResult(ocenka, Answers.Count(x => x == true), Answers.Count, FullName, Group, Minutes, Seconds, TimeForTest);
            Program.rezult.ShowDialog();

            if(DBConnection != "")
            {
                var flag = false;
                Program.dbProcessor = new DBProcessor(DBConnection);
                var Error = "";
                if (Program.dbProcessor.OpenConnection(ref Error))
                {
                    if (Program.dbProcessor.CreateTestTable(ref Error))
                    {
                        if(!Program.dbProcessor.InsertItem(FullName, Group, ocenka, ref Error))
                            flag = true;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = true;
                }
                if (flag)
                    MessageBox.Show("Ошибка при записи в БД!" + Environment.NewLine + Error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Данные успешно добавлены в БД", "БД", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.dbProcessor.CloseConnection();
            }

            Hide();
            Program.menu.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Seconds == 0)
            {
                Seconds = 60;
                Minutes -= 1;
            }
            Seconds -= 1;

            labelTime.Text = "Времени осталось: " + Minutes + ":" + Seconds;

            if (Minutes < 0)
            {
                timer.Stop();
                while (Answers.Count < Questions.Count)
                    Answers.Add(false);
                ShowResults();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowNextVopr(false);
        }

        //индекс перемещаемого элемента
        int indexToMove;

        private void listBoxSequenceEstablishment_DragDrop(object sender, DragEventArgs e)
        {
            //индекс, куда перемещаем
            int newIndex = listBoxSequenceEstablishment.IndexFromPoint(listBoxSequenceEstablishment.PointToClient(new Point(e.X, e.Y)));
            //если вставка происходит в начало списка
            if (newIndex == -1)
            {
                //получаем перетаскиваемый элемент
                object itemToMove = listBoxSequenceEstablishment.Items[indexToMove];
                //удаляем элемент
                listBoxSequenceEstablishment.Items.RemoveAt(indexToMove);
                //добавляем в конец списка
                listBoxSequenceEstablishment.Items.Add(itemToMove);
            }
            //вставляем где-то в середину списка
            else if (indexToMove != newIndex)
            {
                //получаем перетаскиваемый элемент
                object itemToMove = listBoxSequenceEstablishment.Items[indexToMove];
                //удаляем элемент
                listBoxSequenceEstablishment.Items.RemoveAt(indexToMove);
                //вставляем в конкретную позицию
                listBoxSequenceEstablishment.Items.Insert(newIndex, itemToMove);
            }
        }

        private void listBoxSequenceEstablishment_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listBoxSequenceEstablishment_MouseMove(object sender, MouseEventArgs e)
        {
            //если нажата левая кнопка мыши, начинаем Drag&Drop
            if (e.Button == MouseButtons.Left)
            {
                //индекс элемента, который мы перемещаем
                indexToMove = listBoxSequenceEstablishment.IndexFromPoint(e.X, e.Y);
                listBoxSequenceEstablishment.DoDragDrop(indexToMove, DragDropEffects.Move);
            }
        }

        private void buttonPlaySound_Click(object sender, EventArgs e)
        {
            Program.PlaySound(SoundFile, SoundExt);
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            buttonNextQuestion.Enabled = true;
        }

        private void textBoxSvobodn_TextChanged(object sender, EventArgs e)
        {
            if(textBoxSvobodn.Text != "")
                buttonNextQuestion.Enabled = true;
            else
                buttonNextQuestion.Enabled = false;
        }

        private void buttonStopTest_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены?" + Environment.NewLine + "Все не пройденные вопросы будут считатся ошибками", "Завершить тест", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                while (Answers.Count < Questions.Count)
                    Answers.Add(false);
                ShowResults();
            }
        }
    }
}
