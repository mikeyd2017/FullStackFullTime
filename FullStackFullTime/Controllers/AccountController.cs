using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackFullTime.SqlCommands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FullStackFullTime.Controllers
{
    public class AccountController : Controller
    {
        private Factory _Factory = new Factory();

        public AccountController(IConfiguration iConfig)
        {
            _Factory.DataHelper = new Helpers.DataHelper(iConfig);
            _Factory.AccountCommands = new AccountCommands(_Factory.DataHelper);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string test)
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(string username, string password, string email)
        {
            
            return View();
        }



    }
}