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
using System.Windows.Media.Animation;
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
        private string somebodyName { get; set; }
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
                mastercontact.SetData(list);
                wrpGroups.Children.Add(mastercontact);
            }

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
    }
}
