using Profex_Desktop.Components.Categories;
using Profex_Integrated.Services.Categories;
using Profex_ViewModels.Categories;
using System;
using System.Linq;
using System.Windows;

namespace Profex_Desktop.Windows.AboutCategory
{
    /// <summary>
    /// Interaction logic for AboutCategoryWindow.xaml
    /// </summary>
    public partial class AboutCategoryWindow : Window
    {
        //public long skillId;
        public long categoryId;
        public long page = 1;
        //SkillInformation nm = new SkillInformation();
        CategoryView categoryView = new CategoryView();
        public long lastId;
        //private SkillsService _skillsService = new SkillsService();
        private CategoryService _categoryService = new CategoryService();    
        //public long skillCount;
        public long categoryCount;
        public AboutCategoryWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            wrpPanel.Children.Clear();

            try
            {
                var result = await _categoryService.GetAll(page);

                categoryCount = result.Count();

                foreach (var item in result)
                {
                    //SkillContact sklc = new SkillContact();
                    CategoryView categoryView = new CategoryView();
                    //sklc.SkillId = skillId;
                    //sklc.categoryId = categoryId;
                    //categoryView.categoryId = categoryId;
                    categoryId = item.Id;
                   

                    var category = new CategoryViewModel
                    {
                        Id = item.Id,
                             
                        Name = item.Name,   
                        Description = item.Description
                    };
                    lastId = item.Id;
                    categoryView.categoryId = item.Id;
                    //sklc.SetData(category);
                    categoryView.SetData(category);

                    wrpPanel.Children.Add(categoryView);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
