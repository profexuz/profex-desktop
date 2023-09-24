using Profex_Integrated.Services.Skills;
using Profex_ViewModels.Skills;
using System;
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
        public Action Yangilash { get; set; }

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
                if (result == 1)
                {
                    MessageBox.Show("Muvoffaqiyatli o'chirildi!");
                    Yangilash();
                }
                else if (result == 0)
                {
                    MessageBox.Show("Siz ushbu mahoratni allaqachon o'chirgansiz");
                }
                else if (result == -1)
                {
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
                if (result == 1)
                {
                    MessageBox.Show("Mahorat muvaffaqiyatli ravishda o'chirildi!");
                    Yangilash();
                }
                else if (result == 0)
                {
                    MessageBox.Show("Mahorat allaqachon o'chirildi.");
                    Yangilash();
                }
                else if (result == -1)
                {
                    // Handle unexpected errors.
                    MessageBox.Show("Qandaydir xatolik yuz berdi.");
                    Yangilash();
                }
            }
            catch
            {
                MessageBox.Show("internet alqoasu sekin!");
            }
        }
    }
}
