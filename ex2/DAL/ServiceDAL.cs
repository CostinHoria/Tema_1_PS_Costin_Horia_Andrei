using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ex2.Entities;

namespace ex2.DAL
{
    class ServiceDAL
    {
        private static ServiceDAL _servicesDAL = null;
        private String _connectionString = @"Data Source=DESKTOP-MR6F4FF\SQLEXPRESS;Initial Catalog=ex2db;Integrated Security=True";
        SqlConnection _conn = null;

        private ServiceDAL()
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

        public static ServiceDAL getInstance()
        {
            if (_servicesDAL == null)
            {
                _servicesDAL = new ServiceDAL();
            }
            return _servicesDAL;
        }

        public void saveService(Service service)
        {
            String sql = "INSERT INTO dbo.service (name,price)VALUES('" + service.getName() + "', '" + service.getPrice() + "'); ";

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

        public Service getServiceByName(String name)
        {
            Service u = null;
            String sql = "SELECT * FROM dbo.service WHERE name='" + name + "'";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                String price_string = reader["price"].ToString();
                float price = float.Parse(price_string);
                u = new Service(reader["name"].ToString(), price);
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return u;
        }

        public void deleteServiceByName(String name)
        {
            Service u = null;
            String sql = "DELETE FROM dbo.service WHERE name='" + name + "'";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.ExecuteNonQuery();
                //SqlDataReader reader = cmd.ExecuteReader();
                //reader.Read();
                //String price_string = reader["price"].ToString();
                //float price = float.Parse(price_string);
                //u = new Service(reader["name"].ToString(), price);
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                //return null;
            }
        }

        public void updateService(Service service, String name)
        {
            String sql = "UPDATE dbo.service SET name = @nm, price = @pr Where name = @n";

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@nm", service.Name);
                cmd.Parameters.AddWithValue("@pr", service.Price);
                cmd.Parameters.AddWithValue("@n", name);
                //SqlDataAdapter adapter = new SqlDataAdapter();
                //adapter.InsertCommand = new SqlCommand(sql, _conn);
                //adapter.InsertCommand.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
