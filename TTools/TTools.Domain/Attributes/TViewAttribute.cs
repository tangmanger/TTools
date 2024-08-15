using Dicgo.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TTools.Domain.Enums;

namespace TTools.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TViewAttribute : Attribute
    {
        public TViewAttribute(ViewType viewType, string viewName, Type type, Type vmType, string icon, ToolType _toolType, string brushes = "", int sortId = 0)
        {

            ViewType = viewType;
            Type = type;
            if (!string.IsNullOrWhiteSpace(brushes))
            {
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(brushes));
            }
            SortId = sortId;
            Icon = icon;
            ViewName = viewName.GetLangText();
            ViewModelType = vmType;
            ToolType = _toolType;
        }
        public ToolType ToolType { get; set; }
        public string ViewName { get; set; }
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
        public string Icon { get; private set; }

        public Type Type { get; set; }
        public Type ViewModelType { get; set; }
        /// <summary>
        /// 界面
        /// </summary>
        public ViewType ViewType { get; set; }

    }
}
