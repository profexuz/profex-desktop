using Profex_Desktop.Windows.UserPostImage;
using Profex_Dtos.Post;
using Profex_Integrated.Services.Posts;
using System.Windows;

namespace Profex_Desktop.Windows.UserPosts
{
    /// <summary>
    /// Interaction logic for UserPostUpdateWindow.xaml
    /// </summary>
    public partial class UserPostUpdateWindow : Window
    {
        public long vacancyId;
        public long categoryId;
        public long postId;
        public long ImageID;
        private PostService _postService = new PostService();
        public UserPostUpdateWindow()
        {
            InitializeComponent();
        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            PostCreateDto dto = new PostCreateDto();
            
            dto.CategoryId = categoryId;
            dto.Title = txtTitle.Text;
            dto.Price = double.Parse(txtPrice.Text);
            dto.Deccription = rbDefenation.Text;
            dto.Region = txtRegion.Text;
            dto.District = txtDistrict.Text;
            dto.Latidute = 12323;
            dto.Longitude = 1235;
            dto.PhoneNumber = txtPhoneNumber.Text;
            var res = await _postService.UpdateAsync(vacancyId,dto);
            if (res == 1)
            {
                var reeesult = MessageBox.Show("Postingiz muvofaqiyatli ravishda yangilandi", "Warning", MessageBoxButton.OK);
                if (reeesult == MessageBoxResult.OK)
                {
                    /*//UserPostImageWindow us = new UserPostImageWindow();
                    UserPostImageUpdateWindow us = new UserPostImageUpdateWindow();
                    vacancyId = us.PostId;
                    //ImageID = us.imageID;
                    us.imageID = ImageID;
                    us.ShowDialog();*/
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Internet bilan muomo yuzaga keldi!");
            }
        }
    }
}
