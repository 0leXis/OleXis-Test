using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using Ionic.Zip;
using Ionic.Zlib;
using System.Security.Cryptography;

namespace TestirSystem
{
    //Тип распределения вопросов
    public enum QuestionAllocation { One_Variant, Section_Variant, Generate}

    //Класс для хранения данных теста
    public class Test
    {
        //Пароль
        public string Password;
        //Вопросы
        public List<Question> Questions;
        //Разделы
        public List<string> Sections;
        //Время на прохождение
        public int TimeForTest;
        //Вариант распределения вопросов
        public QuestionAllocation QuestionAllocation;
        //Кол-во вопросов из каждого раздела для случ варианта
        public int CountForGenerate;
        //Строка подключения к БД
        public string DBConnectionRequest;

        //Стандартный конструктор
        public Test()
        {
            Password = "";
            Questions = new List<Question>();
            Sections = new List<string>();
            TimeForTest = 0;
            QuestionAllocation = QuestionAllocation.One_Variant;
            CountForGenerate = 0;
            DBConnectionRequest = "";
        }
        //Конструктор с загрузкой из файла
        public Test(string FileName, string TmpPath, string Password = "")
        {
            Questions = new List<Question>();
            Sections = new List<string>();

            if (Password == "")
            {
                using (ZipFile Zip = new ZipFile(FileName))
                {
                    Zip.ExtractAll("");
                }
            }
            else
            {
                EncryptDecryptFile(FileName, Password, false, TmpPath + @"\testtmp.test");
                using (ZipFile Zip = new ZipFile(TmpPath + @"\testtmp.test"))
                {
                    Zip.ExtractAll("");
                }
            }

            var Doc = new XmlDocument();
            Doc.Load(TmpPath + @"\" + "main.xml");

            var Root = Doc.DocumentElement;

            foreach(XmlNode Child1 in Root)
            {
                if (Child1.Name == "password")
                    this.Password = Child1.InnerText;
                else
                if (Child1.Name == "time")
                    TimeForTest = Convert.ToInt32(Child1.InnerText);
                else
                if (Child1.Name == "raspred")
                    QuestionAllocation = (QuestionAllocation)Convert.ToInt32(Child1.InnerText);
                else
                if (Child1.Name == "generate")
                    CountForGenerate = Convert.ToInt32(Child1.InnerText);
                else
                if (Child1.Name == "BD")
                    DBConnectionRequest = Child1.InnerText;
                else
                if (Child1.Name == "razdeli")
                    foreach (XmlNode Child2 in Child1.ChildNodes)
                        if (Child2.Name == "razdeli")
                            Sections.Add(Child2.InnerText);
            }

            var i = 0;
            while (File.Exists(TmpPath + @"\" + i.ToString() + ".xml"))
            {
                Questions.Add(new Question(i.ToString() + ".xml", TmpPath));
                i++;
            }
        }
        //Сохранение в файл
        public void SaveToFile(string Path, string TmpPath)
        {
            XmlWriter Writer = XmlWriter.Create(TmpPath + @"\main.xml");

            Writer.WriteStartDocument();
            Writer.WriteStartElement("params");

            Writer.WriteStartElement("password");
            Writer.WriteValue(Password);
            Writer.WriteEndElement();

            Writer.WriteStartElement("time");
            Writer.WriteValue(TimeForTest);
            Writer.WriteEndElement();

            Writer.WriteStartElement("raspred");
            Writer.WriteValue((int)QuestionAllocation);
            Writer.WriteEndElement();

            Writer.WriteStartElement("generate");
            Writer.WriteValue(CountForGenerate);
            Writer.WriteEndElement();

            Writer.WriteStartElement("BD");
            Writer.WriteValue(DBConnectionRequest);
            Writer.WriteEndElement();

            Writer.WriteStartElement("razdeli");
            foreach (var Section in Sections)
            {
                Writer.WriteStartElement("razdeli");
                Writer.WriteValue(Section);
                Writer.WriteEndElement();
            }
            Writer.WriteEndElement();

            Writer.WriteEndElement();
            Writer.WriteEndDocument();
            Writer.Close();

            var i = 0;
            foreach(var Question in Questions)
            {
                Question.SaveToFile(TmpPath, i.ToString() + ".xml");
                i++;
            }

            using (ZipFile Zip = new ZipFile())
            {
                Zip.CompressionLevel = CompressionLevel.BestCompression;
                foreach (var File in Directory.GetFiles(TmpPath))
                    Zip.AddFile(File);
                Zip.Save(TmpPath + @"\testtmp.test");  
            }

            if(Password != "")
            {
                if (File.Exists(Path))
                    File.Delete(Path);
                EncryptDecryptFile(TmpPath + @"\testtmp.test", Password, true, Path);
            }
            else
            {
                if (File.Exists(Path))
                    File.Delete(Path);
                File.Copy(TmpPath + @"\testtmp.test", Path);
            }
        }
        //Шифрование и расшифровка
        public static void EncryptDecryptFile(string InputPath, string Password, bool IsEncryptMode, string OutputPath)
        {
            using (var Сypher = new AesManaged())
            using (var FileStrIn = new FileStream(InputPath, FileMode.Open))
            using (var FileStrOut = new FileStream(OutputPath, FileMode.Create))
            {
                const int SaltLength = 256;
                var Salt = new byte[SaltLength];
                var IV = new byte[Сypher.BlockSize / 8];

                if (IsEncryptMode)
                {
                    // Генерация соли и вектора инициализации
                    using (var RNG = new RNGCryptoServiceProvider())
                    {
                        RNG.GetBytes(Salt);
                        RNG.GetBytes(IV);
                    }
                    FileStrOut.Write(Salt, 0, Salt.Length);
                    FileStrOut.Write(IV, 0, IV.Length);
                }
                else
                {
                    // Считывание соли и вектора из файла
                    FileStrIn.Read(Salt, 0, SaltLength);
                    FileStrIn.Read(IV, 0, IV.Length);
                }

                // Генерация пароля
                var PDB = new Rfc2898DeriveBytes(Password, Salt);
                var Key = PDB.GetBytes(Сypher.KeySize / 8);

                // Шифрование и расшифровка
                using (var CryptoTransform = IsEncryptMode ? Сypher.CreateEncryptor(Key, IV) : Сypher.CreateDecryptor(Key, IV))
                using (var CryptStr = new CryptoStream(FileStrOut, CryptoTransform, CryptoStreamMode.Write))
                {
                    FileStrIn.CopyTo(CryptStr);
                }
            }
        }
    }
}
