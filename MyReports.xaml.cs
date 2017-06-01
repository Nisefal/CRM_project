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

namespace Version_5
{
    /// <summary>
    /// Interaction logic for MyReports.xaml
    /// </summary>
    public partial class MyReports : Window
    {
        User CurrentUser;

        public MyReports()
        {
            InitPics();
            InitializeComponent();

        }

        public MyReports(User u)
        {
            CurrentUser = u;
            InitPics();
            InitializeComponent();
            InSystem();
        }



        ////////////////////////////////
        ///   BUTTON_CLICK_SECTION   /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////



        ////////////////////////////////
        ///   BUTTON_ENTER_SECTION   /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////



        /////////////////////////////
        ///   FUNCTIONS_SECTION   /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////




        ////////////////////////////////
        ///   MENU_INITS+FUNCTIONS   /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////

        private void Post_Click(object sender, RoutedEventArgs e)
        {
            PostWin w = new PostWin(CurrentUser);
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Task_Click(object sender, RoutedEventArgs e)
        {
            Tasks w = new Tasks(CurrentUser);
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Warn_Click(object sender, RoutedEventArgs e)
        {
            WarnWin w = new WarnWin(CurrentUser);
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Propos_Click(object sender, RoutedEventArgs e)
        {
            Proposition w = new Proposition(CurrentUser);
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            Reports w = new Reports(CurrentUser);
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Cont_Click(object sender, RoutedEventArgs e)
        {
            Contacts w = new Contacts(CurrentUser);
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Planer_Click(object sender, RoutedEventArgs e)
        {
            Planner w = new Planner(CurrentUser);
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Progr_Click(object sender, RoutedEventArgs e)
        {
            ProgressWin w = new ProgressWin(CurrentUser);
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void MyRep_Click(object sender, RoutedEventArgs e)
        {
            Reports w = new Reports(CurrentUser);
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void ProposProf_Click(object sender, RoutedEventArgs e)
        {
            Proposition w = new Proposition(CurrentUser);
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void TaskCur_Click(object sender, RoutedEventArgs e)
        {
            Planner w = new Planner(CurrentUser);
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Registr w = new Registr();
            w.ShowDialog();
        }

        private void Entr_Click(object sender, RoutedEventArgs e)
        {
            Logwin entr = new Logwin();
            entr.ShowDialog();
            Close();
        }

        private void Ext_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser = null;

            FileStream fs = new FileStream("UserInfoLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            string str = "";
            sw.WriteLine(str);
            sw.Close();
            fs.Close();

            MainWindow w = new MainWindow(CurrentUser);
            w.Show();
            Close();
        }

        private void Sett_Click(object sender, RoutedEventArgs e)
        {
            Settings w = new Settings();
            w.Show();
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            Info modalWindow = new Info();
            modalWindow.ShowDialog();
        }

        private void FAQ_Click(object sender, RoutedEventArgs e)
        {

        }



        //////////////////////////////
        ///   ALL_INITIALIZATION   /////////////////////////////////////////////////////////////////////////////
        //////////////////////////////

        private void SetUser()
        {
            if (CurrentUser != null)
                Ext.Header = CurrentUser.Login;
        }

        private void InSystem()
        {
            Disable();
            HideShow();
            SetUser();
        }

        private void Disable()
        {
            if (CurrentUser == null)
            {
                MessageBox.Show("Щоб працювати у системі, ви маєту увійти.\nСторінки доступні у режимі перегляду.");
            }
        }

        private void HideShow()
        {
            if (CurrentUser != null)
            {
                if (CurrentUser.Group == "Викладач")
                {
                    StudItem.Visibility = System.Windows.Visibility.Collapsed;
                    EmissItem.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    if (CurrentUser.spec)
                    {
                        StudItem.Visibility = System.Windows.Visibility.Collapsed;
                        CuraItem.Visibility = System.Windows.Visibility.Collapsed;
                    }
                    else
                    {
                        EmissItem.Visibility = System.Windows.Visibility.Collapsed;
                        CuraItem.Visibility = System.Windows.Visibility.Collapsed;
                    }
                }
                Reg.Visibility = System.Windows.Visibility.Collapsed;
                Entr.Visibility = System.Windows.Visibility.Collapsed;
                Ext.Visibility = System.Windows.Visibility.Visible;
            }
        }


        private void SettingsOn()
        {
            if (Settings0.Default.FontColor == "Black")
                this.Foreground = Brushes.Black;
            else if (Settings0.Default.FontColor == "Red")
                this.Foreground = Brushes.Red;
            else
                this.Foreground = Brushes.Gray;

            if (Settings0.Default.ScreenSize == "FullScreen")
                this.WindowState = System.Windows.WindowState.Maximized;
            else this.WindowState = System.Windows.WindowState.Normal;
        }

        private void In()
        {
            StreamReader sr = new StreamReader("UserInfoLog.txt", Encoding.UTF8);
            string list_stat = sr.ReadToEnd();
            sr.Dispose();
            string[] strings = list_stat.Split('\n');
            strings[1] = strings[1].Split('\r')[0];
            if (strings.Length > 1)
                CurrentUser = Logwin.EnterMethod(strings[0], strings[1]);
        }

        private void InitPics()
        {
            try // icon&background&cursor
            {
                Uri iconUri = new Uri("./Images/Icon.ico", UriKind.RelativeOrAbsolute);
                this.Icon = BitmapFrame.Create(iconUri);
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource = new BitmapImage(new Uri("./Images/Village.jpg", UriKind.Relative));
                this.Background = myBrush;
                this.Cursor = new Cursor(Directory.GetCurrentDirectory() + "@/./Images/Pointer_hand.cur");
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                try
                {
                    Uri iconUri = new Uri("../../Images/Icon.ico", UriKind.RelativeOrAbsolute);
                    this.Icon = BitmapFrame.Create(iconUri);
                    ImageBrush myBrush = new ImageBrush();
                    myBrush.ImageSource = new BitmapImage(new Uri("../../Images/Village.jpg", UriKind.Relative));
                    this.Background = myBrush;
                    this.Cursor = new Cursor(Directory.GetCurrentDirectory() + "@/../../Images/Pointer_hand.cur");
                }
                catch (DirectoryNotFoundException)
                {
                    Uri iconUri = new Uri("../Images/Icon.ico", UriKind.RelativeOrAbsolute);
                    this.Icon = BitmapFrame.Create(iconUri);
                    ImageBrush myBrush = new ImageBrush();
                    myBrush.ImageSource = new BitmapImage(new Uri("../Images/Village.jpg", UriKind.Relative));
                    this.Background = myBrush;
                    this.Cursor = new Cursor(Directory.GetCurrentDirectory() + "@/../Images/Pointer_hand.cur");
                }
            }
        }
    }
}
