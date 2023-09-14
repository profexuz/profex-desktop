using Profex_Desktop.Windows.Offerta_shartlari;
using Profex_Dtos.Auth;
using Profex_Integrated.Services.Auth;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Profex_Desktop.Windows.AuthPages
{
    /// <summary>
    /// Interaction logic for UserRegisterPage.xaml
    /// </summary>
    public partial class UserRegisterPage : Page
    {
        private RegisterDto _registerDto = new RegisterDto();
        private AuthUserService _authUserService = new AuthUserService();
        public UserRegisterPage()
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
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void SignUserbtn_Click(object sender, RoutedEventArgs e)
        {
            SignUpbtn.IsEnabled = false;
            if (txtPassword.Password.Length > 0 && txtName.Text.Length > 0 && phoneNum1.Text.Length > 0 && txtSurname.Text.Length > 0)
            {
                if (txtPassword.Password.Length > 3 && txtName.Text.Length > 3 && phoneNum1.Text.Length == 12 && txtSurname.Text.Length > 3)
                {
                    _registerDto.FirstName = txtName.Text;
                    _registerDto.LastName = txtSurname.Text.ToString();
                    _registerDto.PhoneNumber = "+" + phoneNum1.Text.ToString();
                    _registerDto.Password = txtPassword.Password.ToString();
                    bool res = await _authUserService.RegisterAsync(_registerDto);

                    if (res)
                    {
                        var result = await _authUserService.SendCodeForRegisterAsync(_registerDto.PhoneNumber);
                        if (result)
                        {
                            SmsPage smsPage = new SmsPage();
                            smsPage.PhoneNum = "+" + phoneNum1.Text;
                            NavigationService.Navigate(smsPage);
                        }

                    }
                    else
                    {
                        SignUpbtn.IsEnabled = true;

                    }
                }
                else
                {
                    MessageBox.Show("Ma'lumotlar to'liq kiritlmagan");
                    SignUpbtn.IsEnabled = true;

                }
            }
            else
            {
                MessageBox.Show("Ma'lumotlar bo'sh bo'lmasligi kerak");
                SignUpbtn.IsEnabled = true;

            }
        }
    }
}
