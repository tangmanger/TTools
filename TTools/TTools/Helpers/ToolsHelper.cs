using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTools.Domain.Attributes;
using TTools.Domain.Interfaces;
using TTools.Domain.Models;
using TTools.ViewModels;

namespace TTools.Helpers
{
    public class ToolsHelper
    {
        public static List<string> MouduleList = new List<string>();
        /// <summary>
        /// 初始化工具
        /// </summary>
        /// <returns></returns>
        public static List<ToolModel> Init(bool hasLogin)
        {
            List<ToolModel> list = new List<ToolModel>();
            var types = GetAlTypes();
            foreach (var item in types)
            {
                var toolAttribute =
                  (ToolAttribute)Attribute.GetCustomAttribute(item, typeof(ToolAttribute));
                if ( toolAttribute.IsBaseMoudle == false && toolAttribute.CanNoLogin == false)
                    if (!toolAttribute.IsShow || !MouduleList.Exists(p => p == toolAttribute.ToolDesc)) continue;
                list.Add(new ToolModel()
                {
                    Icon = toolAttribute.Icon,
                    Title = toolAttribute.ToolDesc,
                    HasView = toolAttribute.HasView,
                    Foreground = toolAttribute.Foreground,
                    IsBaseModel = toolAttribute.IsBaseMoudle,
                    SortId = toolAttribute.SortId,
                    CanNoLogin = toolAttribute.CanNoLogin
                });
            }
            if (hasLogin == false)
                return list.FindAll(p => p.CanNoLogin).OrderBy(p => p.SortId).ToList();
            return list.OrderBy(p => p.SortId).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static Type[] GetAlTypes()
        {
            var allTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ITools))))
                .ToArray();
            return allTypes;
        }
    }
}
