using Profex_Desktop.Components.MasterContact;
using Profex_Desktop.Components.Vacancies;
using Profex_Integrated.Helpers;
using Profex_Integrated.Services.Masters;
using Profex_Integrated.Services.Users;
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
    /// Interaction logic for UserDashboard.xaml
    /// </summary>
    public partial class UserDashboard : Page
    {
        private long mastersCount = 0;
        private long usersCount = 0;
        private long vacanciesCount = 0;
        //private string BASE_URL = "http://64.227.42.134:4040/";
        private MasterService _masterService = new MasterService();
        private VacancyService _vacancyService = new VacancyService();
        private UserService _userService = new UserService();
        public UserDashboard()
        {
            InitializeComponent();
        }

        async System.Threading.Tasks.Task MyTask()
        {
            Task.Factory.StartNew(async () =>
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    Loading_InfosAsync();
                });
            });
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await MyTask();

        }
        private async Task<bool> Loading_InfosAsync()
        {
            wrpGroups.Children.Clear();
            wrpVacancies.Children.Clear();
            try
            {
                var usCount = await _userService.CountAsync();
                var result = await _masterService.GetAllAsync();
                var vacancy = await _vacancyService.GetAllAsync(1);
                vacanciesCount = vacancy.Count;
                mastersCount = result.Count;
                usersCount = usCount;
                await CountAllUsers();
                short count = 0;
                loader.Visibility = Visibility.Collapsed;
                loader2.Visibility = Visibility.Collapsed;
                loader3.Visibility = Visibility.Collapsed;
                loader4.Visibility = Visibility.Collapsed;
                loader5.Visibility = Visibility.Collapsed;

                foreach (var res in result)
                {
                    if (count == 6) break; count++;
                    string imageUrl = API.BASEIMG_URL + res.ImagePath;
                    MasterContactControl ms = new MasterContactControl();
                    ms.ustaId = res.Id;
                    string[] list =
                    {

                        imageUrl,
                        res.FirstName+" "+res.LastName,
                        MakeRandom()

                };
                    ms.SetData(list);
                    wrpGroups.Children.Add(ms);
                }


                //##################################

                wrpVacancies.Children.Clear();
                Vacancie vacancie = new Vacancie();
                wrpVacancies.Children.Add(vacancie);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void AddVacancieElement()
        {

        }

        private static string MakeRandom()
        {
            Random random = new Random();
            int n = random.Next(0, 15);
            string[] colors1 =
                {
                    "#2e933c", "#90f1ef", "#e4ff1a", "#f2545b", "#6e2594", "#4059ad", "#ff8552", "#ef3054", "#ee6c4d",
                    "#83af9d","#b7bb80", "#eac763", "#e49f61", "#df765f","#d94e5d"
                };
            string selected = colors1[n];
            return selected;
        }


        //####################################################################################
        public async Task CountAllUsers()
        {
            if (usersCount + mastersCount >= 10000)
                AllUsers.Content = $"{(usersCount + mastersCount) / 1000}K";
            else
                AllUsers.Content = (usersCount + mastersCount).ToString() + " ta";

            if (vacanciesCount >= 10000)
                VacancyCount.Content = $"{vacanciesCount / 1000}K";
            else
            {
                VacancyCount.Content = vacanciesCount + " ta";
            }
            if (mastersCount >= 10000)
                MastersCount.Content = $"{mastersCount / 1000}K";
            else
            {
                MastersCount.Content = mastersCount.ToString() + " ta";
            }
        }



        //####################################################################################
        public System.Drawing.Image DownloadImageFromUrl(string imageUrl)
        {
            System.Drawing.Image image = null;

            try
            {
                System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                System.Net.WebResponse webResponse = webRequest.GetResponse();

                System.IO.Stream stream = webResponse.GetResponseStream();

                image = System.Drawing.Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }




    }
}
