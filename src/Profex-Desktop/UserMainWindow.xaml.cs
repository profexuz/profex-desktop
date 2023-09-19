
using Profex_Desktop.Pages;
using Profex_Integrated.Interfaces;
using Profex_Integrated.Security;
using Profex_Integrated.Services.Auth.JwtToken;
using Profex_Integrated.Services.Masters;
using Profex_Integrated.Services.Users;
using System;
using System.Windows;
using System.Windows;

using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace Profex_Desktop
{
    /// <summary>
    /// Interaction logic for UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        private IdentityService _identityService;
        private JwtParser jwtParser = new JwtParser();
        //private MasterService _masterService = new MasterService();
        private UserService _userService = new UserService();
        private string BASEIMG_URL = "http://64.227.42.134:4040/";
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

        private async void Window_loading(object sender, RoutedEventArgs e)
        {
            var result = await _userService.GetByIdAsync(IdentitySingelton.GetInstance().Id);
            string imageUrl = BASEIMG_URL + result.ImagePath;
            Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
            MyPhoto.ImageSource = new BitmapImage(imageUri);
            //Name.Content = result.FirstName;
            UserMyName.Content = result.FirstName;
            rbDashboard.IsChecked = true;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void rbMyPost_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "My Posts";
            UserPostPage userPostPage = new UserPostPage();
            PageNavigator.Navigate(userPostPage);
        }



        private void rbProfil_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "PROFILE";
            UserEditPage userEditPage = new UserEditPage();
            PageNavigator.Navigate(userEditPage);
        }

        

        private void rbSorovlar(object sender, RoutedEventArgs e)
        {
            appName.Content = "So'rovlarim";
            MyRequestPageUser mys = new MyRequestPageUser();
            PageNavigator.Navigate(mys);

        }
    }
}
