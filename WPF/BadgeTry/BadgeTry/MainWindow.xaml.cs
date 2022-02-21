using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using System.Windows;

namespace BadgeTry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void setBadgeNumber(int num)
        {
            BadgeTemplateType type = BadgeTemplateType.BadgeNumber;
            var xml = BadgeUpdateManager.GetTemplateContent(type);

            var elt = (XmlElement)xml.SelectSingleNode("/badge");
            elt.SetAttribute("value", num.ToString());

            var badge = new BadgeNotification(xml);
            var updater = BadgeUpdateManager.CreateBadgeUpdaterForApplication();
            updater.Update(badge);
        }

        private void OnClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            setBadgeNumber(10);
        }
    }
}
