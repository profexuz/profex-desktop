using Profex_Desktop.Windows.AboutMaster;
using Profex_Integrated.Services.Requests;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Components.MyRequestUser
{
    /// <summary>
    /// Interaction logic for MyRequestUser.xaml
    /// </summary>
    public partial class MyRequestUser : UserControl
    {

        public long vacancyId;
        public long UserId;
        public long MasterId;
        private RequestService rqs = new RequestService();

        public MyRequestUser()
        {
            InitializeComponent();
        }
        public void SetData(string[] values)
        {
            Uri imageUri = new Uri(values[0], UriKind.Absolute);
            VacancieImg.ImageSource = new BitmapImage(imageUri);
            lblTitle.Content = values[1];
            loader.Visibility = Visibility.Collapsed;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnAccepted_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bu postni qabul qilasizmi?", "Warning!", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var result1 = await rqs.DeleteReq1(MasterId, vacancyId);
                    if (result1 == 1)
                    {
                        MessageBox.Show("So'rov muvaffaqiyatli ravishda qabul qilindi!");
                    }
                    else if (result1 == 0)
                    {
                        MessageBox.Show("So'rovni allaqachon qabul qilgansiz");
                    }
                    else if (result1 == -1)
                    {
                        MessageBox.Show("Nomalum xatolik yuz berdi so'rovni qabul qilish vaqtida.");
                    }
                }
                catch
                {
                    MessageBox.Show("internet is slow!");
                }

            }
            else
            { }
        }

        private async void btnIgnore_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bu postni qabul qilmaysizmi?", "Warning!", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var result1 = await rqs.DeleteReq1(MasterId, vacancyId);
                    if (result1 == 1)
                    {
                        MessageBox.Show("Ushbu so'rpv muvaffaqiyatli ravishda o'chirildi!");
                    }
                    else if (result1 == 0)
                    {
                        MessageBox.Show("Ushbu so'rovni allaqachon o'chirgansiz.");
                    }
                    else if (result1 == -1)
                    {
                        MessageBox.Show("So'rovni o'chirish vaqtida qandaydir xatolik yuz berdi.");
                    }
                }
                catch
                {
                    MessageBox.Show("internet bilan muomo bor.");
                }

            }
            else
            { }
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AboutMasterWindow ms = new AboutMasterWindow();
            ms.ustaId = MasterId;
            ms.ShowDialog();
        }
    }
}
