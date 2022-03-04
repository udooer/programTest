using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Threading;

namespace androidNotificationTest
{
    class Program
    {
        public static string _androidUrl;
        public static string _androidUrlTemplate = "http://{0}:4724/wd/hub";
        private static AndroidDriver<AndroidElement> androidDriver;
        public static bool CreateAndroidDriver(string noReset = "true")
        {
            string ip = "127.0.0.1";
            _androidUrl = string.Format(_androidUrlTemplate, ip);
            try
            {
                AppiumOptions androidAppOptions = new AppiumOptions();
                androidAppOptions.AddAdditionalCapability("deviceName", "Mi 10 Lite 5G");
                androidAppOptions.AddAdditionalCapability("automationName", "UiAutomator2");
                androidAppOptions.AddAdditionalCapability("platformName", "Android");
                androidAppOptions.AddAdditionalCapability("platformVersion", "10");
                androidAppOptions.AddAdditionalCapability("autoGrantPermissions", "true");
                androidAppOptions.AddAdditionalCapability("newCommandTimeout", 1800);    // 30 mins no cmd, timeout the android driver

                //androidAppOptions.AddAdditionalCapability("appPackage", "com.asus.glidex");
                //androidAppOptions.AddAdditionalCapability("appActivity", "com.asus.glidex.MainActivity");
                //androidAppOptions.AddAdditionalCapability("noReset", noReset);

                Uri androidLocalUri = new Uri(Program._androidUrl);
                androidDriver = new AndroidDriver<AndroidElement>(androidLocalUri, androidAppOptions);
                androidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            CreateAndroidDriver();
            androidDriver.OpenNotifications();
            Thread.Sleep(2000);
            var allnotifications = androidDriver.FindElementsById("android:id/title");
            Console.WriteLine("no of notifications " + allnotifications.Count);

            foreach (var webElement in allnotifications)
            {
                Console.WriteLine(webElement.Text);
                //if (webElement.Text.Contains("Dianne"))
                //{
                //    System.out.println("Notification found");
                //    break;
                //}
            }
            int a = 0;
        }
    }
}
