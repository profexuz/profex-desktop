﻿using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Profex_Desktop.Components.MasterContact
{
    /// <summary>
    /// Interaction logic for MasterContactControl.xaml
    /// </summary>
    public partial class MasterContactControl : UserControl
    {
        public MasterContactControl()
        {
            InitializeComponent();
        }
        public async void SetData(string[] salom)
        {
            Uri imageparse = new Uri(salom[0], UriKind.Absolute);
            ProfileImg.ImageSource = new BitmapImage(imageparse);
            var bc = new BrushConverter();
            NameOfMaster.Content = salom[1];
            brBackgr.Background = (Brush)bc.ConvertFrom(salom[2])!;
        }
    }
}
