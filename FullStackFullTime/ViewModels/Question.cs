using FullStackFullTime.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackFullTime.ViewModels
{
    public class Question
    {
        public DataModels.Question ModelQuestion { get; set; }
        public List<Comment> Comments { get; set; }

        public string Username { get; set; }
        public Question()
        {

        }

    }
}
