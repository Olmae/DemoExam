using DemoEx18032024.Modul2;
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
    /// Логика взаимодействия для AddReq.xaml
    /// </summary>
    public partial class AddReq : Page
    {
        DatabaseQuerry DB = new DatabaseQuerry();

        public AddReq()
        {
            InitializeComponent();
            CBDevice.ItemsSource = DB.GetDevice();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserMenu());
        }

        private void ClearPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddReq());
        }

        private void SaveReq(object sender, RoutedEventArgs e)
        {
            string FIO = TBName.Text;
            string number = TBNumber.Text;
            string email = TBEmail.Text;
            string device = CBDevice.SelectedItem.ToString();
            string serialNumber = TBSN.Text;
            string description = TBDescription.Text;
            string comment = TBComment.Text;
            string status = "В ожидании";

            if (CheckFio(FIO) == true && CheckNumber(number) == true && CheckEmail(email) == true)
            {
                if (string.IsNullOrEmpty(device) || string.IsNullOrEmpty(serialNumber) || string.IsNullOrEmpty(description))
                {
                    MessageBox.Show("Введите значения оборудования, серийного номера и описания поломки");
                }
                else
                {
                    DB.CreateRequest(FIO, number, email, device, serialNumber, description, comment, status);
                    MessageBox.Show("Заявка добавлена");
                    NavigationService.Navigate(new AddReq());
                }
            }
        }

        private bool CheckFio(string Fio)
        {
            if (string.IsNullOrEmpty(Fio))
            {
                MessageBox.Show("Введите ФИО или наименования организации");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CheckNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                MessageBox.Show("Введите номер телефона");
                return false;
            }
            else
            {
                if ((number[0] == '8') || ((number[0] == '+') && (number[1] == '7')))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Неверный формат номера");
                    return false;
                }
            }
        }
        private bool CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Введите почту");
                return false;
            }
            else
            {
                if (email.Contains("@"))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Неверный формат почты");
                    return false;
                }
            }
        }
    }
}
