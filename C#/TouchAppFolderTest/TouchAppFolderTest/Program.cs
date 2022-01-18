using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TouchAppFolderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = System.AppDomain.CurrentDomain.BaseDirectory;
            //string path = @"C:\Users\shane_hsu\AppData\Local\Packages\B9ECED6F.Glidex_qmba6cd70vzyy\Settings\settings.dat";
            //if (File.Exists(path)) 
            //{
            //    File.Delete(path);
            //}
            StringBuilder sb = new StringBuilder();
            foreach (Process p in Process.GetProcesses("."))
            {
                try
                {

                    if (p.MainWindowTitle.Length > 0)
                    {
                        sb.Append("Window Title:\t" + p.MainWindowTitle.ToString() + Environment.NewLine);
                        sb.Append("Process Name:\t" + p.ProcessName.ToString() + Environment.NewLine);
                        sb.Append("Window Handle:\t" + p.MainWindowHandle.ToString() + Environment.NewLine);
                        sb.Append("Memory Allocation:\t" + p.PrivateMemorySize64.ToString() + Environment.NewLine);
                        sb.Append(Environment.NewLine);
                    }
                }
                catch { }
            }
            Console.WriteLine(sb.ToString());
            int a = 0;
        }
    }
}
