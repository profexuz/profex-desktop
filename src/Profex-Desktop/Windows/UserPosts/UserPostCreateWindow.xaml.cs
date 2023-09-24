using Notification.Wpf;
using Profex_Desktop.Windows.AboutCategory;
using Profex_Desktop.Windows.UserPostImage;
using Profex_Dtos.Post;
using Profex_Integrated.Services.Categories;
using Profex_Integrated.Services.Posts;
using Profex_Integrated.Services.Vacancies;
using Profex_Integrated.Validation;
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
        private readonly VacancyService _vacancyService = new VacancyService();
        ValidationAttribute validationAttribute = new ValidationAttribute();
        List<string> lst = new List<string>();

        public Action CloseWindow { get; set; }

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

            /*var resultCatrgory = await _categoryService.GetAll(2);
            foreach (var iiii in resultCatrgory)
            {
                PostId = iiii.Id;
            }
*/
            var res = await _vacancyService.GetAllAsync(1);
            foreach(var item in res)
            {
                PostId = item.Id;
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            PostCreateDto dto = new PostCreateDto();
            if(validationAttribute.IsValidTitle(txtTitle.Text).isSuccessful==false)
            {
                var notificationManager = new NotificationManager();
                notificationManager.Show("Diqqat!", validationAttribute.IsValidTitle(txtTitle.Text).Message, NotificationType.Warning);
                
            }
            else if(validationAttribute.IsValidPrice(txtPrice.Text).isSuccessful==false)
            {
                var notificationManager = new NotificationManager();
                notificationManager.Show("Diqqat!", validationAttribute.IsValidPrice(txtPrice.Text).Message, NotificationType.Warning);
            }

            else if(validationAttribute.IsValidDescription(rbDefenation.Text).isSuccessful==false)
            {
                var notificationManager = new NotificationManager();
                notificationManager.Show("Diqqat!", validationAttribute.IsValidDescription(rbDefenation.Text).Message, NotificationType.Warning);
            }


            else if(validationAttribute.IsValidRegion(txtRegion.Text).isSuccessful==false)
            {
                var notificationManager = new NotificationManager();
                notificationManager.Show("Diqqat!", validationAttribute.IsValidRegion(txtRegion.Text).Message, NotificationType.Warning);
            }

            else if(validationAttribute.IsValidDistrict(txtDistrict.Text).isSuccessful == false)
            {
                var notificationManager = new NotificationManager();
                notificationManager.Show("Diqqat!", validationAttribute.IsValidDistrict(txtDistrict.Text).Message, NotificationType.Warning);
            }
            else if(validationAttribute.IsValidPhoneNumber(txtPhoneNumber.Text).isSuccessful==false)
            {
                var notificationManager = new NotificationManager();
                notificationManager.Show("Warning!", validationAttribute.IsValidPhoneNumber(txtPhoneNumber.Text).Message, NotificationType.Warning);
            }
            else
            {
                dto.CategoryId = CategoryId;
                dto.Title = txtTitle.Text;
                dto.Price = double.Parse(txtPrice.Text);
                dto.Deccription = rbDefenation.Text;
                dto.Region = txtRegion.Text;
                dto.District = txtDistrict.Text;
                dto.Latidute = 12323;
                dto.Longitude = 12321;
                dto.PhoneNumber = txtPhoneNumber.Text;
                var res = await _postService.AddPost(dto);
                if (res == 1)
                {
                    var reeesult = MessageBox.Show("Postingiz muvofaqiyatli ravishda yaratildi , Postga surat qoyasizmi?", "Warning", MessageBoxButton.YesNo);
                    if (reeesult == MessageBoxResult.Yes)
                    {
                        UserPostImageWindow us = new UserPostImageWindow();
                        us.PostId = PostId;
                        us.ShowDialog();
                        this.Hide();

                    }
                    else
                    {
                        this.Close();
                    }
                    //CloseWindow();
                    
                }
            }

            
        }
    }
}
