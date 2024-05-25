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

namespace DemoEx18032024.Modul3
{
    /// <summary>
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Page
    {
        DatabaseQuerry DB = new DatabaseQuerry();
        public AddWorker()
        {
            InitializeComponent();
            CBID.ItemsSource = DB.GetIdRequest();
            CBWorker.ItemsSource = DB.GetWorker();
        }

        private void Save(object sender, RoutedEventArgs e)
        {

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagerMenu());
        }
    }
}
