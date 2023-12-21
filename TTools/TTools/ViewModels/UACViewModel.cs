using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TTools.Domain.Attributes;
using TTools.Domain.Enums;

namespace TTools.ViewModels
{
    public class UACViewModel : BaseTools
    {

        #region 命令

        public RelayCommand CloseUACCommand => new RelayCommand(() =>
        {
            SetUac(UACStatus.Disabled);
        });

        public RelayCommand OpenUACCommand => new RelayCommand(() =>
        {
            SetUac(UACStatus.Enabled);
        });

        #endregion

        #region 方法

        /// <summary>
        /// 设置uac
        /// 参考https://www.cnblogs.com/zhaotianff/p/11596668.html
        /// </summary>
        /// <param name="uACStatus"></param>
        void SetUac(UACStatus uACStatus)
        {
            try
            {
                string path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
                string uac = "EnableLUA";
                RegistryKey key = Registry.LocalMachine.CreateSubKey(path);
                if (key != null)
                {
                    key.SetValue(uac, (int)uACStatus, RegistryValueKind.DWord);
                    key.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
