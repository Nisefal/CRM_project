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
    /// Interaction logic for Contacts.xaml
    /// </summary>
    public partial class Contacts : Window
    {
        List<UserInTable> result = new List<UserInTable>();
        List<UserInTable> toshow;
        public Contacts(User u)
        {
            InitPics();
            InitContacts(u);
            InitializeComponent();
        }

        public Contacts()
        {
            InitPics();
            SettingsOn();
            InitializeComponent();
        }

        ////////////////////////////////
        ///   BUTTON_CLICK_SECTION   /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////

        private void CB1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (false)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Login to work in system, please!");
            }
        }

        private void CB2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (false)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Login to work in system, please!");
            }
        }

        private void CB3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (false)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Login to work in system, please!");
            }
        }


        ////////////////////////////////
        ///   BUTTON_ENTER_SECTION   /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////



        /////////////////////////////
        ///   FUNCTIONS_SECTION   /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////

        private void InitContacts(User u)
        {

        }

        ///////////////////////////
        ///   CHECKED_SECTION   /////////////////////////////////////////////////////////////////////////////
        ///////////////////////////

        private void GB_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (false)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Login to work in system, please!");
            }
            if(this.IsInitialized)
                ModFillGrid();
        }

        private void GB_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (false)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Login to work in system, please!");
            }
            if(this.IsInitialized)
                ModFillGrid();
        }

        private void ModFillGrid()
        {
            toshow = new List<UserInTable>();
            foreach (UserInTable el in result)
            {
                if (GB2.IsChecked == true && el.Group == "Curator")
                    toshow.Add(el);
                else
                {
                    if (GB3.IsChecked == true && el.Spec == "Proforg" && el.Group != "Curator")
                        toshow.Add(el);
                    else
                        if (GB1.IsChecked == true && el.Group != "Curator" && el.Spec != "Proforg")
                            toshow.Add(el);
                }
            }
            CDG.ItemsSource = toshow;
        }

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
            MainWindow w = new MainWindow();
            this.Close();
            w.Show();
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
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource = new BitmapImage(new Uri("./Images/Village.jpg", UriKind.Relative));
                if(Settings0.Default.Background == "Picture")
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
                    if (Settings0.Default.Background == "Picture")
                        this.Background = myBrush;
                    this.Cursor = new Cursor(Directory.GetCurrentDirectory() + "@/../../Images/Pointer_hand.cur");
                }
                catch (DirectoryNotFoundException)
                {
                    Uri iconUri = new Uri("../Images/Icon.ico", UriKind.RelativeOrAbsolute);
                    this.Icon = BitmapFrame.Create(iconUri);
                    ImageBrush myBrush = new ImageBrush();
                    myBrush.ImageSource = new BitmapImage(new Uri("../Images/Village.jpg", UriKind.Relative));
                    if (Settings0.Default.Background == "Picture")
                        this.Background = myBrush;
                    this.Cursor = new Cursor(Directory.GetCurrentDirectory() + "@/../Images/Pointer_hand.cur");
                }
            }
        }

        private void ToCh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (false)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Login to work in system, please!");
            }

            if (CDG.SelectedItems.Count != 0)
            {
                string users = "";
                foreach (UserInTable el in CDG.SelectedItems)
                {
                        if (users == "")
                            users += el.Login;
                        else
                            users += ", " + el.Login;
                }
                PostWin w = new PostWin(users);
                w.Show();
            }
        }

        private List<UserInTable> InitGrid()
        {
            List<UserInTable> tb = new List<UserInTable>();
            //...
            //...
            //...
            return tb;
        }

        private void CDG_Loaded(object sender, RoutedEventArgs e)
        {
            //init list from contacts
            //foreach...
            //--- delete after include SQL
            //result.Add(new UserInTable("Ivan Prohorov", "0675549163", "20.11.1998", "IS52", "M", "IvaPro", "ivapro@gmail.compot"));
           // result.Add(new UserInTable("Sasha Gray", "0635241422", "11.07.1997", "IS42", "W", "SasaG", "someGray@gmail.aud"));
            //result.Add(new UserInTable("Iliya Vatutin", "0635241422", "11.07.1997", "IS42", "M", "Fantomas777", "someGray@gmail.aud"));
            //--- delete after include SQL
            result = InitGrid();
            CDG.ItemsSource = result;
        }

        private void CDG_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (false)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Login to work in system, please!");
            }

            if (ShowOnClick.IsChecked == true)
            {
                UserInTable path = CDG.SelectedItem as UserInTable;
                MessageBox.Show("FIO: " + path.Name + "\nNumber: " + path.PhoneNumber + "\nDate of birth: " + path.DateOfBirth + "\nGroup: " + path.Group + "\nLogin: " + path.Login + "\nEmail: " + path.Email);
            }
        }


        public class UserInTable
        {
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string DateOfBirth { get; set; }
            public string Group { get; set; }
            public string Sex { get; set; }
            public string Login { get; set; }
            public string Email { get; set; }
            public string Spec { get; private set; }

            public UserInTable(string name, string phoneNumber, string dateOfBirth, string group, string sex, string login, string em, string prof)
            {
                Name = name;
                PhoneNumber = phoneNumber;
                DateOfBirth = dateOfBirth;
                Group = group;
                Sex = sex;
                Login = login;
                Email = em;
                if(prof == "p")
                    Spec = "Proforg";
            }
        }

        private void AddC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (false)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Login to work in system, please!");
            }

            //find in window+select+add contact
            result.Add(new UserInTable("Sasha Pupkin", "0635241422", "11.07.1997", "IS42", "M", "Eizenhorn", "someGray@gmail.aud", "p"));
            result.Add(new UserInTable("Sasha Knopkin", "0635241422", "11.07.1997", "IS42", "M", "Eizenhorn", "someGray@gmail.aud", "n"));
            //add new user
            CDG.ItemsSource = null;
            CDG.ItemsSource = result;
        }

    }
}