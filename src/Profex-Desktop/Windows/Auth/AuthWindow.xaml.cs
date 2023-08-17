using Profex_Desktop.Windows.AuthPages;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Profex_Desktop.Windows.Auth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private RegisterPage register = new RegisterPage();
        private LoginPage login = new LoginPage();
        private string signUP = "Ro'yxatdan o'tish"; 
        private string signIn = "Kirish";
        private string Ihave = "Ro'yxatdan o'tganman";
        private string Ihavenot = "Ro'yxatdan o'tmaganman";
        public bool signUp_In { get; set; } = true;


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
            
        }

        private void SignUp_Checked(object sender, RoutedEventArgs e)
        {
            Sign.Content = signUP;
            SignIn.Opacity = 0.5;
            SignUp.Opacity = 1;
            registerFrame.Navigate(register);


        }

        private void SignIn_Checked(object sender, RoutedEventArgs e)
        {
            Sign.Content = signIn;
            SignUp.Opacity = 0.5;
            SignIn.Opacity = 1;
            registerFrame.Navigate(login);

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Idonthave_Click(object sender, RoutedEventArgs e)
        {
            if (signUp_In)
            {
                SignUp.IsChecked = true;
                SignIn.IsChecked = false;
                Sign.Content = signUP;
                Idonthave.Content = Ihave;
                registerFrame.Navigate(register);

                signUp_In = false;
            }
            else
            {
                SignUp.IsChecked = false;
                SignIn.IsChecked = true;
                Sign.Content = signIn;
                Idonthave.Content = Ihavenot;
                registerFrame.Navigate(login);

                signUp_In = true;

            }
        }
    }
}
