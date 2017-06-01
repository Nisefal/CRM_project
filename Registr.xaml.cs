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
    /// Interaction logic for Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitPics();
            InitializeComponent();
            SettingsOn();
            this.Show();
        }


        ////////////////////////////////
        ///   BUTTON_CLICK_SECTION   ////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogBox.Text = Group();
        }


        ////////////////////////////////
        ///   BUTTON_ENTER_SECTION   //////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////



        ////////////////////////////////
        ///   TEXT_CHANGED_SECTION   //////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        /////////////////////////////
        ///   FUNCTIONS_SECTION   /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////

        private string Group()
        {
            if (GCB.SelectedIndex >= 0)
                return ((ComboBoxItem)GCB.SelectedItem).Content.ToString();
            else return "";
        }


        ////////////////////////////////
        ///   MENU_INITS+FUNCTIONS   /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////


        private void Sett_Click(object sender, RoutedEventArgs e)
        {
            Settings modalWindow = new Settings();
            modalWindow.ShowDialog();
        }




        //////////////////////////////
        ///   ALL_INITIALIZATION   /////////////////////////////////////////////////////////////////////////////
        //////////////////////////////

        private void SettingsOn()
        {
            if (Settings0.Default.Background == "None")
                this.Background = new ImageBrush();

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
