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
using System.Threading;

namespace ThreadTry
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

        private void OnShowTextClick(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(UpdateText);
            thread.Start();

        }
        private void UpdateText() {
            Thread.Sleep(5000);
            this.Dispatcher.BeginInvoke(new Action(() => 
            {
                text.Text = "hello thread";
                MessageBox.Show("finish");
            }));
        }
    }
}
