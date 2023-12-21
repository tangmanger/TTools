using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TTools.Domain.Models
{
    public class ToolModel
    {
        /// <summary>
        /// 实例类型
        /// </summary>
        public object Instance { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 是否有界面
        /// </summary>
        public bool HasView { get; set; }
        /// <summary>
        /// 是否是基础模块
        /// </summary>
        public bool IsBaseModel { get; set; }
        /// <summary>
        /// 排序id
        /// </summary>
        public int SortId { get; set; }
        /// <summary>
        /// 不登录是否可以访问
        /// </summary>
        public bool CanNoLogin { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public SolidColorBrush Foreground { get; set; }
    }
}
