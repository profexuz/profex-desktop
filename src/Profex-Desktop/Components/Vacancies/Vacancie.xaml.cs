using Profex_Desktop.Components.MasterContact;
using Profex_Integrated.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Profex_Desktop.Components.Vacancies
{
    /// <summary>
    /// Interaction logic for Vacancie.xaml
    /// </summary>
    public partial class Vacancie : UserControl
    {
        private UserService _userService = new UserService();
        private string BASE_URL = "http://95.130.227.187/";
        private List<string[]> list = new List<string[]>();
        private string[] imagePaths =
            {
            "C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Images\\somebreakedthing1.jpeg",
            "C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Images\\somebreakedthing2.jpeg",
            "C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Images\\somebreakedthing3.jpg",
            "C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Images\\somebreakedthing4.jpg",
            "C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Images\\somebreakedthing5.jpg"};
        private int currentElement = 0;
        private DispatcherTimer timer;
        public Vacancie()
        {
            InitializeComponent();

        }
        public void SetData(string[] lists)
        {
            wrpContac.Children.Clear();
            MasterContactControl master = new MasterContactControl();
            master.SetData(lists);
            wrpContac.Children.Add(master);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            currentElement = (currentElement + 1) % imagePaths.Length;
            AnimateCarousel();
        }
        private async void UpdateImage()
        {
            string imagePath = imagePaths[currentElement];
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            VacancieImg.ImageSource = bitmapImage;



            List<Border> borderList = new List<Border>()
            {
                br1,br2,br3,br4,br5,
            };

            var bc = new BrushConverter();
            borderList[0].Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            borderList[1].Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            borderList[2].Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            borderList[3].Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            borderList[4].Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            borderList[currentElement].Background = (Brush)bc.ConvertFrom("#495057")!;
            wrpContac.Children.Clear();

            MasterContactControl master = new MasterContactControl();
            master.SetData(list[0]);
            wrpContac.Children.Add(master);

        }

        private void AnimateCarousel()
        {
            DoubleAnimation slideAnimation = new DoubleAnimation
            {
                From = 0,
                To = -this.ActualWidth,
                Duration = TimeSpan.FromSeconds(1)
            };

            slideAnimation.Completed += SlideAnimation_Completed!;

            VacancieImg.BeginAnimation(TranslateTransform.XProperty, slideAnimation);
        }
        private void SlideAnimation_Completed(object sender, EventArgs e)
        {
            UpdateImage();
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

        private async void Control_Loaded(object sender, RoutedEventArgs e)
        {
            var alluser = await _userService.GetAllAsync();
            short count = 0;

            foreach (var user in alluser)
            {
                string[] list1 = new string[3];

                if (count == 5) break; count++;
                string imageUrl = BASE_URL + user.ImagePath;

                list1[0] = imageUrl.ToString();
                list1[1] = user.FirstName + " " + user.LastName;
                list1[2] = MakeRandom();
                list.Add(list1);
            }

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5); // Change image every 4 seconds
            timer.Tick += Timer_Tick;
            timer.Start();

            // Display the initial image
            UpdateImage();
        }
    }
}
