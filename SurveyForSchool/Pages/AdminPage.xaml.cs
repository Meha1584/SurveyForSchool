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
        public AdminPage()
        {
            InitializeComponent();
            ReadFile();
            Loaded += MainWindow_Loaded;
            
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

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = 800;
            Application.Current.MainWindow.Height = 450;
        }

        public void StartOprions()
        {
            CheckCategories();
        }


        /// <summary>
        /// вывод всех категорий
        /// </summary>
        public void CheckCategories()
        {
            List<string> categories = new List<string>();

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
            NavigationService.Navigate(new CreateCategoriesPage());
        }

        private void AddCategories(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateCategoriesPage());
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
    }
}
