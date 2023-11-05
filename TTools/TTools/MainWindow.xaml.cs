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

namespace TTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var left = SystemParameters.PrimaryScreenWidth / 2 - this.Width / 2;
            Left = left;
            Top = 50;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            pop.IsOpen = true;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            pop.IsOpen = false;
        }
    }
}
