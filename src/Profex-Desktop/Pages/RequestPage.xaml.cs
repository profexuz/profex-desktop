using Profex_Desktop.Components.Request;
using Profex_Desktop.Components.Vacancies;
using Profex_Integrated.Services.Vacancies;
using System.Windows.Controls;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        private VacancyService _vacancyService = new VacancyService();
        private string BASE_URL = "http://64.227.42.134:4040/";
        public RequestPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //wrpNewsVacancy.Children.Clear();
            wrpAdvertising.Children.Clear();
            var result = await _vacancyService.GetAllAsync(1);
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
                RequestMaster rqm  = new RequestMaster();
                rqm.vacancyId = item.Id;
                rqm.UserId = item.UserId;
                values[0] = BASE_URL + item.ImagePath[0];
                values[1] = item.Title;
                values[2] = item.Price.ToString();
                rqm.SetData(values);
                wrpAdvertising.Children.Add(rqm);
                    
            }
        }
    }
}
