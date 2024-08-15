using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TTools.Domain.Enums;
using TTools.Domain.Interfaces;
using TTools.Domain.Models;

namespace TTools.ViewModels
{
    public abstract class BaseTools : ObservableObject
    {
        #region 属性

        private List<NativeModel>? _toolList;
        private FrameworkElement? _workView;

        /// <summary>
        /// 工具列表
        /// </summary>
        public List<NativeModel> ToolList
        {
            get
            {
                return _toolList;
            }
            set
            {
                _toolList = value;
                OnPropertyChanged("ToolList");
            }
        }



        /// <summary>
        /// 工作区域
        /// </summary>
        public FrameworkElement WorkView
        {
            get
            {
                return _workView;
            }
            set
            {
                _workView = value;
                OnPropertyChanged("WorkView");
            }
        }

        #endregion
        public FrameworkElement GoTo<T>(ViewType viewType, T param)
        {
            if (viewType == ViewType.None) return null;

            var view = ToolList.Find(p => p.ViewType == viewType);
            if (view == null) { return null; }
            var control = Ioc.Default.GetService(view.Type) as FrameworkElement;
            var vm = Ioc.Default.GetService(view.ViewModelType) as BaseTools;
            if (control != null && control.DataContext == null)
                control.DataContext = vm;
            if (WorkView != null)
            {
                var naviget = WorkView.DataContext as INavigateOut;
                if (naviget != null)
                    naviget.NavigateOut();
            }
            var navigate = vm as INavigateIn;
            if (navigate != null)
            {
                navigate.NavigateIn();
            }
            else
            {
                var navigateParam = vm as INavigateIn<T>;
                if (navigateParam != null)
                {
                    navigateParam.NavigateIn(param);
                }
            }
            return control;
        }
    }
}
