using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CheatSharp.LoaderExt.Launcher
{
    public class UpdateEngine
    {
        //Todo: Put old code back
        public static bool IsServerRunning()
        {
            try
            {
                using (var wc = new WebClient())
                {
                    var result = wc.DownloadString("https://api.cheatsharp.net/status");

                    //Too lazy to read the json lmao
                    if (result.Contains("running"))
                        return true;
                }
            }
            catch { }

            return false;
        }

        public static Status IsDetected()
        {
            try
            {
                using (var wc = new WebClient())
                {
                    var result = wc.DownloadString("https://api.cheatsharp.net/status/detect");

                    //Too lazy to read the json lmao
                    if (result.Contains("ud"))
                        return Status.Okay;
                    else if (result.Contains("warn"))
                        return Status.Warn;
                    else return Status.Error;
                }
            }
            catch { }

            return Status.Down;
        }
        public static string LatestTestVersion()
        {
            try
            {
                using (var wc = new WebClient())
                {
                    var result = wc.DownloadString("https://api.cheatsharp.net/status/testedVerRaw");

                    //Too lazy to read the json lmao
                    return result;
                }
            }
            catch { }

            return "9.8.1";
        }

        public static Status IsUpToDate()
        {
            try
            {
                using (var wc = new WebClient())
                {
                    var result = wc.DownloadString("https://api.cheatsharp.net/latest/dll");

                    //Too lazy to read the json lmao
                    return Status.Okay;
                }
            }
            catch { }

            return Status.Down;
        }

        public static Status IsLauncherUpToDate()
        {
            try
            {
                using (var wc = new WebClient())
                {
                    var result = wc.DownloadString("https://api.cheatsharp.net/latest/launcher");

                    //Too lazy to read the json lmao
                    return Status.Okay;
                }
            }
            catch { }

            return Status.Down;
        }

        public static bool DownloadUpdater()
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add("dl", "client.loadext.v1");
                    wc.Headers.Add("user", UserAccount.Username);
                    wc.Headers.Add("hash", UserAccount.PasswordHash); 

                    wc.DownloadFileAsync(new Uri("https://dl.cheatsharp.net/api/download/GetUpdateInstaller"), "update.exe");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public enum Status
    {
        Okay,
        Warn,
        Error,
        Down
    }
}
