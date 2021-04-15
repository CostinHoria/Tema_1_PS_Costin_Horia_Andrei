using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ex2.DAL;
using ex2.UI;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace ex2.BL
{
    public class UserService
    {
        private static UserService _usersDAL = null;
        private String _connectionString = @"Data Source=DESKTOP-MR6F4FF\SQLEXPRESS;Initial Catalog=ex2db;Integrated Security=True";
        SqlConnection _conn = null;

        private UserService()
        {
            //_usersDAL = UserService.getInstance();
            try
            {
                _conn = new SqlConnection(_connectionString);
            }
            catch (SqlException e)
            {
                //de facut ceva error handling, afisat mesaj, etc..
                _conn = null;
            }
        }

        public static UserService getInstance()
        {
            if (_usersDAL == null)
            {
                _usersDAL = new UserService();
            }
            return _usersDAL;
        }


        public UserDAO getUser(String username, String password)
        {
            UserDAO u = null;
            String sql = "SELECT * FROM dbo.users WHERE username='" + username + "' AND password='" + password + "'";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                u = new UserDAO(reader["username"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["role"].ToString());
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return u;
        }

        public void saveUser(UserDAO user)
        {
            String sql = "INSERT INTO dbo.users (username,password,role,name)VALUES('" + user.getUsername() + "', '" + user.getPassword() + "', '" + user.getRole() + "', '" + user.getName() + "'); ";

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(sql, _conn);
                adapter.InsertCommand.ExecuteNonQuery();
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static String getMd5Hash(String input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public void login(String username, String password)
        {
            //UsersDAL usersDAL = UsersDAL.getInstance();
            UserService userService = UserService.getInstance();
            String passMD5 = getMd5Hash(password);

            UserDAO u = userService.getUser(username, passMD5);
            if (u != null)
            {
                if (u.getRole() == "user")
                {
                    FormUser formUser = new FormUser();
                    formUser.Show();
                }
                else if (u.getRole() == "admin")
                {
                    FormAdmin formAdmin = new FormAdmin();
                    formAdmin.Show();
                }
            }
        }

        public void createAccount(String username, String name, String password)
        {
            String passMD5 = getMd5Hash(password);
            UserDAO newEmployee = new UserDAO(username,passMD5,name,"user");
            UserService userService = UserService.getInstance();
            //_usersDAL = 
            userService.saveUser(newEmployee);

        }

    }
}
