using Profex_Desktop.Pages;
using Profex_Desktop.Themes;
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
using System.Net.Mime;

namespace Profex_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void rbDashboard_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            PageNavigator.Navigate(dashboard);
        }

        private void rbVacancies_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbFAQs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_loading(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleButton_PreviewStylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {

        }

        private void IsChecked(object sender, RoutedEventArgs e)
        {
            if (chkbox.IsChecked == true)
            {
                AppTheme.ChangeTheme(new Uri("Themes/DarkTheme.xaml", UriKind.Relative));
                ProfileImg.ImageSource = new BitmapImage(new Uri("C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Profile images\\default image.jpg", UriKind.Relative));

            }
            else
            {
                AppTheme.ChangeTheme(new Uri("Themes/LightTheme.xaml", UriKind.Relative));
                ProfileImg.ImageSource = new BitmapImage(new Uri("C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Profile images\\default imageLight.jpg", UriKind.Relative));
            }
        }
    }
}
