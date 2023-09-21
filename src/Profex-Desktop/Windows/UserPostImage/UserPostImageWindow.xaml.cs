﻿using Microsoft.AspNetCore.Http.Internal;
using Profex_Dtos.PostImages;
using Profex_Integrated.Services.Categories;
using Profex_Integrated.Services.PostImages;
using Profex_Integrated.Services.Posts;
using Profex_ViewModels.Categories;
using Profex_ViewModels.Masters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Windows.UserPostImage
{
    /// <summary>
    /// Interaction logic for UserPostImageWindow.xaml
    /// </summary>
    public partial class UserPostImageWindow : Window
    {
        private string selectedFilePath = "";
        List<CategoryViewModel> list = new List<CategoryViewModel>();
        //public long CategoryId;
        public long PostId;
        string lastIdFilePath = @"C:\Users\Public\LastID.txt";
        public long lastId;
        private PostService _postService = new PostService();
        private PostImageService _postImageService = new PostImageService();
        private CategoryService _categoryService = new CategoryService();
        List<string> lst = new List<string>();
        public UserPostImageWindow()
        {
            InitializeComponent();
        }

        public void SetData(string[] values)
        {
            lastId = long.Parse(values[3]);
        }
        private async void BtnImage_Click(object sender, RoutedEventArgs e)
        {
            if(File.Exists(lastIdFilePath))
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
                var fileName = Path.GetFileName(selectedFilePath);
                dto.ImagePath = new FormFile(new MemoryStream(fileBytes), 0, fileBytes.Length, null, fileName);
                BtnImage.IsEnabled = true;
            }

            //var res = await _postImageService.AddPostImage(dto);
            var res = await _postService.AddPostImage(dto);
            if(res==1)
            {
                MessageBox.Show("Muvoffaqiyatli yaratildi");
                //UserPostImageWindow ms = new UserPostImageWindow();
                this.Close();
                //ms.Close();
            }
            else if(res==0)
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
    }
}
