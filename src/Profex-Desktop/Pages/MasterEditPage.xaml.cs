using Profex_Dtos.Masters;
using Profex_Integrated.Security;
using Profex_Integrated.Services.Auth.JwtToken;
using Profex_Integrated.Services.Masters;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for MasterEditPage.xaml
    /// </summary>
    public partial class MasterEditPage : Page
    {

        private string _path = "C:\\Users\\Public\\Token.txt";
        private MasterService _masterService = new MasterService();
        private JwtParser jwtParser = new JwtParser();
        private MasterUpdateDto _masterViewModel = new MasterUpdateDto();
        private string selectedFilePath = "";
        //private string BASEIMG_URL = "http://localhost:5230/";
        private string BASEIMG_URL = "http://64.227.42.134:4040/";


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
                openFileDialog.Filter = "Rasm fayllari|*.jpg;*.jpeg;*.png;|Barcha fayllar|*.*";

                // Faylni tanlash va natijani oluvchi oynani ochish
                bool? result = openFileDialog.ShowDialog();

                // Agar fayl tanlansa va rasm fayli bo'lsa
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


            string token = File.ReadAllText(_path);
            IdentityService identityService = jwtParser.ParseToken(token);

            _masterViewModel.FirstName = txtFName.Text;
            _masterViewModel.LastName = txtLName.Text;
            _masterViewModel.PhoneNumber = "+" + txtNum.Text;
            if (selectedFilePath != "")
            {
                //_masterViewModel.ImagePath = selectedFilePath.ToString();
                //_masterViewModel.ImagePath = selectedFilePath.ToString();
                _masterViewModel.ImagePath = selectedFilePath;
                btnSave.IsEnabled = true;
            }

            else
            {
                var res = await _masterService.GetByIdAsync(IdentitySingelton.GetInstance().Id);
                _masterViewModel.ImagePath = res.ImagePath;
                btnSave.IsEnabled = true;
            }
            if (cmbIsFree.SelectedIndex == 0)
            {
                _masterViewModel.IsFree = false;
            }
            else
            {
                _masterViewModel.IsFree = true;
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
                MainWindow main = new MainWindow();
                main.Show();
            }
            else
            {
                MessageBox.Show("Internet bilan muammo yuzaga keldi!");
            }

        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            btnChange.Visibility = Visibility.Hidden;
            brUpload.IsEnabled = true;
            /*txtFName.Text = "";
            txtLName.Text = "";
            txtNum.Text = "";
*/
            txtFName.IsReadOnly = false;
            txtLName.IsReadOnly = false;
            txtNum.IsReadOnly = false;
            cmbIsFree.IsReadOnly = false;
        }

        private async void Page_loaded(object sender, RoutedEventArgs e)
        {
            string token = File.ReadAllText(_path);
            IdentityService identityService = jwtParser.ParseToken(token);
            var result = await _masterService.GetByIdAsync(identityService.Id);
            txtFName.Text = result.FirstName.ToUpper();
            txtLName.Text = result.LastName.ToUpper();
            txtNum.Text = result.PhoneNumber.ToUpper().Substring(1);
            if (result.IsFree == true)
                cmbIsFree.SelectedIndex = 0;
            else
                cmbIsFree.SelectedIndex = 1;
            string imageUrl = BASEIMG_URL + result.ImagePath;
            Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
            imgProfile.ImageSource = new BitmapImage(imageUri);
        }
    }
}
