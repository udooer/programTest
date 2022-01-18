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
using System.Diagnostics;

namespace EnvPathTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string defaultDownloadPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Trace.WriteLine(programDataPath);
            Trace.WriteLine(localAppDataPath);
            Trace.WriteLine(defaultDownloadPath);
        }
    }
}