using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion
    }
}
