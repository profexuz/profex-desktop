using System.Windows.Controls;

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
