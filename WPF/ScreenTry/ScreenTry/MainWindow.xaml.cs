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

namespace ScreenTry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        

        private void ShowClick(object sender, RoutedEventArgs e)
        {
            // For each screen, add the screen properties to a list box.
            foreach (var screen in System.Windows.Forms.Screen.AllScreens)
            {

                string s = "Device Name: " + screen.DeviceName + "Bounds: " +

                     screen.GetType().ToString() + "Working Area: " + "Primary Screen: " +
                     screen.Primary.ToString();

                MessageBox.Show(s);
            }
        }
    }
}
