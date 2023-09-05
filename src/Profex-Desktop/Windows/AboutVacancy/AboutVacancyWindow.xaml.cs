using Profex_Integrated.Services.Vacancies;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Windows.AboutVacancy
{
    /// <summary>
    /// Interaction logic for AboutVacancyWindow.xaml
    /// </summary>
    public partial class AboutVacancyWindow : Window
    {
        private VacancyService _vacancyService = new VacancyService();
        public long vacancyId;
        private string BASE_URL = "http://95.130.227.187/";
        public AboutVacancyWindow()
        {
            InitializeComponent();
        }

        private void rbImg_Click(object sender, RoutedEventArgs e)
        {
            ImageSource imageSource = new BitmapImage(new Uri(rbImg.Content.ToString()!));
            imgMain.ImageSource = imageSource;
        }

        private void rbImg1_Click(object sender, RoutedEventArgs e)
        {
            ImageSource imageSource = new BitmapImage(new Uri(rbImg1.Content.ToString()!));
            imgMain.ImageSource = imageSource;

        }

        private void rbImg2_Click(object sender, RoutedEventArgs e)
        {
            ImageSource imageSource = new BitmapImage(new Uri(rbImg2.Content.ToString()!));
            imgMain.ImageSource = imageSource;
        }

        private void rbImg3_Click(object sender, RoutedEventArgs e)
        {
            ImageSource imageSource = new BitmapImage(new Uri(rbImg3.Content.ToString()!));
            imgMain.ImageSource = imageSource;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await _vacancyService.GetByIdAsync(vacancyId);
                foreach (var item in result)
                {
                    if (result != null)
                    {
                        if (item.ImagePath.Count > 0)
                        {
                            Uri imageUri = new Uri(BASE_URL + item.ImagePath[0], UriKind.Absolute);
                            imgMain.ImageSource = new BitmapImage(imageUri);
                            rbImg.Visibility = Visibility.Visible;
                            rbImg.Content = new BitmapImage(imageUri);
                            if (item.ImagePath.Count > 1)
                            {
                                rbImg1.Visibility = Visibility.Visible;
                                Uri imageUri1 = new Uri(BASE_URL + item.ImagePath[1], UriKind.Absolute);
                                rbImg1.Content = new BitmapImage(imageUri1);
                                if (item.ImagePath.Count > 2)
                                {
                                    rbImg2.Visibility = Visibility.Visible;
                                    Uri imageUri2 = new Uri(BASE_URL + item.ImagePath[2], UriKind.Absolute);
                                    rbImg2.Content = new BitmapImage(imageUri2);
                                    if (item.ImagePath.Count > 3)
                                    {
                                        rbImg3.Visibility = Visibility.Visible;
                                        Uri imageUri3 = new Uri(BASE_URL + item.ImagePath[3], UriKind.Absolute);
                                        rbImg3.Content = new BitmapImage(imageUri3);
                                    }
                                }
                            }
                        }


                        lblTitle.Content = item.Title;
                        lblRegionAnswer.Content = item.Region;
                        lblDistrictAnswer.Content = item.District;
                        lblUserName.Content = item.FirstName + " " + item.LastName;
                        lblPhoneNum.Content = item.PhoneNumber;
                        txtDesc.Text = item.Description;
                        lblCost.Content = item.Price.ToString() + " SO'M";
                    }
                }
            }
            catch
            {
                MessageBox.Show("Internet bilan muammo yuzaga keldi.");
            }



        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
