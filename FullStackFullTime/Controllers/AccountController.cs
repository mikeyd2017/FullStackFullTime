﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackFullTime.Helpers;
using FullStackFullTime.SqlCommands;
using Microsoft.AspNetCore.Http;
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
            _Factory.AccountHelper = new AccountHelper(_Factory);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            _Factory.AccountHelper.CheckAccount(username, password);

            HttpContext.Session.SetString("role", _Factory.AccountCommands.GetUserRole(username));
            HttpContext.Session.SetString("userID", Convert.ToString(_Factory.AccountCommands.GetUserID(username)));
            HttpContext.Session.SetString("username", username);


            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string email)
        {

            _Factory.AccountHelper.CreateUser(username, _Factory.AccountHelper.HashPassword(password), email);
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("role", "");
            HttpContext.Session.SetString("userID", "");
            HttpContext.Session.SetString("username", "");

            return RedirectToAction("Questions", "Question");
        }



    }
}