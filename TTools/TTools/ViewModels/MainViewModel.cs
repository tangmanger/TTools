using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using TTools.Domain.Enums;
using TTools.Domain.Interfaces;
using TTools.Domain.Models;
using TTools.Helpers;

namespace TTools.ViewModels
{
    public class MainViewModel : ObservableObject
    {


        public MainViewModel()
        {
            SearchText = string.Empty;

        }


        #region 属性


        private string searchText = string.Empty;
        /// <summary>
        /// 搜索
        /// </summary>
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged();
            }
        }
        private List<NativeModel> _toolList;
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

        private FrameworkElement _workView;
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

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>

        public void Init()
        {
            TViewsHelper.Init();
            ToolList = TViewsHelper.NaviteViewList;
        }
        FrameworkElement GoTo<T>(ViewType viewType, T param)
        {
            if (viewType == ViewType.None) return null;

            var view = ToolList.Find(p => p.ViewType == viewType);
            if (view == null) { return null; }
            if (WorkView != null)
            {
                var naviget = WorkView.DataContext as INavigateOut;
                if (naviget != null)
                    naviget.NavigateOut();
            }
            var navigate = Ioc.Default.GetService(view.ViewModelType) as INavigateIn;
            if (navigate != null)
            {
                navigate.NavigateIn();
            }
            else
            {
                var navigateParam = Ioc.Default.GetService(view.ViewModelType) as INavigateIn<T>;
                if (navigateParam != null)
                {
                    navigateParam.NavigateIn(param);
                }
            }
            return Ioc.Default.GetService(view.Type) as FrameworkElement;
        }
        #endregion


        #region 命令

        public RelayCommand<NativeModel> NavigateToCommand => new RelayCommand<NativeModel>((n) =>
        {
            if (n != null)
            {
                WorkView = GoTo<string>(n.ViewType, "");
            }

        });

        public RelayCommand BackCommand => new RelayCommand(() =>
        {
            WorkView = GoTo<string>(ViewType.None, "");
        });

        #endregion
    }
}
