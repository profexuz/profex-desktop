using Profex_Desktop.Windows.UserPostImage;
using Profex_Dtos.Post;
using Profex_Integrated.Services.Categories;
using Profex_Integrated.Services.Posts;
using Profex_ViewModels.Categories;
using Profex_ViewModels.Vacancies;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Profex_Desktop.Windows.UserPosts
{
    /// <summary>
    /// Interaction logic for UserPostCreateWindow.xaml
    /// </summary>
    public partial class UserPostCreateWindow : Window
    {
        List<CategoryViewModel> list = new List<CategoryViewModel>();
        public long CategoryId;
        public long PostId;
        private PostService _postService = new PostService();
        private CategoryService _categoryService = new CategoryService();
        List<string> lst = new List<string>();

        public UserPostCreateWindow()
        {
            InitializeComponent();
        }
        public UserPostCreateWindow(long categoryId)
        {
            InitializeComponent();
            CategoryId = categoryId;
        }
        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var resultCatrgory = await _categoryService.GetAll(1);
            foreach(var iiii in resultCatrgory)
            {
                PostId = iiii.Id;
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {

            PostCreateDto dto = new PostCreateDto();
            //dto.CategoryId = int.Parse(cmbCategory.Text);
            dto.Title = txtTitle.Text;
            //CategoryId = dto.CategoryId;
            dto.CategoryId = CategoryId;
            dto.Price = double.Parse(txtPrice.Text);
            dto.Deccription = rbDefenation.Text;
            dto.Region = txtRegion.Text;
            dto.District = txtDistrict.Text;
            dto.Latidute = 12323;
            dto.Longitude = 12321;
            dto.PhoneNumber = txtPhoneNumber.Text;
            var res = await _postService.AddPost(dto);
            var reeesult = MessageBox.Show("Postingiz muvofaqiyatli ravishda yaratildi , Postga surat qoyasizmi?", "Warning", MessageBoxButton.YesNo);
            if(reeesult== MessageBoxResult.Yes)
            {
                UserPostImageWindow us = new UserPostImageWindow();
                //PostId = us.PostId;
                
                us.PostId = PostId;
                
                us.ShowDialog();
                ///MessageBox.Show("Bu funksiya xali qoshilmadi jarayonda");
            }
            else
            {
                this.Close();
            }
            





        }
    }
}
