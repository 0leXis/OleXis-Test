using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.IO;

namespace TestirSystem
{
    //Типы вопросов
    public enum QuestionType { SingleChoose, MultiChoose, AlternativeChoose, AccordanceEstablishment, SequenceEstablishment, FreeStatement }

    //Класс для хранения информации о вопросе
    public class Question
    {
        //Тип вопроса
        public QuestionType Question_Type;
        //Раздел
        public string Section;
        //Название
        public string Name;

        //Информация о вопросе
        public string Text;
        public Bitmap Image;
        public string SoundFileExt;
        public byte[] SoundFile;

        //Варианты ответа и ответы
        public List<string> Variants;
        public List<int> Answers;

        //Стандартный конструктор
        public Question(string Name, QuestionType Question_Type, string Text, List<string> Variants, List<int> Answers = null, string Section = "NONE", Bitmap Image = null, string SoundFileExt = null, byte[] SoundFile = null)
        {
            this.Question_Type = Question_Type;
            this.Name = Name;
            this.Text = Text;
            this.Section = Section;
            this.Variants = Variants;
            this.Answers = Answers;
            this.Image = Image;
            this.SoundFileExt = SoundFileExt;
            this.SoundFile = SoundFile;
        }
        //Конструктор с загрузкой из файла
        public Question(string FileName, string TmpPath)
        {
            Variants = new List<string>();
            Answers = new List<int>();

            var Doc = new XmlDocument();
            Doc.Load(TmpPath + @"\" + FileName);

            var Root = Doc.DocumentElement;

            foreach(XmlNode Child1 in Root.ChildNodes)
            {
                if (Child1.Name == "name")
                    Name = Child1.InnerText;
                else
                if (Child1.Name == "type")
                    Question_Type = (QuestionType)Convert.ToInt32(Child1.InnerText);
                else
                if (Child1.Name == "razdel")
                    Section = Child1.InnerText;
                else
                if (Child1.Name == "text")
                    Text = Child1.InnerText;
                else
                if (Child1.Name == "image")
                {
                    var Img = new MemoryStream(File.ReadAllBytes(TmpPath + @"\" + Child1.InnerText));
                    Image = new Bitmap(Img);
                }
                else
                if (Child1.Name == "sound")
                {
                    using (var FileStr = File.OpenRead(TmpPath + @"\" + Child1.InnerText))
                    {
                        SoundFileExt = Child1.InnerText.Substring(Child1.InnerText.LastIndexOf('.'));
                        SoundFile = new byte[FileStr.Length];
                        FileStr.Read(SoundFile, 0, (int)FileStr.Length);
                    }
                }
                else
                if (Child1.Name == "varianti")
                {
                    foreach (XmlNode Child2 in Child1.ChildNodes)
                        if (Child2.Name == "variant")
                            Variants.Add(Child2.InnerText);
                }
                else
                if (Child1.Name == "otveti")
                {
                    foreach (XmlNode Child2 in Child1.ChildNodes)
                        if (Child2.Name == "otvet")
                            Answers.Add(Convert.ToInt32(Child2.InnerText));
                }
            }
        }

        //Запись в файл
        public void SaveToFile(string Path, string FileName)
        {
            XmlWriter Writer = XmlWriter.Create(Path + @"\" + FileName);
            Writer.WriteStartDocument();
            Writer.WriteStartElement("vopros");

            Writer.WriteStartElement("name");
            Writer.WriteValue(Name);
            Writer.WriteEndElement();

            Writer.WriteStartElement("type");
            Writer.WriteValue((int)Question_Type);
            Writer.WriteEndElement();

            Writer.WriteStartElement("razdel");
            Writer.WriteValue(Section);
            Writer.WriteEndElement();

            Writer.WriteStartElement("text");
            Writer.WriteValue(Text);
            Writer.WriteEndElement();

            if(Image != null)
            {
                var i = 0;
                while (true)
                {
                    if (File.Exists(i.ToString() + ".png"))
                        i++;
                    else
                        break;
                }

                Image.Save(Path + @"\" + i.ToString() + ".png");

                Writer.WriteStartElement("image");
                Writer.WriteValue(i + ".png");
                Writer.WriteEndElement();
            }

            if(SoundFileExt != null)
            {
                var i = 0;
                while (true)
                {
                    if (File.Exists(i.ToString() + SoundFileExt))
                        i++;
                    else
                        break;
                }
                using (var sw = File.OpenWrite(Path + @"\" + i.ToString() + SoundFileExt))
                {
                    sw.Write(SoundFile, 0, SoundFile.Length);
                }

                Writer.WriteStartElement("sound");
                Writer.WriteValue(i + SoundFileExt);
                Writer.WriteEndElement();
            }

            Writer.WriteStartElement("varianti");
            foreach (var Variant in Variants)
            {
                Writer.WriteStartElement("variant");
                Writer.WriteValue(Variant);
                Writer.WriteEndElement();
            }
            Writer.WriteEndElement();

            Writer.WriteStartElement("otveti");
            foreach (var otvet in Answers)
            {
                Writer.WriteStartElement("otvet");
                Writer.WriteValue(otvet);
                Writer.WriteEndElement();
            }
            Writer.WriteEndElement();

            Writer.WriteEndElement();
            Writer.WriteEndDocument();
            Writer.Close();
        }
    }
}
