﻿using System;
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
using System.Windows.Shapes;

namespace Profex_Desktop.Windows.Offerta_shartlari
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class OffertaShartlari : Window
    {
        public OffertaShartlari()
        {
            InitializeComponent();
        }

        private void btnBack_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
