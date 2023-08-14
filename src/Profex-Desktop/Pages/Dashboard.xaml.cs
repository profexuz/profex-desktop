using Profex_Desktop.Components.MasterContact;
using Profex_Desktop.Components.Vacancies;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpGroups.Children.Clear();
            
               for (int i = 0; i < 5; i++)
               {
                    string[] list =
                    {
                        "C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Profile images\\DefaultProfileImage.png",
                        "Aliyev Vali",
                        MakeRandom()

                    };
                    MasterContactControl mastercontact = new MasterContactControl();
                    //GrouposChipUserControl grouposChipUserControl = new GrouposChipUserControl();
                    mastercontact.SetData(list);
                    wrpGroups.Children.Add(mastercontact);
               }
            string[] list1 =
            {
                "C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Profile images\\DefaultProfileImage.png",
                "Toshmatov Eshmat",
                MakeRandom()

            };
            wrpVacancies.Children.Clear();
            Vacancie vacancie = new Vacancie();
            vacancie.SetData(list1);
            wrpVacancies.Children.Add(vacancie);

        }

        private void br1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            br1.Background = (Brush)bc.ConvertFrom("#495057")!;
            br2.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br3.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br4.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br5.Background = (Brush)bc.ConvertFrom("#adb5bd")!;


            string[] list1 =
            {
                "C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Profile images\\DefaultProfileImage.png",
                "Toshmatov Eshmat",
                MakeRandom()

            };
            wrpVacancies.Children.Clear();
            Vacancie vacancie = new Vacancie();
            vacancie.SetData(list1);
            wrpVacancies.Children.Add(vacancie);
        }

        private void br2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            br1.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br2.Background = (Brush)bc.ConvertFrom("#495057")!;
            br3.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br4.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br5.Background = (Brush)bc.ConvertFrom("#adb5bd")!;

            string[] list1 =
            {
                "C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Profile images\\DefaultProfileImage.png",
                "Tursunaliyev G'iybadulla",
                MakeRandom()

                };
            wrpVacancies.Children.Clear();
            Vacancie vacancie = new Vacancie();
            vacancie.SetData(list1);
            wrpVacancies.Children.Add(vacancie);
        }


        private void br3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            br1.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br2.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br3.Background = (Brush)bc.ConvertFrom("#495057")!;
            br4.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br5.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            string[] list1 =
            {
                "C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Profile images\\DefaultProfileImage.png",
                "G'aniyev Boltavoy",
                MakeRandom()

                };
            wrpVacancies.Children.Clear();
            Vacancie vacancie = new Vacancie();
            vacancie.SetData(list1);
            wrpVacancies.Children.Add(vacancie);
        }

        private void br4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            br1.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br2.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br3.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br4.Background = (Brush)bc.ConvertFrom("#495057")!;
            br5.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            string[] list1 =
            {
                "C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Profile images\\DefaultProfileImage.png",
                "Tiqildiyev Teshavoy",
                MakeRandom()

                };
            wrpVacancies.Children.Clear();
            Vacancie vacancie = new Vacancie();
            vacancie.SetData(list1);
            wrpVacancies.Children.Add(vacancie);
        }

        private void br5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var bc = new BrushConverter();
            br1.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br2.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br3.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br4.Background = (Brush)bc.ConvertFrom("#adb5bd")!;
            br5.Background = (Brush)bc.ConvertFrom("#495057")!;
            string[] list1 =
            {
                "C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Profile images\\DefaultProfileImage.png",
                "Yo'lchiyev Mekke",
                MakeRandom()

                };
            wrpVacancies.Children.Clear();
            Vacancie vacancie = new Vacancie();
            vacancie.SetData(list1);
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
    }
}
