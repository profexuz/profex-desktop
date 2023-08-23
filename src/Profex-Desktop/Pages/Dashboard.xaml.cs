using Profex_Desktop.Components.MasterContact;
using Profex_Desktop.Components.Vacancies;
using Profex_Integrated.Services.Masters;
using Profex_Integrated.Services.Users;
using Profex_Integrated.Services.Vacancies;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    /// 

    public partial class Dashboard : Page
    {
        private long mastersCount = 0;
        private long usersCount = 0;
        private long vacanciesCount = 0;
        private MasterService _masterService = new MasterService();
        private VacancyService _vacancyService = new VacancyService();
        private UserService _userService = new UserService();
        public Dashboard()
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
            AddVacancieElement();
        }
        private async Task<bool> Loading_InfosAsync()
        {
            wrpGroups.Children.Clear();
            wrpVacancies.Children.Clear();
            try
            {
                usersCount = await _userService.CountAsync();
                var result = await _masterService.GetAllAsync();
                mastersCount = result.Count;
                await CountAllUsers();
                short count = 0;

                foreach (var res in result)
                {
                    if (count == 6) break; count++;

                    //Download img from api url
                    string imageUrl = "http://95.130.227.187/" + res.ImagePath;

                    string[] list =
                    {
                        imageUrl,
                        res.FirstName+" "+res.LastName,
                        MakeRandom()

                };
                    MasterContactControl mastercontact = new MasterContactControl();
                    mastercontact.SetData(list);
                    wrpGroups.Children.Add(mastercontact);
                }


                //##################################

                //var vacancy = await _vacancyService.GetAllAsync();
                //short countV = 0;

                //foreach (var vac in vacancy)
                //{
                //    if (countV == 5) break; countV++;

                //    //Download img from api url
                //    System.Drawing.Image image = DownloadImageFromUrl("http://95.130.227.187/" + vac.ImagePath);
                //    string rootPath = @"C:\Users\99891\Desktop\profex-desktop\src\Profex-Desktop\Assets\Images";
                //    string fileName = "";
                //    if (res.ImagePath.Contains("\\"))
                //    {
                //        fileName = System.IO.Path.Combine(rootPath, res.ImagePath.Split("\\")[2]);
                //    }
                //    else
                //    {
                //        fileName = System.IO.Path.Combine(rootPath, res.ImagePath.Split("/")[2]);
                //    }
                //    image.Save(fileName);

                //    string[] list =
                //    {
                //            fileName,
                //            res.FirstName+" "+res.LastName,
                //            MakeRandom()

                //    };
                //    MasterContactControl mastercontact = new MasterContactControl();
                //    mastercontact.SetData(list);
                //    wrpGroups.Children.Add(mastercontact);
                //}

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void AddVacancieElement()
        {
            wrpVacancies.Children.Clear();
            Vacancie vacancie = new Vacancie();
            wrpVacancies.Children.Add(vacancie);
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
                AllUsers.Content = (usersCount + mastersCount).ToString();

            if (vacanciesCount >= 10000)
                VacancyCount.Content = $"{vacanciesCount / 1000}K";
            else
            {
                VacancyCount.Content = vacanciesCount;
            }
            if (mastersCount >= 10000)
                MastersCount.Content = $"{mastersCount / 1000}K";
            else
            {
                MastersCount.Content = mastersCount.ToString();
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
