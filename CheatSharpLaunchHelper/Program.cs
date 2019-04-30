using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CheatSharpLaunchHelper
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

            
            Process.Start("CheatSharp.LoaderExt.exe");
        }
    }
}
