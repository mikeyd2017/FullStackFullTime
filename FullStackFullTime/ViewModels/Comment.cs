using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FullStackFullTime.ViewModels
{
    public class Comment
    {
        public int CommentID { get; set; }

        public int UserID { get; set; }

        public int QuestionID { get; set; }

        public string CommentText { get; set; }

        public int IsAnswer { get; set; }
        public DateTime CreateDate { get; set; }

        public string Username { get; set; }
        public Comment()
        {

        }
        public Comment([Optional] int commentID, int userID, int questionID, string commentText, int isAnswer, DateTime createDate, string userName)
        {
            CommentID = commentID;
            UserID = userID;
            QuestionID = questionID;
            CommentText = commentText;
            IsAnswer = isAnswer;
            CreateDate = createDate;
            Username = userName;
        }

    }
}
