using Profex_Integrated.Services.Skills;
using Profex_ViewModels.Categories;
using Profex_ViewModels.Skills;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        private async void SkillQoshish(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var result = await _skillsService.AddSkill(SkillId);

                // Check the result and take appropriate action.
                if (result == 1)
                {
                    // Skill added successfully, you can update your UI here if needed.
                    MessageBox.Show("Skill added successfully!");
                }
                else if (result == 0)
                {
                    // Handle the case where adding the skill failed.
                    MessageBox.Show("skill has already exists.");
                }
                else if (result == -1)
                {
                    // Handle unexpected errors.
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
