using DemoEx18032024.Modul2;
using DemoEx18032024.Modul3;
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

namespace DemoEx18032024.Modul1
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        DatabaseQuerry DB = new DatabaseQuerry();
        public Autorization()
        {
            InitializeComponent();
        }

        private void BTEnter(object sender, RoutedEventArgs e)
        {
            string Login = TBLogin.Text;
            string password = TBPassword.Password;

            string resultAuto = DB.AuthenticateUser(Login, password);
            if (resultAuto == "Success")
            {
                string role = DB.VerifyRole(Login);
                role.ToLower();
                if (role == "User")
                {
                    NavigationService.Navigate(new UserMenu());
                }
                else if (role == "Manager")
                {
                    NavigationService.Navigate(new ManagerMenu());
                }
                else if (role == "Worker")
                {
                    NavigationService.Navigate(new WorkerPage());
                }
            }
            else if (resultAuto == "IncorrectPassword")
            {
                MessageBox.Show("Неправильный пароль");
                return;
            }
            else if (resultAuto == "UserNotFound")
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }
            else
            {
                MessageBox.Show("Неизвестная ошибка");
                return;
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
