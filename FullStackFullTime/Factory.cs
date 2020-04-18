using FullStackFullTime.Helpers;
using FullStackFullTime.SqlCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FullStackFullTime
{
    public class Factory
    {
        //Only 2 classes needed right now, as mentioned in HomeController we will be adding many more, this will be the best way to keep them all together.
        //In the future I want to make this so that we set certain session or cookie values for the Factory, so we only need to load the classes specific to the session or cookie.
        //That way we don't have to remake the whole factory every time the controller is called, it's not too intensive either way.
        public DataHelper DataHelper;
        public AccountHelper AccountHelper;
        public AccountCommands AccountCommands;
        public TableCommands TableCommands;

        public Factory()
        {

        }
        public Factory(DataHelper dataHelper, [Optional] AccountHelper accountHelper, [Optional] AccountCommands accountCommands, [Optional] TableCommands tableCommands)
        {
            DataHelper = dataHelper;
            AccountCommands = accountCommands;
            TableCommands = tableCommands;
            AccountHelper = accountHelper;
        }
    }
}
