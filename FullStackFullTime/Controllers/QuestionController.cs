using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackFullTime.Helpers;
using FullStackFullTime.Models;
using FullStackFullTime.SqlCommands;
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
        }

        public IActionResult Questions()
        {
           List<Question> allQuestions = _Factory.QuestionCommands.GetAllQuestions();
           return View(allQuestions);
        }

        public IActionResult Question(int questionID)
        {
            ViewModels.Question viewQuestion = new ViewModels.Question();
            viewQuestion.ModelQuestion = _Factory.QuestionCommands.GetQuestion(questionID);
            viewQuestion.Comments = _Factory.QuestionCommands.GetAllQuestionComments(questionID);
            return View(viewQuestion);
        }
        public IActionResult Ask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ask(int userID, string categoryLanguage, string questionText)
        {
            _Factory.QuestionHelper.AddQuestion(userID, categoryLanguage, DateTime.Now, questionText);
            return RedirectToAction("Questions");
        }

        [HttpPost]
        public IActionResult AddComment(int userID, int questionID, string commentText)
        {
            _Factory.QuestionHelper.AddComment(userID, questionID, commentText, 0, DateTime.Now);
            return RedirectToAction("Question", questionID);
        }
    }
}