using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatSharp.LoaderExt.Launcher
{
    public class UpdateEngine
    {
        public static bool IsServerRunning()
        {
            return false;
        }

        public static Status IsDetected()
        {
            return Status.Okay;
        }

        public static Status IsUpToDate()
        {
            return Status.Warn;
        }

        public static Status IsLauncherUpToDate()
        {
            return Status.Warn;
        }
    }

    public enum Status
    {
        Okay,
        Warn,
        Error
    }
}
