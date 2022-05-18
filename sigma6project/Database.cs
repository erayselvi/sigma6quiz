using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;
namespace sigma6project
{
    class Database
    {
        private const string myConn = @"Data Source=DESKTOP-1SGNBLK\SQL;Initial Catalog=sigma6db;Persist Security Info=True;User ID=sa;Password=password1";
        private const string InsertQuery = "Insert into  LoginTable(Username,Password,Mail,Name,Surname,UserTypeID) Values (@UserName, @Password, @Mail, @Name, @Surname, @UserTypeID)";
        private const string UpdateQuery = "Update LoginTable set UserName=@UserName, Password=@Password, Mail=@Mail, Name=@Name, SurName=@SurName, UserTypeID=@TypeId where UserID=@UserID";
        private const string ContainUserNameQuery = "Select * From LoginTable Where UserName=@UserName";
        private const string ContainMailQuery = "Select * From LoginTable Where Mail=@Mail";
        private const string LoginQuery = "Select UserTypeID From LoginTable Where UserName=@UserName and Password=@Password";
        
        public int Currect;

        private const string QuestionQuery = "Insert into QuestionsTable(QuestionUpText,QuestionDownText,SubjectID,UnitID,PicturePath,Answer1,Answer2,Answer3,RightAnswer) Values(@QuestionUpText,@QuestionDownText,@SubjectID,@UnitID,@PicturePath,@Answer1,@Answer2,@Answer3,@RightAnswer)";

