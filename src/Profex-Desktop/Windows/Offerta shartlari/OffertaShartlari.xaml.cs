using System.Windows;

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
