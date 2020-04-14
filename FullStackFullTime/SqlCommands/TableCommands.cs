using FullStackFullTime.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackFullTime.SqlCommands
{
    public class TableCommands
    {
        private DataHelper DataHelper;

        public TableCommands(DataHelper dataHelper)
        {
            DataHelper = dataHelper;
        }

        public bool CreateUserTable()
        {
            DataHelper.DbConn.Open();

            SqlCommand cmd = DataHelper.DbConn.CreateCommand();
            cmd.CommandText = "Create Table Users (UserID int IDENTITY(1,1) PRIMARY KEY, Username varchar(20) NOT NULL, Password varchar(40) NOT NULL, Email varchar(60) NOT NULL, Role varchar(30) NOT NULL, CreateDate date NOT NULL);";
            cmd.ExecuteNonQuery();

            DataHelper.DbConn.Close();
            return true;
        }
    }
}
