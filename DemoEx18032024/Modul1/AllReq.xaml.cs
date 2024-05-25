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
    /// Логика взаимодействия для AllReq.xaml
    /// </summary>
    public partial class AllReq : Page
    {
        DatabaseQuerry DB = new DatabaseQuerry();
        public AllReq()
        {
            InitializeComponent();
            AllRequest.ItemsSource = DB.GetAllRequests().DefaultView;
            AllRequest.AutoGenerateColumns = true;
            AllRequest.CanUserAddRows = false;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
