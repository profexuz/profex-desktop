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
        private string BASE_URL = "http://64.227.42.134:4040/";
        public long ustaId;
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
                Uri image = new Uri(BASE_URL+ result.ImagePath);
                //Uri imageUri = new Uri(BASE_URL + item.MasterRasmi[0]);
                //lblTitle.Content = item.Title;
                lblTitle.Content = "ABOUT FOR MASTERS";
                lblFirstNameAnswer.Content = result.FirstName;
                //lblFirstNameAnswer.Content = item.FirstName;
                ////lblDistrictAnswer.Content = item.District;
                //lblLastNameAnswer.Content = item.LastName;
                lblLastNameAnswer.Content = result.LastName;
                //lblPhoneNumerAns.Content = item.PhoneNumerAns;
                lblPhoneNumerAns.Content = result.PhoneNumber;
                //lblIsFree.Content = item.IsFree;
                lblIsFree.Content=result.IsFree;


                //foreach (var item in result)
                //{
                //    if (result != null)
                //    {
                //        //if (item.ImagePath.Count > 0)
                //        //{
                //        //    Uri imageUri = new Uri(BASE_URL + item.ImagePath[0], UriKind.Absolute);
                //        //    imgMain.ImageSource = new BitmapImage(imageUri);
                //        //Uri imageUri = new Uri(BASE_URL + item.MasterRasmi[0], UriKind.Absolute);
                //        //var bitmapImage = new BitmapImage(imageUri);
                //        //imgMain.ImageSource = bitmapImage;
                //        Uri imageUri = new Uri(BASE_URL + item.MasterRasmi[0]);
                //        //    //rbImg.Visibility = Visibility.Visible;
                //        //    //rbImg.Content = new BitmapImage(imageUri);
                //        //    //if (item.ImagePath.Count > 1)
                //        //    //{
                //        //    //    //rbImg1.Visibility = Visibility.Visible;
                //        //    //    //Uri imageUri1 = new Uri(BASE_URL + item.ImagePath[1], UriKind.Absolute);
                //        //    //    //Uri imageUri1 = new Uri(BASE_URL + item.ImagePath[1], UriKind.Absolute);
                //        //    //    rbImg1.Content = new BitmapImage(imageUri1);
                //        //    //    if (item.ImagePath.Count > 2)
                //        //    //    {
                //        //    //        rbImg2.Visibility = Visibility.Visible;
                //        //    //        //Uri imageUri2 = new Uri(BASE_URL + item.ImagePath[2], UriKind.Absolute);
                //        //    //        Uri imageUri2 = new Uri(BASE_URL + item.ImagePath[2], UriKind.Absolute);
                //        //    //        rbImg2.Content = new BitmapImage(imageUri2);
                //        //    //        if (item.ImagePath.Count > 3)
                //        //    //        {
                //        //    //            rbImg3.Visibility = Visibility.Visible;
                //        //    //            //Uri imageUri3 = new Uri(BASE_URL + item.ImagePath[3], UriKind.Absolute);
                //        //    //            Uri imageUri3 = new Uri(BASE_URL + item.ImagePath[3], UriKind.Absolute);
                //        //    //            rbImg3.Content = new BitmapImage(imageUri3);
                //        //    //        }
                //        //    //    }
                //        //    //}
                //        //}

                //        lblTitle.Content = item.Title;
                //        //lblRegionAnswer.Content = item.Region;
                //        lblFirstNameAnswer.Content=item.FirstName;
                //        //lblDistrictAnswer.Content = item.District;
                //        lblLastNameAnswer.Content = item.LastName;
                //        lblPhoneNumerAns.Content = item.PhoneNumerAns;
                //        lblIsFree.Content = item.IsFree;
                        
                //        //lblUserName.Content = item.FirstName + " " + item.LastName;
                //        //lblPhoneNum.Content = item.PhoneNumber;
                        
                        
                //        //txtDesc.Text = item.Description;
                //        //lblCost.Content = item.Price.ToString() + " SO'M";
                //    }
                //}
            }
            catch
            {
                MessageBox.Show("Internet bilan muammo yuzaga keldi.");
            }
        }
    }
}
