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

namespace Profex_Desktop.Components.MastersInfo
{
    /// <summary>
    /// Interaction logic for MasterInfo.xaml
    /// </summary>
    public partial class MasterInfo : UserControl
    {
        private string BASE_URL = "http://95.130.227.187:8080/";
        public MasterInfo()
        {
            InitializeComponent();
        }
        public void SetData(string[] masterskills)
        {
            string imageUrl = BASE_URL + masterskills[0];
            Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
            imgProfile.ImageSource = new BitmapImage(imageUri);
            lblname.Content= masterskills[1];
            phone.Content= masterskills[2];
            wrpSkills.Children.Clear();
            for(int i=3; i<5; i++)
            {
                MastersSkills mastersSkills = new MastersSkills();
                mastersSkills.lblSkill.Content = masterskills[i];
                wrpSkills.Children.Add(mastersSkills);
            }
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
