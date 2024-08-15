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
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;
using TTools.Domain.Enums;
using TTools.Domain.Interfaces;
using TTools.Domain.Models;
using TTools.Helpers;

namespace TTools.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        DispatcherTimer? _timer = null;
        public MainViewModel()
        {
            SearchText = string.Empty;
            string txt = App.Current.FindResource("SystemContent") as string ?? "";
            if (!string.IsNullOrWhiteSpace(txt))
            {
                CurrentTitle = txt;
            }
            _timer = new DispatcherTimer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Start();
        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            TimeTips = DateTime.Now;
        }


        #region 属性

        ToolType currentType = ToolType.System;
        private FrameworkElement? _workView;
        private string? currentTitle;
        private string? searchText = string.Empty;
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
        private List<NativeModel>? _toolList;
        private DateTime timeTips;

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

        /// <summary>
        /// 当前标题
        /// </summary>
        public string CurrentTitle
        {
            get => currentTitle;
            set
            {
                currentTitle = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime TimeTips
        {

            get => timeTips;
            set
            {
                timeTips = value;
                OnPropertyChanged();
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
            ToolList = TViewsHelper.NaviteViewList.FindAll(c => c.ToolType == ToolType.Home);
            var first = ToolList.FirstOrDefault();
            MenuCommand.Execute(new NavigateButtonModel() { ParentToolType = ToolType.Home });
            //if (first != null)
            //{
            //    first.IsSelected = true;
            //    NavigateToCommand?.Execute(first);
            //}
        }
        FrameworkElement GoTo<T>(ViewType viewType, T param, T param1)
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
                    navigateParam.NavigateIn(param1);
                }
            }
            return control;
        }
        #endregion


        #region 命令

        public RelayCommand<NativeModel> NavigateToCommand => new RelayCommand<NativeModel>((n) =>
        {
            //if (n != null)
            //{
            //    WorkView = GoTo(n.ViewType,n.ToolType);
            //}

        });

        public RelayCommand BackCommand => new RelayCommand(() =>
        {
            WorkView = GoTo<string>(ViewType.None, "", "");
        });

        /// <summary>
        /// 选中
        /// </summary>
        public RelayCommand<ToolType> MenuItemCommand => new RelayCommand<ToolType>((t) =>
        {
            //currentType = (ToolType)t;
            //ToolList = TViewsHelper.NaviteViewList;//.FindAll(c => c.ToolType == currentType);
        });

        public RelayCommand<NavigateButtonModel> MenuCommand => new RelayCommand<NavigateButtonModel>((s) =>
        {
            CurrentTitle = s.Title;
            ToolList = TViewsHelper.NaviteViewList.FindAll(c => c.ToolType == s.ParentToolType);
            var first = ToolList.Find(c => c.IsSelected) ?? ToolList.FirstOrDefault();
            if (first != null)
            {
                first.IsSelected = true;
                if (first != null)
                {
                    WorkView = GoTo(first.ViewType, s.ParentToolType, s.ToolType);
                }
            }

        });

        #endregion
    }
}
