using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2.Entities
{
    public class Appointment
    {
        public DateTime appointment_date;
        public String name_client;
        public String phone_number;
        public double total;
        public List<Service> services;
        public String servicesAsString;
        public String Name_client { get { return name_client; }
                                    set { name_client = value;} }
        public String Phone_number {get{ return phone_number; }
                                    set { phone_number = value; } }
        public DateTime Appointment_date { get { return appointment_date; }
                                    set { appointment_date = value; } }
        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        public List<Service> Services
        {
            get { return services; }
            set { services = value; }
        }

        public String ServicesAsString
        {
            get { return servicesAsString; }
            set { servicesAsString = value; }
        }
        public Appointment(String name_client, String phone_number, DateTime appointment_date)
        {
            this.phone_number = phone_number;
            this.name_client = name_client;
            this.services = new List<Service>();
            this.appointment_date = appointment_date;
        }

        public Appointment(String name_client, String phone_number, DateTime appointment_date, double total, String servicesAsString)
        {
            this.phone_number = phone_number;
            this.name_client = name_client;
            this.total = total;
            this.appointment_date = appointment_date;
            this.servicesAsString = servicesAsString;
        }

        public String ServicesToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Service service in Services)
            {
                stringBuilder.Append(service.Name + " ,");
            }
            return stringBuilder.ToString();
        }
    }
}
