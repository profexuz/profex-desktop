using Profex_Desktop.Windows.Auth;
using Profex_Dtos.Auth;
using Profex_Integrated.Services.Auth;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Profex_Desktop.Windows.AuthPages
{
    /// <summary>
    /// Interaction logic for UserSmsPage.xaml
    /// </summary>
    public partial class UserSmsPage : Page
    {
        private DispatcherTimer timer;
        private int totalSeconds = 5 * 60; // 5 minutni sekundga aylantiramiz
        private int remainingSeconds;
        private AuthUserService _authUserService = new AuthUserService();
        private VerifyRegisterDto _verifyRegisterDto = new VerifyRegisterDto();

        public string PhoneNum1 = String.Empty;
        public UserSmsPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            remainingSeconds = totalSeconds;
            txtSmsInfo.Text += " " + PhoneNum1;
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private async void txtSmsCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtSmsCode.Text.Length == 4)
                {
                    _verifyRegisterDto.PhoneNumber = PhoneNum1;
                    _verifyRegisterDto.Code = int.Parse(txtSmsCode.Text);
                    var result = await _authUserService.VerifyRegisterAsync(_verifyRegisterDto);
                    if (result.Result == true)
                    {
                        string fileName = @"C:\\Users\\Public\\Token.txt";
                        if (File.Exists(fileName))
                        {
                            File.Delete(fileName);
                        }
                        using (FileStream fs = File.Create(fileName))
                        {
                            // Add some text to file    
                            Byte[] title = new UTF8Encoding(true).GetBytes($"{result.Token}");
                            fs.Write(title, 0, title.Length);
                        }
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        AuthWindow authWindow = Window.GetWindow(this) as AuthWindow;
                        authWindow?.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tasdiqlash kodi noto'g'ri");
                    }
                }
            }
            catch
            {

            }
        }
    }
}
