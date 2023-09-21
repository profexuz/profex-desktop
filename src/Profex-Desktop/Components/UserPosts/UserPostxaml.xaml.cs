using Profex_Desktop.Windows.AboutVacancy;
using Profex_Desktop.Windows.UserPosts;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_Integrated.Services.Posts;
using Profex_Integrated.Services.Skills;
using Profex_Integrated.Services.Vacancies;
using Profex_ViewModels.Vacancies;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Components.UserPosts
{
    /// <summary>
    /// Interaction logic for UserPostxaml.xaml
    /// </summary>
    public partial class UserPostxaml : UserControl
    {
        public long vacancyId;
        public long lastID;
        private PostService _postService = new PostService();
        private VacancyService _vacancyService = new VacancyService();
        
        public UserPostxaml()
        {
            InitializeComponent();
        }
        public void SetData(string[] values)
        {
            Uri imageUri = new Uri(values[0], UriKind.Absolute);
            VacancieImg.ImageSource = new BitmapImage(imageUri);
            lbName.Content = values[1];

            loader.Visibility = Visibility.Collapsed;
        }
        /*public void SetData1(Vacancy vacancy)
        {
            // O'zgaruvchilarni Vacancy obyekti ma'lumotlari bilan to'ldiring
            // Misol: Agar Vacancy obyekti xususiyatlari "Image", "Title", va "Price" bo'lsa
            // Siz o'zgaruvchilarni shunday to'ldirishingiz mumkin:

            string[] values = new string[3];
            values[0] = API.BASE_URL + vacancy.ImagePath[0];
            values[1] = vacancy.Title;
            values[2] = vacancy.Price.ToString();

        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UserPostUpdateWindow userUpd = new UserPostUpdateWindow();
            // konstruktor orqalidi yuborish kerak
            userUpd.ShowDialog();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                var result = await _vacancyService.RemoveAsync(vacancyId);

                // Check the result and take appropriate action.
                if (result == 1)
                {
                    // Skill added successfully, you can update your UI here if needed.
                    MessageBox.Show("Sizning postingiz muvaffaqiyatli o'chirildi!");
                }
                else if (result == 0)
                {
                    // Handle the case where adding the skill failed.
                    MessageBox.Show("Siz ushbu postni avval o'chirgansiz");
                }
                else if (result == -1)
                {
                    // Handle unexpected errors.
                    MessageBox.Show("Post o'chirishda xatolik mavjud, iltimos qaytadan urinib ko'ring!");
                }
            }
            catch
            {
                MessageBox.Show("internet bilan bog'liq muammo bor!");
            }

        }

        private void grMain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AboutVacancyWindow vacancyWindow = new AboutVacancyWindow();
            vacancyWindow.vacancyId = vacancyId;
            vacancyWindow.ShowDialog();
        }
    }
}
