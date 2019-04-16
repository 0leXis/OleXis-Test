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
    public partial class CreateQuestion : Form
    {
        string SoundFileExt;
        byte[] SoundFile;

        Bitmap Image;
        List<string> Variants;
        List<int> Answers;

        bool IsRedaktState = false;

        public CreateQuestion()
        {
            InitializeComponent();
        }

        public void SetDefault(Test test)
        {
            textBoxName.Text = "";
            textBoxText.Text = "";
            comboBoxType.Text = comboBoxType.Items[0].ToString();
            comboBoxSection.Items.Clear();
            comboBoxSection.Items.Add("Нет");
            comboBoxSection.SelectedIndex = 0;
            foreach (var Section in test.Sections)
                comboBoxSection.Items.Add(Section);
            pictureBox1.Image = null;
            Image = null;
            SoundFileExt = null;
            SoundFile = null;
            Variants = null;
            Answers = null;
            buttonRemoveImage.Enabled = false;
            buttonRemoveSound.Enabled = false;
            buttonPlaySound.Enabled = false;

            IsRedaktState = false;
            //Очистка variants
            Program.variants.QuestionType = QuestionType.AlternativeChoose;
            Program.variants.QuestionType = QuestionType.SingleChoose;
        }

        public void SetVopros(Test test, Question Questionos)
        {
            textBoxName.Text = Questionos.Name;
            textBoxText.Text = Questionos.Text;
            switch (Questionos.Question_Type)
            {
                case QuestionType.SingleChoose:
                    comboBoxType.SelectedIndex = 0;
                    break;
                case QuestionType.AlternativeChoose:
                    comboBoxType.SelectedIndex = 1;
                    break;
                case QuestionType.AccordanceEstablishment:
                    comboBoxType.SelectedIndex = 2;
                    break;
                case QuestionType.SequenceEstablishment:
                    comboBoxType.SelectedIndex = 3;
                    break;
                case QuestionType.FreeStatement:
                    comboBoxType.SelectedIndex = 4;
                    break;
                case QuestionType.MultiChoose:
                    comboBoxType.SelectedIndex = 5;
                    break;
            }
            comboBoxSection.Items.Clear();
            comboBoxSection.Items.Add("Нет");
            foreach (var Section in test.Sections)
                comboBoxSection.Items.Add(Section);
            if(Questionos.Section == "NONE")
                comboBoxSection.SelectedIndex = 0;
            else
                comboBoxSection.SelectedIndex = comboBoxSection.Items.IndexOf(Questionos.Section);
            pictureBox1.Image = Questionos.Image;
            if(pictureBox1.Image == null)
                buttonRemoveImage.Enabled = false;
            else
                buttonRemoveImage.Enabled = true;
            SoundFileExt = Questionos.SoundFileExt;
            SoundFile = Questionos.SoundFile;
            if (SoundFileExt == null)
            {
                buttonRemoveSound.Enabled = false;
                buttonPlaySound.Enabled = false;
            }
            else
            {
                buttonRemoveSound.Enabled = true;
                buttonPlaySound.Enabled = true;
            }

            //Очистка variants
            Program.variants.QuestionType = QuestionType.AlternativeChoose;
            Program.variants.QuestionType = QuestionType.SingleChoose;
            //Установка типа вопроса
            Program.variants.QuestionType = Questionos.Question_Type;
            Program.variants.SetVariants(Questionos.Variants, Questionos.Answers);

            Variants = Questionos.Variants;
            Answers = Questionos.Answers;

            IsRedaktState = true;
        }

        private void buttonRedaktVariants_Click(object sender, EventArgs e)
        {
            if (comboBoxType.Text == comboBoxType.Items[0].ToString())
                Program.variants.QuestionType = QuestionType.SingleChoose;
            else if (comboBoxType.Text == comboBoxType.Items[1].ToString())
                Program.variants.QuestionType = QuestionType.AlternativeChoose;
            else if (comboBoxType.Text == comboBoxType.Items[2].ToString())
                Program.variants.QuestionType = QuestionType.AccordanceEstablishment;
            else if (comboBoxType.Text == comboBoxType.Items[3].ToString())
                Program.variants.QuestionType = QuestionType.SequenceEstablishment;
            else if (comboBoxType.Text == comboBoxType.Items[4].ToString())
                Program.variants.QuestionType = QuestionType.FreeStatement;
            else if (comboBoxType.Text == comboBoxType.Items[5].ToString())
                Program.variants.QuestionType = QuestionType.MultiChoose;

            Program.variants.ShowDialog();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        public void SetVariants(List<string> Variants, List<int> Answers)
        {
            this.Variants = new List<string>(Variants);
            this.Answers = new List<int>(Answers);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text == "" || textBoxText.Text == "")
            {
                MessageBox.Show("Поля \"Название\" и \"Текст вопроса\" должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var flag = true;
            switch (Program.variants.QuestionType)
            {
                case QuestionType.SingleChoose:
                    if (Answers == null || Variants == null || Answers.Count == 0 || Variants.Count < 2)
                        flag = false;
                    break;
                case QuestionType.MultiChoose:
                case QuestionType.SequenceEstablishment:
                    if (Answers == null || Variants == null || Variants.Count < 2)
                        flag = false;
                    break;
                case QuestionType.AlternativeChoose:
                    if(Answers == null || Variants == null || Answers.Count == 0)
                        flag = false;
                    break;
                case QuestionType.AccordanceEstablishment:
                    if(Answers == null || Variants == null || Variants.Count < 4)
                        flag = false;
                    break;
                case QuestionType.FreeStatement:
                    if (Answers == null || Variants == null || Variants[0] == "")
                        flag = false;
                    break;
            }
            if(!flag)
            {
                MessageBox.Show("Введено недопустимое число ответов." + Environment.NewLine + "Нажмите \"Редактировать варианты ответа\" чтобы изменить варианты ответа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsRedaktState)
            {
                var sectionName = "";
                if (comboBoxSection.SelectedIndex == 0)
                    sectionName = "NONE";
                else
                    sectionName = comboBoxSection.Text;
                if (!Program.editing.ChangeVopros(textBoxName.Text, Program.variants.QuestionType, textBoxText.Text, Variants, Answers, sectionName, Image, SoundFileExt, SoundFile))
                    MessageBox.Show("Раздел или вопрос с таким именем уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Hide();
            }
            else
            {
                var sectionName = "";
                if (comboBoxSection.SelectedIndex == 0)
                    sectionName = "NONE";
                else
                    sectionName = comboBoxSection.Text;
                if (!Program.editing.CreateQuestion(textBoxName.Text, Program.variants.QuestionType, textBoxText.Text, Variants, Answers, sectionName, Image, SoundFileExt, SoundFile))
                    MessageBox.Show("Раздел или вопрос с таким именем уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Hide();
            }
        }

        private void buttonAddImage_Click(object sender, EventArgs e)
        {
            buttonRemoveImage.Enabled = false;
            pictureBox1.Image = null;
            Image = null;

            using (var op = new OpenFileDialog())
            {
                op.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    Image = new Bitmap(op.FileName);
                }
            }
            pictureBox1.Image = Image;
            buttonRemoveImage.Enabled = true;
        }

        private void buttonRemoveImage_Click(object sender, EventArgs e)
        {
            buttonRemoveImage.Enabled = false;
            pictureBox1.Image = null;
            Image = null;
        }

        private void buttonAddSound_Click(object sender, EventArgs e)
        {
            SoundFileExt = null;
            SoundFile = null;
            buttonPlaySound.Enabled = false;
            buttonPlaySound.Enabled = false;

            using (var op = new OpenFileDialog())
            {
                op.Filter = "MP3 (.mp3)|*.mp3|Wave (.wav)|*.wav";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    using (var FileStr = File.OpenRead(op.FileName))
                    {
                        if(FileStr.Length > int.MaxValue)
                        {
                            MessageBox.Show("Ошибка: длинна файла слишком велика");
                        }
                        else
                        {
                            SoundFileExt = op.FileName.Substring(op.FileName.LastIndexOf('.'));
                            SoundFile = new byte[FileStr.Length];
                            FileStr.Read(SoundFile, 0, (int)FileStr.Length);
                            buttonPlaySound.Enabled = true;
                            buttonPlaySound.Enabled = true;
                        }
                    }
                }
            }
        }

        private void buttonRemoveSound_Click(object sender, EventArgs e)
        {
            buttonPlaySound.Enabled = false;
            buttonPlaySound.Enabled = false;
            SoundFileExt = null;
            SoundFile = null;
        }

        private void buttonPlaySound_Click(object sender, EventArgs e)
        {
            Program.PlaySound(SoundFile, SoundFileExt);
        }
    }
}
