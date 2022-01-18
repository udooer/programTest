using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StartApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            setBadgeNumber("1");
        }

        private void setBadgeNumber(string s)
        {
            BadgeTemplateType type = BadgeTemplateType.BadgeNumber;
            var xml = BadgeUpdateManager.GetTemplateContent(type);

            var elt = (XmlElement)xml.SelectSingleNode("/badge");
            elt.SetAttribute("value", s);

            var badge = new BadgeNotification(xml);
            var updater = BadgeUpdateManager.CreateBadgeUpdaterForApplication();
            updater.Update(badge);
        }
    }
}
