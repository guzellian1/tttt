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
    /// Логика взаимодействия для Autorize.xaml
    /// </summary>
    public partial class Autorize : Window
    {
        public Autorize()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string login = TextLogin.Text;
            string pass = TextPass.Text;
            if (login.Length < 2)
            {
                MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные");

            }
            else if (pass.Length < 2)
            {
                MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные");

            }

            else
            {
                Users authUser = null;
                using (testingEntities db = new testingEntities())
                {
                    authUser = db.Users.Where(b => b.NameUser == login && b.PassUser == pass).FirstOrDefault();
                }
                if (authUser != null)
                {
                    if (authUser.TypeUser == 0)
                    {

                        MessageBox.Show("Вы успешно вошли в систему!");
                        MainWindow n = new MainWindow(authUser);
                        n.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Вы успешно вошли в систему!");
                        AdminWindow n = new AdminWindow(authUser);
                        n.Show();
                        this.Hide();
                    }
                }

                else
                {
                    MessageBox.Show("Что-то пошло не так, проверьте введённые данные!");

                }
            }
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Register n = new Register();
            n.Show();
            this.Hide();
        }
    }
}
