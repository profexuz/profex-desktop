using Profex_Desktop.Windows.AboutVacancy;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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
            loader.Visibility = System.Windows.Visibility.Collapsed;
            lblTitle.Content = values[1];
            lblCost.Content = values[2];
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            AboutVacancyWindow vacancyWindow = new AboutVacancyWindow();
            vacancyWindow.vacancyId = vacancyId;
            vacancyWindow.ShowDialog();
        }
    }
}
