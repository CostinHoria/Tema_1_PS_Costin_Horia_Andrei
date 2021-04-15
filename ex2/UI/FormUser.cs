using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ex2.Entities;
using ex2.BL;
using System.Globalization;

namespace ex2.UI
{
    public partial class FormUser : Form
    {
        Appointment newAppointment;
        AppointmentService appointmentService;
        ServiceService serviceService;
        public FormUser()
        {
            InitializeComponent();
            appointmentService = new AppointmentService();
            serviceService = new ServiceService();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormUser_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            String ver = "";
            //string dater = textBox3.Text.ToString();
            //string date_str = textBox3.Text.ToString("dd/MM/yyyy HH:mm");
            //DateTime newDateTime = DateTime.Parse(textBox3.Text.ToString());
            //DateTime newDateTime = DateTime.Parse(textBox3.Text.ToString());
            DateTime newDateTime = DateTime.ParseExact(textBox3.Text.ToString(), "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            ver = newDateTime.ToString();
            //Console.WriteLine(ver);
            newAppointment = new Appointment(textBox1.Text.ToString(), textBox2.Text.ToString(),newDateTime);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Service service = serviceService.getByName(textBox4.Text.ToString());
            /*if(service == null)
            {
                Console.WriteLine("NU A GASIT SERVICIUL");
            }*/
            appointmentService.addServiceToAppointment(newAppointment ,service);
            appointmentService.calculateTotal(newAppointment);
            Console.WriteLine(newAppointment.Services.ToString());
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (appointmentService.checkAppointmentsForDuplicates(newAppointment) == false)
            {
                MessageBox.Show("There is an appointment duplicate!");

            }
            else
            {
                appointmentService.addNewAppointment(newAppointment);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /*static DataTable ConvertToDatatable(List<Appointment> list)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("URL");
            foreach (Appointment item in list)
            {
                var row = dt.NewRow();

                row["Name"] = item.Name;
                row["Price"] = Convert.ToString(item.Price);
                row["URL"] = item.URL;

                dt.Rows.Add(row);
            }

            return dt;
        }*/

        private void button4_Click(object sender, EventArgs e)
        {
            String str_apps = "";
            List<Appointment> apps = new List<Appointment>();
            int day = int.Parse(textBox5.Text.ToString());
            apps = appointmentService.getAllAppointmentsByDay(day);
            dataGridView1.DataSource = apps;
            str_apps = apps.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
