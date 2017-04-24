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
    /// Interaction logic for WarnWin.xaml
    /// </summary>
    public partial class WarnWin : Window
    {
        public WarnWin()
        {
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

            }

            private void Task_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Warn_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Propos_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Report_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Cont_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Tools_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Planer_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Progr_Click(object sender, RoutedEventArgs e)
            {

            }

            private void MyRep_Click(object sender, RoutedEventArgs e)
            {

            }

            private void ProposProf_Click(object sender, RoutedEventArgs e)
            {

            }

            private void TaskCur_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Reg_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Entr_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Ext_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Sett_Click(object sender, RoutedEventArgs e)
            {
                Settings modalWindow = new Settings();
                modalWindow.ShowDialog();
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
