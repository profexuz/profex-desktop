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

namespace Profex_Desktop.Components.MastersInfo
{
    /// <summary>
    /// Interaction logic for MasterInfo.xaml
    /// </summary>
    public partial class MasterInfo : UserControl
    {
        public MasterInfo()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string[] skill = { "nimadur", "qachondur", "qattadur", "kimbilandur", "nimadur", "qachondur", "qattadur", "kimbilandur" };
            wrpSkills.Children.Clear();
            for (int i = 0; i < 8; i++)
            {
                MastersSkills mastersSkills = new MastersSkills();
                mastersSkills.SetData(skill[i]);
                wrpSkills.Children.Add(mastersSkills);
            }
        }
    }
}
