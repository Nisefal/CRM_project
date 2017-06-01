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

namespace Version_4
{
    /// <summary>
    /// Interaction logic for Logwin.xaml
    /// </summary>
    public partial class Logwin : Window
    {
        private string pswrd;
        private string login;

        public string GetP()
        {
            return pswrd;
        }

        public string GetL()
        {
            return login;
        }

        public Logwin()
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

        private void In_Click(object sender, RoutedEventArgs e)
        {
            if (LogBox.Text == "" || PswrdBox.ToString() == "")
            {
                MessageBox.Show("Fill in all fields");
                return;
            }

            User user = User.GetUserByLogin(LogBox.Text);
            if (user == null)
            {
                MessageBox.Show("Can not find user with this login");
                return;
            }

            if (PswrdBox.Password.ToString().CompareTo(user.GetPassword()) != 0)
            {
                MessageBox.Show("Incorrect password");
                return;
            }

            MainWindow window = new MainWindow();
            window.Show();
            Hide();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Registr window = new Registr();
            window.Show();
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        ////////////////////////////////
        ///   MENU_INITS+FUNCTIONS   /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////



        //////////////////////////////
        ///   ALL_INITIALIZATION   /////////////////////////////////////////////////////////////////////////////
        //////////////////////////////
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registr w = new Registr();
            this.Close();
            w.ShowDialog();
        }
    }
}
