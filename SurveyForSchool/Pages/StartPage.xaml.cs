using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        int check = 0;
        string admin = "admin";
        public StartPage()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = 400;
            Application.Current.MainWindow.Height = 400;
        }

        private void Go(object sender, RoutedEventArgs e)
        {
            string nameStudent = inputName.Text;
            NavigationService.Navigate(new QuestionSelectionPage(nameStudent));
        }

        private void FieldOpening(object sender, KeyEventArgs e)
        {
            if (inputName.Text.Equals(admin))
            {
                if (e.Key == Key.Enter)
                {
                    check++;
                    if (check >= 3)
                    {
                        checkElement.Visibility = Visibility.Visible;
                        inputPassword.Visibility = Visibility.Visible;
                        goPage.Click -= Go;
                        goPage.Click += GoAdmin;
                    }
                }
            }
        }

        private void GoAdmin(object sender, RoutedEventArgs e)
        {
            if (inputPassword.Text.Equals("admin"))
            {
                NavigationService.Navigate(new AdminPage());
            }
            else
            {
                MessageBox.Show("Пароль неправильный", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
