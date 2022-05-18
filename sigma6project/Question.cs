using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigma6project
{

    class Question
    {
        int _id;
        string _uptext;
        string _downtext;
        int _subjectid;
        int _unitid;
        string _picturepath;
        string _answer1;
        string _answer2;
        string _answer3;
        string _rightanswer;
        string _confirmation;

        public int QuestionID { get => _id; set => _id = value; }
        public int SubjectID { get => _subjectid; set => _subjectid = value; }
        public string QuestionUpText { get => _uptext; set => _uptext = value; }
        public string QuestionDownText { get => _downtext; set => _downtext = value; }
        public int UnitID { get => _unitid; set => _unitid = value; }
        public string PicturePath { get => _picturepath; set => _picturepath = value; }
        public string Answer1 { get => _answer1; set => _answer1 = value; }
        public string Answer2 { get => _answer2; set => _answer2 = value; }
        public string Answer3 { get => _answer3; set => _answer3 = value; }
        public string RightAnswer { get => _rightanswer; set => _rightanswer = value; }
        public string Confirmation { get => _confirmation; set => _confirmation = value; }
    }
}
