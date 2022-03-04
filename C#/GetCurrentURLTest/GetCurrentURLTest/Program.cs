using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Automation;

namespace GetCurrentURLTest
{
    class Program
    {
        //private static string GetURLFromProcess(Process process, BrowserType browser)
        //{
        //    if (process == null)
        //        throw new ArgumentNullException("process");

        //    if (process.MainWindowHandle == IntPtr.Zero)
        //        return null;

        //    AutomationElement elm = AutomationElement.FromHandle(process.MainWindowHandle);
        //    if (elm == null)
        //        return null;
        //    string nameProperty = "";

        //    if (browser.Equals(BrowserType.GOOGLE_CHROME))
        //    {
        //        var elm1 = elm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Google Chrome"));
        //        if (elm1 == null) { return null; } // not the right chrome.exe
        //        var elm2 = elm1.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""))[1];
        //        var elm3 = elm2.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""))[1];
        //        var elm4 = elm3.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""))[1];
        //        var elm5 = elm4.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""));
        //        var elmUrlBar = elm5.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
        //        var url = ((ValuePattern)elmUrlBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
        //        return url;
        //    }
        //    else if (browser.Equals(BrowserType.FIREFOX))
        //    {
        //        AutomationElement elm2 = elm.FindFirst(TreeScope.Children, new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ToolBar),
        //               new PropertyCondition(AutomationElement.IsInvokePatternAvailableProperty, false)));
        //        if (elm2 == null)
        //            return null;
        //        var elm3 = elm2.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ComboBox));
        //        if (elm3 == null)
        //            return null;
        //        var elmUrlBar = elm3.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
        //        if (elmUrlBar != null)
        //        {
        //            var url = ((ValuePattern)elmUrlBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
        //            url;
        //        }
        //    }
        //    else if (browser.Equals(BrowserType.INTERNET_EXPLORER))
        //    {
        //        AutomationElement elm2 = elm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "ReBarWindow32"));
        //        if (elm2 == null)
        //            return null;
        //        AutomationElement elmUrlBar = elm2.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
        //        var url = ((ValuePattern)elmUrlBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
        //        return url;
        //    }
        //    else if (browser.Equals(BrowserType.MICROSOFT_EDGE))
        //    {
        //        var elm2 = elm.FindFirst(TreeScope.Children, new AndCondition(
        //        new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
        //        new PropertyCondition(AutomationElement.NameProperty, "Microsoft Edge")));

        //        var elmUrlBar = elm2.FindFirst(TreeScope.Children,
        //            new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

        //        var url = ((TextPattern)elmUrlBar.GetCurrentPattern(TextPattern.Pattern)).DocumentRange.GetText(int.MaxValue);
        //        return url;
        //    }

        //    return null;
        //}
        private static void test2() 
        {
            Process[] procsChrome = Process.GetProcessesByName("chrome");
            foreach (Process chrome in procsChrome)
            {
                // the chrome process must have a window
                if (chrome.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }

                // find the automation element
                AutomationElement elm = AutomationElement.FromHandle(chrome.MainWindowHandle);
                AutomationElement elmUrlBar = elm.FindFirst(TreeScope.Descendants,
                  new PropertyCondition(AutomationElement.NameProperty, "Address and search bar"));

                // if it can be found, get the value from the URL bar
                if (elmUrlBar != null)
                {
                    AutomationPattern[] patterns = elmUrlBar.GetSupportedPatterns();
                    if (patterns.Length > 0)
                    {
                        ValuePattern val = (ValuePattern)elmUrlBar.GetCurrentPattern(patterns[0]);
                        Console.WriteLine("Chrome URL found: " + val.Current.Value);
                    }
                }
            }
        }


        private static void test1() 
        {
            System.Diagnostics.Process[] procsEdge = System.Diagnostics.Process.GetProcessesByName("msedge");
            string result = "Fail";
            foreach (Process proc in procsEdge)
            {
                if (proc.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }
                result = proc.MainWindowTitle;
                proc.CloseMainWindow();
                int tmp = 0;
                return;
            }
            int tmp2 = 0;
            return;
        }
        private static void test() 
        {
            SHDocVw.InternetExplorer browser;
            string myLocalLink;
            mshtml.IHTMLDocument2 myDoc;
            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
            string filename;
            foreach (SHDocVw.InternetExplorer ie in shellWindows)
            {
                filename = System.IO.Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                Console.WriteLine(filename);
                if ((filename == "iexplore"))
                {
                    browser = ie;
                    myDoc = browser.Document;
                    myLocalLink = myDoc.url;
                    Console.WriteLine(myLocalLink);

                }
                //if ((filename == "explorer"))
                //{
                //    browser = ie;
                //    myDoc = browser.Document;
                //    myLocalLink = myDoc.url;
                //    Console.WriteLine(myLocalLink);

                //}
            }
        }
        static void Main(string[] args)
        {
            test1();
            int a = 0;
        }
    }
}
