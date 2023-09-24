using Profex_Desktop.Windows.AboutVacancy;
using Profex_Desktop.Windows.UserPosts;
using Profex_Integrated.Services.Posts;
using Profex_Integrated.Services.Vacancies;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Components.UserPosts
{
    /// <summary>
    /// Interaction logic for UserPostxaml.xaml
    /// </summary>
    public partial class UserPostxaml : UserControl
    {
        public long vacancyId;
        public long lastID;
        public long postID;
        public long categoryId;
        public long ImageId;
        private PostService _postService = new PostService();
        private VacancyService _vacancyService = new VacancyService();
        
        public UserPostxaml()
        {
            InitializeComponent();
        }
        public void SetData(string[] values)
        {
            Uri imageUri = new Uri(values[0], UriKind.Absolute);
            VacancieImg.ImageSource = new BitmapImage(imageUri);
            lbName.Content = values[1];

            loader.Visibility = Visibility.Collapsed;
        }

        
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
           UserPostUpdateWindow userUpd = new UserPostUpdateWindow();
           userUpd.vacancyId = vacancyId;
           userUpd.ImageID = ImageId;
           userUpd.categoryId = categoryId; 
           userUpd.ShowDialog();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
           try
           { 
               var result = await _vacancyService.RemoveAsync(vacancyId);

               // Check the result and take appropriate action.
               if (result == 1)
               {
                   MessageBox.Show("Sizning postingiz muvaffaqiyatli o'chirildi!");
                }
               else if (result == 0)
               {
                   MessageBox.Show("Siz ushbu postni avval o'chirgansiz");
               }
               else if (result == -1)
               {
                   MessageBox.Show("Post o'chirishda xatolik mavjud, iltimos qaytadan urinib ko'ring!");
               }
           }
           catch
           {
               MessageBox.Show("internet bilan bog'liq muammo bor!");
           }

        }

        private void grMain_MouseDown(object sender, MouseButtonEventArgs e)
        {
           AboutVacancyWindow vacancyWindow = new AboutVacancyWindow();
           vacancyWindow.vacancyId = vacancyId;
           vacancyWindow.ShowDialog();
        }
    }
}
