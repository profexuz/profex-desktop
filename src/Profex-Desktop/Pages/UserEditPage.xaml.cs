﻿using Microsoft.AspNetCore.Http.Internal;
using Profex_Dtos.Users;
using Profex_Integrated.Helpers;
using Profex_Integrated.Security;
using Profex_Integrated.Services.Auth.JwtToken;
using Profex_Integrated.Services.Users;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for UserEditPage.xaml
    /// </summary>
    public partial class UserEditPage : Page
    {
        private string _path = "C:\\Users\\Public\\Token.txt";
        private UserService _userService = new UserService();
        private JwtParser jwtParser = new JwtParser();
        private UserUpdateDto _userViewModel = new UserUpdateDto();
        private string selectedFilePath = "";
        public UserEditPage()
        {
            InitializeComponent();
        }
        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void brUpload_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var clickedElement = sender as UIElement;

            if (clickedElement != null)
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

                openFileDialog.Filter = "Rasm fayllari|*.jpg;*.jpeg;*.png;|Barcha fayllar|*.*";
                bool? result = openFileDialog.ShowDialog();
                if (result == true)
                {
                    selectedFilePath = openFileDialog.FileName;
                    if (selectedFilePath.Contains(".jpg") | selectedFilePath.Contains(".jpeg") | selectedFilePath.Contains(".png"))
                    {
                        btnSave.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Faqat 'jpg','jpeg' va 'png' formatdagi rasmlarni yuklay olasiz", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        btnSave.IsEnabled = false;
                    }
                    ImageSource imageSource = new BitmapImage(new Uri(selectedFilePath));
                    imgProfile.ImageSource = imageSource;
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtFName.IsReadOnly = false;
            txtLName.IsReadOnly = false;
            txtNum.IsReadOnly = false;

            btnSave.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Hidden;
            btnChange.Visibility = Visibility.Visible;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            btnChange.Visibility = Visibility.Hidden;
            brUpload.IsEnabled = true;
            
            txtFName.IsReadOnly = false;
            txtLName.IsReadOnly = false;
            txtNum.IsReadOnly = false;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            btnChange.Visibility = Visibility.Hidden;



            string token = File.ReadAllText(_path);
            IdentityService identityService = jwtParser.ParseToken(token);

            _userViewModel.FirstName = txtFName.Text;
            _userViewModel.LastName = txtLName.Text;
            _userViewModel.PhoneNumber = "+" + txtNum.Text;
            
            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                var fileBytes = File.ReadAllBytes(selectedFilePath);
                var fileName = System.IO.Path.GetFileName(selectedFilePath);
                _userViewModel.ImagePath = new FormFile(new MemoryStream(fileBytes), 0, fileBytes.Length, null, fileName);
                btnSave.IsEnabled = true;
            }
            else
            {
                var res = await _userService.GetByIdAsync(IdentitySingelton.GetInstance().Id);
                _userViewModel.ImagePath = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes(res.ImagePath)), 0, res.ImagePath.Length, null, System.IO.Path.GetFileName(res.ImagePath));
                btnSave.IsEnabled = true;
            }
            
            var result = await _userService.UpdateAsync(identityService.Id, _userViewModel);
            if (result == true)
            {
                await RefreshAsync();
            }
            else
            {
                MessageBox.Show("Internet bilan muammo yuzaga keldi!");
            }

        }

        private async void Page_loaded(object sender, RoutedEventArgs e)
        {
            string token = File.ReadAllText(_path);
            IdentityService identityService = jwtParser.ParseToken(token);
            var result = await _userService.GetByIdAsync(identityService.Id);
            txtFName.Text = result.FirstName.ToUpper();
            txtLName.Text = result.LastName.ToUpper();
            txtNum.Text = result.PhoneNumber.ToUpper().Substring(1);
            string imageUrl = API.BASEIMG_URL + result.ImagePath;
            Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
            imgProfile.ImageSource = new BitmapImage(imageUri);
            loader.Visibility = Visibility.Collapsed;
            loader2.Visibility = Visibility.Collapsed;
        }
        public async Task RefreshAsync()
        {
            string token = File.ReadAllText(_path);
            IdentityService identityService = jwtParser.ParseToken(token);
            var result = await _userService.GetByIdAsync(identityService.Id);
            txtFName.Text = result.FirstName.ToUpper();
            txtLName.Text = result.LastName.ToUpper();
            txtNum.Text = result.PhoneNumber.ToUpper().Substring(1);
            string imageUrl = API.BASEIMG_URL + result.ImagePath;
            Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
            imgProfile.ImageSource = new BitmapImage(imageUri);
            loader.Visibility = Visibility.Collapsed;
            loader2.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Hidden;
            btnChange.Visibility = Visibility.Visible;
            //this.Visibility = Visibility.Hidden;
        }

        

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
