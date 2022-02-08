using Microsoft.Win32;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;
using WPF = System.Windows;

namespace SurveyForSchool
{
  
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        string line = Path.Combine(Directory.GetCurrentDirectory(), "QuestionsFolder");
        List<string> categories;
        List<Test> tests;
        
        public AdminPage()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            WPF.Application.Current.MainWindow.Width = 800;
            WPF.Application.Current.MainWindow.Height = 450;

            StartOprions();

        }


        /// <summary>
        /// функция для создание файла, в котором хранится путь до основой папки с тестами
        /// а также, если этой папки еще нет, то переключение интерфейса на ввод папки
        /// </summary>

        public void StartOprions()
        {
            if (!Directory.Exists(line))
            {
                Directory.CreateDirectory(line);
                if (!Directory.Exists(Path.Combine(line, "Информатика")))
                {
                    Directory.CreateDirectory(Path.Combine(line, "Информатика"));
                }
            }
            CheckCategories();
            CheckQuest();
        }

        /// <summary>
        /// считывание всех тестов в список объектов и вывод всех тестов
        /// </summary>
        /// 
        string checkCategories;
        public void CheckQuest()
        {
            CheckQuestionsClass checkQuestionsClass = new CheckQuestionsClass();
            int checkI = checkCategory.SelectedIndex;
            checkCategories = (string)checkCategory.Items[checkI];
            tests = checkQuestionsClass.LoadingQuestions(checkI, line, checkCategories);
            data.ItemsSource = tests;
            data.Items.Refresh();
        }

        /// <summary>
        /// вывод всех категорий
        /// </summary>
        public void CheckCategories()
        {
            CheckCategoriesClass categoriesClass = new CheckCategoriesClass();
            categories = categoriesClass.LoadingCategories(line);
            checkCategory.ItemsSource = categories;
            checkCategory.SelectedItem = categories[0];
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());
        }

        private void AddCategories(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateCategoriesPage(line));
        }

        /// <summary>
        /// проверка на существование папки, чтобы добавить в неё новую папку
        /// </summary>
        /// <param name="pathToFolder">путь папки</param>
        /// <param name="nameFolder">название создаваемой папки</param>
        /// <returns></returns>
        public bool CheckPath(string nameFolder)
        {
            
            if (nameFolder.Replace(" ", "").Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void AddQuest(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTestPage(categories, line));
        }

        private void RemoveTest(object sender, RoutedEventArgs e)
        {
            Test test = data.SelectedItem as Test;
            tests.Remove(test);
            for (int i = 0; i < categories.Count; i++)
            {
                string pathDeleteFail = Path.Combine($@"{line}\{categories[i]}", test.NameTest);
                if (Directory.Exists(pathDeleteFail))
                {
                    Directory.Delete(pathDeleteFail);
                }
            }
            data.Items.Refresh();
            WPF.MessageBox.Show("Тест удален");
        }

        private void GoTest(object sender, RoutedEventArgs e)
        {
            Test test = data.SelectedItem as Test;
            List<QuestionsClass> questions = ReadFileQuestions(test);
            NavigationService.Navigate(new AdminCheckQuestionPage(questions, test.NameTest, pathFolder));
        }

        private void CheckIndexCategories(object sender, SelectionChangedEventArgs e)
        {
            CheckQuest();
        }
        string pathFolder;
        private List<QuestionsClass> ReadFileQuestions(Test test)
        {
            pathFolder = Path.Combine(Path.Combine(line, checkCategories), test.NameTest);
            string pathFile = "";
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

        private void Filteration(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputNameFile.Text))
            {
                var filterTest = tests.Where(x => x.NameTest.Contains(inputNameFile.Text)).ToList();
                data.ItemsSource = filterTest;
                data.Items.Refresh();
            }
            else
            {
                data.ItemsSource = tests;
                data.Items.Refresh();
            }
        }
    }
}
