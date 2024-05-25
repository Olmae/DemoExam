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
using DemoEx18032024.Modul1;

namespace DemoEx18032024.Modul3
{
    /// <summary>
    /// Логика взаимодействия для ManagerMenu.xaml
    /// </summary>
    public partial class ManagerMenu : Page
    {
        public ManagerMenu()
        {
            InitializeComponent();
        }

        private void GoToAddWork(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddWorker());
        }

        private void GoToEditReq(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagerEditReq());
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Autorization());
        }
    }
}
