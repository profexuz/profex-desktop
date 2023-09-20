using Profex_Desktop.Components.UserPosts;
using Profex_Desktop.Windows.UserPosts;
using Profex_Integrated.Services.Posts;
using Profex_Integrated.Services.Vacancies;
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
        private string BASE_URL = "http://64.227.42.134:4040/";
        public UserPostPage()
        {
            InitializeComponent();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            UserPostCreateWindow userPostCreateWindow = new UserPostCreateWindow();
            userPostCreateWindow.ShowDialog();
            
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpWords_Groups.Children.Clear();
            var result1 = await _postService.GetAllMyPost(1);
            string[] values = new string[3];
            
            byte count = 0;
            foreach ( var item in result1)
            {
                if (count == 6) break; count++;
                UserPostxaml vck = new UserPostxaml();
                vck.vacancyId = item.Id;
                values[0] = BASE_URL + item.ImagePath[0];
                values[1] = item.Title;
                values[2] = item.Price.ToString();
                vck.SetData(values);
                wrpWords_Groups.Children.Add(vck);
                loader.Visibility = Visibility.Collapsed;
            }
        }

        private async void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
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
            }
            catch
            {
                MessageBox.Show("Nimadir bo'ldida");
            }
        }
    }
}
