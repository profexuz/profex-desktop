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
        public LoginPage()
        {
            InitializeComponent();
        }

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            if (checkbox.IsChecked == true)
                SignUpbtn.IsEnabled = true;

            else SignUpbtn.IsEnabled = false;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
