using Microsoft.AspNetCore.Http.Internal;
using Profex_Dtos.PostImages;
using Profex_Integrated.Services.Categories;
using Profex_Integrated.Services.PostImages;
using Profex_Integrated.Services.Posts;
using Profex_ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Windows.UserPostImage
{
    /// <summary>
    /// Interaction logic for UserPostImageUpdateWindow.xaml
    /// </summary>
    public partial class UserPostImageUpdateWindow : Window
    {
        private string selectedFilePath = "";
        List<CategoryViewModel> list = new List<CategoryViewModel>();
        //public long CategoryId;
        public long PostId;
        string lastIdFilePath = @"C:\Users\Public\LastID.txt";
        string AuthPath = @"C:\Users\Public\Token.txt";
        public long lastId;
        public long imageID;

        private PostService _postService = new PostService();
        private PostImageService _postImageService = new PostImageService();
        private CategoryService _categoryService = new CategoryService();
        int s = 0;
        public UserPostImageUpdateWindow()
        {
            InitializeComponent();
        }

        private async void BtnImage_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(lastIdFilePath))
            {
                string lastIdContent = File.ReadAllText(lastIdFilePath);
                if (int.TryParse(lastIdContent, out int lastId))
                {
                    PostId = lastId;
                }
            }
            PostImageCreateDto dto = new PostImageCreateDto();
            dto.PostId = PostId;
            //dto.ImagePath = selectedFilePath;
            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                // Faylni IFormFile ko'rinishida yaratish
                var fileBytes = File.ReadAllBytes(selectedFilePath);
                var fileName = System.IO.Path.GetFileName(selectedFilePath);
                dto.ImagePath = new FormFile(new MemoryStream(fileBytes), 0, fileBytes.Length, null, fileName);
                BtnImage.IsEnabled = true;
            }

            //var res = await _postImageService.AddPostImage(dto);
            var res = await _postService.UpdatePostImage(imageID,dto);
            if (res == 1)
            {
                MessageBox.Show("Muvoffaqiyatli yangilandi");
                this.Close();
            }
            else if (res == 0)
            {
                MessageBox.Show("Qandaydir xatolik mavjud berdi, keyinroq qaytadan urinib ko'ring!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Internet aloqasini tekshirib qaytadan urinib ko'ring!");
                this.Close();
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var clickedElement = sender as UIElement;

            if (clickedElement != null)
            {
                // OpenFileDialog obyektini yaratish
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

                // Foydalanuvchi faylni tanlashi mumkin bo'lgan fayl formatlari
                openFileDialog.Filter = "Rasm fayllari|*.jpg;*.jpeg;*.png;|Barcha fayllar|*.*";

                // Faylni tanlash va natijani oluvchi oynani ochish
                bool? result = openFileDialog.ShowDialog();

                // Agar fayl tanlansa va rasm fayli bo'lsa
                if (result == true)
                {
                    selectedFilePath = openFileDialog.FileName;
                    if (selectedFilePath.Contains(".jpg") | selectedFilePath.Contains(".jpeg") | selectedFilePath.Contains(".png"))
                    {
                        BtnImage.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Faqat 'jpg','jpeg' va 'png' formatdagi rasmlarni yuklay olasiz", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        BtnImage.IsEnabled = false;
                    }

                    // Tanlangan rasm faylini olish va kerakli ishlar bilan davom etish
                    // Misol uchun: Tanlangan rasmni bir joyga joylash va uni ko'rsatish
                    ImageSource imageSource = new BitmapImage(new Uri(selectedFilePath));
                    // imageSource ni WPF Image elementiga berish mumkin
                    PostImage.ImageSource = imageSource;

                }

            }
        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
