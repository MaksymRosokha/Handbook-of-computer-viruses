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
using System.IO;

namespace Handbook_of_computer_viruses
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string PathToContent = "Data\\";//Папка з зовнішніми файлами

        StackPanel pnlTypesOfViruses = new StackPanel();
        StackPanel pnlRemovalMethods = new StackPanel();
        StackPanel pnlAboutAntivirusPrograms = new StackPanel();
        StackPanel pnlMethodsOfFindingViruses = new StackPanel();
        StackPanel pnlPopularAntivirusPrograms = new StackPanel();

        public MainWindow()
        {
            InitializeComponent();
            frmMain_Load();//Виклик функції при запуску програми
        }

        private void frmMain_Load()
        {
            //Загрузка зображень за замовчуванням
            DirectoryInfo dirPhoto = new DirectoryInfo("\\" + PathToContent + "Photo\\Default\\");

            try { imgMenu.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "Background for menu.png", UriKind.Absolute)); }
            catch (Exception) { }
            try { imgIcon.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "Main icon.png", UriKind.Absolute)); }
            catch (Exception) { }

            #region Загрузка дочірніх кнопок для кнопок навігації
            //Загрузка кнопок під кнопку "Комп'ютерний вірус"
            try
            {
                DirectoryInfo dirComputerVirus = new DirectoryInfo(PathToContent + "Text\\Computer virus");
                FileInfo[] arrayComputerVirus = dirComputerVirus.GetFiles();
                for (int i = 0; i < arrayComputerVirus.Length; i++)
                {
                    Button btnComputerVirusChilgren = new Button();
                    string txtComputerVirus = arrayComputerVirus[i] + "";
                    txtComputerVirus = txtComputerVirus.Replace(".txt", "");
                    txtComputerVirus = txtComputerVirus.Replace(i + ". ", "");
                    btnComputerVirusChilgren.Content = txtComputerVirus;
                    btnComputerVirusChilgren.ToolTip = txtComputerVirus;
                    btnComputerVirusChilgren.Style = (Style)Resources["UnderButtons"];
                    pnlComputerVirus.Children.Add(btnComputerVirusChilgren);
                    btnComputerVirusChilgren.Click += ButtonsNavigation_Click;

                    if (i == 2)
                    {
                        pnlComputerVirus.Children.Add(pnlTypesOfViruses);

                        var dirTypesOfViruses = new DirectoryInfo(PathToContent + "Text\\Computer virus\\Types of viruses");
                        FileInfo[] arrayTypesOfViruses = dirTypesOfViruses.GetFiles();

                        for (int j = 0; j < arrayTypesOfViruses.Length; j++)
                        {
                            Button btnTypesOfViruses = new Button();
                            string txtTypesOfViruses = arrayTypesOfViruses[j] + "";
                            txtTypesOfViruses = txtTypesOfViruses.Replace(".txt", "");
                            txtTypesOfViruses = txtTypesOfViruses.Replace(j + ". ", "");
                            btnTypesOfViruses.Content = txtTypesOfViruses;
                            btnTypesOfViruses.ToolTip = txtTypesOfViruses;
                            pnlTypesOfViruses.Children.Add(btnTypesOfViruses);
                            btnTypesOfViruses.Click += ButtonsNavigation_Click;
                        }
                    }
                }
            }
            catch (Exception) { }



            //Загрузка кнопок під кнопку "Уникнення зараження"
            try
            {
                var dirAvoidInfection = new DirectoryInfo(PathToContent + "Text\\Avoid infection");
                FileInfo[] arrayAvoidInfection = dirAvoidInfection.GetFiles();
                for (int i = 0; i < arrayAvoidInfection.Length; i++)
                {
                    Button btnAvoidInfectionChildren = new Button();
                    string txtAvoidInfection = arrayAvoidInfection[i] + "";
                    txtAvoidInfection = txtAvoidInfection.Replace(".txt", "");
                    txtAvoidInfection = txtAvoidInfection.Replace(i + ". ", "");
                    btnAvoidInfectionChildren.Content = txtAvoidInfection;
                    btnAvoidInfectionChildren.ToolTip = txtAvoidInfection;
                    btnAvoidInfectionChildren.Style = (Style)Resources["UnderButtons"];
                    pnlAvoidInfection.Children.Add(btnAvoidInfectionChildren);
                    btnAvoidInfectionChildren.Click += ButtonsNavigation_Click;
                }
            }
            catch (Exception) { }


            //Загрузка кнопок під кнопку "Видалення вірусів"
            try
            {
                var dirVirusRemoval = new DirectoryInfo(PathToContent + "Text\\Virus removal");
                FileInfo[] arrayVirusRemoval = dirVirusRemoval.GetFiles();
                for (int i = 0; i < arrayVirusRemoval.Length; i++)
                {
                    Button btnVirusRemovalChildren = new Button();
                    string txtVirusRemoval = arrayVirusRemoval[i] + "";
                    txtVirusRemoval = txtVirusRemoval.Replace(".txt", "");
                    txtVirusRemoval = txtVirusRemoval.Replace(i + ". ", "");
                    btnVirusRemovalChildren.Content = txtVirusRemoval;
                    btnVirusRemovalChildren.ToolTip = txtVirusRemoval;
                    btnVirusRemovalChildren.Style = (Style)Resources["UnderButtons"];
                    pnlVirusRemoval.Children.Add(btnVirusRemovalChildren);
                    btnVirusRemovalChildren.Click += ButtonsNavigation_Click;

                    //Способи видалення вірусів
                    if (i == 1)
                    {
                        pnlVirusRemoval.Children.Add(pnlRemovalMethods);

                        var dirRemovalMethods = new DirectoryInfo(PathToContent + "Text\\Virus removal\\Removal methods");
                        FileInfo[] arrayRemovalMethods = dirRemovalMethods.GetFiles();

                        for (int j = 0; j < arrayRemovalMethods.Length; j++)
                        {
                            Button btnRemovalMethods = new Button();
                            string txtRemovalMethods = arrayRemovalMethods[j] + "";
                            txtRemovalMethods = txtRemovalMethods.Replace(".txt", "");
                            txtRemovalMethods = txtRemovalMethods.Replace(j + ". ", "");
                            btnRemovalMethods.Content = txtRemovalMethods;
                            btnRemovalMethods.ToolTip = txtRemovalMethods;
                            pnlRemovalMethods.Children.Add(btnRemovalMethods);
                            btnRemovalMethods.Click += ButtonsNavigation_Click;
                        }
                    }
                }
            }
            catch (Exception) { }


            //Загрузка кнопок під кнопку "Антивірусні програми"
            try
            {
                var dirAntivirusPrograms = new DirectoryInfo(PathToContent + "Text\\Antivirus programs");
                FileInfo[] arrayAntivirusPrograms = dirAntivirusPrograms.GetFiles();
                for (int i = 0; i < arrayAntivirusPrograms.Length; i++)
                {
                    Button btnAntivirusProgramsChildren = new Button();
                    string txtAntivirusPrograms = arrayAntivirusPrograms[i] + "";
                    txtAntivirusPrograms = txtAntivirusPrograms.Replace(".txt", "");
                    txtAntivirusPrograms = txtAntivirusPrograms.Replace(i + ". ", "");
                    btnAntivirusProgramsChildren.Content = txtAntivirusPrograms;
                    btnAntivirusProgramsChildren.ToolTip = txtAntivirusPrograms;
                    btnAntivirusProgramsChildren.Style = (Style)Resources["UnderButtons"];
                    pnlAntivirusPrograms.Children.Add(btnAntivirusProgramsChildren);
                    btnAntivirusProgramsChildren.Click += ButtonsNavigation_Click;

                    //Антивірусна програма
                    if (i == 0)
                    {
                        pnlAntivirusPrograms.Children.Add(pnlAboutAntivirusPrograms);

                        var dirAboutAntivirusPrograms = new DirectoryInfo(PathToContent + "Text\\Antivirus programs\\Antivirus program");
                        FileInfo[] arrayAboutAntivirusPrograms = dirAboutAntivirusPrograms.GetFiles();

                        for (int j = 0; j < arrayAboutAntivirusPrograms.Length; j++)
                        {
                            Button btnAboutAntivirusPrograms = new Button();
                            string txtAboutAntivirusPrograms = arrayAboutAntivirusPrograms[j] + "";
                            txtAboutAntivirusPrograms = txtAboutAntivirusPrograms.Replace(".txt", "");
                            txtAboutAntivirusPrograms = txtAboutAntivirusPrograms.Replace(j + ". ", "");
                            btnAboutAntivirusPrograms.Content = txtAboutAntivirusPrograms;
                            btnAboutAntivirusPrograms.ToolTip = txtAboutAntivirusPrograms;
                            pnlAboutAntivirusPrograms.Children.Add(btnAboutAntivirusPrograms);
                            btnAboutAntivirusPrograms.Click += ButtonsNavigation_Click;

                            //Методи відшукання вірусів
                            if (j == 4)
                            {
                                pnlAboutAntivirusPrograms.Children.Add(pnlMethodsOfFindingViruses);

                                var dirMethodsOfFindingViruses = new DirectoryInfo(PathToContent + "Text\\Antivirus programs\\Antivirus program\\Methods of finding viruses");
                                FileInfo[] arrayMethodsOfFindingViruses = dirMethodsOfFindingViruses.GetFiles();

                                for (int k = 0; k < arrayMethodsOfFindingViruses.Length; k++)
                                {
                                    Button btnMethodsOfFindingViruses = new Button();
                                    string txtMethodsOfFindingViruses = arrayMethodsOfFindingViruses[k].Name;
                                    txtMethodsOfFindingViruses = txtMethodsOfFindingViruses.Replace(".txt", "");
                                    txtMethodsOfFindingViruses = txtMethodsOfFindingViruses.Replace(k + ". ", "");
                                    btnMethodsOfFindingViruses.Content = txtMethodsOfFindingViruses;
                                    btnMethodsOfFindingViruses.ToolTip = txtMethodsOfFindingViruses;
                                    btnMethodsOfFindingViruses.Padding = new Thickness(85, 0, 0, 0);
                                    btnMethodsOfFindingViruses.FontSize = 12;
                                    pnlMethodsOfFindingViruses.Children.Add(btnMethodsOfFindingViruses);
                                    btnMethodsOfFindingViruses.Click += ButtonsNavigation_Click;
                                }
                            }
                        }
                    }

                    //Популярні антивірусні програми
                    if (i == 1)
                    {
                        pnlAntivirusPrograms.Children.Add(pnlPopularAntivirusPrograms);

                        var dirPopularAntivirusPrograms = new DirectoryInfo(PathToContent + "Text\\Antivirus programs\\List of popular antivirus programs");
                        FileInfo[] arrayPopularAntivirusPrograms = dirPopularAntivirusPrograms.GetFiles();

                        for (int j = 0; j < arrayPopularAntivirusPrograms.Length; j++)
                        {
                            Button btnPopularAntivirusPrograms = new Button();
                            string txtPopularAntivirusPrograms = arrayPopularAntivirusPrograms[j] + "";
                            txtPopularAntivirusPrograms = txtPopularAntivirusPrograms.Replace(".txt", "");
                            txtPopularAntivirusPrograms = txtPopularAntivirusPrograms.Replace(j + ". ", "");
                            btnPopularAntivirusPrograms.Content = txtPopularAntivirusPrograms;
                            btnPopularAntivirusPrograms.ToolTip = txtPopularAntivirusPrograms;
                            pnlPopularAntivirusPrograms.Children.Add(btnPopularAntivirusPrograms);
                            btnPopularAntivirusPrograms.Click += ButtonsNavigation_Click;
                        }
                    }
                }
            }
            catch (Exception) { }
            #endregion
        }

        //Загрузка текстів з файлів
        private void ButtonsNavigation_Click(object sender, RoutedEventArgs e)
        {
            var dirComputerVirus = new DirectoryInfo(PathToContent + "Text\\Computer virus");
            var dirTypesOfViruses = new DirectoryInfo(dirComputerVirus + "\\Types of viruses");
            var dirAvoidInfection = new DirectoryInfo(PathToContent + "Text\\Avoid infection");
            var dirVirusRemoval = new DirectoryInfo(PathToContent + "Text\\Virus removal");
            var dirRemovalMethods = new DirectoryInfo(dirVirusRemoval + "\\Removal methods");
            var dirAntivirusPrograms = new DirectoryInfo(PathToContent + "Text\\Antivirus programs");
            var dirAboutAntivirusPrograms = new DirectoryInfo(dirAntivirusPrograms + "\\Antivirus program");
            var dirMethodsOfFindingViruses = new DirectoryInfo(dirAboutAntivirusPrograms + "\\Methods of finding viruses");
            var dirPopularAntivirusPrograms = new DirectoryInfo(dirAntivirusPrograms + "\\List of popular antivirus programs");

            //Масиви файлів
            FileInfo[] arrayComputerVirus = dirComputerVirus.GetFiles();
            FileInfo[] arrayTypesOfViruses = dirTypesOfViruses.GetFiles();
            FileInfo[] arrayAvoidInfection = dirAvoidInfection.GetFiles();
            FileInfo[] arrayVirusRemoval = dirVirusRemoval.GetFiles();
            FileInfo[] arrayRemovalMethods = dirRemovalMethods.GetFiles();
            FileInfo[] arrayAntivirusPrograms = dirAntivirusPrograms.GetFiles();
            FileInfo[] arrayAboutAntivirusProgram = dirAboutAntivirusPrograms.GetFiles();
            FileInfo[] arrayMethodsOfFindingViruses = dirMethodsOfFindingViruses.GetFiles();
            FileInfo[] arrayPopularAntivirusPrograms = dirPopularAntivirusPrograms.GetFiles();

            //Content підкнопок
            string title = "";
            try
            {
                title = ((Button)sender).Content.ToString();
                lblTitle.Content = title;
            }
            catch (Exception) { }
            
            //Комп'ютерний вірус
            try
            {
                for (int i = 0; i < arrayComputerVirus.Length; i++)
                {
                    if (arrayComputerVirus[i].Name == i + ". " + title + ".txt" ||
                        arrayComputerVirus[i].Name == title ||
                        arrayComputerVirus[i].Name == title + ".txt")
                    {
                        StreamReader fileContentText = new StreamReader(dirComputerVirus + "\\" + arrayComputerVirus[i]);//Текстовий файл
                        txtTextComputerVirus.Text = fileContentText.ReadToEnd();
                        mnuLinkToTheProgram.Visibility = Visibility.Collapsed;
                        fileContentText.Close();
                    }
                }
            }
            catch (Exception) { txtTextComputerVirus.Text = "Інформація відсутня!"; }
            //Типи вірусів
            try
            {
                for (int i = 0; i < arrayTypesOfViruses.Length; i++)
                {
                    if (arrayTypesOfViruses[i].Name == i + ". " + title + ".txt" ||
                        arrayTypesOfViruses[i].Name == title ||
                        arrayTypesOfViruses[i].Name == title + ".txt")
                    {
                        StreamReader fileContentText = new StreamReader(dirTypesOfViruses + "\\" + arrayTypesOfViruses[i]);//Текстовий файл
                        txtTextComputerVirus.Text = fileContentText.ReadToEnd();
                        mnuLinkToTheProgram.Visibility = Visibility.Collapsed;
                        fileContentText.Close();
                    }
                }
            }
            catch (Exception) { txtTextComputerVirus.Text = "Інформація відсутня!"; }
            //Уникнення зараження
            try
            {
                for (int i = 0; i < arrayAvoidInfection.Length; i++)
                {
                    if (arrayAvoidInfection[i].Name == i + ". " + title + ".txt" ||
                        arrayAvoidInfection[i].Name == title ||
                        arrayAvoidInfection[i].Name == title + ".txt")
                    {
                        StreamReader fileContentText = new StreamReader(dirAvoidInfection + "\\" + arrayAvoidInfection[i]);//Текстовий файл
                        txtTextComputerVirus.Text = fileContentText.ReadToEnd();
                        mnuLinkToTheProgram.Visibility = Visibility.Collapsed;
                        fileContentText.Close();
                    }
                }
            }
            catch (Exception) { txtTextComputerVirus.Text = "Інформація відсутня!"; }
            //Видалення вірусів
            try
            {
                for (int i = 0; i < arrayVirusRemoval.Length; i++)
                {
                    if (arrayVirusRemoval[i].Name == i + ". " + title + ".txt" ||
                        arrayVirusRemoval[i].Name == title ||
                        arrayVirusRemoval[i].Name == title + ".txt")
                    {
                        StreamReader fileContentText = new StreamReader(dirVirusRemoval + "\\" + arrayVirusRemoval[i]);//Текстовий файл
                        txtTextComputerVirus.Text = fileContentText.ReadToEnd();
                        mnuLinkToTheProgram.Visibility = Visibility.Collapsed;
                        fileContentText.Close();
                    }
                }
            }
            catch (Exception) { txtTextComputerVirus.Text = "Інформація відсутня!"; }
            //Методи видалення
            try
            {
                for (int i = 0; i < arrayRemovalMethods.Length; i++)
                {
                    if (arrayRemovalMethods[i].Name == i + ". " + title + ".txt" ||
                        arrayRemovalMethods[i].Name == title ||
                        arrayRemovalMethods[i].Name == title + ".txt")
                    {
                        StreamReader fileContentText = new StreamReader(dirRemovalMethods + "\\" + arrayRemovalMethods[i]);//Текстовий файл
                        txtTextComputerVirus.Text = fileContentText.ReadToEnd();
                        mnuLinkToTheProgram.Visibility = Visibility.Collapsed;
                        fileContentText.Close();

                        if (title == "Застосування повноцінного антивіруса")
                        {
                            mnuLinkToTheProgram.Visibility = Visibility.Visible;
                            mnuLinkToTheProgram.Header = "Завантажити Avast Free Antivirus";
                        }
                    }
                }
            }
            catch (Exception) { txtTextComputerVirus.Text = "Інформація відсутня!"; }
            //Антивірусні програми
            try
            {
                for (int i = 0; i < arrayAntivirusPrograms.Length; i++)
                {
                    if (arrayAntivirusPrograms[i].Name == i + ". " + title + ".txt" ||
                        arrayAntivirusPrograms[i].Name == title ||
                        arrayAntivirusPrograms[i].Name == title + ".txt")
                    {
                        StreamReader fileContentText = new StreamReader(dirAntivirusPrograms + "\\" + arrayAntivirusPrograms[i]);//Текстовий файл
                        txtTextComputerVirus.Text = fileContentText.ReadToEnd();
                        mnuLinkToTheProgram.Visibility = Visibility.Collapsed;
                        fileContentText.Close();
                    }
                }
            }
            catch (Exception) { txtTextComputerVirus.Text = "Інформація відсутня!"; }
            //Про антивірусну програму
            try
            {
                for (int i = 0; i < arrayAboutAntivirusProgram.Length; i++)
                {
                    if (arrayAboutAntivirusProgram[i].Name == i + ". " + title + ".txt" ||
                        arrayAboutAntivirusProgram[i].Name == title ||
                        arrayAboutAntivirusProgram[i].Name == title + ".txt")
                    {
                        StreamReader fileContentText = new StreamReader(dirAboutAntivirusPrograms + "\\" + arrayAboutAntivirusProgram[i]);//Текстовий файл
                        txtTextComputerVirus.Text = fileContentText.ReadToEnd();
                        mnuLinkToTheProgram.Visibility = Visibility.Collapsed;
                        fileContentText.Close();
                    }
                }
            }
            catch (Exception) { txtTextComputerVirus.Text = "Інформація відсутня!"; }
            //Методи відшукання вірусів
            try
            {
                for (int i = 0; i < arrayMethodsOfFindingViruses.Length; i++)
                {
                    if (arrayMethodsOfFindingViruses[i].Name == i + ". " + title + ".txt" ||
                        arrayMethodsOfFindingViruses[i].Name == title ||
                        arrayMethodsOfFindingViruses[i].Name == title + ".txt")
                    {
                        StreamReader fileContentText = new StreamReader(dirMethodsOfFindingViruses + "\\" + arrayMethodsOfFindingViruses[i]);//Текстовий файл
                        txtTextComputerVirus.Text = fileContentText.ReadToEnd();
                        mnuLinkToTheProgram.Visibility = Visibility.Collapsed;
                        fileContentText.Close();
                    }
                }
            }
            catch (Exception) { txtTextComputerVirus.Text = "Інформація відсутня!"; }
            //Список попуярних антивірусних програм
            try
            {
                for (int i = 0; i < arrayPopularAntivirusPrograms.Length; i++)
                {
                    if (arrayPopularAntivirusPrograms[i].Name == i + ". " + title + ".txt" ||
                        arrayPopularAntivirusPrograms[i].Name == title ||
                        arrayPopularAntivirusPrograms[i].Name == title + ".txt")
                    {
                        StreamReader fileContentText = new StreamReader(dirPopularAntivirusPrograms + "\\" + arrayPopularAntivirusPrograms[i]);//Текстовий файл
                        txtTextComputerVirus.Text = fileContentText.ReadToEnd();
                        mnuLinkToTheProgram.Visibility = Visibility.Visible;
                        mnuLinkToTheProgram.Header = "Завантажити " + title;
                        fileContentText.Close();
                    }
                }
            }
            catch (Exception) { txtTextComputerVirus.Text = "Інформація відсутня!"; }
        }

        #region Дії, що відбуваються після натискання головних кнопок навігації
        private void btnComputerVirus_Click(object sender, RoutedEventArgs e)
        {
            if (pnlComputerVirus.Visibility == Visibility.Collapsed)
            {
                ClosingUnderButtons();
                pnlComputerVirus.Visibility = Visibility.Visible;
            }
            else
            {
                ClosingUnderButtons();
            }

            MainTextPage.Visibility = Visibility.Visible;
            imgMenu.Visibility = Visibility.Collapsed;
        }

        private void btnAvoidInfection_Click(object sender, RoutedEventArgs e)
        {
            if (pnlAvoidInfection.Visibility == Visibility.Collapsed)
            {
                ClosingUnderButtons();
                pnlAvoidInfection.Visibility = Visibility.Visible;
            }
            else
            {
                ClosingUnderButtons();
            }

            MainTextPage.Visibility = Visibility.Visible;
            imgMenu.Visibility = Visibility.Collapsed;
        }

        private void btnVirusRemoval_Click(object sender, RoutedEventArgs e)
        {
            if (pnlVirusRemoval.Visibility == Visibility.Collapsed)
            {
                ClosingUnderButtons();
                pnlVirusRemoval.Visibility = Visibility.Visible;
            }
            else
            {
                ClosingUnderButtons();
            }

            MainTextPage.Visibility = Visibility.Visible;
            imgMenu.Visibility = Visibility.Collapsed;
        }

        private void btnAntivirusPrograms_Click(object sender, RoutedEventArgs e)
        {
            if (pnlAntivirusPrograms.Visibility == Visibility.Collapsed)
            {
                ClosingUnderButtons();
                pnlAntivirusPrograms.Visibility = Visibility.Visible;
            }
            else
            {
                ClosingUnderButtons();
            }

            MainTextPage.Visibility = Visibility.Visible;
            imgMenu.Visibility = Visibility.Collapsed;
        }

        private void btnBackToTheMenu_Click(object sender, RoutedEventArgs e)
        {
            ClosingUnderButtons();
            MainTextPage.Visibility = Visibility.Collapsed;
            imgMenu.Visibility = Visibility.Visible;
            lblTitle.Content = "Довідник по комп'ютерним вірусам";
            txtTextComputerVirus.Text = "";
            mnuLinkToTheProgram.Visibility = Visibility.Collapsed;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion

        //Функція якв закриває всі підкнопки меню
        private void ClosingUnderButtons()
        {
            pnlComputerVirus.Visibility = Visibility.Collapsed;
            pnlAvoidInfection.Visibility = Visibility.Collapsed;
            pnlVirusRemoval.Visibility = Visibility.Collapsed;
            pnlAntivirusPrograms.Visibility = Visibility.Collapsed;
        }

        //Ссилки на антивірусні програми
        private void btnLinkToTheProgram_Click(object sender, RoutedEventArgs e)
        {
            switch (mnuLinkToTheProgram.Header)
            {
                case "Завантажити Junkware Removal Tool":
                    {
                        System.Diagnostics.Process.Start("https://ru.malwarebytes.com/junkwareremovaltool/");
                        break;
                    }
                case "Завантажити Zemana AntiMalware":
                    {
                        System.Diagnostics.Process.Start("https://www.zemana.com/antimalware");
                        break;
                    }
                case "Завантажити CrowdInspect":
                    {
                        System.Diagnostics.Process.Start("https://www.crowdstrike.com/resources/crowdinspect/");
                        break;
                    }
                case "Завантажити Spybot Search and Destroy":
                    {
                        System.Diagnostics.Process.Start("https://www.safer-networking.org/");
                        break;
                    }
                case "Завантажити AdwCleaner":
                    {
                        System.Diagnostics.Process.Start("https://toolslib.net/downloads/viewdownload/1-adwcleaner/");
                        break;
                    }
                case "Завантажити Malwarebytes Anti-Malware":
                    {
                        System.Diagnostics.Process.Start("https://ru.malwarebytes.com/premium/");
                        break;
                    }
                case "Завантажити Hitman Pro":
                    {
                        System.Diagnostics.Process.Start("https://www.hitmanpro.com/en-us");
                        break;
                    }
                case "Завантажити Dr.Web CureIt":
                    {
                        System.Diagnostics.Process.Start("https://free.dataprotection.com.ua/cureit/");
                        break;
                    }
                case "Завантажити Kaspersky Rescue Disk":
                    {
                        System.Diagnostics.Process.Start("https://www.kaspersky.co.uk/free-antivirus");
                        break;
                    }
                case "Завантажити Avast Free Antivirus":
                    {
                        System.Diagnostics.Process.Start("https://www.avast.ua/index#pc");
                        break;
                    }
            }
        }

        //Про автора
        private void mnuAboutTheAuthor_Click(object sender, RoutedEventArgs e)
        {
            MainTextPage.Visibility = Visibility.Visible;
            mnuLinkToTheProgram.Visibility = Visibility.Collapsed;
            imgMenu.Visibility = Visibility.Collapsed;

            try
            {
                StreamReader fileContentText = new StreamReader(PathToContent + "Text\\About the author\\Про автора.txt");//Текстовий файл
                txtTextComputerVirus.Text = fileContentText.ReadToEnd();
            }
            catch (Exception) { txtTextComputerVirus.Text = "Інформація відсутня"; }
            lblTitle.Content = "Про автора";
        }
        //Про програму
        private void mnuAboutTheProgram_Click(object sender, RoutedEventArgs e)
        {
            MainTextPage.Visibility = Visibility.Visible;
            mnuLinkToTheProgram.Visibility = Visibility.Collapsed;
            imgMenu.Visibility = Visibility.Collapsed;

            try
            {
                StreamReader fileContentText = new StreamReader(PathToContent + "Text\\About the program\\Про програму.txt");//Текстовий файл
                txtTextComputerVirus.Text = fileContentText.ReadToEnd();
            }
            catch (Exception) { txtTextComputerVirus.Text = "Інформація відсутня"; }
            lblTitle.Content = "Про програму";
        }

        private void mnuEdit_Click(object sender, RoutedEventArgs e)
        {
            wndLogin _wndLogin = new wndLogin();
            if (_wndLogin.ShowDialog().Equals(true))
            {
                _wndLogin.IsEnabled = false;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //При закритті головної форми закриються і інші
            Application.Current.Shutdown();
        }

        #region Зміна теми
        private void DarkTheme()
        {
            //Загрузка зображень для кнопок навігації
            var dirPhoto = new DirectoryInfo("\\" + PathToContent + "Photo\\Navigation\\Dark Theme\\");

            try { imgComputerVirus.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "0.png", UriKind.Absolute)); }
            catch (Exception) { }
            try { imgAvoidInfection.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "1.png", UriKind.Absolute)); }
            catch (Exception) { }
            try { imgVirusRemoval.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "2.png", UriKind.Absolute)); }
            catch (Exception) { }
            try { imgAntivirusPrograms.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "3.png", UriKind.Absolute)); }
            catch (Exception) { }
            try { imgBackToTheMenu.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "4.png", UriKind.Absolute)); }
            catch (Exception) { }
            try { imgExit.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "5.png", UriKind.Absolute)); }
            catch (Exception) { }

            //Зміна кольору шрифту заголовка
            lblTitle.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            //Зміна кольору заднього фону
            grdMain.Background = new SolidColorBrush(Color.FromRgb(30, 30, 78));
            mnsMainMenu.Background = new SolidColorBrush(Color.FromRgb(19, 20, 61));
            pnlNavigation.Background = new SolidColorBrush(Color.FromRgb(25, 26, 69));

            //Зміна кольору заднього фону y ScrollViewer
            scrlTextComputerVirus.Background = grdMain.Background;
            scrlNavigation.Background = pnlNavigation.Background;

            ChangeTheme(pnlNavigation);
            ChangeTheme(mnsMainMenu);

            ChangeTheme(pnlComputerVirus);
            ChangeTheme(pnlAvoidInfection);
            ChangeTheme(pnlVirusRemoval);
            ChangeTheme(pnlAntivirusPrograms);

            //Виключення для кнопки завантажити і зберегти зміни
            mnuLinkToTheProgram.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            mnuLinkToTheProgram.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            mnuLinkToTheProgram.FontWeight = FontWeights.Bold;

            mnuSaveСhanges.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            mnuSaveСhanges.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            mnuSaveСhanges.FontWeight = FontWeights.Bold;
        }

        private void BrightTheme()
        {
            //Загрузка зображень для кнопок навігації
            var dirPhoto = new DirectoryInfo("\\" + PathToContent + "Photo\\Navigation\\Bright Theme\\");
            try { imgComputerVirus.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "0.png", UriKind.Absolute)); }
            catch (Exception) { }
            try { imgAvoidInfection.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "1.png", UriKind.Absolute)); }
            catch (Exception) { }
            try { imgVirusRemoval.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "2.png", UriKind.Absolute)); }
            catch (Exception) { }
            try { imgAntivirusPrograms.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "3.png", UriKind.Absolute)); }
            catch (Exception) { }
            try { imgBackToTheMenu.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "4.png", UriKind.Absolute)); }
            catch (Exception) { }
            try { imgExit.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + dirPhoto + "5.png", UriKind.Absolute)); }
            catch (Exception) { }

            //Зміна кольору шрифту заголовка
            lblTitle.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            //Зміна кольору заднього фону
            grdMain.Background = new SolidColorBrush(Color.FromRgb(173, 199, 235));
            mnsMainMenu.Background = new SolidColorBrush(Color.FromRgb(130, 131, 225));
            pnlNavigation.Background = new SolidColorBrush(Color.FromRgb(245, 202, 49));

            //Зміна кольору заднього фону y ScrollViewer
            scrlTextComputerVirus.Background = grdMain.Background;
            scrlNavigation.Background = pnlNavigation.Background;

            ChangeTheme(pnlNavigation);
            ChangeTheme(mnsMainMenu);

            ChangeTheme(pnlComputerVirus);
            ChangeTheme(pnlAvoidInfection);
            ChangeTheme(pnlVirusRemoval);
            ChangeTheme(pnlAntivirusPrograms);

            //Виключення для кнопки завантажити і зберегти зміни
            mnuLinkToTheProgram.Background = new SolidColorBrush(Color.FromRgb(255, 5, 5));
            mnuLinkToTheProgram.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            mnuLinkToTheProgram.FontWeight = FontWeights.Bold;

            mnuSaveСhanges.Background = new SolidColorBrush(Color.FromRgb(255, 5, 5));
            mnuSaveСhanges.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            mnuSaveСhanges.FontWeight = FontWeights.Bold;
        }

        //Змінити тему для дочірніх кнопок
        private void ChangeTheme(StackPanel panel)
        {
            foreach (var item in panel.Children)
            {
                if (item is Button)
                {
                    ((Button)item).Background = pnlNavigation.Background;
                    if (wndEditing.THEME == "Темна") ((Button)item).Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    if (wndEditing.THEME == "Світла") ((Button)item).Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                }
                if (item is StackPanel)
                {
                    foreach (var item2 in ((StackPanel)item).Children)
                    {
                        if (item2 is Button)
                        {
                            ((Button)item2).Background = pnlNavigation.Background;
                            if (wndEditing.THEME == "Темна") ((Button)item2).Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                            if (wndEditing.THEME == "Світла") ((Button)item2).Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        }
                        if (item2 is StackPanel)
                        {
                            foreach (var item3 in ((StackPanel)item2).Children)
                            {
                                if (item3 is Button)
                                {
                                    ((Button)item3).Background = pnlNavigation.Background;
                                    if (wndEditing.THEME == "Темна") ((Button)item3).Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                                    if (wndEditing.THEME == "Світла") ((Button)item3).Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                }
                            }
                        }
                    }
                }

                if (item is Grid)
                {
                    foreach (var item2 in ((Grid)item).Children)
                    {
                        if (item2 is Button)
                        {
                            ((Button)item2).Background = pnlNavigation.Background;
                            if (wndEditing.THEME == "Темна") ((Button)item2).Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                            if (wndEditing.THEME == "Світла") ((Button)item2).Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        }
                    }
                }
            }
        }
        //Змінити тему для меню
        private void ChangeTheme(Menu menu)
        {
            foreach (var item in menu.Items)
            {
                if (item is MenuItem)
                {
                    ((MenuItem)item).Background = mnsMainMenu.Background;
                    if (wndEditing.THEME == "Темна") ((MenuItem)item).Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    if (wndEditing.THEME == "Світла") ((MenuItem)item).Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                    foreach (var item2 in ((MenuItem)item).Items)
                    {
                        if (item2 is MenuItem)
                        {
                            ((MenuItem)item2).Background = mnsMainMenu.Background;
                            if (wndEditing.THEME == "Темна") ((MenuItem)item2).Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                            if (wndEditing.THEME == "Світла") ((MenuItem)item2).Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        }
                    }
                }
            }
        }
        #endregion
        //Пошук
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search(pnlComputerVirus);
                Search(pnlTypesOfViruses);
                Search(pnlAvoidInfection);
                Search(pnlVirusRemoval);
                Search(pnlRemovalMethods);
                Search(pnlAntivirusPrograms);
                Search(pnlAboutAntivirusPrograms);
                Search(pnlMethodsOfFindingViruses);
                Search(pnlPopularAntivirusPrograms);
            }
        }

        private void Search(StackPanel panel)
        {
            foreach (var item in panel.Children)
            {
                string TextOnButtoForSearch = "";
                try { TextOnButtoForSearch = ((Button)item).Content.ToString(); }
                catch (Exception) { }

                if (item is Button)
                {
                    if (txtSearch.Text == TextOnButtoForSearch)
                    {
                        MainTextPage.Visibility = Visibility.Visible;
                        imgMenu.Visibility = Visibility.Collapsed;
                        ButtonsNavigation_Click((Button)item, null);
                    }
                }
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (wndEditing.THEME == "Темна") DarkTheme();
            if (wndEditing.THEME == "Світла") BrightTheme();
            txtTextComputerVirus.FontSize = wndEditing.FONT_SIZE;
            txtTextComputerVirus.IsReadOnly = wndEditing.TEXT_EDITING;

            if (wndEditing.TEXT_EDITING == false)
            {
                mnuSaveСhanges.Visibility = Visibility.Visible;
            }
            else
            {
                mnuSaveСhanges.Visibility = Visibility.Hidden;
            }

            //Колір тексту
            switch (wndEditing.FONT_COLOR)
            {
                    //Чорний
                case 0:
                    {
                        txtTextComputerVirus.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        break;
                    }
                    //Сірий
                case 1:
                    {
                        txtTextComputerVirus.Foreground = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                        break;
                    }
                    //Синій
                case 2:
                    {
                        txtTextComputerVirus.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));
                        break;
                    }
                    //Зелений
                case 3:
                    {
                        txtTextComputerVirus.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                        break;
                    }
                    //Червоний
                case 4:
                    {
                        txtTextComputerVirus.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        break;
                    }
                    ///Жовтий
                case 5:
                    {
                        txtTextComputerVirus.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                        break;
                    }
            }

            //Тип шрифту
            switch (wndEditing.FONT_TYPE)
            {
                    //Звичайний
                case 0:
                    {
                        txtTextComputerVirus.FontWeight = FontWeights.Normal;
                        txtTextComputerVirus.FontStyle = FontStyles.Normal;
                        break;
                    }
                    //Жирний
                case 1:
                    {
                        txtTextComputerVirus.FontWeight = FontWeights.Bold;
                        txtTextComputerVirus.FontStyle = FontStyles.Normal;
                        break;
                    }
                    //Під нажихилом               
                case 2:
                    {
                        txtTextComputerVirus.FontWeight = FontWeights.Normal;
                        txtTextComputerVirus.FontStyle = FontStyles.Oblique;
                        break;
                    }
                    //Жирний під нахилом
                case 3:
                    {
                        txtTextComputerVirus.FontWeight = FontWeights.Bold;
                        txtTextComputerVirus.FontStyle = FontStyles.Oblique;
                        break;
                    }
            }
        }

        private void mnuSaveСhanges_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo dirComputerVirus = new DirectoryInfo(PathToContent + "Text\\Computer virus");
            var dirTypesOfViruses = new DirectoryInfo(dirComputerVirus + "\\Types of viruses");
            var dirAvoidInfection = new DirectoryInfo(PathToContent + "Text\\Avoid infection");
            var dirVirusRemoval = new DirectoryInfo(PathToContent + "Text\\Virus removal");
            var dirRemovalMethods = new DirectoryInfo(dirVirusRemoval + "\\Removal methods");
            var dirAntivirusPrograms = new DirectoryInfo(PathToContent + "Text\\Antivirus programs");
            var dirAboutAntivirusPrograms = new DirectoryInfo(dirAntivirusPrograms + "\\Antivirus program");
            var dirMethodsOfFindingViruses = new DirectoryInfo(dirAboutAntivirusPrograms + "\\Methods of finding viruses");
            var dirPopularAntivirusPrograms = new DirectoryInfo(dirAntivirusPrograms + "\\List of popular antivirus programs");

            //Масиви файлів
            FileInfo[] arrayComputerVirus = dirComputerVirus.GetFiles();
            FileInfo[] arrayTypesOfViruses = dirTypesOfViruses.GetFiles();
            FileInfo[] arrayAvoidInfection = dirAvoidInfection.GetFiles();
            FileInfo[] arrayVirusRemoval = dirVirusRemoval.GetFiles();
            FileInfo[] arrayRemovalMethods = dirRemovalMethods.GetFiles();
            FileInfo[] arrayAntivirusPrograms = dirAntivirusPrograms.GetFiles();
            FileInfo[] arrayAboutAntivirusProgram = dirAboutAntivirusPrograms.GetFiles();
            FileInfo[] arrayMethodsOfFindingViruses = dirMethodsOfFindingViruses.GetFiles();
            FileInfo[] arrayPopularAntivirusPrograms = dirPopularAntivirusPrograms.GetFiles();

            //Content підкнопок
            string title = lblTitle.Content.ToString();
            try
            {
                title = ((Button)sender).Content.ToString();
                lblTitle.Content = title;
            }
            catch (Exception) { }

            //Комп'ютерний вірус
            try
            {
                for (int i = 0; i < arrayComputerVirus.Length; i++)
                {
                    if (arrayComputerVirus[i].Name == i + ". " + title + ".txt" ||
                        arrayComputerVirus[i].Name == title ||
                        arrayComputerVirus[i].Name == title + ".txt")
                    {
                        File.WriteAllText(dirComputerVirus + "\\" + arrayComputerVirus[i], txtTextComputerVirus.Text);
                    }
                }
            }
            catch (Exception) {}
            //Типи вірусів
            try
            {
                for (int i = 0; i < arrayTypesOfViruses.Length; i++)
                {
                    if (arrayTypesOfViruses[i].Name == i + ". " + title + ".txt" ||
                        arrayTypesOfViruses[i].Name == title ||
                        arrayTypesOfViruses[i].Name == title + ".txt")
                    {
                        File.WriteAllText(dirTypesOfViruses + "\\" + arrayTypesOfViruses[i], txtTextComputerVirus.Text);
                    }
                }
            }
            catch (Exception) {}
            //Уникнення зараження
            try
            {
                for (int i = 0; i < arrayAvoidInfection.Length; i++)
                {
                    if (arrayAvoidInfection[i].Name == i + ". " + title + ".txt" ||
                        arrayAvoidInfection[i].Name == title ||
                        arrayAvoidInfection[i].Name == title + ".txt")
                    {
                        File.WriteAllText(dirAvoidInfection + "\\" + arrayAvoidInfection[i], txtTextComputerVirus.Text);
                    }
                }
            }
            catch (Exception) {}
            //Видалення вірусів
            try
            {
                for (int i = 0; i < arrayVirusRemoval.Length; i++)
                {
                    if (arrayVirusRemoval[i].Name == i + ". " + title + ".txt" ||
                        arrayVirusRemoval[i].Name == title ||
                        arrayVirusRemoval[i].Name == title + ".txt")
                    {
                        File.WriteAllText(dirVirusRemoval + "\\" + arrayVirusRemoval[i], txtTextComputerVirus.Text);
                    }
                }
            }
            catch (Exception) {}
            //Методи видалення
            try
            {
                for (int i = 0; i < arrayRemovalMethods.Length; i++)
                {
                    if (arrayRemovalMethods[i].Name == i + ". " + title + ".txt" ||
                        arrayRemovalMethods[i].Name == title ||
                        arrayRemovalMethods[i].Name == title + ".txt")
                    {
                        File.WriteAllText(dirRemovalMethods + "\\" + arrayRemovalMethods[i], txtTextComputerVirus.Text);
                    }
                }
            }
            catch (Exception) {}
            //Антивірусні програми
            try
            {
                for (int i = 0; i < arrayAntivirusPrograms.Length; i++)
                {
                    if (arrayAntivirusPrograms[i].Name == i + ". " + title + ".txt" ||
                        arrayAntivirusPrograms[i].Name == title ||
                        arrayAntivirusPrograms[i].Name == title + ".txt")
                    {
                        File.WriteAllText(dirAntivirusPrograms + "\\" + arrayAntivirusPrograms[i], txtTextComputerVirus.Text);
                    }
                }
            }
            catch (Exception) { }
            //Про антивірусну програму
            try
            {
                for (int i = 0; i < arrayAboutAntivirusProgram.Length; i++)
                {
                    if (arrayAboutAntivirusProgram[i].Name == i + ". " + title + ".txt" ||
                        arrayAboutAntivirusProgram[i].Name == title ||
                        arrayAboutAntivirusProgram[i].Name == title + ".txt")
                    {
                        File.WriteAllText(dirAboutAntivirusPrograms + "\\" + arrayAboutAntivirusProgram[i], txtTextComputerVirus.Text);
                    }
                }
            }
            catch (Exception) { }
            //Методи відшукання вірусів
            try
            {
                for (int i = 0; i < arrayMethodsOfFindingViruses.Length; i++)
                {
                    if (arrayMethodsOfFindingViruses[i].Name == i + ". " + title + ".txt" ||
                        arrayMethodsOfFindingViruses[i].Name == title ||
                        arrayMethodsOfFindingViruses[i].Name == title + ".txt")
                    {
                        File.WriteAllText(dirMethodsOfFindingViruses + "\\" + arrayMethodsOfFindingViruses[i], txtTextComputerVirus.Text);
                    }
                }
            }
            catch (Exception) { }
            //Список попуярних антивірусних програм
            try
            {
                for (int i = 0; i < arrayPopularAntivirusPrograms.Length; i++)
                {
                    if (arrayPopularAntivirusPrograms[i].Name == i + ". " + title + ".txt" ||
                        arrayPopularAntivirusPrograms[i].Name == title ||
                        arrayPopularAntivirusPrograms[i].Name == title + ".txt")
                    {
                        File.WriteAllText(dirPopularAntivirusPrograms + "\\" + arrayPopularAntivirusPrograms[i], txtTextComputerVirus.Text);
                    }
                }
            }
            catch (Exception) { }
        }
    }
}