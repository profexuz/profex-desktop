using Profex_Desktop.Windows.AuthPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Profex_Desktop.Windows.Auth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
           
        }

        private void btnClose_Clicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginPage login = new LoginPage();
            registerFrame.Navigate(login);

            SignUp.IsChecked = true;
        }

        private void SignUp_Checked(object sender, RoutedEventArgs e)
        {
            Sign.Content = "Ro'yxatdan o'tish";
            SignIn.Opacity = 0.5;
            SignUp.Opacity = 1;
            RegisterPage register = new RegisterPage();
            registerFrame.Navigate(register);


        }

        private void SignIn_Checked(object sender, RoutedEventArgs e)
        {
            Sign.Content = "Kirish";
            SignUp.Opacity = 0.5;
            SignIn.Opacity = 1;
            LoginPage login = new LoginPage();
            registerFrame.Navigate(login);

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
