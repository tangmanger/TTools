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
using TTools.Domain.Interfaces;
using TTools.ViewModels;

namespace TTools.Views
{
    /// <summary>
    /// UACView.xaml 的交互逻辑
    /// </summary>
    [TView(ViewType.UAC,"UAC",typeof(UACView),typeof(UACViewModel), "\ue6bd", ToolType.System, "red")]
    public partial class UACView : UserControl
    {
        public UACView()
        {
            InitializeComponent();
        }

       
    }
}
