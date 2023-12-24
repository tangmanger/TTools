using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TTools.Domain.Enums;

namespace TTools.Domain.Models
{
    public class NativeModel
    {
        /// <summary>
        /// 界面
        /// </summary>
        public ViewType ViewType { get; set; }
        /// <summary>
        /// ViewModel
        /// </summary>
        public Type ViewModelType { get; set; }
        /// <summary>
        /// 实例类型
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// 排序id
        /// </summary>
        public int SortId { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public SolidColorBrush Foreground { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        public string ViewName { get; set; }
        public ToolType ToolType { get; set; }
    }
}
