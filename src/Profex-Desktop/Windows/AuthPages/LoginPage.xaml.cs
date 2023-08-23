using Profex_Desktop.Windows.Auth;
using Profex_Dtos.Auth;
using Profex_Integrated.Services.Auth;
using System.IO;
using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Profex_Desktop.Windows.AuthPages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private RegisterPage registerPage;
        private AuthMasterService _authMasterService = new AuthMasterService();
        private LoginDto _loginDto = new LoginDto();


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

        private async void SignUpbtn_Clicked(object sender, RoutedEventArgs e)
        {
            if(pswBox.Password.Length>3 && phoneNum.Text.Length == 12)
            {
                _loginDto.PhoneNumber = "+"+phoneNum.Text;
                _loginDto.Password = pswBox.Password;
                var result = await _authMasterService.LoginAsync(_loginDto);
                if (result.Result == true)
                {
                    string fileName = @"C:\Users\99891\Desktop\Token.txt";
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    using (FileStream fs = File.Create(fileName))
                    {
                        // Add some text to file    
                        Byte[] title = new UTF8Encoding(true).GetBytes($"{result.Token}");
                        fs.Write(title, 0, title.Length);
                    }
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    AuthWindow authWindow = Window.GetWindow(this) as AuthWindow;
                    authWindow?.Close();
                }
                else
                {
                    MessageBox.Show("Telefon raqam yoki parol noto'g'ri kiritilgan!");
                }
                
            }
            else
            {
                MessageBox.Show("Iltimos ma'lumotlarni to'liq kiriting!");
            }
            
        }
    }
}
