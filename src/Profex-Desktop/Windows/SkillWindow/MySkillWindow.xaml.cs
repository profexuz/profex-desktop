using Profex_Desktop.Components.SkillAbout;
using Profex_Integrated.Services.Skills;
using Profex_ViewModels.Skills;
using System;
using System.Windows;

namespace Profex_Desktop.Windows.SkillWindow
{
    /// <summary>
    /// Interaction logic for MySkillWindow.xaml
    /// </summary>
    public partial class MySkillWindow : Window
    {
        public long masterId;
        MySkills msk = new MySkills();
        private SkillsService _skillsService = new SkillsService();
        public long MySkillCount;
        public MySkillWindow()
        {
            InitializeComponent();
        }

        public MySkillWindow(long MasterId)
        {
            InitializeComponent();
            this.masterId = MasterId;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            wrpPanel.Children.Clear();
            try
            {
                var result = await _skillsService.GetAllMySkills(masterId);

                foreach (var item in result.MasterSkills)
                {
                    MySkills msk = new MySkills();

                    var myskill = new SkillViewModel
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Description = item.Description,
                        CategoryId = item.CategoryId,
                    };

                    msk.SetData(myskill);

                    wrpPanel.Children.Add(msk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
            
}
