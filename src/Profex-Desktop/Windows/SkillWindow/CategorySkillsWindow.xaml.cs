using Profex_Desktop.Components.SkillAbout;
using Profex_Integrated.Services.Skills;
using Profex_ViewModels.Skills;
using System;
using System.Linq;
using System.Windows;

namespace Profex_Desktop.Windows.SkillWindow
{
    /// <summary>
    /// Interaction logic for CategorySkillsWindow.xaml
    /// </summary>
    public partial class CategorySkillsWindow : Window
    {
        public long skillId;
        public  long categoryId; 
        public long page = 1;
        SkillInformation nm = new SkillInformation();
        private SkillsService _skillsService = new SkillsService();
        public long skillCount;

        public CategorySkillsWindow()
        {
            InitializeComponent();
        }
        public CategorySkillsWindow(long categoryId)
        {
            InitializeComponent();
            this.categoryId = categoryId;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            wrpPanel.Children.Clear(); 

            try
            {
                var result = await _skillsService.GetByCategoryId(categoryId, page);

                skillCount = result.Count();

                foreach (var item in result)
                {
                    SkillContact sklc = new SkillContact();
                    sklc.SkillId = skillId;
                    sklc.categoryId = categoryId;

                    var category = new SkillViewModel
                    {
                        Id = item.Id,
                        CategoryId = item.CategoryId,
                        Title = item.Title,
                    };

                    sklc.SetData(category);

                    wrpPanel.Children.Add(sklc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
