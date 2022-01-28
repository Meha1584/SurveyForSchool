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
    /// Логика взаимодействия для CreateCategoriesPage.xaml
    /// </summary>
    public partial class CreateCategoriesPage : Page
    {
        string line;
        public CreateCategoriesPage(string line)
        {
            InitializeComponent();
            Application.Current.MainWindow.Width = 270;
            Application.Current.MainWindow.Height = 300;
            this.line = line;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            string nameCategories = inputCategories.Text;
            string pathCategories = $@"{line}\{nameCategories}";
            if (!Directory.Exists(pathCategories))
            {
                Directory.CreateDirectory(pathCategories);
                MessageBox.Show("Категория создана");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Такая категория уже есть");
            }
        }
    }
}
