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
        string pathFile;
        string pathFolder;
        string line;
        List<string> categories;
        List<Test> tests;
        
        public AdminPage()
        {
            InitializeComponent();
            ReadFile();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            WPF.Application.Current.MainWindow.Width = 800;
            WPF.Application.Current.MainWindow.Height = 450;
            if (!(line == null))
            {
                StartOprions();
            }
        }

        /// <summary>
        /// создание папки для файлов и категории
        /// </summary>
        public void CreateFolder()
        {
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
            }
            
        }

        /// <summary>
        /// функция для создание файла, в котором хранится путь до основой папки с тестами
        /// а также, если этой папки еще нет, то переключение интерфейса на ввод папки
        /// </summary>
        public void ReadFile()
        {
            string getDirectory = Directory.GetCurrentDirectory();
            pathFile = $@"{getDirectory}\StringFolder.txt";

            if (!File.Exists(pathFile))
            {
                FileStream file = new FileStream(pathFile, FileMode.Create);
                file.Close();
            }
            
            StreamReader streamReader = new StreamReader(pathFile);
            line = streamReader.ReadLine();
            if (line == null)
            {
                grid.Visibility = Visibility.Hidden;
            }
            else
            {
                grid.Visibility = Visibility.Visible;
                stackPanelCheck.Visibility = Visibility.Hidden;
                StartOprions();
            }
            streamReader.Close();
        }


        public void StartOprions()
        {
            CheckCategories();
            CheckQuest();
        }

        /// <summary>
        /// считывание всех тестов в список объектов и вывод всех тестов
        /// </summary>
        public void CheckQuest()
        {
            CheckQuestionsClass checkQuestionsClass = new CheckQuestionsClass();
            int checkI = checkCategory.SelectedIndex;
            string checkCategories = (string)checkCategory.Items[checkI];
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
        /// запись пути папки в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteFile(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string nameFolder = inputNameFolder.Text;
                string pathToFolder = fbd.SelectedPath;
                bool check = CheckPath(nameFolder);
                if (check)
                {
                    pathFolder = $@"{pathToFolder}\{nameFolder}\";
                    StreamWriter streamWriter = new StreamWriter(pathFile);
                    streamWriter.Write(pathFolder);
                    streamWriter.Close();
                    CreateFolder();
                    ReadFile();
                }
                else
                {
                    WPF.MessageBox.Show("Вы не ввели имя папки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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
            File.Delete(Path.Combine(line, test.NameTest));
            for (int i = 1; i < categories.Count - 1; i++)
            {
                string pathDeleteFail = Path.Combine($@"{line}\{categories[i]}", test.NameTest);
                if (File.Exists(pathDeleteFail))
                {
                    File.Delete(pathDeleteFail);
                }
            }
            data.Items.Refresh();
        }

        private void GoTest(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminCheckQuestionPage());
        }

        private void CheckIndexCategories(object sender, SelectionChangedEventArgs e)
        {
            CheckQuest();
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
