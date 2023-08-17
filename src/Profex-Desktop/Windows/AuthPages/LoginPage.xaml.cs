using Profex_Desktop.Windows.Auth;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Profex_Desktop.Windows.AuthPages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private RegisterPage registerPage;

        public LoginPage()
        {
            InitializeComponent();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SignUpbtn_Clicked(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            AuthWindow authWindow = Window.GetWindow(this) as AuthWindow;
            authWindow?.Close();
            
        }

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
