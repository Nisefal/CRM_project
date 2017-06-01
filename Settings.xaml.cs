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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        Settings1 p1;
        Settings2 p2;
        public Settings()
        {
            p1 = new Settings1();
            p2 = new Settings2();
            InitPics();
            InitializeComponent();
            InitSettings();
            p1.FColor.Items.Refresh();
        }


        ////////////////////////////////
        ///   BUTTON_CLICK_SECTION   /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////
        private void Move_Click(object sender, RoutedEventArgs e)
        {
            if(Rect.Content.ToString() == "Version_5.Settings1")
            {
                Rect.Content = p2;
            }
            else
            {
                Rect.Content = p1;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Settings0.Default.ScreenSize = p2.ScreenS.SelectedItem.ToString().Split(' ')[1];
            Settings0.Default.Background = p2.Backgr.SelectedItem.ToString().Split(' ')[1];
            Settings0.Default.FontColor = p1.FColor.SelectedItem.ToString().Split(' ')[1];
            Settings0.Default.Save();
            MessageBox.Show("Settings were changed!");
            this.Close();
        }


        ////////////////////////////////
        ///   BUTTON_ENTER_SECTION   /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////



        /////////////////////////////
        ///   FUNCTIONS_SECTION   /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////




        //////////////////////////////
        ///   ALL_INITIALIZATION   /////////////////////////////////////////////////////////////////////////////
        //////////////////////////////

        private void InitSettings()
        {
            if (Settings0.Default.ScreenSize == "FullScreen")
                p2.ScreenS.SelectedItem = p2.ScreenS.Items[0];
            else
                p2.ScreenS.SelectedItem = p2.ScreenS.Items[1];

            if (Settings0.Default.FontColor == "Black")
                p1.FColor.SelectedItem = p1.FColor.Items[0];
            else if (Settings0.Default.FontColor == "Red")
                p1.FColor.SelectedItem = p1.FColor.Items[1];
            else p1.FColor.SelectedItem = p1.FColor.Items[2];

            if(Settings0.Default.Background == "Picture")
                p2.Backgr.SelectedItem = p2.Backgr.Items[1];
            else
                p2.Backgr.SelectedItem = p2.Backgr.Items[0];
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
    }
}
