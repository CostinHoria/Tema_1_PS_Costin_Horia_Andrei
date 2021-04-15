using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ex2.BL;
using ex2.Entities;

namespace ex2.UI
{
    public partial class FormAdmin : Form
    {
        AppointmentService appointmentService;
        ServiceService serviceService;
        public FormAdmin()
        {
            InitializeComponent();
            appointmentService = new AppointmentService();
            serviceService = new ServiceService();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String newUsername = textBox1.Text.ToString();
            String newPassword = textBox2.Text.ToString();
            String newName = textBox3.Text.ToString();

            UserService userService = UserService.getInstance();
            userService.createAccount(newUsername,newName,newPassword);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceService serviceService = new ServiceService();
            String newPrice = textBox5.Text.ToString();
            double price = Convert.ToDouble(newPrice);

            serviceService.addNewService(textBox4.Text.ToString(), price);

            textBox4.Clear();
            textBox5.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Appointment> apps = new List<Appointment>();
            //int day = int.Parse(textBox5.Text.ToString());
            if (textBox6.Text.ToString() != "")
            {
                apps = appointmentService.getAppointmentsByClient(textBox6.Text.ToString());
                dataGridView1.DataSource = apps;
            }else if (textBox10.Text.ToString() != "" && textBox11.Text.ToString() != "")
            {
                DateTime firstDate = DateTime.ParseExact(textBox10.Text.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime lastDate = DateTime.ParseExact(textBox11.Text.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                apps = appointmentService.getAppointmentsBetweenTwoDates(firstDate, lastDate);
                dataGridView1.DataSource = apps;
            }
            //str_apps = apps.ToString();

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            serviceService.deleteService(textBox7.Text.ToString());
            textBox7.Clear();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Service serv = serviceService.getByName(textBox4.Text.ToString());
            serv.Name = textBox8.Text.ToString();
            serv.Price = double.Parse(textBox9.Text.ToString());
            serviceService.updateService(serv,textBox4.Text.ToString());

            textBox8.Clear();
            textBox9.Clear();
        }

        

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
