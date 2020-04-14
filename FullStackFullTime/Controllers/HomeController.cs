using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FullStackFullTime.Models;
using Microsoft.Extensions.Configuration;
using FullStackFullTime.SqlCommands;

namespace FullStackFullTime.Controllers
{
    public class HomeController : Controller
    {

        private Factory oFactory = new Factory();

        public HomeController(IConfiguration iConfig)
        {
            oFactory.DataHelper = new Helpers.DataHelper(iConfig);
            oFactory.AccountCommands = new AccountCommands(oFactory.DataHelper);
            oFactory.TableCommands = new TableCommands(oFactory.DataHelper);
        }
        public IActionResult Questions()
        {
            //oFactory.TableCommands.CreateUserTable();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
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
