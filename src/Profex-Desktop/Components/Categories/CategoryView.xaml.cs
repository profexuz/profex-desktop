﻿using Profex_Desktop.Windows.AboutCategory;
using Profex_Desktop.Windows.UserPosts;
using Profex_ViewModels.Categories;
using System;
using System.Windows.Controls;

namespace Profex_Desktop.Components.Categories
{
    /// <summary>
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl
    {
        

        public long categoryId;
        public Action CloseWindow { get; set; }
        public CategoryView()
        {
            InitializeComponent();
        }
        public async void SetData(CategoryViewModel categoryViewModel)
        {
            categoryId = categoryViewModel.Id;
            CategoryTitle.Content = categoryViewModel.Name;
        } 
        
        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UserPostCreateWindow usp = new UserPostCreateWindow();
            usp.CategoryId = categoryId;
            usp.CloseWindow = CloseWindow;
            usp.ShowDialog();
        }
    }
}
