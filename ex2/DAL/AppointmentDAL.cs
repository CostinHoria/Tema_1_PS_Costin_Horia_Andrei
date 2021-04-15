using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ex2.Entities;
using System.Globalization;

namespace ex2.DAL
{
    public class AppointmentDAL
    {
        private static AppointmentDAL _appointmentDAL = null;
        private String _connectionString = @"Data Source=DESKTOP-MR6F4FF\SQLEXPRESS;Initial Catalog=ex2db;Integrated Security=True";
        SqlConnection _conn = null;

        private AppointmentDAL()
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

        public static AppointmentDAL getInstance()
        {
            if (_appointmentDAL == null)
            {
                _appointmentDAL = new AppointmentDAL();
            }
            return _appointmentDAL;
        }

        public void saveAppointment(Appointment appointment)
        {
            //String date_str = appointment.Appointment_date.ToString("dd/MM/yyyy");
            //String time_str = appointment.Appointment_date
            String sql = "INSERT INTO dbo.appointment ( name_client, phone_number, appointment_date, total, services)VALUES('" + appointment.Name_client + "', '" + appointment.Phone_number + "' , '" + appointment.Appointment_date + "' , '" + appointment.Total + "' , '" + appointment.ServicesToString() + "'); ";

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

        public List<Appointment> getAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            String sql = "SELECT * FROM dbo.appointment";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Double u_price = double.Parse(reader["total"].ToString());
                    //DateTime u_dateTime = DateTime.ParseExact(reader["appointment_date"].ToString(), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime u_dateTime = DateTime.Parse(reader["appointment_date"].ToString());
                    Appointment u = new Appointment(reader["name_client"].ToString(), reader["phone_number"].ToString(), u_dateTime, u_price, reader["services"].ToString());
                    //appointments = new List<Appointment>(reader["nameclient"].ToString(), reader["phonenumber"].ToString(), reader["total"]., reader["services"].ToString());
                    appointments.Add(u);
                }
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return appointments;
        }

    }
}
