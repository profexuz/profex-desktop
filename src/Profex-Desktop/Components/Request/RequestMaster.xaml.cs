using Profex_Desktop.Windows.AboutVacancy;
using Profex_Integrated.Services.Requests;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Components.Request
{
    /// <summary>
    /// Interaction logic for RequestMaster.xaml
    /// </summary>
    public partial class RequestMaster : UserControl
    {
        public long vacancyId;
        public long UserId;
        private RequestService _requestService = new RequestService();
        public RequestMaster()
        {
            InitializeComponent();
        }
        public void SetData(string[] values)
        {
            Uri imageUri = new Uri(values[0], UriKind.Absolute);
            VacancieImg.ImageSource = new BitmapImage(imageUri);
            lblTitle.Content = values[1];
            lblCost.Content = values[2];
            loader.Visibility = Visibility.Collapsed;
        }

        private async void BtnRequst_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Siz ushbu postga so'rov jo'natasizmi?", "Warning!", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var result1 = await _requestService.AddRequest(vacancyId, UserId);
                    if (result1 == 1)
                    {
                        MessageBox.Show("Sizning so'rovingiz muvoffaqiyatli yuborildi!");
                    }
                    else if (result1 == 0)
                    {
                        MessageBox.Show("Siz allaqchon so'rov jo'natib bo'lgansiz.");
                    }
                    else if (result1 == -1)
                    {
                        MessageBox.Show("So'rov jo'natish vaqtida qandaydir xatolik mavjud bo'ldi.");
                    }
                }
                catch
                {
                    MessageBox.Show("Internet aloqasi sekin");
                }

            }
            else
            {}
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AboutVacancyWindow vacancyWindow = new AboutVacancyWindow();
            vacancyWindow.vacancyId = vacancyId;
            vacancyWindow.UserId = UserId;
            vacancyWindow.ShowDialog();
        }
    }
}
