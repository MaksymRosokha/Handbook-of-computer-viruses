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

namespace Handbook_of_computer_viruses
{
    /// <summary>
    /// Логика взаимодействия для wndEditing.xaml
    /// </summary>
    public partial class wndEditing : Window
    {
        public static string THEME = "Темна"; //Тема
        public static int FONT_SIZE = 24; //Розмір шрифту
        public static int FONT_COLOR = 0;//Колір шрифту
        public static int FONT_TYPE = 0;//Тип шрифту
        public static bool TEXT_EDITING = true;//Редагування тексту

        public wndEditing()
        {
            InitializeComponent();
            frm_Load();
        }

        private void frm_Load()
        {
            if (THEME == "Темна")
            {
                rdbDarkTheme.IsChecked = true;
                DarkTheme();
            }
            else
            {
                rdbBrightTheme.IsChecked = true;
                BrightTheme();
            }

            txtFontSize.Text = FONT_SIZE.ToString();

            cmbForeground.SelectedIndex = FONT_COLOR;
            cmbFontType.SelectedIndex = FONT_TYPE;

            if (TEXT_EDITING == true)
            {
                rdbReading.IsChecked = true;
            }
            else
            {
                rdbEditing.IsChecked = true;
            }
        }

        private void brdEditing_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rdbDarkTheme.IsChecked == true) THEME = "Темна";
            if (rdbBrightTheme.IsChecked == true) THEME = "Світла"; 
            
            FONT_COLOR = cmbForeground.SelectedIndex;
            FONT_TYPE = cmbFontType.SelectedIndex;

            if (rdbEditing.IsChecked == true) TEXT_EDITING = false;
            if (rdbReading.IsChecked == true) TEXT_EDITING = true;

            try
            {
                FONT_SIZE = int.Parse(txtFontSize.Text);

                if (FONT_SIZE > 7)
                {
                    this.Close();
                }
                else
                {
                    FONT_SIZE = 25;
                    txtFontSize.Text = FONT_SIZE.ToString();
                    MessageBox.Show("Розмір шрифту не може бути < 8", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неправильно введені дані", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DarkTheme()
        {
            brdMainInEditing.Background = new SolidColorBrush(Color.FromRgb(30, 30, 78));
            lblEditing.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));
            brdEditing.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            brdEditingEffectsMist.Color = Color.FromRgb(0, 255, 0);
            brdTheme.Background = new SolidColorBrush(Color.FromRgb(155, 5, 255));
            brdEffectsMistTheme.Color = Color.FromRgb(155, 5, 255);
            brdFontSize.Background = new SolidColorBrush(Color.FromRgb(155, 5, 255));
            brdEffectsMistFontSize.Color = Color.FromRgb(155, 5, 255);
            brdForeground.Background = new SolidColorBrush(Color.FromRgb(155, 5, 255));
            brdEffectsMistForeground.Color = Color.FromRgb(155, 5, 255);
            cmbForeground.Background = new SolidColorBrush(Color.FromRgb(214, 168, 244));
            brdFontType.Background = new SolidColorBrush(Color.FromRgb(155, 5, 255));
            brdEffectsMistFontType.Color = Color.FromRgb(155, 5, 255);
            cmbFontType.Background = new SolidColorBrush(Color.FromRgb(214, 168, 244));
            brdTextEditing.Background = new SolidColorBrush(Color.FromRgb(155, 5, 255));
            brdEffectsMistTextEditing.Color = Color.FromRgb(155, 5, 255);
            txtFontSize.Background = new SolidColorBrush(Color.FromRgb(214, 168, 244));
        }

        private void BrightTheme()
        {
            brdMainInEditing.Background = new SolidColorBrush(Color.FromRgb(242, 222, 44));
            lblEditing.Foreground = new SolidColorBrush(Color.FromRgb(0, 128, 254));
            brdEditing.Background = new SolidColorBrush(Color.FromRgb(0, 128, 254));
            brdEditingEffectsMist.Color = Color.FromRgb(0, 128, 254);
            brdTheme.Background = new SolidColorBrush(Color.FromRgb(255, 5, 5));
            brdEffectsMistTheme.Color = Color.FromRgb(255, 5, 5);
            brdFontSize.Background = new SolidColorBrush(Color.FromRgb(255, 5, 5));
            brdEffectsMistFontSize.Color = Color.FromRgb(255, 5, 5);
            brdForeground.Background = new SolidColorBrush(Color.FromRgb(255, 5, 5));
            brdEffectsMistForeground.Color = Color.FromRgb(255, 5, 5);
            cmbForeground.Background = new SolidColorBrush(Color.FromRgb(205, 5, 5));
            brdFontType.Background = new SolidColorBrush(Color.FromRgb(255, 5, 5));
            brdEffectsMistFontType.Color = Color.FromRgb(255, 5, 5);
            cmbFontType.Background = new SolidColorBrush(Color.FromRgb(205, 5, 5));
            brdTextEditing.Background = new SolidColorBrush(Color.FromRgb(255, 5, 5));
            brdEffectsMistTextEditing.Color = Color.FromRgb(255, 5, 5);
            txtFontSize.Background = new SolidColorBrush(Color.FromRgb(205, 5, 5));
        }

        private void brdEditing_MouseMove(object sender, MouseEventArgs e)
        {
            if (wndEditing.THEME == "Темна")
            {
                brdEditing.Background = new SolidColorBrush(Color.FromRgb(200, 255, 200));
                brdEditingEffectsMist.Color = Color.FromRgb(200, 255, 200);
            }
            else
            {
                brdEditing.Background = new SolidColorBrush(Color.FromRgb(100, 188, 255));
                brdEditingEffectsMist.Color = Color.FromRgb(100, 188, 255);
            }
        }

        private void brdEditing_MouseLeave(object sender, MouseEventArgs e)
        {
            if (wndEditing.THEME == "Темна")
            {
                brdEditing.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                brdEditingEffectsMist.Color = Color.FromRgb(0, 255, 0);
            }
            else
            {
                brdEditing.Background = new SolidColorBrush(Color.FromRgb(0, 128, 254));
                brdEditingEffectsMist.Color = Color.FromRgb(0, 128, 254);
            }
        }
    }
}
