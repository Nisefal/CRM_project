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

namespace Version_3
{
    /// <summary>
    /// Interaction logic for Planner.xaml
    /// </summary>
    public partial class Planner : Window
    {
        public Planner()
        {
            InitPics();
            SettingsOn();
            InitializeComponent();
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
            PostWin w = new PostWin();
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Task_Click(object sender, RoutedEventArgs e)
        {
            Tasks w = new Tasks();
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Warn_Click(object sender, RoutedEventArgs e)
        {
            WarnWin w = new WarnWin();
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Propos_Click(object sender, RoutedEventArgs e)
        {
            Proposition w = new Proposition();
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            Reports w = new Reports();
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Cont_Click(object sender, RoutedEventArgs e)
        {
            Contacts w = new Contacts();
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Planer_Click(object sender, RoutedEventArgs e)
        {
            Planner w = new Planner();
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void Progr_Click(object sender, RoutedEventArgs e)
        {
            ProgressWin w = new ProgressWin();
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void MyRep_Click(object sender, RoutedEventArgs e)
        {
            Reports w = new Reports();
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void ProposProf_Click(object sender, RoutedEventArgs e)
        {
            Proposition w = new Proposition();
            App.Current.MainWindow = w;
            this.Close();
            w.Show();
        }

        private void TaskCur_Click(object sender, RoutedEventArgs e)
        {
            Planner w = new Planner();
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
        }

        private void Ext_Click(object sender, RoutedEventArgs e)
        {
            // function enables auto-enter
        }

        private void Sett_Click(object sender, RoutedEventArgs e)
        {
            Settings modalWindow = new Settings();
            modalWindow.ShowDialog();
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FAQ_Click(object sender, RoutedEventArgs e)
        {

        }



        //////////////////////////////
        ///   ALL_INITIALIZATION   /////////////////////////////////////////////////////////////////////////////
        //////////////////////////////

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

        private void In(string loginf, string pswrd)
        {

        }

        private void AutoEnter()
        {
            if (true)
            {

            }
        }

        private void InitPics()
        {
            try // icon&background&cursor
            {
                Uri iconUri = new Uri("./Images/Icon.ico", UriKind.RelativeOrAbsolute);
                this.Icon = BitmapFrame.Create(iconUri);
                this.Cursor = new Cursor(Directory.GetCurrentDirectory() + "@/./Images/Pointer_hand.cur");
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                try
                {
                    Uri iconUri = new Uri("../../Images/Icon.ico", UriKind.RelativeOrAbsolute);
                    this.Icon = BitmapFrame.Create(iconUri);
                    this.Cursor = new Cursor(Directory.GetCurrentDirectory() + "@/../../Images/Pointer_hand.cur");
                }
                catch (DirectoryNotFoundException)
                {
                    Uri iconUri = new Uri("../Images/Icon.ico", UriKind.RelativeOrAbsolute);
                    this.Icon = BitmapFrame.Create(iconUri);
                    this.Cursor = new Cursor(Directory.GetCurrentDirectory() + "@/../Images/Pointer_hand.cur");
                }
            }
        }

        private void AddT_Click(object sender, RoutedEventArgs e)
        {
            var tb = new TextBox() { Text = "", Width = 190 };
            //ListBoxItem i = new ListBoxItem();
            //i.Content = tb;
            TaskList.Items.Add(tb);
        }

        private void DelT_Click(object sender, RoutedEventArgs e)
        {
            if(TaskList.SelectedIndex>=0)
                TaskList.Items.Remove(TaskList.SelectedItem);
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem tv = new TreeViewItem();
            tv.Header = MLine.Text;
            foreach (TextBox el in TaskList.Items)
            {
                tv.Items.Add(new Label() { Content = el.Text });
            }
            Tree.Items.Add(tv);
            TaskList.Items.Clear();
            MLine.Text = "";
        }


    }
}
