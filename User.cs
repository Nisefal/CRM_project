using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Version_3
{
    public class User
    {
        public static Dictionary<string, User> users = new Dictionary<string, User>();

        public string Name;
        public string PhoneNumber;
        public string DateOfBirth;
        public string Group;
        public string Sex;
        public string Login;
        private string Password;
        public string Email;

        public User(string name, string phoneNumber, string dateOfBirth, string group, string sex, string login, string password, string em)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Group = group;
            Sex = sex;
            Login = login;
            Password = password;
            Email = em;
        }

        public static void AddUser(User user)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = @"INSERT INTO Users (Login, Name, PhoneNumber, DateOfBirth, Sex, Password) 
                    VALUES (@login, @name, @phoneNumber, @dateOfBirth, @sex, @password)";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@login", user.Login);
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@sex", user.Sex);
                command.Parameters.AddWithValue("@password", user.Password);
                command.ExecuteNonQuery();
            }
        }

        public string GetPassword()
        {
            return Password;
        }

        public static User GetUserByLogin(string login)
        {
            User user = null;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT * FROM Users WHERE @login = Login";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@login", login);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
//                    user = new User(reader.GetValue(1).ToString(), reader.GetValue(2).ToString(),
 //                       reader.GetValue(3).ToString(), reader.GetValue(4).ToString(),
  //                      reader.GetValue(0).ToString(), reader.GetValue(5).ToString());
                }

                return user;
            }
        }
    }
}
