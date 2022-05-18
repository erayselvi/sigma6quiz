using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sigma6_project
{
    public partial class RegisterPage : Form
    {
        
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterPage_Load(object sender, EventArgs e)
        {

        }

        private void Register_BT_Click(object sender, EventArgs e)
        {
            //Mssql db = new Mssql();
            //db.Command("insert into LoginTable ("+"Username"+") Values("+Username_TB.Text+","+Password_TB.Text+","+Mail_TB.Text+","+Name_TB.Text+","+Surname_TB.Text+",'"+1+"')");
            //db.Command("INSERT INTO LoginTable(Username, Password, Mail, Name, Surname, UserTypeID)   VALUES(@un,@pw,@mail,@n,@sn,@type)");
            //db.Command("insert into LoginTable(Username,Password,Mail,Name,Surname,UserTypeID)values('" + Username_TB.Text + "','" + Password_TB.Text + "','" + Mail_TB.Text + "','" + Name_TB.Text + "','" + Surname_TB.Text + "')");
            Mssql db = new Mssql();
            db.UserName = Username_TB.Text;
            db.Password = Password_TB.Text;
            db.Mail = Mail_TB.Text;
            db.Name = Username_TB.Text;
            db.SurName = Surname_TB.Text;
            db.UserTypeID = 1;
            var control = db.InsertPersonal(db);
            if (control) { MessageBox.Show("başarılı"); };
        }
    }
}
