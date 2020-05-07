using FullStackFullTime.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackFullTime.SqlCommands
{
    public class TableCommands
    {
        private DataHelper DataHelper;

        public TableCommands(DataHelper dataHelper)
        {
            DataHelper = dataHelper;
        }

        public bool CreateUserTable()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "Create Table Users (UserID int IDENTITY(1,1) PRIMARY KEY, Username varchar(20) NOT NULL, Password varchar(40) NOT NULL, Email varchar(60) NOT NULL, Role varchar(30) NOT NULL, CreateDate date NOT NULL);";
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }

        public bool AddHashedPassToUserTable()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "ALTER TABLE Users Alter Column Password char(300);";
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }


        public bool CreateQuestionTable()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "Create Table Questions (QuestionID int IDENTITY(1,1) PRIMARY KEY, UserID int NOT NULL, CategoryLanguage varchar(40) NOT NULL, CreateDate date NOT NULL, QuestionText varchar(350) NOT NULL, CONSTRAINT FK_User_Question FOREIGN KEY (UserID) REFERENCES Users (UserID) ON DELETE CASCADE ON UPDATE CASCADE);";
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }

        public bool RaiseVarCharQuestionTextToQuestionTable()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "ALTER TABLE Questions ALTER COLUMN QuestionText VARCHAR(1250);";
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }

        public bool CreateCommentTable()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "Create Table Comments (CommentID int IDENTITY(1,1) PRIMARY KEY, UserID int NOT NULL, QuestionID int NOT NULL, CommentText varchar(250), IsAnswer bit NOT NULL, CONSTRAINT FK_Question_Comment FOREIGN KEY (QuestionID) REFERENCES Questions (QuestionID), CONSTRAINT FK_User_Comment FOREIGN KEY (UserID) References Users (UserID) ON DELETE CASCADE ON UPDATE CASCADE);";
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }

        public bool AddCreateDateToCommentTable()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "ALTER TABLE Comments Add CreateDate date NOT NULL;";
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }

        public bool AddQuestionTitleToQuestionTable()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "ALTER TABLE Questions Add QuestionTitle varchar(50) NOT NULL;";
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }

        public bool DeleteQuestions()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "DELETE FROM Questions;";
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }
        public bool DeleteComments()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "DELETE FROM Comments;";
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }

    }
}
