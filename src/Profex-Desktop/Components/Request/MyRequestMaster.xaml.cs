using Profex_Desktop.Windows.AboutVacancy;
using Profex_Integrated.Services.Requests;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Profex_Desktop.Components.Request
{
    /// <summary>
    /// Interaction logic for MyRequestMaster.xaml
    /// </summary>
    public partial class MyRequestMaster : UserControl
    {
        public long vacancyId;
        public long UserId;
        private RequestService _requestService = new RequestService();
        public MyRequestMaster()
        {
            InitializeComponent();
        }
        public void SetData(string[] values)
        {
            Uri imageUri = new Uri(values[0], UriKind.Absolute);
            VacancieImg.ImageSource = new BitmapImage(imageUri);
            lblTitle.Content = values[1];
            lblCost.Content = values[2];
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /*AboutVacancyWindow vacancyWindow = new AboutVacancyWindow();
            vacancyWindow.vacancyId = vacancyId;
            vacancyWindow.UserId = UserId;
            vacancyWindow.ShowDialog();*/
        }

        private async void BorderDelete_Requests(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Send a request to this post?", "Warning!", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var result1 = await _requestService.DeleteReq(vacancyId, UserId);
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
    }
}
