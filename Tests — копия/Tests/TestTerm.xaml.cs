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
using System.Windows.Shapes;

namespace Tests
{
    /// <summary>
    /// Логика взаимодействия для TestTerm.xaml
    /// </summary>
    public partial class TestTerm : Window
    {
        private Users NewUser = new Users();
       private Test test = new Test();
       
        public TestTerm(Users user)
        {
            NewUser = user;
            InitializeComponent();

            test = testingEntities.GetContext().Test.Find(1);
            Questions quest = new Questions();
            quest = testingEntities.GetContext().Questions.Where(b => b.IdTest == test.IdTest).FirstOrDefault();
            q1.Text = quest.NameQuestion;

            Questions quest1 = new Questions();
            quest1 = testingEntities.GetContext().Questions.Find(2);
            q2.Text = quest1.NameQuestion;

            Questions quest2 = new Questions();
            quest2 = testingEntities.GetContext().Questions.Find(3);
            q3.Text = quest2.NameQuestion;

            QuestAnsw qa = new QuestAnsw();
            qa = testingEntities.GetContext().QuestAnsw.Find(1);
            Answers answer = new Answers();
            answer = testingEntities.GetContext().Answers.Where(b => b.IdAnswer == qa.IdAnswer).FirstOrDefault();
            a1.Content = answer.NameAnswer;

            QuestAnsw qa1 = new QuestAnsw();
            qa1 = testingEntities.GetContext().QuestAnsw.Find(2);
            Answers answer1 = new Answers();
            answer1 = testingEntities.GetContext().Answers.Where(b => b.IdAnswer == qa1.IdAnswer).FirstOrDefault();
            a2.Content = answer1.NameAnswer;

            QuestAnsw qa2 = new QuestAnsw();
            qa2 = testingEntities.GetContext().QuestAnsw.Find(3);
            Answers answer2 = new Answers();
            answer2 = testingEntities.GetContext().Answers.Where(b => b.IdAnswer == qa2.IdAnswer).FirstOrDefault();
            a3.Content = answer2.NameAnswer;

            QuestAnsw qaa = new QuestAnsw();
            qaa = testingEntities.GetContext().QuestAnsw.Find(4);
            Answers answerr = new Answers();
            answerr = testingEntities.GetContext().Answers.Where(b => b.IdAnswer == qaa.IdAnswer).FirstOrDefault();
            a11.Content = answerr.NameAnswer;
            a111.Content = answerr.NameAnswer;

            QuestAnsw qa11 = new QuestAnsw();
            qa11 = testingEntities.GetContext().QuestAnsw.Find(5);
            Answers answer11 = new Answers();
            answer11 = testingEntities.GetContext().Answers.Where(b => b.IdAnswer == qa11.IdAnswer).FirstOrDefault();
            a22.Content = answer11.NameAnswer;
            a222.Content = answer11.NameAnswer;

            QuestAnsw qa22 = new QuestAnsw();
            qa22 = testingEntities.GetContext().QuestAnsw.Find(6);
            Answers answer22 = new Answers();
            answer22 = testingEntities.GetContext().Answers.Where(b => b.IdAnswer == qa22.IdAnswer).FirstOrDefault();
            a33.Content = answer22.NameAnswer;
            a333.Content = answer22.NameAnswer;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Results res = new Results();
            res.IdUser = NewUser.IdUser;
            res.IdTest = test.IdTest;
            res.Count = 0;
            if (a1.IsChecked == true)
            {
                res.Count += 1;

            }
            if (a33.IsChecked == true)
            {
                res.Count += 1;
            }
            if (a333.IsChecked == true)
            {
                res.Count += 1;
            }
            testingEntities.GetContext().Results.Add(res);
            testingEntities.GetContext().SaveChanges();
            MessageBox.Show($"Вы ответили правильно на {res.Count} вопросов");
            this.Hide();

        }
    }
}
