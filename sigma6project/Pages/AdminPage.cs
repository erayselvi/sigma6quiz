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
    public partial class AdminPage : Form
    {

        Database db = new Database();
        List<Question> temp;
        int Currect = 0;
        public AdminPage()
        {
            InitializeComponent();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            temp = db.AdminQuestionData();
            QuestionLoadItems();
            
        }
        private void QuestionLoadItems()
        {
            
            if (Currect < temp.Count)
            {
               
                QUpText_RTB.Text = temp[Currect].QuestionUpText;
                QDownText_RTB.Text = temp[Currect].QuestionDownText;
                pictureBox1.ImageLocation = temp[Currect].PicturePath;
                label2.Text = temp[Currect].QuestionDownText;
                textBox1.Text = temp[Currect].RightAnswer;
                textBox2.Text = temp[Currect].Answer1;
                textBox3.Text = temp[Currect].Answer2;
                textBox4.Text = temp[Currect].Answer3;
                QuestionCurrect_Lbl.Text = "SORU ID: "+temp[Currect].QuestionID.ToString() + ")";
                Currect++;
            }
            else MessageBox.Show("Onaylanmamış soru bulunmamaktadır.");
        }

        private void GotoExaminerPage_B_Click(object sender, EventArgs e)
        {
            
            ExaminerPage EP = new ExaminerPage();
            EP.Show();
        }

        private void QConfirmation_B_Click(object sender, EventArgs e)
        {
            DialogResult Selected = MessageBox.Show("Emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo);
            if (Selected == DialogResult.Yes)
                if (Currect < temp.Count) db.AdminQuestionConfirmation(temp[Currect].QuestionID);
        }

        private void QNext_B_Click(object sender, EventArgs e)
        {

            if (Currect < temp.Count)
            
                QuestionLoadItems();
            
            else MessageBox.Show("Onaylanmamış Soru Kalmadı.");

        }

        private void QUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
