﻿using Profex_Desktop.Windows.SkillWindow;
using Profex_ViewModels.Categories;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Profex_Desktop.Components.SkillAbout
{
    /// <summary>
    /// Interaction logic for SkillInformation.xaml
    /// </summary>
    public partial class SkillInformation : UserControl
    {
        public long skillId;

        public long CategoryId;

        public SkillInformation()
        {
            InitializeComponent();
        }
        public void SetData(CategoryViewModel category)
        {
            if (category != null)
            {
                NameOfMaster.Content = category.Name;
                CategoryId = category.Id;
                //skw.skillId = CategoryId;
            }
            else
            {
                MessageBox.Show("Ma'lumotlar topilmadi");
            }
        }

        private void SkillQoshish(object sender, MouseButtonEventArgs e)
        {

            //CategorySkillsWindow skw = new CategorySkillsWindow();
            //skw.skillId = CategoryId;
            CategorySkillsWindow skw = new CategorySkillsWindow(CategoryId);
            skw.ShowDialog();
        }
    }
}
