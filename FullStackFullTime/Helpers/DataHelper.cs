using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackFullTime.Helpers
{
    public class DataHelper
    {
        private string DbConnString { get; set; }
        public SqlConnection DbConn { get; set; }

        public DataHelper(IConfiguration iConfig)
        {
            DbConnString = iConfig.GetValue<string>("ConnectionStrings:FSFTDatabase");
            DbConn = new SqlConnection(DbConnString);
        }
    }

}
