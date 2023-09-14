using Profex_Integrated.Services.Masters;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Windows.AboutMaster
{
    /// <summary>
    /// Interaction logic for AboutMasterWindow.xaml
    /// </summary>
    public partial class AboutMasterWindow : Window
    {
        private MasterService _masterService = new MasterService();
        public long ustaId;
        private string BASE_URL = "http://64.227.42.134:4040/";
        public AboutMasterWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await _masterService.GetByIdAsync(ustaId);
                string imageUrl = BASE_URL + result.ImagePath;
                Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
                MasterRasmi.ImageSource = new BitmapImage(imageUri);

                lblTitle.Content = "ABOUT FOR MASTERS";
                lblFirstNameAnswer.Content = result.FirstName;
                lblLastNameAnswer.Content = result.LastName;
                lblPhoneNumerAns.Content = result.PhoneNumber;
                lblIsFree.Content = result.IsFree ? "bo'sh" : "band";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internet bilan muammo yuzaga keldi.");
            }
        }
    }
}
