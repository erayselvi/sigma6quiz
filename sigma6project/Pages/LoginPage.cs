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
    public partial class LoginPage : Form
    {
        Database db = new Database();
        Personal p = new Personal();
        public LoginPage()
        {
            InitializeComponent();
        }


        private void Login_B_Click(object sender, EventArgs e)
        {
            p.UserName = UserName_TB.Text;
            p.Password = Password_TB.Text;
            int id = db.LoginPerson(p);

            if(id==1)
            {
                MainPage MP = new MainPage();
                MP.UserId = id;
                MP.Show();

            }
            else if(id==2)
            {
                ExaminerPage EP = new ExaminerPage();
                this.Hide();

                EP.Show();
            }else if(id==3)
            {
                AdminPage AP = new AdminPage();
                this.Hide();
                AP.Show();
            }
           
        }

        private void Register_B_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterPage RP = new RegisterPage();
            RP.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Password pg = new Password();
            pg.Show();


        }
    }
}
