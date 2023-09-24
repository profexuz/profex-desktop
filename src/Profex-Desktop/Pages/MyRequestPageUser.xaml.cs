using Profex_Desktop.Components.MyRequestUser;
using Profex_Integrated.Helpers;
using Profex_Integrated.Services.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for MyRequestPageUser.xaml
    /// </summary>
    public partial class MyRequestPageUser : Page
    {
        private RequestService _requestService = new RequestService();
        private List<long> masterIds = new List<long>(1);
        public long demoInt;
        public MyRequestPageUser()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpAdvertising.Children.Clear();
            var result = await _requestService.GetAllAsync1(1);
            string[] values = new string[5];
            byte count = 0;
            
            foreach (var item in result)
            {
                if (count == 6) break; count++;
                
                MyRequestUser rqm = new MyRequestUser();
                rqm.vacancyId = item.id;
                foreach (var xxx in item.request)
                {
                    rqm.MasterId = xxx.masterId;
                    demoInt = xxx.masterId;
                    masterIds.Add(demoInt);
                }
                rqm.MasterId = masterIds[0];
                masterIds.Clear();
                rqm.UserId = item.userId;
                values[0] = API.BASE_URL + item.imagePath[0];
                values[1] = item.title;
                values[2] = item.price.ToString();
                rqm.SetData(values);
                wrpAdvertising.Children.Add(rqm);

            }
            loader.Visibility = Visibility.Collapsed;
        }
        public async Task RefreshAsync()
        {
            wrpAdvertising.Children.Clear();
            var result = await _requestService.GetAllAsync1(1);
            string[] values = new string[5];
            byte count = 0;

            foreach (var item in result)
            {
                if (count == 6) break; count++;

                MyRequestUser rqm = new MyRequestUser();
                rqm.vacancyId = item.id;
                foreach (var xxx in item.request)
                {
                    rqm.MasterId = xxx.masterId;
                    demoInt = xxx.masterId;
                    masterIds.Add(demoInt);
                }
                rqm.MasterId = masterIds[0];
                masterIds.Clear();
                rqm.UserId = item.userId;
                values[0] = API.BASE_URL + item.imagePath[0];
                values[1] = item.title;
                values[2] = item.price.ToString();
                rqm.SetData(values);
                wrpAdvertising.Children.Add(rqm);

            }
            loader.Visibility = Visibility.Collapsed;
        }
    }
}
