using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

namespace MainWindowTry
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        private const int SW_RESTORE = 9;
        private const int HWND_TOPMOST = -1;
        private const int HWND_NOTOPMOST = -2;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOSIZE = 0x0001;
        private Mutex instanceMutex = null;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bool result;
            //instanceMutex = new Mutex(true, "MainWindowTryTest", out result);
            
            IntPtr hwnd = FindWindow(null, "MainWindowTest");
            if (hwnd != IntPtr.Zero)
            {
                MessageBox.Show("mainwindow found");
                if (IsIconic(hwnd))
                {
                    ShowWindow(hwnd, SW_RESTORE);
                }
                else
                {
                    SetWindowPos(hwnd, (IntPtr)(HWND_TOPMOST), 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
                    Thread.Sleep(50);
                    SetWindowPos(hwnd, (IntPtr)(HWND_NOTOPMOST), 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
                }

                Application.Current.Shutdown();
                return;
            }
            else
            {
                Process currentProcess = Process.GetCurrentProcess();
                Process[] glideXProcess = Process.GetProcessesByName("MainWindowTry");

                foreach (Process process in glideXProcess)
                {
                    if (process.Id != currentProcess.Id)
                    {
                        process.Kill();
                    }
                }
                MessageBox.Show("mainwindow not found");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                return;
            }
        }
    }
}
