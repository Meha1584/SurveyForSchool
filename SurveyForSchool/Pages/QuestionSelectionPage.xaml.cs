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
            string pathFile = $@"{getDirectory}\StringFolder.txt";

            StreamReader streamReader = new StreamReader(pathFile);
            line = streamReader.ReadLine();
            streamReader.Close();
        }
        public void CheckQuestions()
        {
            CheckQuestionsClass checkQuestionsClass = new CheckQuestionsClass();
            int checkI = checkCategory.SelectedIndex;
            string chosenCategory = (string)checkCategory.Items[checkI];
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

        private void GoTest(object sender, RoutedEventArgs e)
        {

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

        private void S(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
