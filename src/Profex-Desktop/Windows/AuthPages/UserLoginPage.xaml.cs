﻿using Profex_Desktop.Windows.Auth;
using Profex_Dtos.Auth;
using Profex_Integrated.Services.Auth;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Profex_Desktop.Windows.AuthPages
{
    /// <summary>
    /// Interaction logic for UserLoginPage.xaml
    /// </summary>
    public partial class UserLoginPage : Page
    {
        private UserRegisterPage userRegisterPage;
        private AuthUserService _authUserService = new AuthUserService();
        private LoginDto _loginDto = new LoginDto();

        public UserLoginPage()
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
            loader.Visibility = Visibility;
            SignUpbtn.IsEnabled = false;
            if (pswBox.Password.Length > 3 && phoneNum.Text.Length == 12)
            {
                _loginDto.PhoneNumber = "+" + phoneNum.Text;
                _loginDto.Password = pswBox.Password;
                var result = await _authUserService.LoginAsync(_loginDto);
                if (result.Result == true)
                {
                    string fileName = "C:\\Users\\Public\\Token.txt";
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
                    UserMainWindow mainWindow = new UserMainWindow();
                    loader.Visibility = Visibility.Collapsed;
                    mainWindow.Show();
                    UserAuthWindow authWindow = Window.GetWindow(this) as UserAuthWindow;
                    authWindow?.Close();
                }
                else
                {
                    loader.Visibility = Visibility.Collapsed;
                    MessageBox.Show("Telefon raqam yoki parol noto'g'ri kiritilgan!");
                    SignUpbtn.IsEnabled = true;

                }

            }
            else
            {
                loader.Visibility = Visibility.Collapsed;
                MessageBox.Show("Iltimos ma'lumotlarni to'liq kiriting!");
                SignUpbtn.IsEnabled = true;
            }

        }
    }
}
