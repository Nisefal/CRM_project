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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Sql;
using System.Threading;

namespace Version_5
{
    /// <summary>
    /// Interaction logic for Contacts.xaml
    /// </summary>
    public partial class Contacts : Window
    {
        User CurrentUser;
        List<UserInTable> result = new List<UserInTable>();
        List<UserInTable> toshow;
        List<UserInTable> selected = new List<UserInTable>();

        public Contacts(User u)
        {
            CurrentUser = u;
            InitPics();
            InitContacts();
            SettingsOn();
            InitializeComponent();
            InSystem();

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 15);
            dispatcherTimer.Start();
        }

        public Contacts()
        {
            InitPics();
            SettingsOn();
            InitializeComponent();
        }
        ////////////////////////////////
        ///   TIMER_SECTION   /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            result = InitGrid();
            ModFillGrid();
            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }

        ////////////////////////////////
        ///   BUTTON_CLICK_SECTION   /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////


        private void DelC_Click(object sender, RoutedEventArgs e)
        {
            if (IsInitialized)
            {
                try
                {
                    if (CurrentUser == null)
                        throw new Exception();
                }
                catch (Exception)
                {
                    MessageBox.Show("Увійдіть у систему, щоб працювати!");
                }

                if (CurrentUser != null)
                {
                    SqlConnection connection;
                    SqlCommand cmd;
                    string connectionString = ConfigurationManager.ConnectionStrings["Version_5.Properties.Settings.Prj_DBConnectionString"].ConnectionString;

                    string query = "DELETE FROM Contacts WHERE Owner = " + CurrentUser.GetId().ToString() + " AND ContactID = " + (CDG.SelectedItem as UserInTable).GetId().ToString();
                    using (connection = new SqlConnection(connectionString))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        connection.Open();
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                    }
                }
                
            }
            
        }


        private void ToCh_Click(object sender, RoutedEventArgs e)
        {
            if (IsInitialized)
            {
                try
                {
                    if (CurrentUser == null)
                        throw new Exception();
                }
                catch (Exception)
                {
                    MessageBox.Show("Увійдіть у систему, щоб працювати!");
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
        }

        private void AddC_Click(object sender, RoutedEventArgs e)
        {
            if (IsInitialized)
            {
                try
                {
                    if (CurrentUser == null)
                        throw new Exception();
                }
                catch (Exception)
                {
                    MessageBox.Show("Увійдіть у систему, щоб працювати!");
                }

                AddCont w = new AddCont(CurrentUser);
                w.Show();
            }
        }


        private void CB1_Click(object sender, RoutedEventArgs e)
        {
            if (IsInitialized)
            {
                try
                {
                    if (CurrentUser == null)
                        throw new Exception();
                }
                catch (Exception)
                {
                    MessageBox.Show("Увійдіть у систему, щоб працювати!");
                }
            }
        }

        private void CB2_Click(object sender, RoutedEventArgs e)
        {
            if (IsInitialized)
            {
                try
                {
                    if (CurrentUser == null)
                        throw new Exception();
                }
                catch (Exception)
                {
                    MessageBox.Show("Увійдіть у систему, щоб працювати!");
                }
            }
        }

        private void CB3_Click(object sender, RoutedEventArgs e)
        {
            if (IsInitialized)
            {
                try
                {
                    if (CurrentUser == null)
                        throw new Exception();
                }
                catch (Exception)
                {
                    MessageBox.Show("Увійдіть у систему, щоб працювати!");
                }
            }
        }

        ////////////////////////////////
        ///   BUTTON_ENTER_SECTION   /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////



        /////////////////////////////
        ///   FUNCTIONS_SECTION   /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////

        private void InitContacts()
        {
            result = InitGrid();
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

        ///////////////////////////
        ///   CHECKED_SECTION   /////////////////////////////////////////////////////////////////////////////
        ///////////////////////////

        private void GB_Checked(object sender, RoutedEventArgs e)
        {
            if (IsInitialized)
            {
                try
                {
                    if (CurrentUser == null)
                        throw new Exception();
                }
                catch (Exception)
                {
                    MessageBox.Show("Увійдіть у систему, щоб працювати!");
                }
                if (this.IsInitialized)
                    ModFillGrid();
            }
        }

        private void GB_Unchecked(object sender, RoutedEventArgs e)
        {
            if (IsInitialized)
            {
                try
                {
                    if (CurrentUser == null)
                        throw new Exception();
                }
                catch (Exception)
                {
                    MessageBox.Show("Увійдіть у систему, щоб працювати!");
                }
                if (this.IsInitialized)
                    ModFillGrid();
            }
        }

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

        private void InitPics()
        {
            try // icon&background&cursor
            {
                Uri iconUri = new Uri("./Images/Icon.ico", UriKind.RelativeOrAbsolute);
                this.Icon = BitmapFrame.Create(iconUri);
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource = new BitmapImage(new Uri("./Images/Village.jpg", UriKind.Relative));
                if (Settings0.Default.Background == "Picture")
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


        private List<UserInTable> InitGrid()
        {
            List<UserInTable> tb = new List<UserInTable>();
            if (CurrentUser != null)
            {
                SqlConnection connection;
                SqlCommand cmd;
                string connectionString = ConfigurationManager.ConnectionStrings["Version_5.Properties.Settings.Prj_DBConnectionString"].ConnectionString;

                string query = "SELECT * FROM Contacts INNER JOIN UserAcc ON Contacts.ContactID = UserAcc.Id WHERE Contacts.Owner = " + CurrentUser.GetId().ToString();
                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    connection.Open();
                    cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@l", CurrentUser.GetId());
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    //get group!!!!!!!!!

                    foreach (DataRow dr in table.Rows)
                    {
                        tb.Add(new UserInTable(Convert.ToInt32(dr["Id"].ToString()), dr["Name"].ToString() + " " + dr["Secondname"].ToString(), dr["telephone_number"].ToString(), dr["dateOf"].ToString(), dr["groupID"].ToString(), dr["ulogin"].ToString(), dr["e_mail"].ToString(), dr["spec"].ToString()));
                    }
                }
            }
            return tb;
        }

        private void CDG_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsInitialized)
            {
                CDG.ItemsSource = result;
            }
        }

        private void CDG_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (IsInitialized)
            {
                try
                {
                    if (CurrentUser == null)
                        throw new Exception();
                }
                catch (Exception)
                {
                    MessageBox.Show("Увійдіть у систему, щоб працювати!");
                }

                if (ShowOnClick.IsChecked == true)
                {
                    UserInTable path = CDG.SelectedItem as UserInTable;

                    /// REDOOOOOOOOOOOOOOOOOOOOO!

                    MessageBox.Show("FIO: " + path.Name + "\nNumber: " + path.PhoneNumber + "\nDate of birth: " + path.DateOfBirth + "\nGroup: " + path.Group + "\nLogin: " + path.Login + "\nEmail: " + path.Email);
                }
                else

                    if (selected.Contains(CDG.SelectedItem as UserInTable))
                    {
                        selected.Remove(CDG.SelectedItem as UserInTable);
                    }
                    else
                    {
                        selected.Add(CDG.SelectedItem as UserInTable);
                    }
                CDG.SelectedItems.Clear();
                foreach (var el in selected)
                    CDG.SelectedItems.Add(el);
            }
        
        }

        private void CDG_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

    }


    public class UserInTable
    {
        private int Id;
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Group { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Spec { get; private set; }

        public UserInTable(int i, string name, string phoneNumber, string dateOfBirth, string group, string login, string em, string prof)
        {
            Id = i;
            Name = name;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Group = group;
            Login = login;
            Email = em;
            if (prof == "True")
                Spec = "Профорг";
        }

        public int GetId()
        {
            return Id;
        }
    }
}