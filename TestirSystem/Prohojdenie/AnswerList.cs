using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TestirSystem
{
    public partial class AnswerList : Form
    {
        //Элементы, отображающие информацию
        List<Label> Ansvers;

        public AnswerList()
        {
            InitializeComponent();
            Ansvers = new List<Label>();
        }

        //Очищает элементы отображения
        public void ClearAnswers()
        {
            Ansvers.Clear();
        }

        //Добавляет информацию об ответе пользователя для одиночного, множественного и альтернативного выбора
        public void AddAnswerSingleMultiAlternative(string QuestionText, List<string> AnswerVariants, List<int> UserAnswer, List<int> RightAnswer)
        {
            //Текст вопроса
            var lbltmp = new Label()
            {
                AutoSize = true,
                Parent = panel,
                Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                Text = QuestionText
            };
            Ansvers.Add(lbltmp);
            //Каждый возможный вариант ответа
            for (var i = 0; i < AnswerVariants.Count; i++)
            {
                lbltmp = new Label()
                {
                    AutoSize = true,
                    Parent = panel,
                    Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                    Text = "    " + AnswerVariants[i]
                };
                if (UserAnswer.Contains(i) && RightAnswer.Contains(i)) //Правильный ответ
                    lbltmp.ForeColor = Color.Green;
                else
                if (!UserAnswer.Contains(i) && RightAnswer.Contains(i)) //Пользователь не выбрал правильный ответ
                    lbltmp.ForeColor = Color.Red;
                else
                if (UserAnswer.Contains(i) && !RightAnswer.Contains(i)) //Неправильный ответ
                    lbltmp.ForeColor = Color.DarkRed;
                Ansvers.Add(lbltmp);
            }
        }

        //Добавляет информацию об ответе пользователя для установления последовательности
        public void AddAnswerSequence(string QuestionText, List<string> UserAnswer, List<string> RightAnswer)
        {
            //Текст вопроса
            var lbltmp = new Label()
            {
                AutoSize = true,
                Parent = panel,
                Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                Text = QuestionText
            };
            Ansvers.Add(lbltmp);

            //Вывод правильной последовательности
            lbltmp = new Label()
            {
                AutoSize = true,
                Parent = panel,
                Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                Text = "  " + "Правильный вариант:"
            };
            Ansvers.Add(lbltmp);
            foreach (var Variant in RightAnswer)
            {
                lbltmp = new Label()
                {
                    AutoSize = true,
                    Parent = panel,
                    Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                    Text = "    " + Variant,
                    ForeColor = Color.Green
                };
                Ansvers.Add(lbltmp);
            }

            //Вывод последовательности, введенной пользователем
            lbltmp = new Label()
            {
                AutoSize = true,
                Parent = panel,
                Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                Text = "  " + "Ваш ответ:"
            };
            Ansvers.Add(lbltmp);
            for (var i = 0; i < RightAnswer.Count; i++)
            {
                lbltmp = new Label()
                {
                    AutoSize = true,
                    Parent = panel,
                    Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                    Text = "    " + UserAnswer[i],
                    ForeColor = (UserAnswer[i] == RightAnswer[i]) ? Color.Green : Color.Red
                };
                Ansvers.Add(lbltmp);
            }
        }

        //Добавляет информацию об ответе пользователя для установления соответствия
        public void AddAnswerAccordance(string QuestionText, List<string> Accordance, List<string> UserAnswer, List<string> RightAnswer)
        {
            //Текст вопроса
            var lbltmp = new Label()
            {
                AutoSize = true,
                Parent = panel,
                Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                Text = QuestionText
            };
            Ansvers.Add(lbltmp);

            //Вывод правильных соответствий
            lbltmp = new Label()
            {
                AutoSize = true,
                Parent = panel,
                Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                Text = "  " + "Правильный вариант:"
            };
            Ansvers.Add(lbltmp);
            for (var i = 0; i < RightAnswer.Count; i++)
            {
                lbltmp = new Label()
                {
                    AutoSize = true,
                    Parent = panel,
                    Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                    Text = "    " + RightAnswer[i] + " - " + Accordance[i],
                    ForeColor = Color.Green
                };
                Ansvers.Add(lbltmp);
            }

            //Вывод соответствий, введенных пользователем
            lbltmp = new Label()
            {
                AutoSize = true,
                Parent = panel,
                Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                Text = "  " + "Ваш ответ:"
            };
            Ansvers.Add(lbltmp);
            for (var i = 0; i < RightAnswer.Count; i++)
            {
                lbltmp = new Label()
                {
                    AutoSize = true,
                    Parent = panel,
                    Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                    Text = "    " + UserAnswer[i] + " - " + Accordance[i],
                    ForeColor = (UserAnswer[i] == RightAnswer[i]) ? Color.Green : Color.Red
                };
                Ansvers.Add(lbltmp);
            }
        }

        //Добавляет информацию об ответе пользователя для свободного изложения
        public void AddAnswerFree(string QuestionText, string RightAnswer, string UserAnswer)
        {
            //Текст вопроса
            var lbltmp = new Label()
            {
                AutoSize = true,
                Parent = panel,
                Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                Text = QuestionText
            };

            //Вывод правильного ответа
            lbltmp = new Label()
            {
                AutoSize = true,
                Parent = panel,
                Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                Text = "  " + "Правильный вариант:"
            };
            Ansvers.Add(lbltmp);
            lbltmp = new Label()
            {
                AutoSize = true,
                Parent = panel,
                Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                Text = "    " + RightAnswer,
                ForeColor = Color.Green
            };
            Ansvers.Add(lbltmp);

            //Вывод ответа пользователя
            lbltmp = new Label()
            {
                AutoSize = true,
                Parent = panel,
                Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                Text = "  " + "Ваш ответ:"
            };
            Ansvers.Add(lbltmp);
            lbltmp = new Label()
            {
                AutoSize = true,
                Parent = panel,
                Top = (Ansvers.Count > 0) ? Ansvers.Last().Top + Ansvers.Last().Height : 0,
                Text = "    " + UserAnswer,
                ForeColor = (UserAnswer == RightAnswer) ? Color.Green : Color.Red
            };
            Ansvers.Add(lbltmp);
        }

        //Выход
        private void buttonOK_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
