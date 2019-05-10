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

namespace CheatSharp.LoaderExt.Pages.Overlays
{
    /// <summary>
    /// Interaction logic for ReportBan.xaml
    /// </summary>
    public partial class ReportBan : Page
    {
        public static readonly Brush hoverColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1C97EA"));
        public static readonly Brush noneColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2D2D30"));

        public ReportBan()
        {
            InitializeComponent();
            RegionBox.Items.Add("Brazil (BR)");
            RegionBox.Items.Add("Europe Nordic & East (EUNE)");
            RegionBox.Items.Add("Europe West (EUW)");
            RegionBox.Items.Add("Latin America North (LAN)");
            RegionBox.Items.Add("Latin America South (LAS)");
            RegionBox.Items.Add("North America (NA)");
            RegionBox.Items.Add("Oceania (OCE)");
            RegionBox.Items.Add("Russia (RU)");
            RegionBox.Items.Add("Turkey (TR)");
            RegionBox.Items.Add("Japan (JP)");
            RegionBox.Items.Add("South East Asia (GARN-SEA)");
            RegionBox.Items.Add("Republic of Korea (KR)");
            RegionBox.Items.Add("Public Beta Environment (PBE)");
            RegionBox.Items.Add("People's Republic of China (CH)");
            RegionBox.Items.Add("League of Memories (LoM)");
        }

        private void HideOverlay_MouseEnter(object sender, MouseEventArgs e)
        {
            HideOverlay.Background = hoverColor;
        }

        private void HideOverlay_MouseLeave(object sender, MouseEventArgs e)
        {
            HideOverlay.Background = noneColor;
        }
    }
}
