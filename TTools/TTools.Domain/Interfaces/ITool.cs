using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TTools.Domain.Interfaces
{
    public interface ITools
    {
        void Load();
        void Unload();

        FrameworkElement GetView();
    }
}
