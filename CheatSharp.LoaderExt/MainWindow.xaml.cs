using CheatSharp.LoaderExt.Pages;
using CheatSharp.LoaderExt.Pages.Overlays;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheatSharp.LoaderExt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private static readonly About aboutPage = new About();
        private static readonly Accounts accountsPage = new Accounts();
        private static readonly Dashboard dashboardPage = new Dashboard();
        private static readonly News newsPage = new News();
        private static readonly Plugins pluginsPage = new Plugins();
        private static readonly Settings settingsPage = new Settings();

        private static readonly ReportBan reportBanOverlay = new ReportBan();

        public static readonly Brush selectColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF007ACC"));
        public static readonly Brush hoverColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1C97EA"));
        public static readonly Brush noneColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3F3F46"));

        private string SelectedPage = "home";

        public MainWindow()
        {
            InitializeComponent();
            ChangePage(dashboardPage);
            dashboardPage.BanReportButton.Click += BanReportButton_Click;
            reportBanOverlay.SubmitReport.Click += SubmitReport_Click;
            reportBanOverlay.HideOverlay.Click += HideOverlay_Click;
        }

        private void HideOverlay_Click(object sender, RoutedEventArgs e)
        {
            OverlayGrid.Visibility = Visibility.Hidden;
        }

        private void SubmitReport_Click(object sender, RoutedEventArgs e)
        {
            OverlayGrid.Visibility = Visibility.Hidden;
        }

        private void BanReportButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeOverlay(reportBanOverlay);
        }

        public void ChangeOverlay(Page page)
        {
            OverlayGrid.Visibility = Visibility.Visible;
            Overlay.Height = page.MinHeight;
            Overlay.Width = page.MinWidth;
            Overlay.Content = page.Content;
        }

        private void ChangePage(Page page)
        {
            MainContentHolder.Content = page.Content;

            if (page is ICheatSharpPage pg)
            {
                pg.Load();
            }
        }

        bool extended = false;

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation;
            if (extended)
            {
                widthAnimation = new DoubleAnimation
                {
                    From = 160,
                    To = 40,
                    Duration = TimeSpan.FromMilliseconds(150)
                };
            }
            else
            {
                widthAnimation = new DoubleAnimation
                {
                    From = 40,
                    To = 160,
                    Duration = TimeSpan.FromMilliseconds(150)
                };
            }

            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));
            Storyboard.SetTarget(widthAnimation, SidebarHolder);

            Storyboard s = new Storyboard();
            s.Children.Add(widthAnimation);
            s.Begin();

            extended = !extended;
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                if (grid.Name.ToLower() != SelectedPage)
                {
                    grid.Background = hoverColor;
                }
            }
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                if (grid.Name.ToLower() == SelectedPage)
                {
                    grid.Background = selectColor;
                }
                else
                {
                    grid.Background = noneColor;
                }
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangePage(dashboardPage);
            if (sender is Grid grid)
            {
                switch (grid.Name.ToLower())
                {
                    case "home":
                        ChangePage(dashboardPage);
                        break;
                    case "news":
                        ChangePage(newsPage);
                        break;
                    case "plugins":
                        ChangePage(pluginsPage);
                        break;
                    case "account":
                        ChangePage(accountsPage);
                        break;
                    case "about":
                        ChangePage(aboutPage);
                        break;
                    case "settings":
                        ChangePage(settingsPage);
                        break;
                }


                SelectedPage = grid.Name.ToLower();
                ResetAllGrids();
                grid.Background = selectColor;
            }
        }

        private void ResetAllGrids()
        {
            About.Background = noneColor;
            Account.Background = noneColor;
            Home.Background = noneColor;
            News.Background = noneColor;
            Plugins.Background = noneColor;
            Settings.Background = noneColor;
        }

        private void MainContent_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (extended)
            {
                var widthAnimation = new DoubleAnimation
                {
                    From = 160,
                    To = 40,
                    Duration = TimeSpan.FromMilliseconds(100)
                };

                Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));
                Storyboard.SetTarget(widthAnimation, SidebarHolder);

                Storyboard s = new Storyboard();
                s.Children.Add(widthAnimation);
                s.Begin();

                extended = false;
            }
        }
    }
}
