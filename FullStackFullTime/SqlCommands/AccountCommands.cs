using FullStackFullTime.Helpers;
using FullStackFullTime.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackFullTime.SqlCommands
{
    public class AccountCommands
    {
        private DataHelper DataHelper;

        public AccountCommands(DataHelper dataHelper)
        {
             DataHelper = dataHelper;
        }


        public bool InsertUser(User newUser)
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();

            cmd.CommandText = "INSERT INTO Users Values(@userName, @password, @email, @role, @dateCreated);";

            cmd.Parameters.Add(new SqlParameter("userName", newUser.Username));
            cmd.Parameters.Add(new SqlParameter("password", newUser.Password));
            cmd.Parameters.Add(new SqlParameter("email", newUser.Email));
            cmd.Parameters.Add(new SqlParameter("dateCreated", newUser.DateCreated));
            cmd.Parameters.Add(new SqlParameter("role", newUser.Role));

            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();

            return true;
        }
    }
}
