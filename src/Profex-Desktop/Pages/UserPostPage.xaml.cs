using Profex_Desktop.Components.UserPosts;
using Profex_Desktop.Windows.AboutCategory;
using Profex_Desktop.Windows.UserPostImage;
using Profex_Desktop.Windows.UserPosts;
using Profex_Integrated.Services.Posts;
using Profex_Integrated.Services.Vacancies;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for UserPostPage.xaml
    /// </summary>
    public partial class UserPostPage : Page
    {
        private PostService _postService = new PostService();
        private VacancyService _vacancyService = new VacancyService();
        public long LastId;
        public long ImageId;
        private string BASE_URL = "http://64.227.42.134:4040/";
        
        public UserPostPage()
        {
            InitializeComponent();
        }


        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpWords_Groups.Children.Clear();
            var result1 = await _postService.GetAllMyPost(1);
            string[] values = new string[4];
            
            byte count = 0;
            foreach ( var item in result1)
            {
                if (count == 6) break; count++;
                UserPostxaml vck = new UserPostxaml();
                vck.vacancyId = item.Id;
                vck.categoryId = item.CategoryId;
//                vck.ImageId = item.Images; 
                foreach(var iteeeeem in item.Images)
                {
                    vck.ImageId = iteeeeem.Id;
                }
                values[0] = BASE_URL + item.ImagePath[0];
                values[1] = item.Title;
                values[2] = item.Price.ToString();
                //LastId = item.Id;
                //values[3] = LastId;
                UserPostImageWindow inc = new UserPostImageWindow();
                //values[3] = item.Id;
                inc.lastId = item.Id;
                values[3] = item.Id.ToString();
                string fileName = "C:\\Users\\Public\\LastID.txt";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file    
                    Byte[] title = new UTF8Encoding(true).GetBytes($"{item.Id}");
                    fs.Write(title, 0, title.Length);
                }
                vck.SetData(values);
                inc.SetData(values);
                loader.Visibility = Visibility.Collapsed;
                wrpWords_Groups.Children.Add(vck);
            }
            
            
        }
        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //UserPostCreateWindow userPostCreateWindow = new UserPostCreateWindow();
            AboutCategoryWindow aboutCategoryWindow = new AboutCategoryWindow();
            LastId = aboutCategoryWindow.lastId;
            aboutCategoryWindow.ShowDialog();
            //userPostCreateWindow.ShowDialog();
            
        }

        private async void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                loader.Visibility = Visibility.Visible;
                if (e.Key == Key.Enter)
                {
                    if (tbSearch.Text.Length > 0)
                    {
                        wrpWords_Groups.Children.Clear();

                        var result = await _postService.SearchAsync(tbSearch.Text.ToString());
                        foreach (var word in result)
                        {
                            UserPostxaml userPostxaml = new UserPostxaml();
                            string[] value = new string[3];
                            value[0] = BASE_URL + word.ImagePath[0];
                            value[1] = word.Title;
                            userPostxaml.SetData(value);
                            wrpWords_Groups.Children.Add(userPostxaml);
                        }
                    }
                    else if (tbSearch.Text.Length == 0)
                    {
                        wrpWords_Groups.Children.Clear();
                        var result1 = await _postService.GetAllMyPost(1);
                        string[] values = new string[4];

                        byte count = 0;
                        foreach (var item in result1)
                        {
                            if (count == 6) break; count++;
                            UserPostxaml vck = new UserPostxaml();
                            vck.vacancyId = item.Id;
                            vck.categoryId = item.CategoryId;
                            //                vck.ImageId = item.Images; 
                            foreach (var iteeeeem in item.Images)
                            {
                                vck.ImageId = iteeeeem.Id;
                            }
                            values[0] = BASE_URL + item.ImagePath[0];
                            values[1] = item.Title;
                            values[2] = item.Price.ToString();
                            //LastId = item.Id;
                            //values[3] = LastId;
                            UserPostImageWindow inc = new UserPostImageWindow();
                            //values[3] = item.Id;
                            inc.lastId = item.Id;
                            values[3] = item.Id.ToString();
                            string fileName = "C:\\Users\\Public\\LastID.txt";
                            if (File.Exists(fileName))
                            {
                                File.Delete(fileName);
                            }
                            using (FileStream fs = File.Create(fileName))
                            {
                                // Add some text to file    
                                Byte[] title = new UTF8Encoding(true).GetBytes($"{item.Id}");
                                fs.Write(title, 0, title.Length);
                            }
                            vck.SetData(values);
                            inc.SetData(values);

                            wrpWords_Groups.Children.Add(vck);
                        }
                    }
                }
                loader.Visibility = Visibility.Collapsed;
            }
            catch
            {
                MessageBox.Show("Nimadir bo'ldida");
            }
        }
    }
}
