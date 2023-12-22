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
using TTools.Domain.Attributes;
using TTools.Domain.Enums;
using TTools.ViewModels;

namespace TTools.Views
{
    /// <summary>
    /// GpeditView.xaml 的交互逻辑
    /// </summary>
    [TView(ViewType.GpeditView, "组策略", typeof(GpeditView), typeof(GpeditViewModel), "\ue6bd", "red")]
    public partial class GpeditView : UserControl
    {
        public GpeditView()
        {
            InitializeComponent();
        }
    }
}
