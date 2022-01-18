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
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Runtime.ExceptionServices;
using System.Security;

namespace DLLCrashTry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Import CDS.dll for getting the display status and set the display settings.
        [DllImport("Crash.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void DoCrash();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                DoCrash();
                int reCode = Marshal.GetLastWin32Error();
                MessageBox.Show(reCode.ToString());
            }
            catch (Exception ex) 
            {
                MessageBox.Show("error");
            }
        }
    }
}
