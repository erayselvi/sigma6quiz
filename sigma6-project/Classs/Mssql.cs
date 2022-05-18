using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace sigma6_project
{
    public class Mssql
    {
        //private static string SQLConnectionString = @"Data Source=DESKTOP-1SGNBLK\SQL;Initial Catalog=denemedb;Persist Security Info=True;User ID=sa;Password=password1";
        //private SqlConnection con = new SqlConnection();
        //private SqlDataAdapter da = new SqlDataAdapter();
        //private SqlCommand com = new SqlCommand();
        //public Mssql()
        //{
        //    con = new SqlConnection(SQLConnectionString);
        //    if (con.State == System.Data.ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }

        //    //}
        //    //public object Command(string query)
        //    //{
        //    //    object obj;
        //    //    com.Connection = con; // SqlCommand
        //    //    com.CommandText = query; // SqlCommand
        //    //    obj = com.ExecuteScalar();
        //    //    return obj;
        //    //}
        //    //public DataTable Table(string query)
        //    //{
        //    //    DataTable dt = new DataTable();
        //    //    com.Connection = con; // SqlCommand
        //    //    com.CommandText = query; // SqlCommand
        //    //    da.SelectCommand = com; // // SqlCommand'ın bir select sorgusu olduğunu belirtiyoruz.
        //    //    da.Fill(dt);
        //    //    return dt;
        //    //}
        //    //public void register(string username, string password, string mail, string name, string sname, int type)
        //    //{
        //    //    com.CommandText="Insert into  LoginTable(Username,Password,Mail,Name,Surname,UserTypeID) Values ('" + username + "','" + password + "','" + mail + "','" + name + "','" + sname + "'," + type + ")";

        //    //    com.ExecuteNonQuery();

        //    //}

        //}
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

        private static string myConn = ConfigurationManager.ConnectionStrings[@"Data Source=DESKTOP-1SGNBLK\SQL;Initial Catalog=sigma6db;Persist Security Info=True;User ID=sa;Password=password1"].ConnectionString;
        private const string InsertQuery = "Insert into  LoginTable(Username,Password,Mail,Name,Surname,UserTypeID) Values (@UserName, @Password, @Mail, @Name, @Surname, @UserTypeID)";

        public bool InsertPersonal(Mssql personal)
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
        public bool UpdatePersonel(Mssql personal)
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