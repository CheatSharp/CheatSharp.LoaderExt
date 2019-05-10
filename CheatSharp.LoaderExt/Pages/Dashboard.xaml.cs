using CheatSharp.LoaderExt.Launcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheatSharp.LoaderExt.Pages
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page, ICheatSharpPage
    {
        public Dashboard()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            //Check if server is running
            if (UpdateEngine.IsServerRunning())
            {
                ServerStatusColor.Fill = Brushes.Green;
                ServerStatusLabel.Content = "Server status - okay";
            }
            else
            {
                ServerStatusColor.Fill = Brushes.Red;
                ServerStatusLabel.Content = "Server status - down";
            }

            //TODO: Update this to be proper checks against client and tested server versions
            TestedStatusColor.Fill = Brushes.Green;
            TestedStatusLabel.Content = "Tested working - Patch " + UpdateEngine.LatestTestVersion();

            switch (UpdateEngine.IsDetected())
            {
                case Status.Okay:
                    DetectionStatusColor.Fill = Brushes.Green;
                    DetectionStatusLabel.Content = "Still undetected";
                    break;
                case Status.Warn:
                    DetectionStatusColor.Fill = Brushes.Yellow;
                    DetectionStatusLabel.Content = "Detected increase in ban reports";
                    break;
                case Status.Error:
                    DetectionStatusColor.Fill = Brushes.Red;
                    DetectionStatusLabel.Content = "Detected & disabled";
                    break;
                case Status.Down:
                    DetectionStatusColor.Fill = Brushes.Gray;
                    DetectionStatusLabel.Content = "Server down - unable to get detections status";
                    break;
            }

            var days = UserAccount.DaysLeft();
            if (days == -1)
            {
                LicenseStatusColor.Fill = Brushes.Green;
                LicenseStatusLabel.Content = $"License active - ∞ days until next payment";
            }
            else if (days == 0)
            {
                LicenseStatusColor.Fill = Brushes.Red;
                LicenseStatusLabel.Content = $"License not active";
            }
            else if (days >= 7)
            {
                LicenseStatusColor.Fill = Brushes.Green;
                LicenseStatusLabel.Content = $"License active - {days} days until next payment";
            }
            else if (days < 7)
            {
                LicenseStatusColor.Fill = Brushes.Yellow;
                LicenseStatusLabel.Content = $"License active - {days} days until next payment";
            }

            //Check for updates

            switch (UpdateEngine.IsUpToDate())
            {
                case Status.Okay:
                    CheatSharpUpdateStatusColor.Fill = Brushes.Green;
                    CheatSharpUpdateStatusLabel.Content = "Cheat# up to date";
                    break;
                case Status.Warn:
                    CheatSharpUpdateStatusColor.Fill = Brushes.Yellow;
                    CheatSharpUpdateStatusLabel.Content = "Cheat# is out of date";
                    break;
                case Status.Error:
                    CheatSharpUpdateStatusColor.Fill = Brushes.Red;
                    CheatSharpUpdateStatusLabel.Content = "Cheat# version is out of date and detected";
                    break;
                case Status.Down:
                    CheatSharpUpdateStatusColor.Fill = Brushes.Gray;
                    CheatSharpUpdateStatusLabel.Content = "Cheat# server is down";
                    break;
            }

            switch (UpdateEngine.IsLauncherUpToDate())
            {
                case Status.Okay:
                    CheatSharpLauncherUpdateStatusColor.Fill = Brushes.Green;
                    CheatSharpLauncherUpdateStatusLabel.Content = "Cheat# launcher up to date";
                    break;
                case Status.Warn:
                    CheatSharpLauncherUpdateStatusColor.Fill = Brushes.Red;
                    CheatSharpLauncherUpdateStatusLabel.Content = "Cheat# launcher out of date";
                    break;
                case Status.Error:
                    CheatSharpLauncherUpdateStatusColor.Fill = Brushes.Yellow;
                    CheatSharpLauncherUpdateStatusLabel.Content = "Cheat# launcher must be updated to run cheats";
                    break;
            }
        }

    }
}
