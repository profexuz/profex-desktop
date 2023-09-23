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
using System.Windows.Shapes;

namespace Profex_Desktop.Windows.UserPosts
{
    /// <summary>
    /// Interaction logic for UserPostCreateWindow.xaml
    /// </summary>
    public partial class UserPostviewWindow : Window
    {
        private VacancyService vacancyService = new VacancyService();
        public long vacancyId;
        //private string BASE_URL = "htpp://64.227.42.134.4040";
        public UserPostviewWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbImg1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbImg2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbImg3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbImg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
