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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Users NewUser = new Users();
        public MainWindow(Users user)
        {
            NewUser = user;
            InitializeComponent();
        }

        private void TestTermOpen(object sender, RoutedEventArgs e)
        {
            TestTerm t = new TestTerm(NewUser);
            t.Show();
        }

        private void Cabinet_Click(object sender, RoutedEventArgs e)
        {
            PersonalCabinet p = new PersonalCabinet(NewUser);
            p.Show();
        }

        private void DB_Click(object sender, RoutedEventArgs e)
        {
            TestDataBase d = new TestDataBase(NewUser);
            d.Show();
        }
    }
}
