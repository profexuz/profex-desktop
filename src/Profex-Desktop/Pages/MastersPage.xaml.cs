using Profex_Desktop.Components.MastersInfo;
using Profex_Integrated.Services.Masters;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for MastersPage.xaml
    /// </summary>
    public partial class MastersPage : Page
    {
        private MasterService _masterService = new MasterService();
        //private string BASE_URL = "http://localhost:5230/";
        private string BASE_URL = "http://64.227.42.134:4040/";
        
        public MastersPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Loading();
        }

        private async void Loading()
        {
            wrpMasters.Children.Clear();

            string[] maste = new string[5];
            var search = await _masterService.GetAllAsync();
            foreach (var master in search)
            {
                MasterInfo info = new MasterInfo();
                maste[0] = BASE_URL + master.ImagePath;
                maste[1] = (master.FirstName + " " + master.LastName);
                maste[2] = (master.PhoneNumber);
                maste[3] = master.IsFree ? "bo'sh" : "band";
                maste[4] = (master.CreatedAt.ToString());
                info.SetData(maste);
                wrpMasters.Children.Add(info);
            }
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            wrpMasters.Children.Clear();
            string[] maste = new string[5];
            if (txtSearch.Text.Length == 0)
            {
                Loading();
            }
            else
            {
                var search = await _masterService.SearchAsync($"{txtSearch.Text}");
                foreach (var master in search)
                {
                    MasterInfo info = new MasterInfo();
                    maste[0] = (master.ImagePath);
                    maste[1] = (master.FirstName + " " + master.LastName);
                    maste[2] = (master.PhoneNumber);
                    //maste[3] = (master.IsFree.ToString());
                    maste[3] = master.IsFree ? "bo'sh" : "band";
                    maste[4] = (master.CreatedAt.ToString());
                    info.SetData(maste);
                    wrpMasters.Children.Add(info);
                }
            }
        }
    }
}
