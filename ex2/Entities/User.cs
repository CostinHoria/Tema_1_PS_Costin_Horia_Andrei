using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2.Entities
{
    public class User
    {
        private String username;
        private String password;
        private String name;
        private String role;

        public User(String username, String password, String name, String role)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.role = role;
        }

        public String getRole()
        {
            return this.role;
        }

        public String getUsername()
        {
            return this.username;
        }

        public String getName()
        {
            return this.name;
        }

        public String getPassword()
        {
            return this.password;
        }

        public void setRole(String role)
        {
            this.role = role;
        }

        public void setUsername(String username)
        {
            this.username = username;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public void setPassword(String password)
        {
            this.password = password;
        }
    }
}
