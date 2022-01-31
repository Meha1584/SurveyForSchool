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
        public AdminCheckQuestionPage()
        {
            InitializeComponent();
            questions = new List<QuestionsClass>();
            Loaded += MainWindow_Loaded;
            //otvet1.SetValue(Grid.RowProperty, 0);
            //otvet1.SetValue(Grid.ColumnProperty, 0);
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = 800;
            Application.Current.MainWindow.Height = 450;
            AddQuestion();
        }
        public void AddQuestion()
        {
            StreamReader streamReader = new StreamReader(@"C:\Users\Fillaa\source\repos\SurveyForSchool\SurveyForSchool\bin\Debug\d\1.txt");
            string line;
            List<string> listElement = new List<string>();
            var list = new List<List<string>>();
            while ((line = streamReader.ReadLine()) != null)
            {
                listElement.Add(line);
            }
            for (int i = 0; i < listElement.Count; i += 6)
            {
                list.Add(listElement.GetRange(i, Math.Min(6, listElement.Count - i)));
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
            streamReader.Close();
            listQuestion.ItemsSource = questions;
        }
    }
}
