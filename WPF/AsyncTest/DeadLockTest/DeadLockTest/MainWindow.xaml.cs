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

namespace DeadLockTest
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

        private async void OnDeadlock(object sender, RoutedEventArgs e)
        {
            var task = DoWorkAsync();
            task.Wait(); //wait until task completes, so it means you block the UI thread. Also, the task is waiting, so it is deadlock 
        }

        private async Task DoWorkAsync() {
            await Task.Delay(1000).ConfigureAwait(true); //default is true. When you are writing lib, use false instead 
            MessageBox.Show("finish");
        }
    }
}
