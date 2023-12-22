using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTools.ViewModels
{
    public class GpeditViewModel : BaseTools
    {

        #region 命令

        public RelayCommand AddGpeditCommand => new RelayCommand(() =>
        {
            List<string> list = new List<string>();
            list.Add("@echo off");
            list.Add("pushd \"%~dp0\"");
            list.Add("dir /b C:\\Windows\\servicing\\Packages\\Microsoft-Windows-GroupPolicy-ClientExtensions-Package~3*.mum >List.txt");
            list.Add("dir /b C:\\Windows\\servicing\\Packages\\Microsoft-Windows-GroupPolicy-ClientTools-Package~3*.mum >>List.txt");
            list.Add("for /f %%i in ('findstr /i . List.txt 2^>nul') do dism /online /norestart /add-package:\"C:\\Windows\\servicing\\Packages\\%%i\"");
            list.Add("");
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "a.bat");
            File.WriteAllLines(path, list);
            if (File.Exists(path))
            {
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = path,
                    Verb = "runas"
                };

                process.Start();
            }
        });

        #endregion
    }
}
