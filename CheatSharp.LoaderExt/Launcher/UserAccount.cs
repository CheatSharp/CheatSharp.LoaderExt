using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatSharp.LoaderExt.Launcher
{
    public static class UserAccount
    {
        public static string Username { get; set; }

        public static string PasswordHash { get; set; }

        public static int DaysLeft()
        {
            //TODO: Remember to put the old code back
            return -1;
        }
    }
}
