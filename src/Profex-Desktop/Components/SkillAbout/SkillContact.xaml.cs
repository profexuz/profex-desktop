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
                    MessageBox.Show("Mahorat muvaffaqiyatli qo'shildi!");
                }
                else if (result == 0)
                {
                    MessageBox.Show("Sizda ushbu mahorat avvaldan mavjud");
                }
                else if (result == -1)
                {
                    MessageBox.Show("Mahorat qo'shish vaqtida qandaydir xatolik yuz berdi");
                }
            }
            catch
            {
                MessageBox.Show("internet aloqasi sekin!");
            }
        }
    }
}
