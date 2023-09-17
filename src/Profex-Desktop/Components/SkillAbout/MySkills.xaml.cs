using Profex_Integrated.Services.Skills;
using Profex_ViewModels.Skills;
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

namespace Profex_Desktop.Components.SkillAbout
{
    /// <summary>
    /// Interaction logic for MySkills.xaml
    /// </summary>
    public partial class MySkills : UserControl
    {
        public long SkillId;
        public long MasterId;

        private SkillsService _skillsService = new SkillsService();

        public MySkills()
        {
            InitializeComponent();
        }
        public void SetData(SkillViewModel skill)
        {
            if (skill != null)
            {
                NameOfSkill.Content = skill.Title;
                SkillId = skill.Id;
            }
            else
            {
                MessageBox.Show("Ma'lumotlar topilmadi");
            }
        }

        private async void SkillChopish(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var result = await _skillsService.RemoveMySkill(SkillId);

                // Check the result and take appropriate action.
                if (result == 1)
                {
                    // Skill added successfully, you can update your UI here if needed.
                    MessageBox.Show("Skill removed successfully!");
                }
                else if (result == 0)
                {
                    // Handle the case where adding the skill failed.
                    MessageBox.Show("skill has already removed.");
                }
                else if (result == -1)
                {
                    // Handle unexpected errors.
                    MessageBox.Show("An error occurred while removed the skill.");
                }
            }
            catch
            {
                MessageBox.Show("internet is slow!");
            }

        }

        private async void SkillChopish(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await _skillsService.RemoveMySkill(SkillId);

                // Check the result and take appropriate action.
                if (result == 1)
                {
                    // Skill added successfully, you can update your UI here if needed.
                    MessageBox.Show("Skill removed successfully!");
                }
                else if (result == 0)
                {
                    // Handle the case where adding the skill failed.
                    MessageBox.Show("skill has already removed.");
                }
                else if (result == -1)
                {
                    // Handle unexpected errors.
                    MessageBox.Show("An error occurred while removed the skill.");
                }
            }
            catch
            {
                MessageBox.Show("internet is slow!");
            }
        }
    }
}
