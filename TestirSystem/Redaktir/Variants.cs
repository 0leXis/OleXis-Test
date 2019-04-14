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
    public partial class Variants : Form
    {
        //Отступы для компонентов
        public const int OtstupX = 10;
        public const int OtstupY = 35;
        
        //Поля для ввода
        List<TextBox> TextVariant;
        List<TextBox> AccordanceEstablishment;
        List<Button> DeleteVariant;
        List<Button> UpVariant;
        List<Button> DownVariant;
        List<RadioButton> CorrectVariantSingle;
        List<CheckBox> CorrectVariantMulti;
        //Тип вопроса
        QuestionType _QuestionType = QuestionType.SingleChoose;
        //Свойство для типа
        public QuestionType QuestionType
        {
            get
            {
                return _QuestionType;
            }
            set
            {
                //В зависимости от типа вопроса отобразить определенные элементы
                if(_QuestionType != value)
                {
                    foreach (var component in TextVariant)
                        component.Dispose();
                    TextVariant.Clear();
                    foreach (var component in AccordanceEstablishment)
                        component.Dispose();
                    AccordanceEstablishment.Clear();
                    foreach (var component in DeleteVariant)
                        component.Dispose();
                    DeleteVariant.Clear();
                    foreach (var component in UpVariant)
                        component.Dispose();
                    UpVariant.Clear();
                    foreach (var component in DownVariant)
                        component.Dispose();
                    DownVariant.Clear();
                    foreach (var component in CorrectVariantSingle)
                        component.Dispose();
                    CorrectVariantSingle.Clear();
                    foreach (var component in CorrectVariantMulti)
                        component.Dispose();
                    CorrectVariantMulti.Clear();

                    textBoxAnswer.Text = "";
                    if(value == QuestionType.FreeStatement)
                    {
                        textBoxAnswer.Visible = true;
                        labelAnswer.Visible = true;
                        buttonAddVariant.Visible = false;
                        radioButtonNo.Visible = false;
                        radioButtonYes.Visible = false;
                    }
                    else
                    if(value == QuestionType.AlternativeChoose)
                    {
                        textBoxAnswer.Visible = false;
                        labelAnswer.Visible = false;
                        buttonAddVariant.Visible = false;
                        radioButtonNo.Visible = true;
                        radioButtonYes.Visible = true;
                    }
                    else
                    {
                        textBoxAnswer.Visible = false;
                        labelAnswer.Visible = false;
                        buttonAddVariant.Visible = true;
                        radioButtonNo.Visible = false;
                        radioButtonYes.Visible = false;
                    }

                    _QuestionType = value;
                }
            }
        }

        public Variants()
        {
            InitializeComponent();
            panel.AutoScroll = true;
            //Инициализация переменных
            TextVariant = new List<TextBox>();
            AccordanceEstablishment = new List<TextBox>();
            DeleteVariant = new List<Button>();
            UpVariant = new List<Button>();
            DownVariant = new List<Button>();
            CorrectVariantMulti = new List<CheckBox>();
            CorrectVariantSingle = new List<RadioButton>();

            QuestionType QuestionType = QuestionType.SingleChoose;
            textBoxAnswer.Visible = false;
            labelAnswer.Visible = false;
            radioButtonNo.Visible = false;
            radioButtonYes.Visible = false;
        }
        //Устанавливает варианты ответа
        public void SetVariants(List<string> Variants, List<int> Answers)
        {
            switch (QuestionType)
            {
                case QuestionType.AlternativeChoose:
                    if (Answers[0] == 0)
                        radioButtonYes.Checked = true;
                    else
                        radioButtonNo.Checked = true;
                    break;
                case QuestionType.MultiChoose:
                    for(var i = 0; i < Variants.Count; i++)
                    {
                        buttonAddVariant_Click(this, new EventArgs());
                        TextVariant[i].Text = Variants[i];
                        if (Answers.Contains(i))
                            CorrectVariantMulti[i].Checked = true;
                    }
                    break;
                case QuestionType.SingleChoose:
                    for (var i = 0; i < Variants.Count; i++)
                    {
                        buttonAddVariant_Click(this, new EventArgs());
                        TextVariant[i].Text = Variants[i];
                        if (Answers.Contains(i))
                            CorrectVariantSingle[i].Checked = true;
                    }
                    break;
                case QuestionType.SequenceEstablishment:
                    for (var i = 0; i < Variants.Count; i++)
                    {
                        buttonAddVariant_Click(this, new EventArgs());
                        TextVariant[i].Text = Variants[i];
                    }
                    break;
                case QuestionType.AccordanceEstablishment:
                    for (var i = 0; i < Variants.Count / 2; i++)
                    {
                        buttonAddVariant_Click(this, new EventArgs());
                        TextVariant[i].Text = Variants[i];
                        AccordanceEstablishment[i].Text = Variants[i + 1];
                    }
                    break;
                case QuestionType.FreeStatement:
                    textBoxAnswer.Text = Variants[0];
                    break;
            }
        }
        //Кнопка Добавить вариант
        private void buttonAddVariant_Click(object sender, EventArgs e)
        {
            switch (QuestionType)
            {
                case QuestionType.SingleChoose:
                case QuestionType.MultiChoose:
                    var TmpTxt = new TextBox()
                    {
                        Parent = panel,
                        Top = TextVariant.Count * OtstupY,
                        Left = OtstupX,
                        Width = 330,
                        Height = 30
                    };
                    TextVariant.Add(TmpTxt);

                    var TmpBtn = new Button()
                    {
                        Parent = panel,
                        Top = DeleteVariant.Count * OtstupY,
                        Left = TextVariant.Last().Left + TextVariant.Last().Width + OtstupX,
                        Text = "Удалить",
                        Width = 90,
                        Height = 30
                    };
                    TmpBtn.Click += ButtonDeleteClick;
                    DeleteVariant.Add(TmpBtn);

                    if(QuestionType == QuestionType.MultiChoose)
                    {
                        var TmpChk = new CheckBox()
                        {
                            Parent = panel,
                            Top = CorrectVariantMulti.Count * OtstupY,
                            Left = DeleteVariant.Last().Left + DeleteVariant.Last().Width + OtstupX,
                            Text = "Правильный вариант",
                            Width = 200,
                            Height = 30
                        };
                        CorrectVariantMulti.Add(TmpChk);
                    }
                    else
                    {
                        var TmpRad = new RadioButton()
                        {
                            Parent = panel,
                            Top = CorrectVariantSingle.Count * OtstupY,
                            Left = DeleteVariant.Last().Left + DeleteVariant.Last().Width + OtstupX,
                            Text = "Правильный вариант",
                            Width = 200,
                            Height = 30
                        };
                        if (CorrectVariantSingle.Count == 0)
                            TmpRad.Checked = true;
                        CorrectVariantSingle.Add(TmpRad);
                    }
                    break;
                case QuestionType.SequenceEstablishment:
                    TmpTxt = new TextBox()
                    {
                        Parent = panel,
                        Top = TextVariant.Count * OtstupY,
                        Left = OtstupX,
                        Width = 330,
                        Height = 30
                    };
                    TextVariant.Add(TmpTxt);

                    TmpBtn = new Button()
                    {
                        Parent = panel,
                        Top = UpVariant.Count * OtstupY,
                        Left = TextVariant.Last().Left + TextVariant.Last().Width + OtstupX,
                        Text = " ↓",
                        Width = 40,
                        Height = 30
                    };
                    TmpBtn.Click += UpClick;
                    UpVariant.Add(TmpBtn);

                    TmpBtn = new Button()
                    {
                        Parent = panel,
                        Top = DownVariant.Count * OtstupY,
                        Left = UpVariant.Last().Left + UpVariant.Last().Width + OtstupX,
                        Text = " ↑",
                        Width = 40,
                        Height = 30
                    };
                    TmpBtn.Click += DownClick;
                    DownVariant.Add(TmpBtn);

                    TmpBtn = new Button()
                    {
                        Parent = panel,
                        Top = DeleteVariant.Count * OtstupY,
                        Left = DownVariant.Last().Left + DownVariant.Last().Width + OtstupX,
                        Text = "Удалить",
                        Width = 90,
                        Height = 30
                    };
                    TmpBtn.Click += ButtonDeleteClick;
                    DeleteVariant.Add(TmpBtn);
                    break;
                case QuestionType.AccordanceEstablishment:
                    TmpTxt = new TextBox()
                    {
                        Parent = panel,
                        Top = TextVariant.Count * OtstupY,
                        Left = OtstupX,
                        Width = 330,
                        Height = 30
                    };
                    TextVariant.Add(TmpTxt);

                    TmpTxt = new TextBox()
                    {
                        Parent = panel,
                        Top = AccordanceEstablishment.Count * OtstupY,
                        Left = TextVariant.Last().Left + TextVariant.Last().Width + OtstupX,
                        Width = 330,
                        Height = 30
                    };
                    AccordanceEstablishment.Add(TmpTxt);

                    TmpBtn = new Button()
                    {
                        Parent = panel,
                        Top = DeleteVariant.Count * OtstupY,
                        Left = AccordanceEstablishment.Last().Left + AccordanceEstablishment.Last().Width + OtstupX,
                        Text = "Удалить",
                        Width = 90,
                        Height = 30
                    };
                    TmpBtn.Click += ButtonDeleteClick;
                    DeleteVariant.Add(TmpBtn);
                    break;
            }
        }
        //Поместить вариант выше
        public void UpClick(object Sender, EventArgs e)
        {
            var tmp = Sender as Button;
            var index = UpVariant.FindIndex(x => x == tmp);
            if(index < UpVariant.Count - 1)
            {
                var tmpcomp = TextVariant[index];
                TextVariant[index] = TextVariant[index + 1];
                TextVariant[index + 1] = tmpcomp;

                var tmpbtn = UpVariant[index];
                UpVariant[index] = UpVariant[index + 1];
                UpVariant[index + 1] = tmpbtn;

                tmpbtn = DownVariant[index];
                DownVariant[index] = DownVariant[index + 1];
                DownVariant[index + 1] = tmpbtn;

                tmpbtn = DeleteVariant[index];
                DeleteVariant[index] = DeleteVariant[index + 1];
                DeleteVariant[index + 1] = tmpbtn;

                TextVariant[index + 1].Top += OtstupY;
                UpVariant[index + 1].Top += OtstupY;
                DownVariant[index + 1].Top += OtstupY;
                DeleteVariant[index + 1].Top += OtstupY;

                TextVariant[index].Top -= OtstupY;
                UpVariant[index].Top -= OtstupY;
                DownVariant[index].Top -= OtstupY;
                DeleteVariant[index].Top -= OtstupY;
            }
        }
        //Поместить вариант ниже
        public void DownClick(object Sender, EventArgs e)
        {
            var tmp = Sender as Button;
            var index = DownVariant.FindIndex(x => x == tmp);
            if (index > 0)
            {
                var tmpcomp = TextVariant[index];
                TextVariant[index] = TextVariant[index - 1];
                TextVariant[index - 1] = tmpcomp;

                var tmpbtn = UpVariant[index];
                UpVariant[index] = UpVariant[index - 1];
                UpVariant[index - 1] = tmpbtn;

                tmpbtn = DownVariant[index];
                DownVariant[index] = DownVariant[index - 1];
                DownVariant[index - 1] = tmpbtn;

                tmpbtn = DeleteVariant[index];
                DeleteVariant[index] = DeleteVariant[index - 1];
                DeleteVariant[index - 1] = tmpbtn;

                TextVariant[index].Top += OtstupY;
                UpVariant[index].Top += OtstupY;
                DownVariant[index].Top += OtstupY;
                DeleteVariant[index].Top += OtstupY;

                TextVariant[index - 1].Top -= OtstupY;
                UpVariant[index - 1].Top -= OtstupY;
                DownVariant[index - 1].Top -= OtstupY;
                DeleteVariant[index - 1].Top -= OtstupY;
            }
        }
        //Удалить вариант
        public void ButtonDeleteClick(object Sender, EventArgs e)
        {
            var tmp = Sender as Button;
            var index = DeleteVariant.FindIndex(x => x == tmp);
            switch (QuestionType)
            {
                case QuestionType.SingleChoose:
                case QuestionType.MultiChoose:
                    TextVariant[index].Dispose();
                    DeleteVariant[index].Dispose();
                    if(QuestionType == QuestionType.MultiChoose)
                        CorrectVariantMulti[index].Dispose();
                    else
                        CorrectVariantSingle[index].Dispose();

                    TextVariant.RemoveAt(index);
                    DeleteVariant.RemoveAt(index);
                    if (QuestionType == QuestionType.MultiChoose)
                        CorrectVariantMulti.RemoveAt(index);
                    else
                        CorrectVariantSingle.RemoveAt(index);

                    for (var i = index; i < TextVariant.Count; i++)
                    {
                        TextVariant[i].Top -= OtstupY;
                        DeleteVariant[i].Top -= OtstupY;
                        if (QuestionType == QuestionType.MultiChoose)
                            CorrectVariantMulti[i].Top -= OtstupY;
                        else
                            CorrectVariantSingle[i].Top -= OtstupY;
                    }
                    break;
                case QuestionType.SequenceEstablishment:
                    TextVariant[index].Dispose();
                    DeleteVariant[index].Dispose();
                    UpVariant[index].Dispose();
                    DownVariant[index].Dispose();

                    TextVariant.RemoveAt(index);
                    DeleteVariant.RemoveAt(index);
                    UpVariant.RemoveAt(index);
                    DownVariant.RemoveAt(index);

                    for (var i = index; i < TextVariant.Count; i++)
                    {
                        TextVariant[i].Top -= OtstupY;
                        UpVariant[i].Top -= OtstupY;
                        DownVariant[i].Top -= OtstupY;
                        DeleteVariant[i].Top -= OtstupY;
                    }
                    break;
                case QuestionType.AccordanceEstablishment:
                    TextVariant[index].Dispose();
                    DeleteVariant[index].Dispose();
                    AccordanceEstablishment[index].Dispose();

                    TextVariant.RemoveAt(index);
                    DeleteVariant.RemoveAt(index);
                    AccordanceEstablishment.RemoveAt(index);

                    for (var i = index; i < TextVariant.Count; i++)
                    {
                        TextVariant[i].Top -= OtstupY;
                        DeleteVariant[i].Top -= OtstupY;
                        AccordanceEstablishment[i].Top -= OtstupY;
                    }
                    break;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        //Применить изменения к вопросу
        private void buttonOK_Click(object sender, EventArgs e)
        {
            var Variants = new List<string>();
            var Answers = new List<int>();

            switch (QuestionType)
            {
                case QuestionType.SingleChoose:
                case QuestionType.MultiChoose:
                    foreach (var Variant in TextVariant)
                        Variants.Add(Variant.Text);
                    if (QuestionType == QuestionType.MultiChoose)
                    {
                        for (var i = 0; i < CorrectVariantMulti.Count; i++)
                            if (CorrectVariantMulti[i].Checked)
                                Answers.Add(i);
                    }
                    else
                        for (var i = 0; i < CorrectVariantSingle.Count; i++)
                            if (CorrectVariantSingle[i].Checked)
                            {
                                Answers.Add(i);
                                break;
                            }
                    break;
                case QuestionType.AlternativeChoose:
                    if (radioButtonYes.Checked)
                        Answers.Add(0);
                    else
                        Answers.Add(1);
                    break;
                case QuestionType.SequenceEstablishment:
                    foreach (var Variant in TextVariant)
                        Variants.Add(Variant.Text);
                    break;
                case QuestionType.AccordanceEstablishment:
                    for(var i = 0; i < TextVariant.Count; i++)
                    {
                        Variants.Add(TextVariant[i].Text);
                        Variants.Add(AccordanceEstablishment[i].Text);
                    }
                    break;
                case QuestionType.FreeStatement:
                    Variants.Add(textBoxAnswer.Text);
                    break;
            }
            Program.createQuestion.SetVariants(Variants, Answers);
            Hide();
        }
    }
}
