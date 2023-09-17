using Profex_Integrated.Services.Skills;
using Profex_ViewModels.Skills;
using System.Windows;
using System.Windows.Controls;

namespace Profex_Desktop.Components.SkillAbout
{
    /// <summary>
    /// Interaction logic for SkillContact.xaml
    /// </summary>
    public partial class SkillContact : UserControl
    {
        public long SkillId;
        public long categoryId;
        private SkillsService _skillsService = new SkillsService();
        public SkillContact()
        {
            InitializeComponent();
        }
        public void SetData(SkillViewModel skill)
        {
            if (skill != null)
            {
                NameOfSkill.Content = skill.Title;
                categoryId = skill.CategoryId;
                SkillId = skill.Id;
            }
            else
            {
                MessageBox.Show("Ma'lumotlar topilmadi");
            }
        }
        

        private async void SkillQoshish(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await _skillsService.AddSkill(SkillId);

                if (result == 1)
                {
                    MessageBox.Show("Skill added successfully!");
                }
                else if (result == 0)
                {
                    MessageBox.Show("skill has already exists.");
                }
                else if (result == -1)
                {
                    MessageBox.Show("An error occurred while adding the skill.");
                }
            }
            catch
            {
                MessageBox.Show("internet is slow!");
            }
        }
    }
}
