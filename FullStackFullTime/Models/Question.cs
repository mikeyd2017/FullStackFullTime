using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FullStackFullTime.Models
{
    public class Question
    {
        public int QuestionID { get; set; }

        public int UserID { get; set; }

        public string CategoryLanguage { get; set; }

        public DateTime CreateDate { get; set; }

        public string QuestionText { get; set; }

        public Question()
        {

        }

        public Question([Optional] int questionID, int userID, string categoryLanguage, DateTime createDate, string questionText)
        {
            QuestionID = questionID;
            UserID = userID;
            CategoryLanguage = categoryLanguage;
            CreateDate = createDate;
            QuestionText = questionText;
        }
    }
}
