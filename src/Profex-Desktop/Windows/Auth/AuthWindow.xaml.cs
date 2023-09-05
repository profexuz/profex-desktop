using Profex_Desktop.Windows.AuthPages;
using System.Windows;
using System.Windows.Input;

namespace Profex_Desktop.Windows.Auth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class AuthWindow : Window
    {
        public bool vis { get; set; } = true;
        private RegisterPage register = new RegisterPage();
        private LoginPage login = new LoginPage();
        private string signUP = "Ro'yxatdan o'tish";
        private string signIn = "Kirish";


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
    }
}
