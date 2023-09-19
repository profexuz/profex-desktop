using Profex_Desktop.Windows.UserPosts;
using Profex_Integrated.Services.Skills;
using Profex_Integrated.Services.Vacancies;
using Profex_ViewModels.Vacancies;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Profex_Desktop.Components.UserPosts
{
    /// <summary>
    /// Interaction logic for UserPostxaml.xaml
    /// </summary>
    public partial class UserPostxaml : UserControl
    {
        public  long UserId { get; set; }
        public long PostId { get; set; }
        //private SkillsService _skillsService = new SkillsService();
        private VacancyService _vck = new VacancyService();

        public UserPostxaml()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            UserPostUpdateWindow msk = new UserPostUpdateWindow();
            msk.ShowDialog();
        }

        private void grMain_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await _vck.RemoveAsync(PostId);

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
        public void SetData(Vacancy vacancy )
        {
            if (vacancy != null)
            {
                lbName.Content = vacancy.Title;
                UserId = vacancy.UserId;
                PostId = vacancy.Id;
            }
            else
            {
                MessageBox.Show("Ma'lumotlar topilmadi");
            }
        }

    }
}
