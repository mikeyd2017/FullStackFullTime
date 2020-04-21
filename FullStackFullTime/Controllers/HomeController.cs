using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FullStackFullTime.Models;
using Microsoft.Extensions.Configuration;
using FullStackFullTime.SqlCommands;
using Microsoft.AspNetCore.Http;
using FullStackFullTime.Helpers;

namespace FullStackFullTime.Controllers
{
    public class HomeController : Controller
    {

        private Factory _Factory = new Factory();

        public HomeController(IConfiguration iConfig)
        {
            _Factory.DataHelper = new DataHelper(iConfig);
            _Factory.AccountCommands = new AccountCommands(_Factory.DataHelper);
            _Factory.TableCommands = new TableCommands(_Factory.DataHelper);
        }
        public IActionResult Landing()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
