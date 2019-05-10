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
