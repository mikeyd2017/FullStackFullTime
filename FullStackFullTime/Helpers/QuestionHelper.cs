using FullStackFullTime.Models;
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
        public bool AddQuestion(int userID, string categoryLanguage, DateTime createDate, string questionText)
        {
            Question newQuestion = new Question(0, userID, categoryLanguage, createDate, questionText);

            _Factory.QuestionCommands.InsertQuestion(newQuestion);

            return true;
        }

        public bool AddComment(int userID, int questionID, string commentText, int isAnswer, DateTime createDate)
        {
            Comment newComment = new Comment(0, userID, questionID, commentText, isAnswer, createDate);

            _Factory.QuestionCommands.InsertComment(newComment);

            return true;
        }

    }
}
