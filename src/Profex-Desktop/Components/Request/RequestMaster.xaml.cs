using Profex_Desktop.Windows.AboutVacancy;
using Profex_Integrated.Services.Requests;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Components.Request
{
    /// <summary>
    /// Interaction logic for RequestMaster.xaml
    /// </summary>
    public partial class RequestMaster : UserControl
    {
        public long vacancyId;
        public long UserId;
        private RequestService _requestService = new RequestService();
        public RequestMaster()
        {
            InitializeComponent();
        }
        public void SetData(string[] values)
        {
            Uri imageUri = new Uri(values[0], UriKind.Absolute);
            VacancieImg.ImageSource = new BitmapImage(imageUri);
            lblTitle.Content = values[1];
            lblCost.Content = values[2];
            loader.Visibility = Visibility.Collapsed;
        }

        private async void BtnRequst_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Send a request to this post?", "Warning!", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var result1 = await _requestService.AddRequest(vacancyId, UserId);
                    if (result1 == 1)
                    {
                        MessageBox.Show("Your request has been sent successfully!");
                    }
                    else if (result1 == 0)
                    {
                        MessageBox.Show("You have already sent a request for this post.");
                    }
                    else if (result1 == -1)
                    {
                        MessageBox.Show("An unknown error occurred while sending the request.");
                    }
                }
                catch
                {
                    MessageBox.Show("internet is slow!");
                }

            }
            else
            {}
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AboutVacancyWindow vacancyWindow = new AboutVacancyWindow();
            vacancyWindow.vacancyId = vacancyId;
            vacancyWindow.UserId = UserId;
            vacancyWindow.ShowDialog();
        }
    }
}
