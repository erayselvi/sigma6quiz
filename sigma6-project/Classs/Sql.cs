using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace sigma6_project.Classs
{
    class Sql
    {
        private static string myConn = ConfigurationManager.ConnectionStrings[@"Data Source = DESKTOP - 1SGNBLK\SQL; Initial Catalog = denemedb; Persist Security Info=True;User ID = sa; Password=password1"].ConnectionString;
        private const string InsertQuery= "Insert into  LoginTable(Username,Password,Mail,Name,Surname,UserTypeID) Values (@UserName, @Password, @Mail, @Name, @Surname, @UserTypeID)";

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
