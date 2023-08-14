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
        public void SetData(string[] salom)
        {
            ProfileImg.ImageSource = new BitmapImage(new Uri(salom[0], UriKind.Relative));
            var bc = new BrushConverter();
            brBackgr.Background = (Brush)bc.ConvertFrom(salom[2])!;
            NameOfMaster.Content = salom[1];
        }
    }
}
