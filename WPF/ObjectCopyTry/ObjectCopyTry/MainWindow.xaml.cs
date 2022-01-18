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

namespace ObjectCopyTry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> a = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
            AddSomething();
            AssignAndModify();
        }
        private void AddSomething() {
            a.Add(1);
            a.Add(2);
            a.Add(3);
            MessageBox.Show(a.Count.ToString());
        }
        private void AssignAndModify() {
            List<int> tmp = new List<int>(a);
            tmp.Clear();
            MessageBox.Show(a.Count.ToString());
    }
    }
}
