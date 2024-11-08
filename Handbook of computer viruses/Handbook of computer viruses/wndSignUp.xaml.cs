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
    /// Логика взаимодействия для wndSignUp.xaml
    /// </summary>
    public partial class wndSignUp : Window
    {
        public wndSignUp()
        {
            InitializeComponent();
            frm_Load();
        }

        private void frm_Load()
        {
            if (wndEditing.THEME == "Темна") DarkTheme();
            if (wndEditing.THEME == "Світла") BrightTheme();
        }

        private void brdSignUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string login = txtLogin.Text;

            for (int i = 0; i < login.Length; i++)
            {
                if (((int)login[i]) >= 48 && ((int)login[i]) <= 57 ||
                    ((int)login[i]) >= 65 && ((int)login[i]) <= 90 ||
                    ((int)login[i]) >= 97 && ((int)login[i]) <= 122 ||
                    ((int)login[i]) == 46)
                {
                    try
                    {
                        StreamReader streamReader = new StreamReader("Data\\User\\User.txt");
                        string[] CutPageBreaks = streamReader.ReadToEnd().Split('\n');

                        string CutIsEqualTo = "";
                        for (int j = 0; j < CutPageBreaks.Length; j++)
                        {
                            CutIsEqualTo += CutPageBreaks[j] + "=";
                        }
                        string[] User = CutIsEqualTo.Split('=');


                        for (int j = 0; j < User.Length; j += 2)
                        {
                            if (User[j] == txtLogin.Text)
                            {
                                MessageBox.Show("Аккаунт з таким логіном вже існує", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }

                        streamReader.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Немає доступу до бази даних", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }


                    if (psbSignUpPassword_1.Password != psbSignUpPassword_2.Password)
                    {
                        MessageBox.Show("Паролі не співпадають", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        psbSignUpPassword_1.Password = "";
                        psbSignUpPassword_2.Password = "";
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Недопустимий символ", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            wndLogin.LOGIN = txtLogin.Text;
            wndLogin.PASSWORD = psbSignUpPassword_1.Password;

            try { File.AppendAllText("Data\\User\\User.txt", wndLogin.LOGIN + "=" + wndLogin.PASSWORD + "\n"); }
            catch (Exception) { MessageBox.Show("Немає доступу до бази даних", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error); }

            wndEditing _wndEditing = new wndEditing();
            _wndEditing.Show();
            this.Close();
        }

        private void DarkTheme()
        {
            brdMainInSignUp.Background = new SolidColorBrush(Color.FromRgb(30, 30, 78));
            lblSignUp.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));
            brdSignUp.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            brdSignUpEffectsMist.Color = Color.FromRgb(0, 255, 0);
            txtLogin.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            psbSignUpPassword_1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            psbSignUpPassword_2.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void BrightTheme()
        {
            brdMainInSignUp.Background = new SolidColorBrush(Color.FromRgb(242, 222, 44));
            lblSignUp.Foreground = new SolidColorBrush(Color.FromRgb(0, 128, 254));
            brdSignUp.Background = new SolidColorBrush(Color.FromRgb(0, 128, 254));
            brdSignUpEffectsMist.Color = Color.FromRgb(0, 128, 254);
            txtLogin.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            psbSignUpPassword_1.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            psbSignUpPassword_2.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void brdSignUp_MouseMove(object sender, MouseEventArgs e)
        {
            if (wndEditing.THEME == "Темна")
            {
                brdSignUp.Background = new SolidColorBrush(Color.FromRgb(200, 255, 200));
                brdSignUpEffectsMist.Color = Color.FromRgb(200, 255, 200);
            }
            else
            {
                brdSignUp.Background = new SolidColorBrush(Color.FromRgb(100, 188, 255));
                brdSignUpEffectsMist.Color = Color.FromRgb(100, 188, 255);
            }
        }

        private void brdSignUp_MouseLeave(object sender, MouseEventArgs e)
        {
            if (wndEditing.THEME == "Темна")
            {
                brdSignUp.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                brdSignUpEffectsMist.Color = Color.FromRgb(0, 255, 0);
            }
            else
            {
                brdSignUp.Background = new SolidColorBrush(Color.FromRgb(0, 128, 254));
                brdSignUpEffectsMist.Color = Color.FromRgb(0, 128, 254);
            }
        }
    }
}