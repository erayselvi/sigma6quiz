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
    public partial class QuizPage : Form
    {
        Database db = new Database();
        List<Question> temp;
        private int QuizID;
        int SigmaSayac;
        public int UserId;
        public int onTimer;
        int SigmaCurrect = 0,Currect=0;
        int sayac;
        string tempAnswer;
        public QuizPage()
        {
            InitializeComponent();
        }
        private void ItemLoad()
        {
            QUText_Label.Text =Currect+1+") " + temp[Currect].QuestionUpText;
            QDText_Label.Text = temp[Currect].QuestionDownText;
            pictureBox1.ImageLocation = temp[Currect].PicturePath;
            Right_RB.Text = temp[Currect].QuestionDownText;
            Right_RB.Text = temp[Currect].RightAnswer;
            Answer1_RB.Text = temp[Currect].Answer1;
            Answer2_RB.Text = temp[Currect].Answer2;
            Answer3_RB.Text = temp[Currect].Answer3;
        }
        int TimeMunite = 10;
        int TimeSecond=59;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            TimeSecond = TimeSecond - 1;
            LabelMunite.Text = (TimeMunite-1).ToString();
            LabelSecond.Text = TimeSecond.ToString();
            if(TimeSecond==0)
            {
                TimeMunite = TimeMunite - 1;
                TimeSecond = 60;
                if(TimeMunite==0)
                {
                    MessageBox.Show("Quiz süreniz dolmuştur.");
                    Next.Enabled = false;
                }
            }

        }
        private void QuizPage_Load(object sender, EventArgs e)
        {

            //KULLANICI GUNDE 1 KEZ QUİZ OLABİLİR EĞER BUGUN QUIZ OLMUS ISE QUIZ BASLATMASIN
            if (onTimer == 1)
            {
                timer1.Enabled = true;
                timer1.Start();
                timer1.Interval = 1000;
                LabelMunite.Text = (TimeMunite - 1).ToString();
                LabelSecond.Text = TimeSecond.ToString();
            }
            else label2.Text = "Süresiz Quiz-Test";


            db.QuizCheck(UserId);
            QuizID =db.QuizCreate(UserId); //UserExamResult create eder sınava girilen tarih için getdate ve quiz ıd oluşturur.

            temp = db.QuizSigma6(UserId); //sigma önceki quizde doğru bilinen soruları çekecektir.
            if (temp != null)
            {
                ItemLoad();
                SigmaSayac = temp.Count;
            }
            else
            {
                SigmaCurrect = db.Currect;
                temp = db.QuizStart(UserId);
                ItemLoad();
            }

        }


        private void Q1_B_Click(object sender, EventArgs e)
        {
            
        }


        private void Next_Click(object sender, EventArgs e)
        {
            if (sayac < SigmaSayac)//ise Sigma prensibi soru çekmiştir
            {
                if (Right_RB.Checked == true) tempAnswer = Right_RB.Text;
                else if (Answer1_RB.Checked == true) tempAnswer = Answer1_RB.Text;
                else if (Answer2_RB.Checked == true) tempAnswer = Answer2_RB.Text;
                else if (Answer3_RB.Checked == true) tempAnswer = Answer3_RB.Text;
                else tempAnswer = null;
                db.QuestionAnswerCheck(QuizID, temp[sayac].QuestionID, tempAnswer);
                Currect++;
                sayac++;
                if(SigmaSayac!=sayac)
                ItemLoad();
                label1.Text = sayac+1 + ".Sigma Sorusu";
            }
            else if(sayac==SigmaSayac)
            {
                sayac++;
                Currect = 0;
                SigmaCurrect = db.Currect;
                temp = db.QuizStart(UserId);
                ItemLoad();
                label1.Text = "QUİZ";
            }
            else if (Currect < temp.Count)//Quiz başlar
            {
                if (Right_RB.Checked == true) tempAnswer = Right_RB.Text;
                else if (Answer1_RB.Checked == true) tempAnswer = Answer1_RB.Text;
                else if (Answer2_RB.Checked == true) tempAnswer = Answer2_RB.Text;
                else if (Answer3_RB.Checked == true) tempAnswer = Answer3_RB.Text;
                else tempAnswer = null;
                //sınava gıren kişinin quiz ıdsi,cevaplanan soru id,quizde seçilen soru
                db.QuestionAnswerCheck(QuizID,temp[Currect].QuestionID, tempAnswer);
                Currect++;

                if (Currect != temp.Count) ItemLoad();
                else MessageBox.Show("Sınav Bitti");

            }
            else MessageBox.Show("sınav bitti");
                        
        }
    }
}
