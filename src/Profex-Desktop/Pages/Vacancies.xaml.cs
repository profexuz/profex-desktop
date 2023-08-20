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
    /// Interaction logic for Vacancies.xaml
    /// </summary>
    public partial class Vacancies : Page
    {
        private string[] values = { "5 KUN", "salomdunyo", "50000 so'm" };
        
        public Vacancies()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpNewsVacancy.Children.Clear();
            wrpAdvertising.Children.Clear();
            for (int i = 0; i < 6; i++)
            {
                Vacancy vacancy = new Vacancy();
                vacancy.SetData(values);
                wrpNewsVacancy.Children.Add(vacancy);
            }
            for (int i = 0; i < 30; i++)
            {
                Vacancy vacancy = new Vacancy();
                vacancy.SetData(values);
                wrpAdvertising.Children.Add(vacancy);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(Search.Text.Length > 0)
            {
                wrpNewsVacancy.Children.Clear();
                NewAdded.Visibility = Visibility.Hidden;
                wrpNewsVacancy.Visibility = Visibility.Hidden;
                wrpAdvertising.Children.Clear();

                for (int i = 0; i < 30; i++)
                {
                    Vacancy vacancy = new Vacancy();
                    values[1] = Search.Text;
                    vacancy.SetData(values);
                    wrpAdvertising.Children.Add(vacancy);
                }
            }
        }
    }
}
