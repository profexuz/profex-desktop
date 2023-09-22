using Profex_Integrated.Services.Skills;
using Profex_ViewModels.Skills;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
                    MessageBox.Show("Muvoffaqiyatli o'chirildi!");
                }
                else if (result == 0)
                {
                    // Handle the case where adding the skill failed.
                    MessageBox.Show("Siz ushbu mahoratni allaqachon o'chirgansiz");
                }
                else if (result == -1)
                {
                    // Handle unexpected errors.
                    MessageBox.Show("Nomalum xatolik yuz berdi");
                }
            }
            catch
            {
                MessageBox.Show("internet aloqasi sekin!");
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
                    MessageBox.Show("Mahorat muvaffaqiyatli ravishda o'chirildi!");
                }
                else if (result == 0)
                {
                    // Handle the case where adding the skill failed.
                    MessageBox.Show("Mahorat allaqachon o'chirildi.");
                }
                else if (result == -1)
                {
                    // Handle unexpected errors.
                    MessageBox.Show("Qandaydir xatolik yuz berdi.");
                }
            }
            catch
            {
                MessageBox.Show("internet alqoasu sekin!");
            }
        }
    }
}
