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
using System.IO;
using System.Diagnostics;

namespace FilePermissionTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        public static string dataSubFolder = "\\ASUS\\GlideX";
        private static string path = programDataPath + dataSubFolder;
        private static string filename = Path.Combine(path, "GlideX.log");
        //private static bool isWriteLog = System.IO.File.Exists(filename);
        public MainWindow()
        {
            InitializeComponent();
            bool isWriteLog = System.IO.File.Exists(filename);
            MessageBox.Show(isWriteLog.ToString());
            //Trace.WriteLine(isWriteLog);
        }
    }
}
