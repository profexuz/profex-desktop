﻿using Profex_Desktop.Components.MastersInfo;
using Profex_Integrated.Helpers;
using Profex_Integrated.Services.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for UserMastersPage.xaml
    /// </summary>
    public partial class UserMastersPage : Page
    {
        private MasterService _masterService = new MasterService();
        public UserMastersPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            {
                Loading();
            }
        }

        private async void Loading()
        {
            wrpMasters.Children.Clear();

            string[] maste = new string[5];
            var search = await _masterService.GetAllAsync();
            foreach (var master in search)
            {
                MasterInfo info = new MasterInfo();
                maste[0] = API.BASEIMG_URL + master.ImagePath;
                maste[1] = (master.FirstName + " " + master.LastName);
                maste[2] = (master.PhoneNumber);
                maste[3] = master.IsFree ? "bo'sh" : "band";
                maste[4] = (master.CreatedAt.ToString());
                info.SetData(maste);
                wrpMasters.Children.Add(info);
                loader.Visibility = Visibility.Collapsed;
            }
        }
        public async Task RefreshAsync()
        {
            wrpMasters.Children.Clear();

            string[] maste = new string[5];
            var search = await _masterService.GetAllAsync();
            foreach (var master in search)
            {
                MasterInfo info = new MasterInfo();
                maste[0] = API.BASEIMG_URL + master.ImagePath;
                maste[1] = (master.FirstName + " " + master.LastName);
                maste[2] = (master.PhoneNumber);
                maste[3] = master.IsFree ? "bo'sh" : "band";
                maste[4] = (master.CreatedAt.ToString());
                info.SetData(maste);
                wrpMasters.Children.Add(info);
                loader.Visibility = Visibility.Collapsed;
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

                    maste[0] =API.BASEIMG_URL + master.ImagePath;
                    maste[1] = (master.FirstName + " " + master.LastName);
                    maste[2] = (master.PhoneNumber);
                    maste[3] = master.IsFree ? "bo'sh" : "band";
                    maste[4] = (master.CreatedAt.ToString());
                    info.SetData(maste);
                    wrpMasters.Children.Add(info);
                }
            }
        }


    }
}
