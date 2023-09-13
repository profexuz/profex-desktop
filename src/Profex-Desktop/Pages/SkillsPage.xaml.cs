using Profex_Desktop.Components.SkillAbout;
using Profex_Integrated.Services.Masters;
using Profex_Integrated.Services.Skills;
using System.Linq;
using System;
using System.Windows;
using System.Windows.Controls;
using Profex_ViewModels.Categories;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for SkillsPage.xaml
    /// </summary>
    public partial class SkillsPage : Page
    {
        public long skillId;
        public long page = 1;
        private SkillsService _skillsService = new SkillsService();
        private long categoryCount = 0;
        public SkillsPage()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {}

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /*wrpSkills.Children.Clear();
            try
            {
                var result = await _skillsService.GetAllAysnc(page);
                categoryCount = result.Count();
                foreach (var item in result)
                {
                    SkillInformation ms = new SkillInformation();
                    ms.skillId = item.Id;

                    // CategoryViewModel obyektini olib tashlash
                    var category = new CategoryViewModel
                    {
                        Id = item.Id, // CategoryId ni o'zgartiring, agar qo'shimcha ma'lumotlar bor bo'lsa
                        Name = item.Name // CategoryName ni o'zgartiring, agar qo'shimcha ma'lumotlar bor bo'lsa
                    };

                    // SkillInformation komponentiga CategoryViewModel obyektini uzatish
                    ms.SetData(category);

                    wrpSkills.Children.Add(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/


            wrpSkills.Children.Clear();
            try
            {
                var result = await _skillsService.GetAllAysnc(page);
                categoryCount = result.Count();
                foreach (var item in result)
                {
                    SkillInformation ms = new SkillInformation();
                    ms.skillId = item.Id;

                    // CategoryViewModel obyektini olib tashlash
                    var category = new CategoryViewModel
                    {
                        Id = item.Id, // CategoryId ni o'zgartiring, agar qo'shimcha ma'lumotlar bor bo'lsa
                        Name = item.Name // CategoryName ni o'zgartiring, agar qo'shimcha ma'lumotlar bor bo'lsa
                    };

                    // SkillInformation komponentiga CategoryViewModel obyektini uzatish
                    ms.SetData(category);

                    // Har bir SkillInformation komponentini WrapPanel ga qo'shib berish
                    wrpSkills.Children.Add(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            /*wrpSkills.Children.Clear();
            try
            {
                //var result = await _skillsService.GetAllAysnc(1);
                var result = await _skillsService.GetAllAysnc(page);
                categoryCount = result.Count();
                foreach (var item in result)
                {
                    SkillInformation ms = new SkillInformation();
                    ms.skillId = item.Id;
                    string[] list =
                    {
                        item.Name,
                    };
                    ms.SetData(list);
                    // Category nomini alohida alohida o'zgartirish
                    if (category1.DataContext == null)
                    {
                        category1.DataContext = item.Name;
                    }
                    else if (category2.DataContext == null)
                    {
                        category2.DataContext = item.Name;
                    }
                    //wrpSkills.Children.Add(ms);
                }
            }
            catch (Exception ex)
            {
                //return false;
                MessageBox.Show(ex.Message);
            }
        }*/

        }
    }
}
