using Profex_Desktop.Windows.AboutMaster;
using Profex_Integrated.Services.Requests;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Components.MyRequestUser
{
    /// <summary>
    /// Interaction logic for MyRequestUser.xaml
    /// </summary>
    public partial class MyRequestUser : UserControl
    {

        public long vacancyId;
        public long UserId;
        public long MasterId;
        private RequestService rqs = new RequestService();

        public MyRequestUser()
        {
            InitializeComponent();
        }
        public void SetData(string[] values)
        {
            Uri imageUri = new Uri(values[0], UriKind.Absolute);
            VacancieImg.ImageSource = new BitmapImage(imageUri);
            lblTitle.Content = values[1];
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAccepted_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnIgnore_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Send a request to this post?", "Warning!", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var result1 = await rqs.DeleteReq1(MasterId, vacancyId);
                    if (result1 == 1)
                    {
                        MessageBox.Show("Your request has been delete successfully!");
                    }
                    else if (result1 == 0)
                    {
                        MessageBox.Show("You have already delete a request for this post.");
                    }
                    else if (result1 == -1)
                    {
                        MessageBox.Show("An unknown error occurred while deleteing the request.");
                    }
                }
                catch
                {
                    MessageBox.Show("internet is slow!");
                }

            }
            else
            { }
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AboutMasterWindow ms = new AboutMasterWindow();
            ms.ustaId = MasterId;
            ms.ShowDialog();
        }
    }
}
