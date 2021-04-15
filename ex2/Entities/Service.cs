using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2.Entities
{
    public class Service
    {
        String name;
        double price;

        public Service(String name,double price)
        {
            this.name = name;
            this.price = price;
        }

        public String Name { get { return name; }
                            set { name = value; } }
        public double Price { get { return price; }
                              set { price = value; } }

        public String getName()
        {
            return this.name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public double getPrice()
        {
            return this.price;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }
    }
}
