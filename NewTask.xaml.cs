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

namespace Version_1
{
    /// <summary>
    /// Interaction logic for NewTask.xaml
    /// </summary>
    public partial class NewTask : Window
    {
        public NewTask()
        {
            InitPics();
            InitializeComponent();

        }

        public NewTask(string st1, string st2)
        {
            InitPics();
            FillForm(st1, st2);
            InitializeComponent();
            MouseDown += Window_MouseDown;
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

        private void FillForm(string st1, string st2)
        {
            Topic.Text = st1;
            Content.Text = st2;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        ////////////////////////////////
        ///   MENU_INITS+FUNCTIONS   /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////

        private void StudItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sett_Click(object sender, RoutedEventArgs e)
        {
            Settings modalWindow = new Settings();
            modalWindow.ShowDialog();
        }

        private void EmissItem_Click(object sender, RoutedEventArgs e)
        {

        }


        //////////////////////////////
        ///   ALL_INITIALIZATION   /////////////////////////////////////////////////////////////////////////////
        //////////////////////////////
        private void InitPics()
        {
            try // icon&background&cursor
            {
                Uri iconUri = new Uri("./Images/Icon.ico", UriKind.RelativeOrAbsolute);
                this.Icon = BitmapFrame.Create(iconUri);
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource = new BitmapImage(new Uri("./Images/Scroll.png", UriKind.Relative));
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
                    myBrush.ImageSource = new BitmapImage(new Uri("../../Images/Scroll.png", UriKind.Relative));
                    this.Background = myBrush;
                    this.Cursor = new Cursor(Directory.GetCurrentDirectory() + "@/../../Images/Pointer_hand.cur");
                }
                catch (DirectoryNotFoundException)
                {
                    Uri iconUri = new Uri("../Images/Icon.ico", UriKind.RelativeOrAbsolute);
                    this.Icon = BitmapFrame.Create(iconUri);
                    ImageBrush myBrush = new ImageBrush();
                    myBrush.ImageSource = new BitmapImage(new Uri("../Images/Scroll.png", UriKind.Relative));
                    this.Background = myBrush;
                    this.Cursor = new Cursor(Directory.GetCurrentDirectory() + "@/../Images/Pointer_hand.cur");
                }
            }
        }

    }
}
