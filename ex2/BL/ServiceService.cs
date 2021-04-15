using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ex2.Entities;
using ex2.DAL;

namespace ex2.BL
{
    public class ServiceService
    {
        ServiceDAL serviceDAL;

        public ServiceService()
        {
            serviceDAL = ServiceDAL.getInstance();
        }

        public void addNewService(String name, double price)
        {
            Service newService = new Service(name,price);
            //serviceDAL = ServiceService.getInstance();
            serviceDAL.saveService(newService);
        }

        public Service getByName(String name)
        {
            Service service = serviceDAL.getServiceByName(name);
            return service;
        }

        public void deleteService(String name)
        {
            serviceDAL.deleteServiceByName(name);
        }

        public void updateService(Service service, String name)
        {
            serviceDAL.updateService(service, name);
        }
    }
}
