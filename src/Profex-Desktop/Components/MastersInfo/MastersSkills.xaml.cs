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
    /// Interaction logic for MastersSkills.xaml
    /// </summary>
    public partial class MastersSkills : UserControl
    {
        public MastersSkills()
        {
            InitializeComponent();
        }
        public void SetData(string skill)
        {
            lblSkill.Content = skill;
        }
    }
}
