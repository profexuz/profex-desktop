//using Profex_Desktop.Components.SkillAbout;
//using Profex_Integrated.Services.Skills;
//using Profex_ViewModels.Skills;
//using System;
//using System.Linq;
//using System.Windows;

//namespace Profex_Desktop.Windows.SkillWindow
//{
//    /// <summary>
//    /// Interaction logic for CategorySkillsWindow.xaml
//    /// </summary>
//    public partial class CategorySkillsWindow : Window
//    {
//        public long skillId;
//        public static long categoryId;
//        public long page = 1;
//        SkillInformation nm = new SkillInformation();
//        private SkillsService _skillsService = new SkillsService();
//        public long skillCount;


//        public CategorySkillsWindow()
//        {
//            InitializeComponent();
//        }

//        private async void Window_Loaded(object sender, RoutedEventArgs e)
//        {
//            wrpPanel.Children.Clear();
//            try
//            {
//                var result = await _skillsService.GetByCategoryId(skillId, page);
//                skillCount = result.Count();
//                foreach (var item in result)
//                {
//                    SkillContact sklc = new SkillContact();
//                    sklc.SkillId = skillId;
//                    sklc.categoryId = categoryId;



//                    var category = new SkillViewModel
//                    {
//                        Id = item.Id,
//                        CategoryId = item.CategoryId,
//                        Title = item.Title,// CategoryId ni o'zgartiring, agar qo'shimcha ma'lumotlar bor bo'lsa

//                    };

//                    sklc.SetData(category);

//                    wrpPanel.Children.Add(sklc);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }



//        }

//        private void btnClose_Click(object sender, RoutedEventArgs e)
//        {
//            Close();
//        }
//    }
//}




using Profex_Desktop.Components.SkillAbout;
using Profex_Integrated.Services.Skills;
using Profex_ViewModels.Skills;
using System;
using System.Linq;
using System.Windows;

namespace Profex_Desktop.Windows.SkillWindow
{
    /// <summary>
    /// Interaction logic for CategorySkillsWindow.xaml
    /// </summary>
    public partial class CategorySkillsWindow : Window
    {
        // Member variables
        public long skillId;
        public  long categoryId; // Static variable shared across all instances
        public long page = 1;
        SkillInformation nm = new SkillInformation();
        private SkillsService _skillsService = new SkillsService();
        public long skillCount;

        // Constructor
        public CategorySkillsWindow()
        {
            InitializeComponent();
        }
        public CategorySkillsWindow(long categoryId)
        {
            InitializeComponent();
            this.categoryId = categoryId;
        }

        // Event handler for when the window is loaded
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            wrpPanel.Children.Clear(); // Clear the UI panel

            try
            {
                // Fetch skills related to the specified category and page asynchronously
                var result = await _skillsService.GetByCategoryId(categoryId, page);

                // Count the number of skills
                skillCount = result.Count();

                // Iterate over the fetched skills and create UI elements for each
                foreach (var item in result)
                {
                    SkillContact sklc = new SkillContact();
                    sklc.SkillId = skillId;
                    sklc.categoryId = categoryId;

                    // Create a SkillViewModel and populate it with data
                    var category = new SkillViewModel
                    {
                        Id = item.Id,
                        CategoryId = item.CategoryId,
                        Title = item.Title,
                        // You can modify CategoryId if additional data is available
                    };

                    // Set the data for the SkillContact element
                    sklc.SetData(category);

                    // Add the SkillContact to the UI panel
                    wrpPanel.Children.Add(sklc);
                }
            }
            catch (Exception ex)
            {
                // Display an error message in case of an exception
                MessageBox.Show(ex.Message);
            }
        }

        // Event handler for the Close button
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // Close the window
            Close();
        }
    }
}
