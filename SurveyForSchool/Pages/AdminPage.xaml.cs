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
        public AdminPage()
        {
            InitializeComponent();
            ReadFile();
            Loaded += MainWindow_Loaded;
            StartOprions();
        }

        public void CreateFolder()
        {
            if (!Directory.Exists($"{pathFolder}"))
            {
                Directory.CreateDirectory($"{pathFolder}");
            }
            
        }

        public void ReadFile()
        {
            string getDirectory = Directory.GetCurrentDirectory();
            pathFile = $@"{getDirectory}\StringFolder.txt";

            if (!File.Exists($"{pathFile}"))
            {
                FileStream file = new FileStream($"{pathFile}", FileMode.Create);
                file.Close();
            }
            
            StreamReader streamReader = new StreamReader(pathFile);
            string line = streamReader.ReadLine();
            if (line == null)
            {
                grid.Visibility = Visibility.Hidden;
            }
            else
            {
                grid.Visibility = Visibility.Visible;
                stackPanelCheck.Visibility = Visibility.Hidden;
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
        public void CheckCategories()
        {
            
            List<string> categories = new List<string>();
            categories.Add("Все");
            var dirInfos = Directory.GetDirectories(@"C:\Users\Fillaa\Desktop\TestWork").ToList();
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


        private void WriteFile(object sender, RoutedEventArgs e)
        {
            string pathToFolder = inputPathFolder.Text;
            string nameFolder = inputNameFolder.Text;
            pathFolder = $@"{pathToFolder}\{nameFolder}";
            StreamWriter streamWriter = new StreamWriter(pathFile);
            streamWriter.Write(pathFolder);
            streamWriter.Close();
            CreateFolder();
            ReadFile();
        }
    }
}
