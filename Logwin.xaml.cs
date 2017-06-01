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

        User CurrentUser;

        private void In_Click(object sender, RoutedEventArgs e)
        {
            if (LogBox.Text == "" || PswrdBox.ToString() == "")
            {
                MessageBox.Show("Заповніть усі поля!");
                return;
            }
            else
            {
                CurrentUser = UserExist();
                if (CurrentUser != null)
                {
                    MainWindow window = new MainWindow(CurrentUser);
                    window.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Логін або пароль невірні!");
                    PswrdBox.Password = "";
                }
            }
        }

        SqlConnection connection;
        SqlCommand cmd;
        string connectionString = ConfigurationManager.ConnectionStrings["Version_5.Properties.Settings.Prj_DBConnectionString"].ConnectionString;

        private User UserExist()
        {
            CheckUser u = new CheckUser(LogBox.Text, PswrdBox.Password);
            string query = "SELECT * FROM UserAcc WHERE ulogin LIKE '%" + u.loginfo + "%' OR e_mail LIKE '%" + u.loginfo + "%'"; // 
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                connection.Open();
                cmd = new SqlCommand(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                //SqlDataReader table = cmd.ExecuteReader();
                //while(table.Read())
                //{
                //    if (table["password"].ToString() == u.pswrd)
                //    {
                //        string s = table["spec"].ToString();
                //        if (table["spec"].ToString() == "True") //name + table["Secondname"].ToString()
                //        {
                //            User us = new User(table["Name"].ToString(), table["Login"].ToString(), table["groupID"].ToString(), table["number"].ToString(), table["telephone_number"].ToString(), table["e_mail"].ToString(), table["password"].ToString(), table["dateOf"].ToString(), true);
                //            return us;
                //        }
                //        else
                //            return new User(table["Name"].ToString() + table["Secondname"].ToString(), table["Login"].ToString(), table["groupID"].ToString(), table["number"].ToString(), table["telephone_number"].ToString(), table["e_mail"].ToString(), table["password"].ToString(), table["dateOf"].ToString(), false);
                //    }
                //}
                //adapter.Fill(table);

                foreach (DataRow dr in table.Rows)
                {
                    if (dr["password"].ToString() == u.pswrd && (dr["ulogin"].ToString() == u.loginfo || dr["e_mail"].ToString() == u.loginfo))
                    {
                        if (dr["spec"].ToString() == "True") //name + table["Secondname"].ToString()
                        {
                            User us = new User(Convert.ToInt32(dr["Id"].ToString()), dr["Name"].ToString(), dr["ulogin"].ToString(), dr["groupID"].ToString(), dr["number"].ToString(), dr["telephone_number"].ToString(), dr["e_mail"].ToString(), dr["password"].ToString(), dr["dateOf"].ToString(), true);

                            FileStream fs = new FileStream("UserInfoLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter sw = new StreamWriter(fs);
                            string str = u.loginfo + '\n' + u.pswrd;
                            sw.WriteLine(str);
                            sw.Close();
                            fs.Close();

                            return us;
                        }
                        else
                        {

                            FileStream fs = new FileStream("UserInfoLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter sw = new StreamWriter(fs);
                            string str = u.loginfo + '\n' + u.pswrd;
                            sw.WriteLine(str);
                            sw.Close();
                            fs.Close();

                            return new User(Convert.ToInt32(dr["Id"].ToString()), dr["Name"].ToString() + dr["Secondname"].ToString(), dr["ulogin"].ToString(), dr["groupID"].ToString(), dr["number"].ToString(), dr["telephone_number"].ToString(), dr["e_mail"].ToString(), dr["password"].ToString(), dr["dateOf"].ToString(), false);
                        }
                    }
                }
                return null;
            }
        }

        public static User EnterMethod(string st1, string st2)
        {
            SqlConnection connection;
            string connectionString = ConfigurationManager.ConnectionStrings["Version_5.Properties.Settings.Prj_DBConnectionString"].ConnectionString;
            SqlCommand cmd;
            CheckUser u = new CheckUser(st1, st2);
            string query = "SELECT * FROM UserAcc WHERE ulogin LIKE '%" + u.loginfo + "%' OR e_mail LIKE '%" + u.loginfo + "%'"; // 
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                connection.Open();
                cmd = new SqlCommand(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                foreach (DataRow dr in table.Rows)
                {
                    if (dr["password"].ToString() == u.pswrd && (dr["ulogin"].ToString() == u.loginfo || dr["e_mail"].ToString() == u.loginfo))
                    {
                        if (dr["spec"].ToString() == "True") //name + table["Secondname"].ToString()
                        {
                            User us = new User(Convert.ToInt32(dr["Id"].ToString()), dr["Name"].ToString(), dr["ulogin"].ToString(), dr["groupID"].ToString(), dr["number"].ToString(), dr["telephone_number"].ToString(), dr["e_mail"].ToString(), dr["password"].ToString(), dr["dateOf"].ToString(), true);

                            FileStream fs = new FileStream("UserInfoLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter sw = new StreamWriter(fs);
                            string str = st1 + '\n' + st2 + '\n';
                            sw.WriteLine(str);
                            sw.Close();
                            fs.Close();

                            return us;
                        }
                        else
                        {

                            FileStream fs = new FileStream("UserInfoLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter sw = new StreamWriter(fs);
                            string str = st1 + '\n' + st2 + '\n';
                            sw.WriteLine(str);
                            sw.Close();
                            fs.Close();

                            return new User(Convert.ToInt32(dr["Id"].ToString()), dr["Name"].ToString() + dr["Secondname"].ToString(), dr["ulogin"].ToString(), dr["groupID"].ToString(), dr["number"].ToString(), dr["telephone_number"].ToString(), dr["e_mail"].ToString(), dr["password"].ToString(), dr["dateOf"].ToString(), false);
                        }
                    }
                }
                return null;
            }


        }

        private class CheckUser
        {
            public string loginfo { get; set; }
            public string pswrd { get; set; }

            public CheckUser(string l, string p)
            {
                loginfo = l;
                pswrd = p;
            }
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
