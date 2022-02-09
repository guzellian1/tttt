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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string login = TextLogin.Text;
            string pass = TextPass.Text;
            string pass1 = TextPass1.Text;
           

            Users NewUser = new Users();
            NewUser.NameUser = login;
            NewUser.PassUser = pass;
            
            NewUser.TypeUser = 0;
            if (login.Length < 5)
            {
                MessageBox.Show("Длина логина должна быть больше 5!");

            }
            else if (pass.Length < 5)
            {
                MessageBox.Show("Длина пароля должна быть больше 5!");

            }
            else if (pass != pass1)
            {
                MessageBox.Show("Пароли не совпадают!");
            }
            else
            {
                Users authUser = null;
                using (testingEntities db = new testingEntities())
                {
                    authUser = db.Users.Where(b => b.NameUser == login).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show("Такой логин или почта уже существует!");

                }
                else
                {

                    testingEntities.GetContext().Users.Add(NewUser);
                    testingEntities.GetContext().SaveChanges();
                    MessageBox.Show($"Вы успешно зарегистрировались!");
                    MainWindow n = new MainWindow(NewUser);
                    n.Show();
                    this.Hide();

                }
            }
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            Autorize n = new Autorize();
            n.Show();
            this.Hide();
        }
    }
}
