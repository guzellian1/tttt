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
    /// Логика взаимодействия для QuestionEditPage.xaml
    /// </summary>
    public partial class QuestionEditPage : Page
    {
        public QuestionEditPage()
        {
            InitializeComponent();
            DGridQuestions.ItemsSource = testingEntities.GetContext().Questions.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            //this.frame.Navigate(typeof(AddEditPage));
            frame.Navigate(new AddEditPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new AddEditPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var questionForRemoving = DGridQuestions.SelectedItems.Cast<Questions>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {questionForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes);
            {
                try
                {
                    testingEntities.GetContext().Questions.RemoveRange(questionForRemoving);
                    testingEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridQuestions.ItemsSource = testingEntities.GetContext().Questions.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                testingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridQuestions.ItemsSource = testingEntities.GetContext().Questions.ToList();
            }
        }
    }
}
