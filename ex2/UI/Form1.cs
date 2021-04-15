using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using ex2.BL;

namespace ex2.UI
{
    public partial class Form1 : Form
    {
        public UserService userService;
        public Form1(UserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }
        String username;
        String password;

        /*static String getMd5Hash(String input)
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
        }*/


    private void textBox1_TextChanged(object sender, EventArgs e)
            {
                username = sender.ToString();
            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {
                password = sender.ToString();
            }
        private void button1_Click(object sender, EventArgs e)
        {
            //UsersDAL usersDAL = UsersDAL.getInstance();
            //String passMD5 = getMd5Hash(textBox2.Text.ToString());

            /*User u= usersDAL.getUser(textBox1.Text.ToString(), passMD5);
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
            }*/
            //this.userService = UserService.getInstance();
            this.userService.login(textBox1.Text.ToString(), textBox2.Text.ToString());
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
