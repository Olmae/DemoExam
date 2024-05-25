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
    /// Логика взаимодействия для UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Page
    {
        
        public UserMenu()
        {
            InitializeComponent();
        }

        private void GoToAddReq(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddReq());
        }

        private void GoToEditReq(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditReq());
        }

        private void GoToAllReq(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllReq());
        }

        private void GoAddRating(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddMark());
        }

        private void ExitAuto(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Autorization());
        }
    }
}
