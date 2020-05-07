using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackFullTime.Helpers;
using FullStackFullTime.DataModels;
using FullStackFullTime.ViewModels;
using FullStackFullTime.SqlCommands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FullStackFullTime.Controllers
{
    public class QuestionController : Controller
    {
        private Factory _Factory = new Factory();


        public QuestionController(IConfiguration iConfig)
        {
            _Factory.DataHelper = new DataHelper(iConfig);
            _Factory.QuestionCommands = new QuestionCommands(_Factory.DataHelper);
            _Factory.QuestionHelper = new QuestionHelper(_Factory);
            _Factory.AccountCommands = new AccountCommands(_Factory.DataHelper);
        }

        public IActionResult Questions()
        {

           if(String.IsNullOrEmpty(HttpContext.Session.GetString("CurrentLanguage")))
           {
                HttpContext.Session.SetString("CurrentLanguage", "C#");
           }
           List<DataModels.Question> allQuestions = _Factory.QuestionCommands.GetAllQuestions(HttpContext.Session.GetString("CurrentLanguage"));
           return View(allQuestions);
        }

        public IActionResult Question(int questionID)
        {
            List<DataModels.Comment> dataQuestionComments = _Factory.QuestionCommands.GetAllQuestionComments(questionID);

            List<ViewModels.Comment> questionComments = _Factory.QuestionHelper.ConvertDataCommentToViewComment(dataQuestionComments);

            ViewModels.Question viewQuestion = new ViewModels.Question();

            viewQuestion.ModelQuestion = _Factory.QuestionCommands.GetQuestion(questionID);
            viewQuestion.Comments = questionComments;

            return View(viewQuestion);
        }
        public IActionResult Ask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ask(int userID, string categoryLanguage, string questionText, string questionTitle)
        {
            _Factory.QuestionHelper.AddQuestion(userID, categoryLanguage, DateTime.Now, questionText, questionTitle, HttpContext.Session.GetString("CurrentLanguage"));
            return RedirectToAction("Questions");
        }

        [HttpPost]
        public IActionResult AddComment(int userID, int questionID, string commentText)
        {
            _Factory.QuestionHelper.AddComment(userID, questionID, commentText, 0, DateTime.Now);
            return RedirectToAction("Question", new { questionID = questionID });
        }

        public IActionResult CSharp()
        {
            HttpContext.Session.SetString(Convert.ToString(DataModels.Question.ProgrammingLanguages.CSharp), "True");

            HttpContext.Session.SetString("CurrentLanguage", "C#");


            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }

        public IActionResult JS()
        {
            HttpContext.Session.SetString(Convert.ToString(DataModels.Question.ProgrammingLanguages.JS), "True");

            HttpContext.Session.SetString("CurrentLanguage", Convert.ToString(DataModels.Question.ProgrammingLanguages.JS));


            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }

        public IActionResult PHP()
        {
            HttpContext.Session.SetString(Convert.ToString(DataModels.Question.ProgrammingLanguages.PHP), "True");

            HttpContext.Session.SetString("CurrentLanguage", Convert.ToString(DataModels.Question.ProgrammingLanguages.PHP));


            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }

        public IActionResult Java()
        {
            HttpContext.Session.SetString(Convert.ToString(DataModels.Question.ProgrammingLanguages.Java), "True");

            HttpContext.Session.SetString("CurrentLanguage", Convert.ToString(DataModels.Question.ProgrammingLanguages.Java));


            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }

        public IActionResult CSS()
        {
            HttpContext.Session.SetString(Convert.ToString(DataModels.Question.ProgrammingLanguages.CSS), "True");

            HttpContext.Session.SetString("CurrentLanguage", Convert.ToString(DataModels.Question.ProgrammingLanguages.CSS));


            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }
    }
}