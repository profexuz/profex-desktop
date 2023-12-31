﻿using Profex_Desktop.Components.Loading;
using Profex_Desktop.Pages;
using Profex_Desktop.Windows.StartWindow;
using Profex_Integrated.Helpers;
using Profex_Integrated.Security;
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
            appName.Content = "Asosiy";
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
            appName.Content = "Ishlar";
            Vacancies vacancy = new Vacancies();
            PageNavigator.Navigate(vacancy);
        }

        private void rbFAQs_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "Savol-javob";
            FaqsPage faqsPage = new FaqsPage();
            PageNavigator.Navigate(faqsPage);
        }

        private async void Window_loading(object sender, RoutedEventArgs e)
        {
            var result = await _masterService.GetByIdAsync(IdentitySingelton.GetInstance().Id);
            string imageUrl = API.BASEIMG_URL + result.ImagePath;
            Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
            MyPhoto.ImageSource = new BitmapImage(imageUri);
            MyName.Content = result.FirstName;
            rbDashboard.IsChecked = true;

        }

        private void ToggleButton_PreviewStylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {

        }

        private void rbMasters_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "Ustalar";
            MastersPage mastersPage = new MastersPage();
            PageNavigator.Navigate(mastersPage);
        }

        private void rbAccount_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "Profilim";
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

        private void rbSkills_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "Mahoratlarim";
            SkillsPage skillsPage = new SkillsPage();
            PageNavigator.Navigate(skillsPage);

        }

        private void rbRequst_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "So'rovlar";
            RequestPage rqPage = new RequestPage();
            PageNavigator.Navigate(rqPage);
        }

        private void rbMyRequests_Click(object sender, RoutedEventArgs e)
        {
            appName.Content = "So'rovlarim";
            MyRequestsPage myRqPage = new MyRequestsPage();
            PageNavigator.Navigate(myRqPage);
        }

        private void rbMyRequests_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbSignOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BeginWindow begw = new BeginWindow();
            begw.ShowDialog();
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
