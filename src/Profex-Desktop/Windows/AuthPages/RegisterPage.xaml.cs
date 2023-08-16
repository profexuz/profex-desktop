using Profex_Desktop.Windows.Auth;
using Profex_Desktop.Windows.Offerta_shartlari;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Profex_Desktop.Windows.AuthPages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            
            if (checkbox.IsChecked == true)
            {
                SignUpbtn.IsEnabled = true;
            }
            else
            {
                SignUpbtn.IsEnabled = false;
            }
        }

        private void btnOfferta_Clicked(object sender, RoutedEventArgs e)
        {
            OffertaShartlari offerta = new OffertaShartlari();
            offerta.Show();
        }

        private void NumberValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Ihavenotaccount_Click(object sender, RoutedEventArgs e)
        {
            var LoginPage = new LoginPage(); //create your new form.
            LoginPage.Show(); //show the new form.
            this.Close();
        }
    }
}
