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

namespace Version_5
{
    /// <summary>
    /// Interaction logic for Planner.xaml
    /// </summary>
    public partial class Planner : Window
    {

        List<Worker> wlist;
        User CurrentUser;
        StanTask_1 st1;
        task tk;

        public Planner()
        {
            InitPics();
            SettingsOn();
            InitializeComponent();            
            FillWorkers();
        }

        public Planner(User u)
        {
            CurrentUser = u;
            InitPics();
            SettingsOn();
            InitializeComponent();
            InSystem();
            FillWorkers();
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
            if (CurrentUser != null && IsInitialized)
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
            if (CurrentUser == null && IsInitialized)
            {
                MessageBox.Show("Щоб працювати у системі, ви маєту увійти.\nСторінки доступні у режимі перегляду.");
            }
        }

        private void HideShow()
        {
            if (CurrentUser != null && IsInitialized)
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

        private void FillWorkers()
        {
            wlist = new List<Worker>();
            //fill list

            if (CurrentUser != null)
            {
                SqlConnection connection;
                SqlCommand cmd;
                string connectionString = ConfigurationManager.ConnectionStrings["Version_5.Properties.Settings.Prj_DBConnectionString"].ConnectionString;

                string query = "SELECT * FROM Contacts INNER JOIN UserAcc ON Contacts.ContactID = UserAcc.Id WHERE Contacts.Owner = " + CurrentUser.GetId().ToString();// +"AND UserAcc.GroupID =" + CurrentUser.Group;
                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    connection.Open();
                    cmd = new SqlCommand(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    //get group!!!!!!!!!

                    foreach (DataRow dr in table.Rows)
                    {
                        wlist.Add(new Worker(Convert.ToInt32(dr["Id"].ToString()), dr["Name"].ToString()+ " " + dr["SecondName"].ToString()));
                    }
                }

            }

            Workers.ItemsSource = wlist;
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
            try
            {
                if (CurrentUser == null && IsInitialized)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Увійдіть у систему, щоб працювати!");
            }

            TextBox tb = new TextBox() { Text = "", MinWidth = 160, TextWrapping = System.Windows.TextWrapping.Wrap, Margin = new Thickness(5,0,10,0), HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left};
            TaskList.Items.Add(tb);
        }

        private void DelT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentUser == null && IsInitialized)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Увійдіть у систему, щоб працювати!");
            }

            if (TaskList.SelectedIndex >= 0)
                TaskList.Items.Remove(TaskList.SelectedItem);
            else
                if (TaskList.Items.Count > 0)
                    TaskList.Items.RemoveAt(TaskList.Items.Count - 1);
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentUser == null && IsInitialized)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Увійдіть у систему, щоб працювати!");
            }

            tk = new task();
            tk.subtasks = new List<subtask>();
            tk.topic = MLine.Text;

            MovInDb(tk);
        }


        private void B2_Click(object sender, RoutedEventArgs e)
        {
            string loc = TaskFrame.Content.GetType().ToString().Split('.')[1];
            if (loc == "StanTask_1")
                MovInDb(st1.Standart1());
        }


        private void MovInDb(task tl)
        {
            int cid = 0;
            bool lfg = false;
            foreach (Worker el in Workers.Items)
            {
                if (el.flag == true)
                {
                    cid = el.RetId();
                    AddTask(cid, tl);
                    lfg = true;
                }
            }
            if (lfg)
            {
                TreeViewItem tv = new TreeViewItem();
                tv.Header = MLine.Text;
                foreach (TextBox el in TaskList.Items)
                {
                    tv.Items.Add(new Label() { Content = el.Text });
                    tk.subtasks.Add(new subtask() { id = 0, subt = el.Text });
                }
                Tree.Items.Add(tv);
                TaskList.Items.Clear();
                MLine.Text = "";
            }
            else
                MessageBox.Show("Оберіть виконавця(-ів)!");
        }

        private void AddTask(int ui, task tl)
        {
            if (CurrentUser != null)
            {
                SqlConnection connection;
                SqlCommand cmd;
                string connectionString = ConfigurationManager.ConnectionStrings["Version_5.Properties.Settings.Prj_DBConnectionString"].ConnectionString;

                string query = "INSERT INTO TaskTable (Owner, Worker, Topic, Get, Done) VALUES ( @v1, @v2, @v3, 0, 0)";// +CurrentUser.GetId() + ", " + ui.ToString() + ", '" +  + "', " + "1, 0)";// +"AND UserAcc.GroupID =" + CurrentUser.Group;
                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    connection.Open();
                    cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@v1", CurrentUser.GetId());
                    cmd.Parameters.AddWithValue("@v2", ui);
                    cmd.Parameters.AddWithValue("@v3", tl.topic);
                    cmd.ExecuteNonQuery();
                }

                query = "SELECT * FROM TaskTable";

                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    connection.Open();

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    DataRow r = null;

                    foreach (DataRow dr in table.Rows)
                        r = dr;

                    if (r != null)
                    {
                        int subid = Convert.ToInt32(r["Id"].ToString());
                        if (tl.subtasks != null)
                            foreach (subtask s in tl.subtasks)
                            {
                                query = "INSERT INTO Sub_TaskTable (related, Text, Done) VALUES (@v1, @v2, 0)";
                                cmd = new SqlCommand(query, connection);
                                cmd.Parameters.AddWithValue("@v1", subid);
                                cmd.Parameters.AddWithValue("@v2", s.subt);
                                cmd.ExecuteNonQuery();
                            }
                    }
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try 
            {
                if(CurrentUser == null && IsInitialized)
                    throw new Exception();
            }
            catch(Exception)
            {
                MessageBox.Show("Увійдіть у систему, щоб працювати!");
            }
            if (CB.SelectedIndex == 0)
            {
                st1 = new StanTask_1();
                TaskFrame.Content = st1;
            }
        }

        private void Workers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CurrentUser == null && IsInitialized)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Увійдіть у систему, щоб працювати!");
            }

            if (Workers.SelectedItems.Count > 0)
            {
                if (wlist[Workers.SelectedIndex].flag != true)
                    wlist[Workers.SelectedIndex].flag = true;
                else
                    wlist[Workers.SelectedIndex].flag = false;
                Workers.Items.Refresh();
                Workers.SelectedItem = null;
            }
        }




    }

    public class Worker
    {
        public Worker(int id, string n)
        {
            ID = id;
            Name = n;
            flag = false;
        }

        public int RetId()
        {
            return ID;
        }

        private int ID { get; set; }
        public string Name { get; set; }
        public bool flag { get; set; }
    }
}

