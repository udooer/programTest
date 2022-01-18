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

namespace GridCollapsedTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserControl1 f1 = new UserControl1();
        UserControl2 f2 = new UserControl2();
        public MainWindow()
        {
            InitializeComponent();
            TestFun();
        }

        private async void TestFun()
        {
            await Task.Delay(2000);
            MessageBox.Show("1");
            MessageBox.Show("2");
            MessageBox.Show("3");
            MessageBox.Show("4");

            //first.Visibility = Visibility.Visible;
            firstFrame.Content = f1;

            second.Visibility = Visibility.Collapsed;
            MessageBox.Show(second.Visibility.ToString());
            await Task.Delay(2000);
            secondFrame.Content = f2;

            MessageBox.Show("finish");
        }
    }
}
