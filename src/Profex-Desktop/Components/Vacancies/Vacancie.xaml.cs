using Profex_Desktop.Components.MasterContact;
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
    /// Interaction logic for Vacancie.xaml
    /// </summary>
    public partial class Vacancie : UserControl
    {
        public Vacancie()
        {
            InitializeComponent();
        }
        public void SetData(string[] list)
        {
            wrpContac.Children.Clear();

            MasterContactControl master = new MasterContactControl();
            master.SetData(list);
            wrpContac.Children.Add(master);
        }
    }
}
