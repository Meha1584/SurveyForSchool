using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SurveyForSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestingPage.xaml
    /// </summary>
    public partial class TestingPage : Page
    {
        List<QuestionsClass> currentTest;
        int countCorrectAnswers = 0;
        int currentQuestion = 0;
        string folder;
        int countQuestions;
        public TestingPage(List <QuestionsClass> questions, string nameTest, int countQuestions, string pathFolder)
        {
            InitializeComponent();
            folder = pathFolder;
            this.countQuestions = countQuestions;
            Header.Content = nameTest;
            currentTest = new List<QuestionsClass>();
            int []masNumbers = new int[countQuestions];
            Random rand = new Random();
            for (int i=0;i< countQuestions; i++)
            {
                int a = rand.Next(0, questions.Count);
                if (!masNumbers.Contains(a))
                {
                    masNumbers[i] = a;
                }
                else
                    i--;
            }
            for (int i = 0; i < countQuestions; i++)
            {
                currentTest.Add(questions[masNumbers[i]]);
            }
            ShowQuestions();
        }

        private void ShowQuestions()
        {
            if (!String.IsNullOrEmpty(currentTest[currentQuestion].PathImage))
            {

                byte[] imageBytes = File.ReadAllBytes($@"{folder}\{currentTest[currentQuestion].PathImage}");
                if (imageBytes != null)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    ms.Seek(0, SeekOrigin.Begin);
                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.StreamSource = ms;
                    bmp.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                    bmp.CacheOption = BitmapCacheOption.Default;
                    bmp.EndInit();
                    bmp.Freeze();
                    picture.Source = bmp;
                }
                else
                    picture.Source = null;
            }
            question.Text = currentTest[currentQuestion].TitleQuestion;
            int[] mas = new int[4];
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                int a = rand.Next(0, 4);
                if (!mas.Contains(a))
                {
                    mas[i] = a;
                }
                else
                    i--;
            }
            string[] answermas = new string[4];
            answermas[mas[0]] = currentTest[currentQuestion].OtvetTrue;
            answermas[mas[1]] = currentTest[currentQuestion].Otvet1;
            answermas[mas[2]] = currentTest[currentQuestion].Otvet2;
            answermas[mas[3]] = currentTest[currentQuestion].Otvet3;
            answerText1.Text = answermas[0];
            answerText2.Text = answermas[1];
            answerText3.Text = answermas[2];
            answerText4.Text = answermas[3];
            
        }

        private void NextQuestionClick(object sender, RoutedEventArgs e)
        {
            string userAnswer = "";
            if (answer1.IsChecked==true)
                userAnswer = answerText1.Text;
            if (answer2.IsChecked == true)
                userAnswer = answerText2.Text;
            if (answer3.IsChecked == true)
                userAnswer = answerText3.Text;
            if (answer4.IsChecked == true)
                userAnswer = answerText4.Text;
            if (userAnswer.Equals(currentTest[currentQuestion].OtvetTrue))
                countCorrectAnswers++;
            answer1.IsChecked = false;
            answer2.IsChecked = false;
            answer3.IsChecked = false;
            answer4.IsChecked = false;
            if (currentQuestion == countQuestions - 1)
            {
                double mark = (double)countCorrectAnswers / countQuestions;
                int finalMark = 0;
                if (mark >= 0.9)
                    finalMark = 5;
                else if (mark >= 0.75)
                    finalMark = 4;
                else if (mark >= 0.5)
                    finalMark = 3;
                else
                    finalMark = 2;


                MessageBox.Show($"Вы ответили верно на {countCorrectAnswers} вопросов! Ваша оценка за тест - {finalMark}", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                answer1.IsChecked = false;
                answer2.IsChecked = false;
                answer3.IsChecked = false;
                answer4.IsChecked = false;
            }
            else
            {
                currentQuestion++;
                ShowQuestions();
            }

        }
    }
}
