using Profex_Desktop.Windows.SkillWindow;
using Profex_ViewModels.Categories;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Profex_Desktop.Components.SkillAbout
{
    /// <summary>
    /// Interaction logic for SkillInformation.xaml
    /// </summary>
    public partial class SkillInformation : UserControl
    {
        public long skillId;

        public SkillInformation()
        {
            InitializeComponent();
        }
        public void SetData(CategoryViewModel category)
        {
            if (category != null)
            {
                NameOfMaster.Content = category.Name;
            }
            else
            {
                MessageBox.Show("Ma'lumotlar topilmadi");
            }
        }

        private void SkillQoshish(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("Hozircha bu categoryga doir skillar mavjud emas!");
            CategorySkillsWindow skw = new CategorySkillsWindow();
            skw.ShowDialog();
            //yana ozgartirdim
        }
    }
}
