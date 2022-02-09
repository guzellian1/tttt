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
    /// Логика взаимодействия для PersonalCabinet.xaml
    /// </summary>
    public partial class PersonalCabinet : Window
    {
       private Users NewUser = new Users();
        public PersonalCabinet(Users user)
        {
            NewUser = user;
            InitializeComponent();
            
            DGridTests.ItemsSource = testingEntities.GetContext().Results.Where(b => b.IdUser == NewUser.IdUser).ToList();
        }

      
    }
}
