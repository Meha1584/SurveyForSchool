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
using Path = System.IO.Path;

namespace SurveyForSchool
{
    /// <summary>
    /// Логика взаимодействия для QuestionSelectionPage.xaml
    /// </summary>
    public partial class QuestionSelectionPage : Page
    {
        string nameStudent;
        string line;
        List<Test> tests;
        string chosenCategory;
        public QuestionSelectionPage(string nameStudent)
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            StartOptions();
            this.nameStudent = nameStudent;
            nameStudentCheck.Content = nameStudent;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = 810;
            Application.Current.MainWindow.Height = 470;
            StartOptions();
        }

        public void StartOptions()
        {
            textLabel.Content = "Введите количество вопросов\nв тесте";
            ReadFile();
            CheckCategories();
            CheckQuestions();
        }
        public void ReadFile()
        {
            string getDirectory = Directory.GetCurrentDirectory();
            line = $@"{getDirectory}\QuestionsFolder";
        }
        public void CheckQuestions()
        {
            CheckQuestionsClass checkQuestionsClass = new CheckQuestionsClass();
            int checkI = checkCategory.SelectedIndex;
            chosenCategory = (string)checkCategory.Items[checkI];
            tests = checkQuestionsClass.LoadingQuestions(checkI, line, chosenCategory);
            checkQuestionList.ItemsSource = tests;
        }
        public void CheckCategories()
        {
            CheckCategoriesClass checkCategoriesClass = new CheckCategoriesClass();
            List<string> categories = checkCategoriesClass.LoadingCategories(line);
            checkCategory.ItemsSource = categories;
            checkCategory.SelectedItem = categories[0];
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CheckIndexCategories(object sender, SelectionChangedEventArgs e)
        {
            CheckQuestions();
        }

        private void Filteration(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputNameFile.Text))
            {
                var filterTest = tests.Where(x => x.NameTest.Contains(inputNameFile.Text)).ToList();
                checkQuestionList.ItemsSource = filterTest;
                checkQuestionList.Items.Refresh();
            }
            else
            {
                checkQuestionList.ItemsSource = tests;
                checkQuestionList.Items.Refresh();
            }
        }
        string pathFolder;
        private List<QuestionsClass> ReadFileQuestions(Test test)
        {
            pathFolder = Path.Combine(Path.Combine(line, chosenCategory), test.NameTest);
            string pathFile="";
            string[] pathFiles = Directory.GetFiles(pathFolder);
            foreach (var item in pathFiles)
            {
                if (item.Split('.').Last().Equals("txt"))
                {
                    pathFile = item;
                }
            }
            List<QuestionsClass> questions = new List<QuestionsClass>();
            try
            {
                StreamReader reader = new StreamReader(pathFile);
                
                string str = "";                
                List<string> listElement = new List<string>();
                var list = new List<List<string>>();
                while ((str = reader.ReadLine()) != null)
                {
                    listElement.Add(str);
                }
                for (int i = 0; i < listElement.Count; i += 7)
                {
                    list.Add(listElement.GetRange(i, Math.Min(7, listElement.Count - i)));
                }
                for (int i = 0; i < list.Count; i++)
                {

                    questions.Add(new QuestionsClass()
                    {
                        TitleQuestion = list[i][0],
                        PathImage = list[i][1],
                        OtvetTrue = list[i][2],
                        Otvet1 = list[i][3],
                        Otvet2 = list[i][4],
                        Otvet3 = list[i][5],
                    });

                }
                reader.Close();
            }
            catch
            { }
            return questions;
        }

        private void StartTestClick(object sender, MouseButtonEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите начать тестирование?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                
                Test test = (sender as Grid).DataContext as Test;
                List<QuestionsClass> questions = ReadFileQuestions(test);
                NavigationService.Navigate(new Pages.TestingPage(questions, test.NameTest, Convert.ToInt32(inputCountQuestion.Text), pathFolder));
            }
        }
    }
}
