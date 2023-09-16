using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Components.MastersInfo
{
    /// <summary>
    /// Interaction logic for MasterInfo.xaml
    /// </summary>
    public partial class MasterInfo : UserControl
    {
        private string BASE_URL = "http://64.227.42.134:4040/";
        public MasterInfo()
        {
            InitializeComponent();
        }
        public void SetData(string[] masterskills)
        {
            string imageUrl = masterskills[0];
            if (Uri.TryCreate(imageUrl, UriKind.Absolute, out Uri imageUri))
            {
                imgProfile.ImageSource = new BitmapImage(imageUri);
            }
            else
            {
            }

            lblname.Content = masterskills[1];
            phone.Content = masterskills[2];
            wrpSkills.Children.Clear();


            for (int i = 3; i < 5; i++)
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
