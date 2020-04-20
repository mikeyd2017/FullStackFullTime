using FullStackFullTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackFullTime.ViewModels
{
    public class Question
    {
        public Models.Question ModelQuestion { get; set; }
        public List<Comment> Comments { get; set; }

        public Question()
        {

        }

    }
}
