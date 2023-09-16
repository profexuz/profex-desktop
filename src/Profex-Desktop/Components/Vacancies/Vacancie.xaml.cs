using Profex_Desktop.Components.MasterContact;
using Profex_Integrated.Services.Users;
using Profex_Integrated.Services.Vacancies;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Profex_Desktop.Components.Vacancies
{
    public partial class Vacancie : UserControl
    {
        private UserService _userService = new UserService();
        private VacancyService _vacancyService = new VacancyService();
        private string BASE_URL = "http://64.227.42.134:4040/";


        private List<string[]> list = new List<string[]>();
        private string[] imagePaths = new string[5];
        private string[] description = new string[5];

        private int currentElement = 0;
        private DispatcherTimer timer;

        public Vacancie()
        {
            InitializeComponent();
            Loaded += Control_Loaded;
        }

        private async void Control_Loaded(object sender, RoutedEventArgs e)
        {
            var allVacancies = await _vacancyService.GetAllAsync(1);
            short count1 = 0, index = 0;
            foreach (var item in allVacancies)
            {
                if (count1 == 5) break;
                if (item.ImagePath.Count > 0)
                {
                    imagePaths[index] = BASE_URL + item.ImagePath[0];
                    description[index] = item.Description;
                    var getByIdUser = await _userService.GetByIdAsync(item.UserId);
                    string[] list1 = new string[3];

                    string imageUrl = BASE_URL + getByIdUser.ImagePath;
                    list1[0] = imageUrl;
                    list1[1] = getByIdUser.FirstName + " " + getByIdUser.LastName;
                    list1[2] = MakeRandom();
                    list.Add(list1);
                    count1++;
                    index++;
                }
            }

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += Timer_Tick;
            timer.Start();

            // Display the initial image
            UpdateImage();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentElement = (currentElement + 1) % imagePaths.Length;
            AnimateCarousel();
        }

        private void UpdateImage()
        {
            string imagePath = imagePaths[currentElement];
            if (imagePath == null)
            {
                imagePath = BASE_URL + "media\\images\\IMG_91678077-3baf-47ff-81a7-4359f3825c39.png";
            }
            Uri imageUri = new Uri(imagePath, UriKind.Absolute);
            VacancieImg.ImageSource = new BitmapImage(imageUri);
            txtDescription.Text = description[currentElement];

            List<Border> borderList = new List<Border>()
            {
                br1, br2, br3, br4, br5
            };

            var bc = new BrushConverter();
            foreach (var border in borderList)
            {
                border.Background = (Brush)bc.ConvertFrom("#adb5bd");
            }
            borderList[currentElement].Background = (Brush)bc.ConvertFrom("#495057");
            wrpContac.Children.Clear();

            if (list.Count > 0)
            {
                MasterContactControl master = new MasterContactControl();
                master.SetData(list[0]);
                wrpContac.Children.Add(master);
            }
        }

        private void AnimateCarousel()
        {
            DoubleAnimation slideAnimation = new DoubleAnimation
            {
                From = 0,
                To = -ActualWidth,
                Duration = TimeSpan.FromSeconds(1)
            };

            slideAnimation.Completed += SlideAnimation_Completed;

            VacancieImg.BeginAnimation(TranslateTransform.XProperty, slideAnimation);
        }

        private void SlideAnimation_Completed(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private static string MakeRandom()
        {
            Random random = new Random();
            int n = 0;
            /*string[] colors1 =
            {
                "#2e933c", "#90f1ef", "#e4ff1a", "#f2545b", "#6e2594", "#4059ad", "#ff8552", "#ef3054", "#ee6c4d",
                "#83af9d","#b7bb80", "#eac763", "#e49f61", "#df765f","#d94e5d"
            };*/
            string[] colors1 =
            {
                "#2e933c"
                
            };
            string selected = colors1[n];
            return selected;
        }

        private void br1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentElement = 0;
            UpdateImage();
        }

        private void br2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentElement = 1;
            UpdateImage();
        }

        private void br3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentElement = 2;
            UpdateImage();
        }

        private void br4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentElement = 3;
            UpdateImage();
        }

        private void br5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentElement = 4;
            UpdateImage();
        }

        private void btnPre_Clicked(object sender, RoutedEventArgs e)
        {
            if (currentElement == 0) currentElement = 4;
            else currentElement--;
            UpdateImage();
        }

        private void btnNext_Clicked(object sender, RoutedEventArgs e)
        {
            if (currentElement == 4) currentElement = 0;
            else currentElement++;
            UpdateImage();
        }
    }
}
