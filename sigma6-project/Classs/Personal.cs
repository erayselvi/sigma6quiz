using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace sigma6_project.Classs
{
    public class Personal
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

        private static string myConn = ConfigurationManager.ConnectionStrings[@"Data Source = DESKTOP - 1SGNBLK\SQL; Initial Catalog = denemedb; Persist Security Info=True;User ID = sa; Password=password1"].ConnectionString;
        private const string InsertQuery = "Insert into  LoginTable(Username,Password,Mail,Name,Surname,UserTypeID) Values (@UserName, @Password, @Mail, @Name, @Surname, @UserTypeID)";

        public bool InsertPersonal(Personal personal)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@UserName", personal.UserName);
                    com.Parameters.AddWithValue("@Password", personal.Password);
                    com.Parameters.AddWithValue("@Mail", personal.Mail);
                    com.Parameters.AddWithValue("@Name", personal.Name);
                    com.Parameters.AddWithValue("@SurName", personal.SurName);
                    com.Parameters.AddWithValue("@UserTypeID", personal.UserTypeID);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        private const string UpdateQuery = "Update LoginTable set UserName=@UserName, Password=@Password, Mail=@Mail, Name=@Name, SurName=@SurName, UserTypeID=@TypeId where UserID=@UserID";
        public bool UpdatePersonel(Personal personal)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@UserName", personal.UserName);
                    com.Parameters.AddWithValue("@Password", personal.Password);
                    com.Parameters.AddWithValue("@Mail", personal.Mail);
                    com.Parameters.AddWithValue("@Name", personal.Name);
                    com.Parameters.AddWithValue("@SurName", personal.SurName);
                    com.Parameters.AddWithValue("@UserTypeID", personal.UserTypeID);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
    }

}
