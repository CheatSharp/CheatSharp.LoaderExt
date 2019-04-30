using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatSharp.LoaderExt.Launcher
{
    public class LaunchGame
    {
        public static string thisLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

        public static void LaunchLeagueClient()
        {
            var path = GetLolRootPath();

            using (Process sandbox = new Process())
            {
                sandbox.StartInfo.FileName = "C:\\SandFire\\SandFireLite\\SandFireLite.exe";
                sandbox.StartInfo.Arguments = $"\"Ldll\" \"{System.IO.Path.Combine(thisLocation, "ldDlls", "cheatsharp.dll")}\" \"Lcfg\" \"UDM\" \"Phide\" \"CheatSharp.LoaderExt.exe\"";
                sandbox.Start();
            }
        }

        public static string GetLolRootPath()
        {
            //Check for if IcyWind has been run before. If it has been, this should hold the location of the league of legends install
            if (Registry.CurrentUser.GetSubKeyNames().Contains("Software\\IcyWind"))
            {
                return Registry.CurrentUser.OpenSubKey("Software\\IcyWind")?.GetValue("Path").ToString();
            }

            //F**k we gotta look for league of legends
            //Every goddam path
            //A lot of these locations are from Sightstone, which is dead
            var possiblePaths = new List<Tuple<string, string>>
                {
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\Classes\VirtualStore\MACHINE\SOFTWARE\SightstoneLol", "Path"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\Classes\VirtualStore\MACHINE\SOFTWARE\RIOT GAMES", "Path"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\Classes\VirtualStore\MACHINE\SOFTWARE\Wow6432Node\RIOT GAMES", "Path"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\RIOT GAMES", "Path"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\Wow6432Node\Riot Games", "Path"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Riot Games\League Of Legends", "Path"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Riot Games", "Path"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Riot Games\League Of Legends",  "Path"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Riot Games \League Of Legends", "Path"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\Classes\VirtualStore\MACHINE\SOFTWARE\RIOT GAMES, INC", "Path"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\Classes\VirtualStore\MACHINE\SOFTWARE\Wow6432Node\RIOT GAMES, INC", "Path"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\RIOT GAMES, INC", "Path"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\Wow6432Node\Riot Games, Inc", "Path"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Riot Games, Inc\League Of Legends", "Path"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Riot Games, Inc", "Path"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Riot Games, Inc\League Of Legends",  "Path"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Riot Games, Inc \League Of Legends", "Path"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\Classes\VirtualStore\MACHINE\SOFTWARE\RIOT GAMES", "Location"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\Classes\VirtualStore\MACHINE\SOFTWARE\Wow6432Node\RIOT GAMES", "Location"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\RIOT GAMES", "Location"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\Wow6432Node\Riot Games", "Location"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Riot Games\League Of Legends", "Location"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Riot Games", "Location"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Riot Games\League Of Legends",  "Location"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\Classes\VirtualStore\MACHINE\SOFTWARE\RIOT GAMES, INC", "Location"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\Classes\VirtualStore\MACHINE\SOFTWARE\Wow6432Node\RIOT GAMES, INC", "Location"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\RIOT GAMES, INC", "Location"),
                    new Tuple<string, string>(@"HKEY_CURRENT_USER\Software\Wow6432Node\Riot Games, Inc", "Location"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Riot Games, Inc\League Of Legends", "Location"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Riot Games, Inc", "Location"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Riot Games, Inc\League Of Legends",  "Location"),
                    new Tuple<string, string>(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Riot Games, Inc \League Of Legends", "Location"),
                };
            foreach (var tuple in possiblePaths)
            {
                try
                {
                    var value = Registry.GetValue(tuple.Item1, tuple.Item2, string.Empty);
                    if (value == null || value.ToString() == string.Empty)
                        continue;

                    var icyWindRegKey = Registry.CurrentUser.CreateSubKey("Software\\IcyWind");
                    icyWindRegKey?.SetValue("Path", value.ToString());

                    return value.ToString();
                }
                catch
                {
                    //Client.Log(e);
                }
            }

            //Shoot didn't find it

            var findLeagueDialog =
                new OpenFileDialog
                {
                    DefaultExt = ".exe",
                    Filter = "League of Legends|LeagueClient.exe"
                };

            var result = findLeagueDialog.ShowDialog();
            if (result != true)
                return string.Empty;

            var key = Registry.CurrentUser.CreateSubKey("Software\\IcyWind");
            key?.SetValue("Path", findLeagueDialog.FileName.Replace("LeagueClient.exe", string.Empty));

            return findLeagueDialog.FileName.Replace("LeagueClient.exe", string.Empty);
        }
    }
}
