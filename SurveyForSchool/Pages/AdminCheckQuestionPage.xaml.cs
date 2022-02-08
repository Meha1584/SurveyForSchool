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
    /// Логика взаимодействия для AdminCheckQuestionPage.xaml
    /// </summary>
    public partial class AdminCheckQuestionPage : Page
    {
        List<QuestionsClass> questions;
        public AdminCheckQuestionPage(List<QuestionsClass> questions, string nameTest, string pathFolder)
        {
            InitializeComponent();
            this.questions = questions;
            listQuestion.ItemsSource = questions;
            Loaded += MainWindow_Loaded;
            
            //otvet1.SetValue(Grid.RowProperty, 0);
            //otvet1.SetValue(Grid.ColumnProperty, 0);
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = 800;
            Application.Current.MainWindow.Height = 450;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }
    }
}
