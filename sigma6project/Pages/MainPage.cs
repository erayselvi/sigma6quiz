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
    public partial class MainPage : Form
    {
        public int UserId;
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuizPage QP = new QuizPage();
            QP.UserId = UserId;
            QP.onTimer = 1;
            QP.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuizPage QP = new QuizPage();
            QP.UserId = UserId;
            QP.onTimer = 0;
            QP.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            dataGridView1.DataSource = db.QuizRapor(UserId);

        }
    }
}
