using Profex_Integrated.Services.Requests;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Components.Request
{
    /// <summary>
    /// Interaction logic for MyRequestMaster.xaml
    /// </summary>
    public partial class MyRequestMaster : UserControl
    {
        public long vacancyId;
        public long UserId;
        public Action RefreshAsync { get; set; }    
        private RequestService _requestService = new RequestService();
        public MyRequestMaster()
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
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /*AboutVacancyWindow vacancyWindow = new AboutVacancyWindow();
            vacancyWindow.vacancyId = vacancyId;
            vacancyWindow.UserId = UserId;
            vacancyWindow.ShowDialog();*/
        }

        private async void BorderDelete_Requests(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ushbu so'rovni o'chirmoqchimisiz?", "Warning!", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var result1 = await _requestService.DeleteReq(vacancyId, UserId);
                    if (result1 == 1)
                    {
                        MessageBox.Show("So'rovingiz muvoffaqiyatli o'chirildi!");
                    }
                    else if (result1 == 0)
                    {
                        MessageBox.Show("Siz ushbu so'rovni avval o'chirgansiz");
                    }
                    else if (result1 == -1)
                    {
                        MessageBox.Show("Nomalum xatolik yuz berdi.");
                    }
                }
                catch
                {
                    MessageBox.Show("internet sekin ishlamoqda!");
                }

            }
            else
            { }
        }
    }
}
