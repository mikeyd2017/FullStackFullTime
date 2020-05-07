using FullStackFullTime.DataModels;
using FullStackFullTime.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackFullTime.Helpers
{
    public class QuestionHelper
    {
        private Factory _Factory;

        public QuestionHelper(Factory oFactory)
        {
            _Factory = oFactory;

        }
        public bool AddQuestion(int userID, string categoryLanguage, DateTime createDate, string questionText, string questionTitle,
            string currentLanguage)
        {
            DataModels.Question newQuestion = new DataModels.Question(0, userID, categoryLanguage, createDate, questionText, questionTitle);

            newQuestion.CategoryLanguage = currentLanguage;

            _Factory.QuestionCommands.InsertQuestion(newQuestion);

            return true;
        }

        public bool AddComment(int userID, int questionID, string commentText, int isAnswer, DateTime createDate)
        {
            DataModels.Comment newComment = new DataModels.Comment(0, userID, questionID, commentText, isAnswer, createDate);

            _Factory.QuestionCommands.InsertComment(newComment);

            return true;
        }

        public List<ViewModels.Comment> ConvertDataCommentToViewComment(List<DataModels.Comment> dataQuestionComments)
        {
            List<ViewModels.Comment> viewQuestionComments = new List<ViewModels.Comment>();

            foreach (DataModels.Comment questionComment in dataQuestionComments)
            {
                ViewModels.Comment viewComment = new ViewModels.Comment();

                viewComment.CommentID = questionComment.CommentID;
                viewComment.CommentText = questionComment.CommentText;
                viewComment.CreateDate = questionComment.CreateDate;
                viewComment.IsAnswer = questionComment.IsAnswer;
                viewComment.QuestionID = questionComment.QuestionID;
                viewComment.UserID = questionComment.UserID;
                viewComment.Username = _Factory.AccountCommands.GetUserNameWithID(questionComment.UserID);

                viewQuestionComments.Add(viewComment);
            }

            return viewQuestionComments;
        }

    }
}
