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
using System.Windows.Interop;
using System.Diagnostics;

namespace ScrollviewerTest
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

        private void Onchanged(object sender, ScrollChangedEventArgs e)
        {
            Trace.WriteLine(scroll.VerticalOffset.ToString());
            Trace.WriteLine(scroll.HorizontalOffset.ToString());
            Trace.WriteLine("");
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // Handle messages...
            const int WM_MOUSEHWHEEL = 0x020E;

            // Listen for operating system messages. 
            switch (msg)
            {
                case WM_MOUSEHWHEEL:
                    Byte[] a = BitConverter.GetBytes((int)wParam);
                    Byte[] b = {a[2], a[3]};
                    int c = BitConverter.ToInt16(b, 0);
                    int data = (int)wParam / 16 / 16 / 16 / 16;
                    //Trace.WriteLine(data.ToString());
                    double now = scroll.HorizontalOffset;
                    scroll.ScrollToHorizontalOffset(now + data);
                    break;
            }
            return IntPtr.Zero;
        }
    }

    
}
