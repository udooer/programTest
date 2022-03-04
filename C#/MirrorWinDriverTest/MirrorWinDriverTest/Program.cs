using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;

namespace MirrorWinDriverTest
{
    class Program
    {
        public static string _appPath = $@"C:\Program Files\WindowsApps\B9ECED6F.Glidex_1.0.6.22_x64__qmba6cd70vzyy\ModuleDll\GlideXModule\GlideXMirror";
        public static string ip = "127.0.0.1";
        public static string _winUrlTemplate = "http://{0}:4723";
        public static string _winUrl = string.Format(_winUrlTemplate, ip);
        private static WindowsDriver<WindowsElement> winDriver;
        public static List<string> plantypeList = new List<string>()
        {
            { "Standard"},
            { "Plus"},
            { "Pro"},
            { "Ultra"}
        };
        public static bool CreateWinDriver()
        {
            try
            {
                AppiumOptions winAppOptions = new AppiumOptions();
                winAppOptions.AddAdditionalCapability("app", _appPath);
                winAppOptions.AddAdditionalCapability("deviceName", "WindowsPC");
                winAppOptions.AddAdditionalCapability("platformName", "Windows");
                winAppOptions.AddAdditionalCapability("newCommandTimeout", 1800);    // 30 mins no cmd, timeout the windows driver
                Uri winLocalUri = new Uri(_winUrl);
                winDriver = new WindowsDriver<WindowsElement>(winLocalUri, winAppOptions, TimeSpan.FromSeconds(180));
                winDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            CreateWinDriver();

            var titleText = winDriver.FindElementByName("Dialog_RenderFPS");
            if (titleText == null)
            {
                return;
            }
            else
            {
                Console.WriteLine(titleText.Text);
                Console.WriteLine(titleText.Selected);
                Console.WriteLine(titleText.TagName);
            }
            int a = 0;
            //
        }
    }
}
