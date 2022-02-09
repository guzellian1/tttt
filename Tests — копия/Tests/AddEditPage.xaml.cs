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

namespace Tests
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Questions _currentQuestion = new Questions();
        public AddEditPage()
        {
            InitializeComponent();
            DataContext = _currentQuestion;
            ComboTests.ItemsSource = testingEntities.GetContext().Test.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            Test test = new Test();
            test = (Test)ComboTests.SelectedItem;
            _currentQuestion.NameQuestion = QuestionText.Text;
            _currentQuestion.IdTest = test.IdTest;

            if (string.IsNullOrWhiteSpace(_currentQuestion.NameQuestion))
                errors.AppendLine("Укажите содержание вопроса");
            if(ComboTests.SelectedItem == null)
                errors.AppendLine("Укажите тест");

            //if (errors.Length > 0)
            //{
            //    MessageBox.Show(errors.ToString());
            //}

            if (_currentQuestion.IdQuestion == 0)
            {
                
                testingEntities.GetContext().Questions.Add(_currentQuestion);
            }

            //try
            //{
                testingEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }
    }
}
