using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sigma6project
{
    public partial class RegisterPage : Form
    {
        Database db = new Database();
        Personal p = new Personal();
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterPage_Load(object sender, EventArgs e)
        {

        }


        private void UserName_TB_TextChanged(object sender, EventArgs e)
        {
            p.UserName = UserName_TB.Text;
            if(db.RegisterContainUserName(p)) UserName_TB.Clear();

        }

        private void Mail_TB_TextChanged(object sender, EventArgs e)
        {
            p.Mail = Mail_TB.Text;
            if (db.RegisterContainMail(p))Mail_TB.Clear();
        }

        private void Register_B_Click(object sender, EventArgs e)
        {
            if(Password_TB.Text==PasswordR_TB.Text)
            {
                p.UserName = UserName_TB.Text;
                p.Password = Password_TB.Text;
                p.Mail = Mail_TB.Text;
                p.Name = Name_TB.Text;
                p.SurName = SurName_TB.Text;
                if(radioButton1.Checked)
                p.UserTypeID = 1;
                else
                    p.UserTypeID = 2;
                db.InsertPersonal(p);
                LoginPage LP = new LoginPage();
                this.Close();
                LP.Show();
            }
            else
            {
                MessageBox.Show("Şifreler Uyuşmuyor");
                Password_TB.Clear();
                PasswordR_TB.Clear();
            }

        }
    }
}
