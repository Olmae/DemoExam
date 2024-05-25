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
    /// Логика взаимодействия для EditReq.xaml
    /// </summary>
    public partial class EditReq : Page
    {
        DatabaseQuerry DB = new DatabaseQuerry();
        public EditReq()
        {
            InitializeComponent();
            CBListReq.ItemsSource = DB.GetIdRequest();
            CBWork.ItemsSource = DB.GetWorker();
        }

        private void Changed(object sender, SelectionChangedEventArgs e)
        {
            TextBlockInfo.Text = DB.GetDescription(CBListReq.SelectedValue.ToString());
            string name = DB.GetDeviceName(int.Parse(CBListReq.SelectedItem.ToString()));
            int DeviceId = DB.GetDeviceID(name);
            CBRemont.ItemsSource = DB.GetBreakdownsByDeviceId(DeviceId);
        }

        private void SaveBT(object sender, RoutedEventArgs e)
        {
            RadioButton[] radioButtons = { RBWaiting, RBWork, RBNotDone, RBDone };

            foreach (RadioButton radioButton in radioButtons)
            {
                if (radioButton.IsChecked == true)
                {
                    string selectedValue = radioButton.Content.ToString();
                }
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserMenu());
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditReq());
        }

        private void BTDone(object sender, RoutedEventArgs e)
        {

        }
    }
}
