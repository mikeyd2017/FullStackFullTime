using FullStackFullTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackFullTime.Helpers
{
    public class AccountHelper
    {
        private Factory _Factory;
        public AccountHelper(Factory oFactory)
        {
            _Factory = oFactory;
        }
        public bool CreateUser(string username, string password, string email)
        {
            User newUser = new User();
            newUser.Username = username;
            newUser.Password = password;
            newUser.Email = email;
            newUser.DateCreated = DateTime.Now;
            newUser.Role = Convert.ToString(User.Roles.Basic);

            _Factory.AccountCommands.InsertUser(newUser);

            return true;
        }
    }
}
