using Profex_Desktop.Components.MasterContact;
using Profex_Desktop.Pages;
using Profex_Desktop.Themes;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }

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
            Vacancies vacancy = new Vacancies();
            PageNavigator.Navigate(vacancy);
        }

        private void rbFAQs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_loading(object sender, RoutedEventArgs e)
        {
            //if(ProfileMyName.Text.Length > 10)
            //{
            //    string name = string.Empty, name1 = ProfileMyName.Text;
            //    byte count = 0;
            //    foreach(var n in name1)
            //    {
            //        if (count == 7) break;
            //        name = name+ n;
            //        count++;
            //    }
            //    ProfileMyName.Text = name + "...";
            //}
        }

        private void ToggleButton_PreviewStylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {

        }

        private void rbMasters_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbSetting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //private void IsChecked(object sender, RoutedEventArgs e)
        //{
        //    if (chkbox.IsChecked == true)
        //    {
        //        AppTheme.ChangeTheme(new Uri("Themes/DarkTheme.xaml", UriKind.Relative));

        //    }
        //    else
        //    {
        //        AppTheme.ChangeTheme(new Uri("Themes/LightTheme.xaml", UriKind.Relative));
        //    }
        //}

    }
}
