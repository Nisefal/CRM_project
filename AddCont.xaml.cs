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
    /// Interaction logic for AddCont.xaml
    /// </summary>
    public partial class AddCont : Window
    {
        User CurrentUser;
        List<UserInTable> selected = new List<UserInTable>();
        public AddCont(User u)
        {
            CurrentUser = u;
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            List<UserInTable> tb = new List<UserInTable>();
            if (CurrentUser != null)
            {
                SqlConnection connection;
                SqlCommand cmd;
                string connectionString = ConfigurationManager.ConnectionStrings["Version_5.Properties.Settings.Prj_DBConnectionString"].ConnectionString;
                string info = SearchBox.Text;
                string query = "SELECT * FROM UserAcc WHERE ulogin LIKE '%" + info + "%' OR e_mail LIKE '%" + info + "%' OR Name LIKE '%" + info + "%' OR Secondname LIKE '%" + info + "%'";
                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    connection.Open();
                    cmd = new SqlCommand(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    foreach (DataRow dr in table.Rows)
                    {
                        int id = Convert.ToInt32(dr["Id"].ToString());
                        if(id != CurrentUser.GetId())
                            tb.Add(new UserInTable(id, dr["Name"].ToString() + " " + dr["Secondname"].ToString(), dr["telephone_number"].ToString(), dr["dateOf"].ToString(), dr["groupID"].ToString(), dr["ulogin"].ToString(), dr["e_mail"].ToString(), dr["spec"].ToString()));
                    }

                    CDG.ItemsSource = tb;
                }
            }
        }

        private void CDG_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void CDG_MouseUp(object sender, MouseButtonEventArgs e)
        {
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


        private void CDG_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddC_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser != null)
            {
                SqlConnection connection;
                SqlCommand cmd;
                string connectionString = ConfigurationManager.ConnectionStrings["Version_5.Properties.Settings.Prj_DBConnectionString"].ConnectionString;

                foreach (UserInTable user in selected)
                {
                    if (ExistInTable(user) && CurrentUser.GetId() == user.GetId())
                    {
                        selected.Remove(user);
                    }
                }
                int all = 0;
                string query = "INSERT INTO Contacts (Owner, ContactID) VALUES (@l1, @l2)";
                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    connection.Open();
                    cmd = new SqlCommand(query, connection);

                    foreach (UserInTable user in selected)
                    {
                        cmd.Parameters.AddWithValue("@l1", CurrentUser.GetId());
                        cmd.Parameters.AddWithValue("@l2", user.GetId());
                        cmd.ExecuteNonQuery();
                        all++;
                    }
                }
                MessageBox.Show("Було додано " + all.ToString() + "нових контактів!");
            }
        }

        private bool ExistInTable(UserInTable u)
        {
            SqlConnection connection;
            SqlCommand cmd;
            string connectionString = ConfigurationManager.ConnectionStrings["Version_5.Properties.Settings.Prj_DBConnectionString"].ConnectionString;

            string query = "SELECT * FROM Contacts WHERE Owner = " + CurrentUser.GetId().ToString() + " AND ContactID = " + u.GetId().ToString();
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                connection.Open();
                cmd = new SqlCommand(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count != 0)
                    return true;
            }
            return false;
        }

    }
}
