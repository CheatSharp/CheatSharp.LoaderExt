using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LauncherHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CheatSharp Launcher Helper";
            Console.Write("Loading CheatSharp Loader. Please wait");
            Task.Delay(1000).Wait();
            Console.Write(".");
            Task.Delay(1000).Wait();
            Console.Write(".");
            Task.Delay(1000).Wait();
            Console.WriteLine(".");
            Task.Delay(10000).Wait();

            //TODO: CheckHash
            //TODO: CheckUpdate
            //TODO: CheckCert
            //TODO: Launch Exe
        }

        private static void CheckHash()
        {
            var req = new HttpClient();

            var result = req.GetAsync("https://auth.cheatsharp.net");
        }
    }
}
