using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TTools.Domain.Enums;
using TTools.Domain.Interfaces;
using TTools.Domain.Models;
using TTools.Helpers;

namespace TTools.ViewModels
{
    public class ToolViewModel : BaseTools, INavigateIn<ToolType>
    {
        public void NavigateIn(ToolType param)
        {
            ToolList = TViewsHelper.NaviteViewList.FindAll(c => c.ToolType == param);
            var first = ToolList.FirstOrDefault();
            if (first != null)
            {
                first.IsSelected = true;
                NavigateToCommand?.Execute(first);
            }
        }
        public RelayCommand<NativeModel> NavigateToCommand => new RelayCommand<NativeModel>((n) =>
        {
            if (n != null)
            {
                WorkView = GoTo(n.ViewType, n.ToolType);
            }

        });
    }
}
