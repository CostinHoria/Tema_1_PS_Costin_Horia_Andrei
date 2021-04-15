using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ex2.Entities;

namespace ex2.DAL
{
    public class UserDAO
    {
        private String username;
        private String password;
        private String name;
        private String role;

        public UserDAO(String username, String password, String name, String role)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.role = role;
        }

        public UserDAO toUserDAO(User user)
        {
            return new UserDAO(user.getUsername(),user.getPassword(), user.getName(),user.getRole());
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
