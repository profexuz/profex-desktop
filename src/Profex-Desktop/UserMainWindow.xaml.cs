using Profex_Desktop.Pages;
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

namespace Profex_Desktop
{
    /// <summary>
    /// Interaction logic for UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        public UserMainWindow()
        {
            InitializeComponent();
        }

        private void PageNavigator_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

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

        private void rbAccount_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "PROFILE";
            UserMasterEditPage masterEdit = new UserMasterEditPage();
            PageNavigator.Navigate(masterEdit);
        }

        private void rbDashboard_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "ASOSIY";
            UserDashboard dashboard = new UserDashboard();
            PageNavigator.Navigate(dashboard);
        }

        private void rbFAQs_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "SAVOL-JAVOB";
            UserFaqsPage faqsPage = new UserFaqsPage();
            PageNavigator.Navigate(faqsPage);
        }

        private void rbMasters_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "USTALAR";
            UserMastersPage mastersPage = new UserMastersPage();
            PageNavigator.Navigate(mastersPage);
        }

        private void rbVacancies_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "ISHLAR";
            UserVacancies vacancy = new UserVacancies();
            PageNavigator.Navigate(vacancy);
        }

        private void Window_loading(object sender, RoutedEventArgs e)
        { 
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
