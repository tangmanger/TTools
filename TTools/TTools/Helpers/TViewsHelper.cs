using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTools.Domain.Attributes;
using TTools.Domain.Models;

namespace TTools.Helpers
{
    public class TViewsHelper
    {
        public static List<NativeModel> NaviteViewList = new List<NativeModel>();
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {

            var types = GetAlTypes();
            foreach (var item in types)
            {
                var toolAttribute =
               (TViewAttribute)Attribute.GetCustomAttribute(item, typeof(TViewAttribute));

                NaviteViewList.Add(new NativeModel()
                {
                    Type = toolAttribute.Type,
                    ViewType = toolAttribute.ViewType,
                    Foreground = toolAttribute.Foreground,
                    Icon = toolAttribute.Icon,
                    SortId = toolAttribute.SortId,
                    ViewName = toolAttribute.ViewName,
                    ViewModelType = toolAttribute.ViewModelType,
                    ToolType = toolAttribute.ToolType,
                });



            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static Type[] GetAlTypes()
        {
            var allTypes = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(a => a.GetTypes().Where(t => t.GetCustomAttributes(false).ToList().Exists(m => m is TViewAttribute)))
              .ToArray();
            return allTypes;
        }
    }
}
