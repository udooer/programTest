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

namespace PopupTry
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

        private void MouseOnButton(object sender, MouseEventArgs e)
        {

            MyPopup.PlacementTarget = (Button)sender;
            MyPopup.Placement = System.Windows.Controls.Primitives.PlacementMode.Top;
            MyPopup.IsOpen = true;
            switch (((Button)sender).Name) {
                case "optionButton":
                    header.myPopupText.Text = "Option";
                    break;
                case "homeButton":
                    header.myPopupText.Text = "Home";
                    break;
                case "settingButton":
                    header.myPopupText.Text = "Setting";
                    break;
                default:
                    break;
            }
        }
        private void OnCloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MouseLeaveButton(object sender, MouseEventArgs e)
        {
            MyPopup.IsOpen = false;
            //MyPopup.Visibility = Visibility.Collapsed;
        }
    }
}
