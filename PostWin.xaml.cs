﻿using System;
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
using System.Data.SqlClient;

namespace Version_5
{
    /// <summary>
    /// Interaction logic for PostWin.xaml
    /// </summary>
    public partial class PostWin : Window
    {
        User CurrentUser;

        SqlConnection connection;
        SqlCommand cmd;
        string connectionString = ConfigurationManager.ConnectionStrings["Version_5.Properties.Settings.Prj_DBConnectionString"].ConnectionString;
        //User u = new User();               

        public PostWin()
        {
            InitPics();
            SettingsOn();
            InitializeComponent();
            InitMessages();
        }
        public PostWin(User u)
        {
            CurrentUser = u;
            InitPics();
            SettingsOn();
            InitializeComponent();
            InSystem();
            InitMessages();
        }


        public PostWin(string name)
        {
            InitPics();
            InitializeComponent();
            Msg.Text = "To " + name + " : ";
        }

        private void InitMessages()
        {
            ///
            //SqlCeDataAdapter da = new SqlCeDataAdapter();
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();

            //da.SelectCommand = new SqlCommand(@"SELECT * FROM FooTable", connString);
            //da.Fill(ds, "FooTable");
            //dt = ds.Tables["FooTable"];
            
            //foreach (DataRow dr in dt.Rows)
            //{
            //    MessageBox.Show(dr["Column1"].ToString());
            //}

            //int rowNum // row number
            //string columnName = "DepartureTime";  // database table column name
            //dt.Rows[rowNum][columnName].ToString();
            ///

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Chat", connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataGrid g = new DataGrid() { Visibility = System.Windows.Visibility.Collapsed};
                
                foreach(DataRow dr in table.Rows)
                {
                    MsgList.Items.Add(new Label() { Content = dr["TimE"].ToString() + ":" + dr["Who"].ToString() + ": " + dr["Content"].ToString() });
                }   
            }
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

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Msg.Text == "Напишите что-то...")
                Msg.Text = "";
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Msg.Text == "")
                Msg.Text = "Напишите что-то...";
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if(Msg.Text != "" && Msg.Text != "Напишите что-то...")
            {
                string time = DateTime.Now.ToString(), text = Msg.Text;
                Label l = new Label() { Content = time  + ":" + CurrentUser.Login + ": " +  text};
                SolidColorBrush b = new SolidColorBrush(Colors.Yellow);
                ListBoxItem li = new ListBoxItem();
                li.Background = b;
                li.Content = l;
                MsgList.Items.Add(li);
                Msg.Text = "";

                string query = "INSERT INTO Chat (Who,TimE,Content) VALUES (@Who,@TimE,@Cont)";
                connection = new SqlConnection(connectionString);
                connection.Open();
                cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Who", 1);
                cmd.Parameters.AddWithValue("@TimE", time);
                cmd.Parameters.AddWithValue("@Cont", text);

                cmd.ExecuteNonQuery();
            }
        }

    }
}
