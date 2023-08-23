using Profex_Desktop.Pages;
using Profex_Desktop.Windows.AboutVacancy;
using Profex_Desktop.Windows.AuthPages;
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

namespace Profex_Desktop.Components.Vacancies
{
    /// <summary>
    /// Interaction logic for Vacancy.xaml
    /// </summary>
    public partial class Vacancy : UserControl
    {
        public long vacancyId;
        public Vacancy()
        {
            InitializeComponent();
        }
        public void SetData(string[] values)
        {
            Uri imageUri = new Uri(values[0], UriKind.Absolute);
            VacancieImg.ImageSource = new BitmapImage(imageUri);
            lblTitle.Content = values[1];
            lblCost.Content = values[2];
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

           AboutVacancyWindow vacancyWindow = new AboutVacancyWindow();
            vacancyWindow.vacancyId = vacancyId;
            vacancyWindow.Show();
        }
    }
}
