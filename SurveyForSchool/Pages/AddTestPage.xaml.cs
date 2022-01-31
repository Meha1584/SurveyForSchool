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
    /// Логика взаимодействия для AddTestPage.xaml
    /// </summary>
    public partial class AddTestPage : Page
    {
        List<string> categories;
        string line;
        string pathToFolder;
        public AddTestPage(List<string> categories, string line)
        {
            InitializeComponent();
            this.categories = categories;
            this.line = line;
            StartOptions();
        }

        public void StartOptions()
        {
            categoriesCheck.ItemsSource = categories;
            categoriesCheck.SelectedItem = categories[0];
        }

        public void CheckCategories()
        {
            if (categoriesCheck.SelectedIndex == 0)
            {
                pathToFolder = line;
            }
            else
            {
                pathToFolder = $@"{line}\{categoriesCheck.Text}";
            }
        }
        private void AddFile(object sender, RoutedEventArgs e)
        {
            CheckCategories();
            string pathFolder = inputTest.Text;
            string pathFile = inputFile.Text;
            if (Directory.Exists(pathFolder))
            {
                string finishPathFile = Path.Combine(pathFolder, pathFile);
                string pathCopyFile = Path.Combine(pathToFolder, pathFile);
                if (File.Exists(finishPathFile))
                {
                    File.Copy(finishPathFile, pathCopyFile, true);
                    File.Copy(finishPathFile, Path.Combine(line, pathFile), true);
                    MessageBox.Show("Файл добавлен");
                }
                else
                {
                    MessageBox.Show("Такого файла не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Такого каталога не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
