﻿using System.Windows;
using System.Windows.Input;

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

        }

        private void rbDashboard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbFAQs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbMasters_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbVacancies_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_loading(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}