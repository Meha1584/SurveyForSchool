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
            pathToFolder = $@"{line}\{categoriesCheck.Text}";
        }
        private void AddFile(object sender, RoutedEventArgs e)
        {
            CheckCategories();
            string nameTest = inputNameTest.Text.Replace(" ", "");
            string path = Path.Combine(pathToFolder, nameTest);
            if (nameTest.Length == 0)
            {
                MessageBox.Show("Не ввели название теста");
            }
            else
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "C:\\";
                //openFileDialog.Filter = "filex txt |*.txt";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == true)
                {
                    string[] filePath = openFileDialog.FileNames;
                    foreach (var item in filePath)
                    {
                        string[] arrayLine = item.Split('\\');
                        string fileName = arrayLine.Last();
                        File.Copy(item, Path.Combine(path, fileName), true);
                    }
                    MessageBox.Show("Тест создан");
                    NavigationService.GoBack();
                }
            }
            
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
