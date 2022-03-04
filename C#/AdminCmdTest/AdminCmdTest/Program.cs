using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AdminCmdTest
{
    
    class Program
    {
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        public static void ExecuteCommandAsAdmin(string command = "wmic product where name=\"GlideX Service Installer\" call uninstall")
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo()
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                FileName = "cmd.exe",
                Arguments = "/user:Administrator cmd /K " + command
            };

            using (Process proc = new Process())
            {
                proc.StartInfo = procStartInfo;
                proc.Start();
            }
        }
        static void Main(string[] args)
        {
            //ExecuteCommandAsAdmin();
            try
            {
                Process[] procs = Process.GetProcesses();
                foreach (var p in procs)
                {
                    if (p.ProcessName == "GlideX")
                    {
                        p.WaitForInputIdle();
                        IntPtr s = p.MainWindowHandle;
                        ShowWindow(s, 5);
                        SetForegroundWindow(s);
                        Console.Write("Proccess found: " + p.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Application is not running!\nException: " + ex.Message);
                Console.ReadKey();
                return;
            }
            int a = 0;
        }
    }
}
