using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsAppiumTest
{
    class Program
    {
        //public static string appFolder = "B9ECED6F.Glidex_qmba6cd70vzyy";
        //public static string _appPath = appFolder + "!App";
        //public static string _appPath = @"C:\Users\H5600QE\Asus_2022\env & project\programTest\C#\AdminCmdTest\AdminCmdTest\bin\x64\Release\AdminCmdTest.exe";
        //public static string _appPath = @"C:\Program Files\WindowsApps\B9ECED6F.Glidex_1.0.6.22_x64__qmba6cd70vzyy\ModuleDll\GlideXModule\GlideXMirror";
        public static string _appPath = @"C:\Users\H5600QE\Asus_2022\project\MyTask\AutoTest\GlideXAutoTest\GlideXAutoTestHelper\bin\x64\Debug\GlideXAutoTestHelper.exe";
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
            Thread.Sleep(5000);
            test1();
            //string type = FGetPlanType();
            int a = 0;
        }
        public static string FGetPlanType()
        {
            // 1-1 Find & Click home button
            var homeBtn = winDriver.FindElementByAccessibilityId("hamburger_1");
            if (homeBtn != null)
            {
                homeBtn.Click();
            }
            else
            {
                return "Fail";
            }
            Thread.Sleep(2000);

            // 1-2 Find PlanType
            foreach (string s in plantypeList) 
            {
                var plan = winDriver.FindElementByAccessibilityId(s);
                if (plan.Displayed) 
                {
                    return plan.Text;
                }
            }
            return "Fail";
        }
        public static void test() 
        {
            var closeBtn = winDriver.FindElementByName("MenuBar_WinCloseBtn");
            if (closeBtn == null)
            {
                return;
            }
            int a = 0;
            closeBtn = winDriver.FindElementByName("MenuBar_WinCloseBtn");
            if (closeBtn == null)
            {
                return;
            }
            closeBtn.Click();
        }

        public static void test1() 
        {
            string result="";
            try
            {
                var button = winDriver.FindElementByAccessibilityId("ShowGlideXButton");
                Thread.Sleep(1000);

                button?.Click();
                Thread.Sleep(5000);
                result = winDriver.FindElementByAccessibilityId("ShowCheck").Text;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
