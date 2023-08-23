using Profex_Desktop.Components.Loading;
using Profex_Desktop.Pages;
using Profex_Integrated.Services.Auth.JwtToken;
using Profex_Integrated.Services.Masters;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Profex_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IdentityService _identityService;
        private JwtParser jwtParser = new JwtParser();
        private MasterService _masterService = new MasterService();
        private string BASEIMG_URL = "http://95.130.227.187/";


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

        private async void rbDashboard_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "ASOSIY";
            Dashboard dashboard = new Dashboard();
            PageNavigator.Navigate(dashboard);
        }

        async System.Threading.Tasks.Task ShowIndicator()
        {
            Task.Factory.StartNew(async () =>
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    wrpLoading.Children.Clear();
                    LoadingUserControll loadingUserControll = new LoadingUserControll();
                    wrpLoading.Children.Add(loadingUserControll);
                });
            });
        }

        private void rbVacancies_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "ISHLAR";
            Vacancies vacancy = new Vacancies();
            PageNavigator.Navigate(vacancy);
        }

        private void rbFAQs_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "SAVOL-JAVOB";
            FaqsPage faqsPage = new FaqsPage();
            PageNavigator.Navigate(faqsPage);
        }

        private async void Window_loading(object sender, RoutedEventArgs e)
        {
            string tokenString = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjEzIiwiRmlyc3ROYW1lIjoiSmF2bG9uYmVrIiwiTGFzdE5hbWUiOiJEamFsZWtlZXYiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9tb2JpbGVwaG9uZSI6Iis5OTg5MTM3NzQ1MDYiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJNYXN0ZXIiLCJleHAiOjE2OTI4ODAzNzYsImlzcyI6Imh0dHA6Ly9wcm9mZXgudXoiLCJhdWQiOiJQcm9GZXgifQ.UGojGvHrmbNrND0-D1cJFmTdP6KSbKXNge9VAAXNbzo";
            IdentityService tokenModel = jwtParser.ParseToken(tokenString);

            var result = await _masterService.GetByIdAsync(tokenModel.Id);
            string imageUrl = BASEIMG_URL + result.ImagePath;
            Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
            MyPhoto.ImageSource = new BitmapImage(imageUri);
            MyName.Content = tokenModel.FirstName.ToUpper();
            rbDashboard.IsChecked = true;

        }

        private void ToggleButton_PreviewStylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {

        }

        private void rbMasters_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "USTALAR";
            MastersPage mastersPage = new MastersPage();
            PageNavigator.Navigate(mastersPage);
        }

        private void rbAccount_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "PROFILE";
            MasterEditPage masterEdit = new MasterEditPage();
            PageNavigator.Navigate(masterEdit);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {

            }
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
