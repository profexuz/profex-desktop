using Profex_Desktop.Windows.Offerta_shartlari;
using Profex_Dtos.Auth;
using Profex_Integrated.Services.Auth;
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
        private RegisterDto registerDto = new RegisterDto();
        private AuthMasterService _authMasterService = new AuthMasterService();

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

        private async void SignUpbtn_Click(object sender, RoutedEventArgs e)
        {
            loader.Visibility = Visibility;
            SignUpbtn.IsEnabled = false;
            if (txtPassword.Password.Length > 0 && txtName.Text.Length > 0 && phoneNum.Text.Length > 0 && txtSurname.Text.Length > 0)
            {
                if (txtPassword.Password.Length > 3 && txtName.Text.Length > 3 && phoneNum.Text.Length == 12 && txtSurname.Text.Length > 3)
                {
                    registerDto.FirstName = txtName.Text;
                    registerDto.LastName = txtSurname.Text.ToString();
                    registerDto.PhoneNumber = "+" + phoneNum.Text.ToString();
                    registerDto.Password = txtPassword.Password.ToString();
                    bool res = await _authMasterService.RegisterAsync(registerDto);

                    if (res)
                    {
                        var result = await _authMasterService.SendCodeForRegisterAsync(registerDto.PhoneNumber);
                        if (result)
                        {
                            SmsPage smsPage = new SmsPage();
                            smsPage.PhoneNum = "+" + phoneNum.Text;
                            loader.Visibility = Visibility.Collapsed;
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
