using Profex_Desktop.Components.Request;
using Profex_Integrated.Helpers;
using Profex_Integrated.Services.Requests;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for MyRequestsPage.xaml
    /// </summary>
    public partial class MyRequestsPage : Page
    {
        private RequestService _requestService = new RequestService();
        public MyRequestsPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpAdvertising.Children.Clear();
            var result = await _requestService.GetAllAsync(1);
            string[] values = new string[5];
            byte count = 0;
            foreach (var item in result)
            {
                if (count == 6) break; count++;
                MyRequestMaster rqm = new MyRequestMaster();
                rqm.vacancyId = item.id;
                rqm.RefreshAsync = RefreshAsync;
                rqm.UserId = item.userId;
                values[0] = API.BASEIMG_URL + item.imagePath[0];
                values[1] = item.title;
                values[2] = item.price.ToString();
                rqm.SetData(values);
                wrpAdvertising.Children.Add(rqm);

            }
            loader.Visibility = Visibility.Collapsed;
        }
        public async void RefreshAsync()
        {
            wrpAdvertising.Children.Clear();
            var result = await _requestService.GetAllAsync(1);
            string[] values = new string[5];
            byte count = 0;
            foreach (var item in result)
            {
                if (count == 6) break; count++;
                MyRequestMaster rqm = new MyRequestMaster();
                rqm.vacancyId = item.id;
                rqm.UserId = item.userId;
                values[0] = API.BASEIMG_URL + item.imagePath[0];
                values[1] = item.title;
                values[2] = item.price.ToString();
                rqm.SetData(values);
                wrpAdvertising.Children.Add(rqm);

            }
            loader.Visibility = Visibility.Collapsed;
        }
    }
}
