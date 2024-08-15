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
    /// ToolView.xaml 的交互逻辑
    /// </summary>
    [TView(ViewType.ToolView, "PDF", typeof(ToolView), typeof(ToolViewModel), "\ue8e8", ToolType.Tool, "red")]
    public partial class ToolView : UserControl
    {
        public ToolView()
        {
            InitializeComponent();
        }
    }
}
