using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ex2.Entities;
using ex2.DAL;

namespace ex2.BL
{
    public class AppointmentService
    {
        AppointmentDAL appointmentDAL;

        public AppointmentService()
        {
            appointmentDAL = AppointmentDAL.getInstance();
        }

        public void calculateTotal(Appointment appointment)
        {
            double total = 0.0f;
            foreach (Service service in appointment.Services)
            {
                total += service.Price;
            }
            Console.WriteLine(total);

            appointment.Total = total;
        }

        public void addServiceToAppointment(Appointment appointment ,Service service)
        {
            //appointment.Services.Add(service);
            List<Service> list = appointment.Services;
            list.Add(service);
            appointment.Services = list;
        }
        public void addNewAppointment(Appointment newAppointment)
        {
            //Service newService = new Service(name, price);
            //Appointment newAppointment = new Appointment();
            //serviceDAL = ServiceService.getInstance();
            appointmentDAL.saveAppointment(newAppointment);
        }

        public bool checkAppointmentsForDuplicates(Appointment appointment)
        {
            bool ok = true;
            foreach(Appointment app in appointmentDAL.getAllAppointments())
            {
                if((app.Appointment_date.Day == appointment.Appointment_date.Day) && 
                    (app.Appointment_date.Month == appointment.Appointment_date.Month) && 
                    (app.Appointment_date.Year == appointment.Appointment_date.Year) &&
                    (app.appointment_date.Hour == appointment.Appointment_date.Hour) &&
                    (app.Appointment_date.Minute == appointment.Appointment_date.Minute))
                {
                        foreach(Service ser_j in appointment.Services)
                        {
                            if(app.ServicesAsString.Contains(ser_j.Name) == true)
                            {
                                ok = false;
                            }
                        }
                }
            }
            return ok;
        }

        public List<Appointment> getAllAppointmentsByDay(int day)
        {
            List<Appointment> apps_list = new List<Appointment>();
            foreach (Appointment app in appointmentDAL.getAllAppointments())
            {
                if (app.Appointment_date.Day == day)
                    apps_list.Add(app);
            }
            return apps_list;
        }

        public List<Appointment> getAppointmentsByClient(String name)
        {
            List<Appointment> apps_list = new List<Appointment>();
            foreach (Appointment app in appointmentDAL.getAllAppointments())
            {
                if (app.Name_client == name)
                    apps_list.Add(app);
            }
            return apps_list;
        }

        public List<Appointment> getAppointmentsBetweenTwoDates(DateTime firstDate, DateTime lastDate)
        {
            List<Appointment> apps_list = new List<Appointment>();
            foreach (Appointment app in appointmentDAL.getAllAppointments())
            {
                if ( DateTime.Compare(app.Appointment_date, firstDate) > 0 && DateTime.Compare(app.Appointment_date, lastDate) < 0)
                    apps_list.Add(app);
            }
            return apps_list;
        }
    }
}
