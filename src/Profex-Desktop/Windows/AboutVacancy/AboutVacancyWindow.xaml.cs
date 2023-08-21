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

namespace Profex_Desktop.Windows.AboutVacancy
{
    /// <summary>
    /// Interaction logic for AboutVacancyWindow.xaml
    /// </summary>
    public partial class AboutVacancyWindow : Window
    {
        public AboutVacancyWindow()
        {
            InitializeComponent();
        }

        private void rbImg_Click(object sender, RoutedEventArgs e)
        {
            ImageSource imageSource = new BitmapImage(new Uri(rbImg.Content.ToString()!));
            imgMain.ImageSource = imageSource;
        }

        private void rbImg1_Click(object sender, RoutedEventArgs e)
        {
            ImageSource imageSource = new BitmapImage(new Uri(rbImg1.Content.ToString()!));
            imgMain.ImageSource = imageSource;

        }

        private void rbImg2_Click(object sender, RoutedEventArgs e)
        {
            ImageSource imageSource = new BitmapImage(new Uri(rbImg2.Content.ToString()!));
            imgMain.ImageSource = imageSource;
        }

        private void rbImg3_Click(object sender, RoutedEventArgs e)
        {
            ImageSource imageSource = new BitmapImage(new Uri(rbImg3.Content.ToString()!));
            imgMain.ImageSource = imageSource;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ImageSource imageSource = new BitmapImage(new Uri(rbImg.Content.ToString()!));
            imgMain.ImageSource = imageSource;
        }

        private void btnLongLatitudeAnswer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
