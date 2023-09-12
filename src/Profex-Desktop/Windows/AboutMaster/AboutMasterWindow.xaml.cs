using Profex_Integrated.Services.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
                //Uri image = new Uri(BASE_URL+ result.ImagePath);

                //ImageSource imageSource = new BitmapImage(new Uri(selectedFilePath));
                // imageSource ni WPF Image elementiga berish mumkin
                //imgProfile.ImageSource = imageSource;
                //ImageSource imageSource = new ImageSource(image);

                string imageUrl = BASE_URL + result.ImagePath;
                Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
                //MasterRasmi.Background = new BitmapImage(imageUri);
                MasterRasmi.ImageSource = new BitmapImage(imageUri);

                lblTitle.Content = "ABOUT FOR MASTERS";
                lblFirstNameAnswer.Content = result.FirstName;
                lblLastNameAnswer.Content = result.LastName;
                lblPhoneNumerAns.Content = result.PhoneNumber;
                //lblIsFree.Content=result.IsFree;
                //maste[3] = master.IsFree ? "bo'sh" : "band";
                lblIsFree.Content = result.IsFree ? "bo'sh" : "band";
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Internet bilan muammo yuzaga keldi.");
            }
        }
    }
}
