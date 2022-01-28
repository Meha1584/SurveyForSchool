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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        string pathFile;
        string pathFolder;
        string line;
        List<string> categories;
        List<Test> tests;
        string pathCategoriesWithTest;
        public AdminPage()
        {
            InitializeComponent();
            ReadFile();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = 800;
            Application.Current.MainWindow.Height = 450;
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
            tests = new List<Test>();
            int checkI = checkCategory.SelectedIndex;
            if (checkCategory.SelectedIndex == 0)
            {
                pathCategoriesWithTest = line;
            }
            else
            {
                pathCategoriesWithTest = $@"{line}\{checkCategory.Items[checkI]}";
            }
            var fileInfo = Directory.GetFiles(pathCategoriesWithTest).ToList();
            foreach (var item in fileInfo)
            {
                string[] file = item.Split('\\');
                tests.Add(new Test(file.Last()));
            }
            data.ItemsSource = tests;
            data.Items.Refresh();
        }

        /// <summary>
        /// вывод всех категорий
        /// </summary>
        public void CheckCategories()
        {
            categories = new List<string>();
            categories.Add("Все");
            var dirInfos = Directory.GetDirectories(line).ToList();
            
            foreach (var item in dirInfos)
            {
                string[] category = item.Split('\\');
                categories.Add(category.Last());
            }

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
            string pathToFolder = inputPathFolder.Text;
            string nameFolder = inputNameFolder.Text;
            bool check = CheckPath(pathToFolder, nameFolder);
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
                MessageBox.Show("Вы ввели неправильный путь", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// проверка на существование папки, чтобы добавить в неё новую папку
        /// </summary>
        /// <param name="pathToFolder">путь папки</param>
        /// <param name="nameFolder">название создаваемой папки</param>
        /// <returns></returns>
        public bool CheckPath(string pathToFolder, string nameFolder)
        {
            
            if (pathToFolder.Replace(" ", "").Length == 0 || nameFolder.Replace(" ", "").Length == 0)
            {
                return false;
            }
            else
            {
                if (!Directory.Exists(pathToFolder))
                {
                    return false;
                }
                return true;
            }
        }

        private void AddQuest(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTestPage(categories, line));
        }

        private void RemoveTest(object sender, RoutedEventArgs e)
        {

        }

        private void GoTest(object sender, RoutedEventArgs e)
        {

        }

        private void CheckIndexCategories(object sender, SelectionChangedEventArgs e)
        {
            CheckQuest();
        }
    }
}
