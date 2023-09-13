using Profex_Desktop.Components.SkillAbout;
using Profex_Integrated.Services.Skills;
using System;
using System.Linq;
using System.Windows;

namespace Profex_Desktop.Windows.AboutSKill
{
    /// <summary>
    /// Interaction logic for AboutSKillWindow.xaml
    /// </summary>
    public partial class AboutSKillWindow : Window
    {
        public long skillId;
        private string BASE_URL = "http://64.227.42.134:4040/";
        //private MasterService _masterService = new MasterService();
        private SkillsService _skillsService = new SkillsService();
        private long categoryCount = 0;
        public AboutSKillWindow()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpSkills.Children.Clear();
            try
            {
                var result = await _skillsService.GetAllAysnc(1);
                categoryCount = result.Count();
                foreach (var item in result)
                {
                    SkillInformation ms = new SkillInformation();
                    ms.skillId = item.Id;
                    string[] list =
                    {
                        item.Name,
                    };
                    ms.SetData(item);
                    //ms.SetData(list);
                    wrpSkills.Children.Add(ms);
                }
            }
            catch(Exception ex)
            {
                //return false;
                MessageBox.Show(ex.Message);
            }

        }
        
        

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
