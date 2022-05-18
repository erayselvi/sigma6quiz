using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigma6project
{
    class Personal
    {
        int _id;
        string _username;
        string _password;
        string _mail;
        string _name;
        string _sname;
        int _type;

        public int UserID { get => _id; set => _id = value; }
        public string UserName { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Mail { get => _mail; set => _mail = value; }
        public string Name { get => _name; set => _name = value; }
        public string SurName { get => _sname; set => _sname = value; }
        public int UserTypeID { get => _type; set => _type = value; }
    }
}
