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
using gv = HangTest.GlobalVariable;
using System.Windows.Threading;
using System.Diagnostics;
using System.Threading;


namespace HangTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class Test {
            public int test;
            public Test() {
                test = 0;
            }
        }
        private Test t = new Test();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnHangClick(object sender, RoutedEventArgs e)
        {
            Task.Delay(5000).Wait();
            MessageBox.Show("finished");
        }

        private async void OnNotHangClick(object sender, RoutedEventArgs e)
        {
            await Task.Delay(5000);
            MessageBox.Show("finished");
        }

        private async void OnUIThreadClick(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
            await Task.Delay(1000).ConfigureAwait(true);
            gv.testNumber = -1;
            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
            MessageBox.Show("finished");
        }

        private void OnShowNumberClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(gv.testNumber.ToString());
            MessageBox.Show(t.test.ToString());
        }

        private async void OnWorkerThreadClick(object sender, RoutedEventArgs e)
        {
            await Task.Delay(1000).ConfigureAwait(false);
            gv.testNumber = -1;
            t.test = -1;
            MessageBox.Show("finished");
        }

        private async void OnUseDispatcherClick(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
            await Task.Delay(1000).ConfigureAwait(false);
            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
            //ChangeColorBtn.Background = new SolidColorBrush(Colors.LawnGreen);
            Dispatcher.Invoke(() => {
                ChangeColorBtn.Background = new SolidColorBrush(Colors.LawnGreen);
            });
            MessageBox.Show("finished");
        }
    }
}
