using Profex_Desktop.Components.Vacancies;
using Profex_Integrated.Helpers;
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
    /// Interaction logic for UserVacancies.xaml
    /// </summary>
    public partial class UserVacancies : Page
    {

        private VacancyService _vacancyService = new VacancyService();
        //private string BASE_URL = "http://64.227.42.134:4040/";
        public UserVacancies()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpNewsVacancy.Children.Clear();
            wrpAdvertising.Children.Clear();
            var result = await _vacancyService.GetAllAsync(1);
            string[] values = new string[3];
            byte count = 0;
            foreach (var item in result)
            {
                if (count == 4) break; count++;
                Vacancy vacancy = new Vacancy();
                vacancy.vacancyId = item.Id;
                values[0] = API.BASEIMG_URL + item.ImagePath[0];
                values[1] = item.Title;
                values[2] = item.Price.ToString();
                vacancy.SetData(values);
                wrpNewsVacancy.Children.Add(vacancy);
                loader.Visibility = Visibility.Collapsed;
            }

            count = 0;
            foreach (var item in result)
            {
                if (count == 6)
                {
                    count++;
                    continue;
                }
                Vacancy vacancy = new Vacancy();
                vacancy.vacancyId = item.Id;
                values[0] = API.BASEIMG_URL + item.ImagePath[0];
                values[1] = item.Title;
                values[2] = item.Price.ToString();
                vacancy.SetData(values);
                wrpAdvertising.Children.Add(vacancy);

            }
        }
        public async Task RefreshAsync()
        {
            wrpNewsVacancy.Children.Clear();
            wrpAdvertising.Children.Clear();
            var result = await _vacancyService.GetAllAsync(1);
            string[] values = new string[3];
            byte count = 0;
            foreach (var item in result)
            {
                if (count == 4) break; count++;
                Vacancy vacancy = new Vacancy();
                vacancy.vacancyId = item.Id;
                values[0] = API.BASEIMG_URL + item.ImagePath[0];
                values[1] = item.Title;
                values[2] = item.Price.ToString();
                vacancy.SetData(values);
                wrpNewsVacancy.Children.Add(vacancy);
                loader.Visibility = Visibility.Collapsed;
            }

            count = 0;
            foreach (var item in result)
            {
                if (count == 6)
                {
                    count++;
                    continue;
                }
                Vacancy vacancy = new Vacancy();
                vacancy.vacancyId = item.Id;
                values[0] = API.BASEIMG_URL + item.ImagePath[0];
                values[1] = item.Title;
                values[2] = item.Price.ToString();
                vacancy.SetData(values);
                wrpAdvertising.Children.Add(vacancy);

            }
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            loader.Visibility = Visibility.Visible;
            string searchText = Search.Text; // Qidiruv so'zini olish
            if(searchText.Length>0)
            {
                var searchResults = await _vacancyService.SearchAsync(searchText);

                wrpNewsVacancy.Children.Clear();
                wrpAdvertising.Children.Clear();
                string[] values = new string[3];
                byte count = 0;

                foreach (var item in searchResults)
                {
                    if (count == 6) break;
                    Vacancy vacancy = new Vacancy();
                    vacancy.vacancyId = item.Id;
                    values[0] = API.BASEIMG_URL + item.ImagePath[0];
                    values[1] = item.Title;
                    values[2] = item.Price.ToString();
                    vacancy.SetData(values);
                    wrpNewsVacancy.Children.Add(vacancy);
                    count++;
                }

                count = 0;

                foreach (var item in searchResults)
                {
                    if (count <= 6)
                    {
                        count++;
                        continue;
                    }
                    Vacancy vacancy = new Vacancy();
                    vacancy.vacancyId = item.Id;
                    values[0] = API.BASEIMG_URL + item.ImagePath[0];
                    values[1] = item.Title;
                    values[2] = item.Price.ToString();
                    vacancy.SetData(values);
                    wrpAdvertising.Children.Add(vacancy);
                }
                loader.Visibility = Visibility.Collapsed;
            }
            // Qidiruvni boshlash uchun VacancyService dan foydalanish
            else if(searchText.Length==0)
            {
                wrpNewsVacancy.Children.Clear();
                wrpAdvertising.Children.Clear();
                var result = await _vacancyService.GetAllAsync(1);
                string[] values = new string[3];
                byte count = 0;
                foreach (var item in result)
                {
                    if (count == 4) break; count++;
                    Vacancy vacancy = new Vacancy();
                    vacancy.vacancyId = item.Id;
                    values[0] = API.BASEIMG_URL + item.ImagePath[0];
                    values[1] = item.Title;
                    values[2] = item.Price.ToString();
                    vacancy.SetData(values);
                    wrpNewsVacancy.Children.Add(vacancy);
                    loader.Visibility = Visibility.Collapsed;
                }

                count = 0;
                foreach (var item in result)
                {
                    if (count == 6)
                    {
                        count++;
                        continue;
                    }
                    Vacancy vacancy = new Vacancy();
                    vacancy.vacancyId = item.Id;
                    values[0] = API.BASEIMG_URL + item.ImagePath[0];
                    values[1] = item.Title;
                    values[2] = item.Price.ToString();
                    vacancy.SetData(values);
                    wrpAdvertising.Children.Add(vacancy);

                }
            }
            
        }
    }
}
