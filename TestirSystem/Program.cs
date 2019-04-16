using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;
using System.IO;

namespace TestirSystem
{
    static class Program
    {   //Все формы, используемые приложением
        public static Menu menu;

        public static Editing editing;
        public static TestParams testParams;
        public static SectionName sectionName;
        public static CreateQuestion createQuestion;
        public static Variants variants;

        public static Passing passing;
        public static Rezult rezult;
        public static StudentData studentData;
        public static AnswerList answerList;

        public static PasswordDialog passwordDialog;
        //Предоставляет звуковую подсистему
        static MediaPlayer Player;
        //Имя временного файла для звуков
        static string PlayingAudioTmp;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Player = new MediaPlayer();
            //Создание форм
            menu = new Menu();
            editing = new Editing();
            testParams = new TestParams();
            sectionName = new SectionName();
            createQuestion = new CreateQuestion();
            variants = new Variants();
            passing = new Passing();
            rezult = new Rezult();
            studentData = new StudentData();
            answerList = new AnswerList();
            passwordDialog = new PasswordDialog();

            Application.Run(menu);

            if (PlayingAudioTmp != null && File.Exists(PlayingAudioTmp))
                File.Delete(PlayingAudioTmp);
        }
        //Воспроизведение звука
        public static void PlaySound(byte[] SoundFile, string SoundExt)
        {
            //Остановить предидущий трек
            Player.Stop();
            Player.Close();
            if (PlayingAudioTmp != null && File.Exists(PlayingAudioTmp))
                File.Delete(PlayingAudioTmp);
            PlayingAudioTmp = "tmp" + SoundExt;

            //Записать временный файл и воспроизвести
            using (var OpenFile = File.OpenWrite(PlayingAudioTmp))
            {
                OpenFile.Write(SoundFile, 0, SoundFile.Length);
            }
            Player.Open(new Uri(PlayingAudioTmp, UriKind.Relative));
            Player.Play();
        }
    }
}
