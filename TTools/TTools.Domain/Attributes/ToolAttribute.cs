using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TTools.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ToolAttribute : Attribute
    {
        public ToolAttribute(bool hasView, string toolDesc, string icon, string brushes = "", int sortId = 0, bool isShow = true, bool isBaseMoudle = false, bool canNoLogin = false)
        {
            HasView = hasView;
            ToolDesc = toolDesc;
            Icon = icon;
            IsShow = isShow;
            IsBaseMoudle = isBaseMoudle;
            SortId = sortId;
            CanNoLogin = canNoLogin;
            if (!string.IsNullOrWhiteSpace(brushes))
            {
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(brushes));
            }
        }
        public bool CanNoLogin { get; set; }
        /// <summary>
        /// 排序id
        /// </summary>
        public int SortId { get; set; }
        /// <summary>
        /// 是否是基础模块
        /// </summary>
        public bool IsBaseMoudle { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public SolidColorBrush Foreground { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; }
        /// <summary>
        /// 是否有界面
        /// </summary>
        public bool HasView { get; set; }
        /// <summary>
        /// 工具描述
        /// </summary>
        public string ToolDesc { get; set; }
        /// <summary>
        /// 是否是测试
        /// </summary>
        public bool IsShow { get; set; }

    }
}
