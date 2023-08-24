using DevExpress.Utils.Url;
using Profex_Dtos.Masters;
using Profex_Integrated.Interfaces;
using Profex_Integrated.Services.Auth.JwtToken;
using Profex_Integrated.Services.Masters;
using Profex_ViewModels.Masters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for MasterEditPage.xaml
    /// </summary>
    public partial class MasterEditPage : Page
    {
        private MasterService _masterService = new MasterService();
        private JwtParser jwtParser = new JwtParser();
        private MasterUpdateDto _masterViewModel = new MasterUpdateDto();

        public MasterEditPage()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void btngetImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtFName.IsReadOnly = false;
            txtLName.IsReadOnly = false;
            txtNum.IsReadOnly = false;
            cmbIsFree.IsReadOnly = false;
        }

        private void brUpload_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var clickedElement = sender as UIElement;

            if (clickedElement != null)
            {
                // OpenFileDialog obyektini yaratish
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

                // Foydalanuvchi faylni tanlashi mumkin bo'lgan fayl formatlari
                openFileDialog.Filter = "Rasm fayllari|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Barcha fayllar|*.*";

                // Faylni tanlash va natijani oluvchi oynani ochish
                bool? result = openFileDialog.ShowDialog();

                // Agar fayl tanlansa va rasm fayli bo'lsa
                if (result == true)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    // Tanlangan rasm faylini olish va kerakli ishlar bilan davom etish
                    // Misol uchun: Tanlangan rasmni bir joyga joylash va uni ko'rsatish
                    ImageSource imageSource = new BitmapImage(new Uri(selectedFilePath));
                    // imageSource ni WPF Image elementiga berish mumkin
                    imgProfile.ImageSource = imageSource;
                    // imageElement.Source = imageSource;
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtFName.IsReadOnly = false;
            txtLName.IsReadOnly = false;
            txtNum.IsReadOnly = false;
            cmbIsFree.IsReadOnly = false;

            btnSave.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Hidden;
            btnChange.Visibility = Visibility.Visible;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            btnChange.Visibility = Visibility.Hidden;

            string path = @"C:\Users\99891\Desktop\Token.txt";
            string token = File.ReadAllText(path);
            IdentityService identityService = jwtParser.ParseToken(token);

            _masterViewModel.FirstName = txtFName.Text;
            _masterViewModel.LastName = txtLName.Text;
            _masterViewModel.PhoneNumber = "+"+txtNum.Text;
            if (cmbIsFree.SelectedIndex == 1)
            {
                _masterViewModel.IsFree = true;
            }
            else
            {
                _masterViewModel.IsFree = false;
            }

            var result = await _masterService.UpdateAsync(identityService.Id, _masterViewModel);
            if (result == true)
            {
                txtFName.IsReadOnly = true;
                txtLName.IsReadOnly = true;
                txtNum.IsReadOnly = true;
                cmbIsFree.IsReadOnly = true;

                btnSave.Visibility = Visibility.Hidden;
                btnCancel.Visibility = Visibility.Hidden;
                btnChange.Visibility = Visibility.Visible;
            }

        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            btnChange.Visibility = Visibility.Hidden;

            txtFName.IsReadOnly = false;
            txtLName.IsReadOnly = false;
            txtNum.IsReadOnly = false;
            cmbIsFree.IsReadOnly = false;
        }
    }
}
