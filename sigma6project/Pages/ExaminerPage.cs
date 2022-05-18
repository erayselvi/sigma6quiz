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
    public partial class ExaminerPage : Form
    {
        public ExaminerPage()
        {
            InitializeComponent();
        }
        Database db = new Database();
        Question qc = new Question();
        private void ExaminerPage_Load(object sender, EventArgs e)
        {
            Subject_CB.DataSource = db.SubjectData();
            YesPicture_RadioB.Checked = true;
        }

        private void Add_B_Click(object sender, EventArgs e)
        {

            //foreach (Control ctl in this.Controls)
            //    if (ctl is TextBox)
            //    {
            //        if (ctl.Text == String.Empty)
            //        {
            //            MessageBox.Show(Convert.ToString(((TextBox)ctl).Tag + " boş!"));
            //        }
            //    }

            DialogResult Selected= MessageBox.Show("Soruyu kaydetmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel);
            if (Selected == DialogResult.Yes)
            {
                qc.QuestionUpText = QText_Up_Txt.Text;
                qc.QuestionDownText = QText_Down_Txt.Text;
                qc.PicturePath = PicturePath_TB.Text;
                if (YesPicture_RadioB.Checked) qc.RightAnswer = RAnswer.Text;
                qc.Answer1 = Answer1.Text;
                qc.Answer2 = Answer2.Text;
                qc.Answer3 = Answer3.Text;
                qc.SubjectID = Subject_CB.SelectedIndex + 1;
                qc.UnitID = Subject_CB.SelectedIndex + 1;
                db.QuestionAdd(qc);
            }
             else if(Selected==DialogResult.No)
            {
                this.Controls.Clear();
                this.InitializeComponent();
                ExaminerPage_Load(sender, e);
            }
        }


        private void YesPicture_RadioB_CheckedChanged(object sender, EventArgs e)
        {
            PicturePath_TB.Enabled = false;
        }

        private void YesPicture_RadioB_CheckedChanged_1(object sender, EventArgs e)
        {
            PicturePath_TB.Enabled = true;
        }

        private void Search_B_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.png;*.nef;*.jpg |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            PicturePath_TB.Text = dosyayolu;
            
        }
    }
}
