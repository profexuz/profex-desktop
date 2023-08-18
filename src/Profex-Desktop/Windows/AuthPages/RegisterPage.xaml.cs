using DevExpress.Utils.Design;
using Profex_Desktop.Windows.Auth;
using Profex_Desktop.Windows.Offerta_shartlari;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

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

        }

        private void SignUpbtn_Click(object sender, RoutedEventArgs e)
        {
            if(txtPassword.Password.Length!=0 || txtName.Text.Length != 0 || phoneNum.Text.Length != 0 || txtSurname.Text.Length != 0)
             
            {
                if (txtPassword.Password.Length > 3 && txtName.Text.Length > 3 && phoneNum.Text.Length == 12 && txtSurname.Text.Length > 3)
                {
                    AuthWindow auth = new AuthWindow();
                    auth.vis = false;
                    SmsPage smsPage = new SmsPage();
                    smsPage.txtSmsInfo.Text += " +" + phoneNum.Text.ToString();
                    NavigationService.Navigate(smsPage);    
                }
                else
                {
                    MessageBox.Show("Ma'lumotlar to'liq kiritlmagan");
                }
            }
            else
            {
                MessageBox.Show("Ma'lumotlar bo'sh bo'lmasligi kerak");
            }

        }
    }
}
