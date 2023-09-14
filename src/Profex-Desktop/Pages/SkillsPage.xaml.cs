﻿using Profex_Desktop.Components.SkillAbout;
using Profex_Integrated.Services.Skills;
using Profex_ViewModels.Categories;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for SkillsPage.xaml
    /// </summary>
    public partial class SkillsPage : Page
    {
        public long skillId;
        public long kerakSkillId;
        public long page = 1;
        public long CategoryId;
        private SkillsService _skillsService = new SkillsService();
        private long categoryCount = 0;
        public SkillsPage()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        { }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpSkills.Children.Clear();
            try
            {
                var result = await _skillsService.GetAllAysnc(page);
                categoryCount = result.Count();
                foreach (var item in result)
                {
                    SkillInformation ms = new SkillInformation();
                    ms.skillId = item.Id;
                    ms.CategoryId = item.Id;

                    var category = new CategoryViewModel
                    {
                        Id = item.Id,
                        Name = item.Name
                    };

                    ms.SetData(category);

                    wrpSkills.Children.Add(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
