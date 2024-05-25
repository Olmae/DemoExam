using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
    /// Логика взаимодействия для AddMark.xaml
    /// </summary>
    public partial class AddMark : Page
    {
        public AddMark()
        {
            InitializeComponent();
            GenerateQRCode("https://www.google.ru/forms/about/");
        }

        private void GenerateQRCode(string url)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            using (MemoryStream ms = new MemoryStream())
            {
                qrCodeImage.Save(ms, ImageFormat.Png);
                ms.Position = 0;

                BitmapImage bitmapImage = new BitmapImage();

                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                Image.Source = bitmapImage;

                qrCodeImage.Dispose();
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserMenu());
        }
    }
}
