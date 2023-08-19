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
        public Vacancy()
        {
            InitializeComponent();
        }
        public void SetData(string[] values)
        {
            lblDay.Content = values[0];
            lblTitle.Content = values[1];
            lblCost.Content = values[2];
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
