using Profex_Desktop.Windows.AuthPages;
using System.Windows;
using System.Windows.Input;

namespace Profex_Desktop.Windows.Auth
{
    /// <summary>
    /// Interaction logic for UserAuthWindow.xaml
    /// </summary>
    public partial class UserAuthWindow : Window
    {
        public bool vis { get; set; } = true;
        private UserRegisterPage register = new UserRegisterPage();
        private UserLoginPage login = new UserLoginPage();
        private string signUP = "Ro'yxatdan o'tish";
        private string signIn = "Kirish";
        public UserAuthWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Clicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SignIn_Checked(object sender, RoutedEventArgs e)
        {
            Sign.Content = signIn;
            SignUp.Opacity = 0.5;
            SignIn.Opacity = 1;
            registerFrame.Navigate(login);
        }

        private void SignUp_Checked(object sender, RoutedEventArgs e)
        {
            Sign.Content = signUP;
            SignIn.Opacity = 0.5;
            SignUp.Opacity = 1;
            registerFrame.Navigate(register);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            registerFrame.Navigate(login);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
