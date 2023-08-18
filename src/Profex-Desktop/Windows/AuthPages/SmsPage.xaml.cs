using Profex_Desktop.Windows.Auth;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Profex_Desktop.Windows.AuthPages
{
    /// <summary>
    /// Interaction logic for SmsPage.xaml
    /// </summary>
    public partial class SmsPage : Page
    {
        private DispatcherTimer timer;
        private int seconds;
        private int minut;
        private int totalSeconds = 5 * 60; // 5 minutni sekundga aylantiramiz
        private int remainingSeconds;
        public SmsPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize the timer
            InitializeComponent();
            
            remainingSeconds = totalSeconds;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick!;

            UpdateTimerDisplay(); // Soatni boshlang'ich ko'rsatish
            timer.Start();
            
        }
        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (remainingSeconds > 0)
            {
                remainingSeconds--;
                UpdateTimerDisplay();
            }
            else
            {
                timer.Stop();
                // Qo'shimcha: Soat tugaganida boshqa harakatlar bajarish mumkin
            }

            await Task.Delay(1000);
        }
        private void UpdateTimerDisplay()
        {
            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;
            lblSecond.Content = $"{minutes:D2}:{seconds:D2}";
        }

        private void ChangeNumber_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        private void NumberValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            
        }

        private void txtSmsCode_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (txtSmsCode.Text.Length == 4)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                AuthWindow authWindow = Window.GetWindow(this) as AuthWindow;
                authWindow?.Close();
            }
        }
    }
}