        public void InsertPersonal(Personal personal)
        {

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
                    com.ExecuteNonQuery();
                }
            }
        }
        public bool UpdatePersonal(Personal personal)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UpdateQuery, con))
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
        public bool RegisterContainUserName(Personal personal)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (var com = new SqlCommand(ContainUserNameQuery, con))
                {
                    com.Parameters.AddWithValue("@UserName", personal.UserName);
                    using (var reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MessageBox.Show("Kullanıcı adı kullanımda!.");
                            return true;
                        }
                    }
                    return false;
                }
            }
        }
        public bool RegisterContainMail(Personal personal)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (var com = new SqlCommand(ContainMailQuery, con))
                {
                    com.Parameters.AddWithValue("@Mail", personal.Mail);

                    using (var reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MessageBox.Show("Mail adresi kullanımda!.");
                            return true;
                        }
                    }
                    return false;
                }
            }
        }
        public int LoginPerson(Personal personal)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (var com = new SqlCommand(LoginQuery, con))
                {
                    com.Parameters.AddWithValue("@UserName", personal.UserName);
                    com.Parameters.AddWithValue("@Password", personal.Password);
                    int type=Convert.ToInt32(com.ExecuteScalar());
                    SqlDataReader r=com.ExecuteReader();
                    if (r.Read())
                    {
                        type = Convert.ToInt32(r["UserTypeID"]);
                        return type;
                    }
                    else MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
                    return 0;
                    //using (object reader = com.ExecuteScalar())
                    //{
                    //    if ()
                    //    {
                    //        MessageBox.Show("giriş yapıldı");
                    //        return true;
                    //    }
                    //}
                    //return false;
                }
            }
        }

        public void QuestionAdd(Question question)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(QuestionQuery, con))
                {
                    com.Parameters.AddWithValue("@QuestionUpText", question.QuestionUpText);
                    com.Parameters.AddWithValue("@QuestionDownText", question.QuestionDownText);
                    com.Parameters.AddWithValue("@SubjectID", question.SubjectID);
                    com.Parameters.AddWithValue("@UnitID", question.UnitID);
                    com.Parameters.AddWithValue("@PicturePath", question.PicturePath);
                    com.Parameters.AddWithValue("@Answer1", question.Answer1);
                    com.Parameters.AddWithValue("@Answer2", question.Answer2);
                    com.Parameters.AddWithValue("@Answer3", question.Answer3);
                    com.Parameters.AddWithValue("@RightAnswer", question.RightAnswer);
                    rows = com.ExecuteNonQuery();
                    if (rows > 0) MessageBox.Show("Soru eklendi.");
                }
            }
        }
        public string[] SubjectData()
        {
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("select * from SubjectTable", con))
                {
                    SqlDataReader dr = com.ExecuteReader();
                    List<string> liste = new List<string>();
                    while (dr.Read())
                    {
                        liste.Add(dr["SubjectName"].ToString());
                    }
                    string[] combobox = liste.ToArray();
                    return combobox;
                }

            }
        }

        public List<Question> QuizSigma6(int id)
        {
            List<Question> quests = new List<Question>();

            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("select * from QuizDetail where isTrue='T' and QuizID=(select top 1 QuizID from UserExamResults where 1=datediff(day,QuizDate,getdate()) Order BY QuizDate DESC)", con))
                {
                    Currect = Convert.ToInt32(com.ExecuteScalar());
                    if (Convert.ToInt32(com.ExecuteScalar()) > 0)
                    {

                        int searchquizid = Convert.ToInt32(com.ExecuteScalar());
                        Currect = Convert.ToInt32(com.ExecuteScalar());

                        SqlDataReader dr = com.ExecuteReader();
                        List<int> trueQuestionNumber = new List<int>();
                        while (dr.Read())
                        {
                            int temp =Convert.ToInt32(dr["QuestionID"]); ;
                            trueQuestionNumber.Add(temp);
                            //Question question = new Question();
                            //question.QuestionID = Convert.ToInt32(dr["QuestionID"]);
                            //question.QuestionUpText = dr["QuestionUpText"].ToString();
                            //question.QuestionDownText = dr["QuestionDownText"].ToString();
                            //question.SubjectID = Convert.ToInt32(dr["SubjectID"]);
                            //question.UnitID = Convert.ToInt32(dr["UnitID"]);
                            //question.PicturePath = dr["PicturePath"].ToString();
                            //question.Answer1 = dr["Answer1"].ToString();
                            //question.Answer2 = dr["Answer2"].ToString();
                            //question.Answer3 = dr["Answer3"].ToString();
                            //question.RightAnswer = dr["RightAnswer"].ToString();
                            //question.Confirmation = dr["Confirmation"].ToString();

                            //quests.Add(question);
                        
                        }
                        dr.Close();
                        for (int i = 0; i < trueQuestionNumber.Count; i++)
                        {
                            
                            using (SqlConnection conn = new SqlConnection(myConn))
                            {
                                conn.Open();
                                using (SqlCommand comm = new SqlCommand("select * from QuestionsTable where QuestionID="+ trueQuestionNumber[i] +"", con))
                                {
                                    SqlDataReader drr = comm.ExecuteReader();
                                    while (drr.Read())
                                    {
                                        Question question = new Question();
                                        question.QuestionID = Convert.ToInt32(drr["QuestionID"]);
                                        question.QuestionUpText = drr["QuestionUpText"].ToString();
                                        question.QuestionDownText = drr["QuestionDownText"].ToString();
                                        question.SubjectID = Convert.ToInt32(drr["SubjectID"]);
                                        question.UnitID = Convert.ToInt32(drr["UnitID"]);
                                        question.PicturePath = drr["PicturePath"].ToString();
                                        question.Answer1 = drr["Answer1"].ToString();
                                        question.Answer2 = drr["Answer2"].ToString();
                                        question.Answer3 = drr["Answer3"].ToString();
                                        question.RightAnswer = drr["RightAnswer"].ToString();
                                        question.Confirmation = drr["Confirmation"].ToString();

                                        quests.Add(question);
                                        
                                    }
                                    drr.Close();
                                }
                            }
                        }
                        return quests;
                    }
                    return null;
                }
            }
        }
        public List<Question> QuizStart(int id)
        {
            List<Question> quests = new List<Question>();

            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("select top 10 * from QuestionsTable where Confirmation='T' Order By NewId()" , con)) //where QuestionId!= (select QuestionID from QuizDetail where QuizID = (select top 1 QuizID from UserExamResults where 1 < datediff(day, QuizDate, getdate()) Order BY QuizDate DESC))
                {
                    if (Convert.ToInt32(com.ExecuteScalar()) > 0)
                    {


                        //com.CommandText = "select * from QuizDetail where QuizID=" + searchquizid + " and isTrue='T'";//son quizin doğru cevaplananları
                        SqlDataReader dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            Question question = new Question();
                            question.QuestionID = Convert.ToInt32(dr["QuestionID"]);
                            question.QuestionUpText = dr["QuestionUpText"].ToString();
                            question.QuestionDownText = dr["QuestionDownText"].ToString();
                            question.SubjectID = Convert.ToInt32(dr["SubjectID"]);
                            question.UnitID = Convert.ToInt32(dr["UnitID"]);
                            question.PicturePath = dr["PicturePath"].ToString();
                            question.Answer1 = dr["Answer1"].ToString();
                            question.Answer2 = dr["Answer2"].ToString();
                            question.Answer3 = dr["Answer3"].ToString();
                            question.RightAnswer = dr["RightAnswer"].ToString();
                            question.Confirmation = dr["Confirmation"].ToString();

                            quests.Add(question);
                        }

                        return quests;

                    }

                    return null;
                }

            }
        }
        public List<Question> AdminQuestionData()
        {
            List<Question> quests = new List<Question>();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("SELECT * FROM QuestionsTable WHERE Confirmation='F'", con))
                {
                    {
                        SqlDataReader dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            Currect++;
                            Question question = new Question();
                            question.QuestionID = Convert.ToInt32(dr["QuestionID"]);
                            question.QuestionUpText = dr["QuestionUpText"].ToString();
                            question.QuestionDownText = dr["QuestionDownText"].ToString();
                            question.SubjectID = Convert.ToInt32(dr["SubjectID"]);
                            question.UnitID = Convert.ToInt32(dr["UnitID"]);
                            question.PicturePath = dr["PicturePath"].ToString();
                            question.Answer1 = dr["Answer1"].ToString();
                            question.Answer2 = dr["Answer2"].ToString();
                            question.Answer3 = dr["Answer3"].ToString();
                            question.RightAnswer = dr["RightAnswer"].ToString();
                            question.Confirmation = dr["Confirmation"].ToString();

                            quests.Add(question);
                        }
                        return quests;
                    }
                    return quests;
                }

            }
        }
        public void AdminQuestionConfirmation(int QuestionID)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("update QuestionsTable set Confirmation='T' WHERE QuestionID=" + QuestionID + "", con))
                {
                    if (Convert.ToInt32(com.ExecuteNonQuery()) > 0)
                    {
                        MessageBox.Show("Soru Güncellendi.");
                    }
                }
            }
        }
        public int QuizCreate(int id)//Quize giren öğrenci için UserExamResult oluşturur.
        {
            int CreateQuizIdReturn;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("insert into UserExamResults(UserID)Values(" + id + ");Select SCOPE_IDENTITY()", con)) //where QuestionId!= (select QuestionID from QuizDetail where QuizID = (select top 1 QuizID from UserExamResults where 1 < datediff(day, QuizDate, getdate()) Order BY QuizDate DESC))
                {

                        //com.CommandText = "select * from QuizDetail where QuizID=" + searchquizid + " and isTrue='T'";//son quizin doğru cevaplananları
                       CreateQuizIdReturn = Convert.ToInt32(com.ExecuteScalar());

                    //{
                    //    CreateQuizIdReturn= Convert.ToInt32(dr["QuizID"].ToString());
                    return CreateQuizIdReturn;
                    
                }
                return CreateQuizIdReturn;
            }
        }
        public void QuestionAnswerCheck(int quizid, int questionid, string tempanswer)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("select * from QuestionsTable where QuestionID=" + questionid + " and RightAnswer='" + tempanswer + "'", con)) //where QuestionId!= (select QuestionID from QuizDetail where QuizID = (select top 1 QuizID from UserExamResults where 1 < datediff(day, QuizDate, getdate()) Order BY QuizDate DESC))
                {
                    if (Convert.ToInt32(com.ExecuteScalar()) > 0)
                    {
                        com.CommandText = "insert into QuizDetail(QuizID,QuestionID,isTrue)Values(" + quizid + "," + questionid + ",'T')";//doğru ise quizdetail tablosuna questionid için T kaydedilir.
                        com.ExecuteNonQuery();
                    }
                    else
                    {
                        com.CommandText = "select RightAnswer from QuestionsTable where QuestionID=" + questionid + " and Answer1='" + tempanswer + "'";
                        com.ExecuteScalar();
                        if (Convert.ToInt32(com.ExecuteScalar()) > 0)
                        {
                            com.CommandText = "insert into QuizDetail(QuizID,QuestionID,isTrue)Values(" + quizid + "," + questionid + ",'F')";//yanlıs cevap verilmiş ise F kaydedilir

                        }else com.CommandText = "select RightAnswer from QuestionsTable where QuestionID=" + questionid + " and Answer2='" + tempanswer + "'";
                        if (Convert.ToInt32(com.ExecuteScalar()) > 0)
                        {
                            com.CommandText = "insert into QuizDetail(QuizID,QuestionID,isTrue)Values(" + quizid + "," + questionid + ",'F')";//yanlıs cevap verilmiş ise F kaydedilir

                        }else com.CommandText = "select RightAnswer from QuestionsTable where QuestionID=" + questionid + " and Answer3='" + tempanswer + "'";
                        if (Convert.ToInt32(com.ExecuteScalar()) > 0)
                        {
                            com.CommandText = "insert into QuizDetail(QuizID,QuestionID,isTrue)Values(" + quizid + "," + questionid + ",'F')";//yanlıs cevap verilmiş ise F kaydedilir

                        }else com.CommandText = "insert into QuizDetail(QuizID,QuestionID,isTrue)Values(" + quizid + "," + questionid + ",'N')";//bos cevaptır N kaydedilir

                    }
                }
            }
        }
        public void QuizCheck(int userid)
        {
            //using (SqlConnection con = new SqlConnection(myConn))
            //{
            //    con.Open();
            //    using (SqlCommand com = new SqlCommand("select * from UserExamResults where QuestionID=" + userid + " and QuizDate='getdate()'", con))
            //    {
            //        if (Convert.ToInt32(com.ExecuteScalar()) > 0) MessageBox.Show("Günlük quiz olunlmuştur.");
            //    }
            //}
        }

        public DataTable QuizRapor(int id)
        {
            
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("SELECT QuizDate,True,False,Empty FROM UserExamResults WHERE UserID="+id+"", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }

            }
        }
        public void getPassword(string mail)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("SELECT Password FROM LoginTable WHERE Mail='" + mail + "'", con))
                {
                    SqlDataReader r;
                    r = com.ExecuteReader();
                    if (r.Read())
                    {

                        MessageBox.Show("Şifre eposta adresinize gönderilmiştir");
                        
                        MailMessage pass = new MailMessage();
                        SmtpClient client = new SmtpClient();
                        client.Credentials = new System.Net.NetworkCredential("sigma6project.cbu@gmail.com", "cbu123456");
                        client.Port = 587;
                        client.Host = "smtp.gmail.com";
                        client.EnableSsl = true;
                        pass.To.Add(mail);
                        pass.From = new MailAddress("sigma6project.cbu@gmail.com");
                        pass.Subject="Sigma6db Şifreniz";
                        pass.Body= r["Password"].ToString();
                        client.Send(pass);


                    }
                    else MessageBox.Show("Kullanıcı bulunamadı");
                }

            }
        }
    }
}
