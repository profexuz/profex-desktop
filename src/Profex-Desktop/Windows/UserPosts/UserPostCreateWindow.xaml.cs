
using Profex_Integrated.Interfaces;
using Profex_Integrated.Services.Posts;
using Profex_Integrated.Services.Skills;
using Profex_ViewModels.Skills;
using Profex_ViewModels.Vacancies;
using System.Windows;
using System.Windows.Input;

namespace Profex_Desktop.Windows.UserPosts
{
    /// <summary>
    /// Interaction logic for UserPostCreateWindow.xaml
    /// </summary>
    public partial class UserPostCreateWindow : Window
    {
        
        public long categoryId;
        private PostService _postService = new PostService();
        
        public UserPostCreateWindow()
        {
            InitializeComponent();
        }
        /*public void SetData(SkillViewModel skill)
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
        }*/
        public void SetData(Vacancy vacancy)
        {
            if(vacancy!=null)
            {
                
                categoryId = vacancy.CategoryId;
                lblPostTitle.Content = vacancy.Title;
                lblPrice.Content = vacancy.Price.ToString();
                lblUserRegion.Content = vacancy.Region;
                lblUserDistrict.Content = vacancy.District;
                txtPhoneNumber.Text = vacancy.PhoneNumber.ToString();
                rbDefenation.Text = vacancy.Description;
            }
        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void btnPicture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void btnPicture2_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }


        private void btnPicture3_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnPicture4_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnPicture5_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await _postService.AddSkill(categoryId);

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
