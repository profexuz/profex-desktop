using Profex_Desktop.Components.Request;
using Profex_Integrated.Services.Requests;
using Profex_Integrated.Services.Vacancies;
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

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for MyRequestsPage.xaml
    /// </summary>
    public partial class MyRequestsPage : Page
    {
        private RequestService _requestService = new RequestService();
        private string BASE_URL = "http://64.227.42.134:4040/";
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
            /*foreach (var item in result)
            {
                if (count == 6) break; count++;
                Vacancy vacancy = new Vacancy();
                vacancy.vacancyId = item.Id;
                values[0] = BASE_URL + item.ImagePath[0];
                values[1] = item.Title;
                values[2] = item.Price.ToString();
                vacancy.SetData(values);
                wrpNewsVacancy.Children.Add(vacancy);
            }*/
            //count = 0;
            foreach (var item in result)
            {
                if (count == 6) break; count++;
                

                /*Vacancy vacancy = new Vacancy();
                vacancy.vacancyId = item.Id;
                values[0] = BASE_URL + item.ImagePath[0];
                values[1] = item.Title;
                values[2] = item.Price.ToString();
                vacancy.SetData(values);
                wrpAdvertising.Children.Add(vacancy);*/
                //RequestMaster rqm = new RequestMaster();
                MyRequestMaster rqm = new MyRequestMaster();
                rqm.vacancyId = item.id;
                rqm.UserId = item.userId;
                values[0] = BASE_URL + item.imagePath[0];
                values[1] = item.title;
                values[2] = item.price.ToString();
                rqm.SetData(values);
                wrpAdvertising.Children.Add(rqm);

            }
        }
    }
}
