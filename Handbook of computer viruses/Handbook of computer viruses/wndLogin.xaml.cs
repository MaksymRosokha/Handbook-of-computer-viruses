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
using System.Windows.Shapes;
using System.IO;

namespace Handbook_of_computer_viruses
{
    /// <summary>
    /// Логика взаимодействия для wndLogin.xaml
    /// </summary>
    public partial class wndLogin : Window
    {
        public static string LOGIN, PASSWORD;

        public wndLogin()
        {
            InitializeComponent();
            frm_Load();
        }

        private void frm_Load()
        {
            txtLogin.Text = LOGIN;
            psbPassword.Password = PASSWORD;

            //Загрузка зображень за замовчуванням
            try { imgLogin.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Data\\Photo\\Default\\User.png", UriKind.Absolute)); }
            catch (Exception) { }
            try { imgPassword.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Data\\Photo\\Default\\Lock.png", UriKind.Absolute)); }
            catch (Exception) { }

            if (wndEditing.THEME == "Темна") DarkTheme();
            if (wndEditing.THEME == "Світла") BrightTheme();
        }

        private void brdLogin_MouseDown(object sender, RoutedEventArgs e)
        {
            LOGIN = txtLogin.Text;
            PASSWORD = psbPassword.Password;

            try
            {
                StreamReader streamReader = new StreamReader("Data\\User\\User.txt");
                string[] CutPageBreaks = streamReader.ReadToEnd().Split('\n');

                string CutIsEqualTo = "";
                for (int i = 0; i < CutPageBreaks.Length; i++)
                {
                    CutIsEqualTo += CutPageBreaks[i] + "=";
                }
                string[] User = CutIsEqualTo.Split('=');


                for (int i = 0; i < User.Length; i += 2)
                {
                    if (LOGIN == User[i] && PASSWORD == User[i + 1])
                    {
                        wndEditing _wndEditing = new wndEditing();
                        _wndEditing.Show();
                        this.Close();
                        break;
                    }
                    else
                    {
                        //Для того, щоб MessageBox не викликався після кожного неспівпадіння з переліку аккаунтів
                        if (User.Length - i == 2)
                        {
                            if (LOGIN == "" || PASSWORD == "")
                            {
                                MessageBox.Show("Введіть логін і пароль", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                MessageBox.Show("Неправильне введений логін або пароль", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Немає доступу до бази даних", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void tbSignUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wndSignUp _wndRegistration = new wndSignUp();
            _wndRegistration.Show();

            txtLogin.Text = LOGIN;
            psbPassword.Password = PASSWORD;

            this.Close();
        }

        private void DarkTheme()
        {
            brdMainInLogin.Background = new SolidColorBrush(Color.FromRgb(30, 30, 78));
            lblLogin.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));
            brdLogin.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            brdLoginEffectsMist.Color = Color.FromRgb(0, 255, 0);
            rnSignUp.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            txtLogin.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            psbPassword.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void BrightTheme()
        {
            brdMainInLogin.Background = new SolidColorBrush(Color.FromRgb(242, 222, 44));
            lblLogin.Foreground = new SolidColorBrush(Color.FromRgb(0, 128, 254));
            brdLogin.Background = new SolidColorBrush(Color.FromRgb(0, 128, 254));
            brdLoginEffectsMist.Color = Color.FromRgb(0, 128, 254);
            rnSignUp.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            txtLogin.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            psbPassword.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void brdLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (wndEditing.THEME == "Темна")
            {
                brdLogin.Background = new SolidColorBrush(Color.FromRgb(200, 255, 200));
                brdLoginEffectsMist.Color = Color.FromRgb(200, 255, 200);
            }
            else
            {
                brdLogin.Background = new SolidColorBrush(Color.FromRgb(100, 188, 255));
                brdLoginEffectsMist.Color = Color.FromRgb(100, 188, 255);
            }
        }

        private void brdLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            if (wndEditing.THEME == "Темна")
            {
                brdLogin.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                brdLoginEffectsMist.Color = Color.FromRgb(0, 255, 0);
            }
            else
            {
                brdLogin.Background = new SolidColorBrush(Color.FromRgb(0, 128, 254));
                brdLoginEffectsMist.Color = Color.FromRgb(0, 128, 254);
            }
        }
    }
}