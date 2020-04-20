using FullStackFullTime.Helpers;
using FullStackFullTime.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackFullTime.SqlCommands
{
    public class QuestionCommands
    {
        private DataHelper DataHelper;
        Question question = new Question();

        public QuestionCommands(DataHelper dataHelper)
        {
            DataHelper = dataHelper;
        }

        public List<Question> GetAllQuestions()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "Select * From Questions;";

            SqlDataReader dr = cmd.ExecuteReader();

            List<Question> allQuestions = new List<Question>();

            while (dr.Read())
            {
                Question question = new Question(Convert.ToInt32(dr[0].ToString()), Convert.ToInt32(dr[1].ToString()), dr[2].ToString(), Convert.ToDateTime(dr[3].ToString()), dr[4].ToString());
                allQuestions.Add(question);
            }

            DataHelper.DbConn.Close();

            return allQuestions;
        }

        public List<Comment> GetAllQuestionComments(int questionID)
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "Select * From Comments Where QuestionID = @questionID;";

            cmd.Parameters.Add(new SqlParameter("questionID", questionID));

            SqlDataReader dr = cmd.ExecuteReader();

            List<Comment> allComments = new List<Comment>();

            while (dr.Read())
            {
                Comment comment = new Comment(Convert.ToInt32(dr[0].ToString()), Convert.ToInt32(dr[1].ToString()), Convert.ToInt32(dr[2].ToString()), dr[3].ToString(), Convert.ToInt32(dr[4]), Convert.ToDateTime(dr[5].ToString()));
                allComments.Add(comment);
            }

            DataHelper.DbConn.Close();

            return allComments;
        }

        public Question GetQuestion(int questionID)
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "Select * From Questions Where QuestionID = @questionID;";

            cmd.Parameters.Add(new SqlParameter("questionID", questionID));

            SqlDataReader dr = cmd.ExecuteReader();

            
            while (dr.Read())
            {
                question = new Question(Convert.ToInt32(dr[0].ToString()), Convert.ToInt32(dr[1].ToString()), dr[2].ToString(), Convert.ToDateTime(dr[3].ToString()), dr[4].ToString());
            }

            DataHelper.DbConn.Close();

            return question;
        }

        public bool InsertQuestion(Question newQuestion)
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "Insert Into Questions Values(@userID, @categoryLanguage, @createDate, @questionText);";

            cmd.Parameters.Add(new SqlParameter("userID", newQuestion.UserID));
            cmd.Parameters.Add(new SqlParameter("categoryLanguage", newQuestion.CategoryLanguage));
            cmd.Parameters.Add(new SqlParameter("createDate", newQuestion.CreateDate));
            cmd.Parameters.Add(new SqlParameter("questionText", newQuestion.QuestionText));

            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();

            return true;
        }

        public bool InsertComment(Comment newComment)
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "Insert Into Comments Values(@userID, @questionID, @commentText, @isAnswer, @createDate);";

            cmd.Parameters.Add(new SqlParameter("userID", newComment.UserID));
            cmd.Parameters.Add(new SqlParameter("questionID", newComment.QuestionID));
            cmd.Parameters.Add(new SqlParameter("commentText", newComment.CommentText));
            cmd.Parameters.Add(new SqlParameter("isAnswer", newComment.IsAnswer));
            cmd.Parameters.Add(new SqlParameter("createDate", newComment.CreateDate));


            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();

            return true;
        }
    }
}
