using Profex_Desktop.Components.MastersInfo;
using System.Windows;
using System.Windows.Controls;

namespace Profex_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for MastersPage.xaml
    /// </summary>
    public partial class MastersPage : Page
    {
        public MastersPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpMasters.Children.Clear();
            for (int i = 0; i < 30; i++)
            {
                MasterInfo info = new MasterInfo();
                wrpMasters.Children.Add(info);
            }
        }
    }
}
