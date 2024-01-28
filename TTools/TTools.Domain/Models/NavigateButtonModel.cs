using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TTools.Domain.Enums;

namespace TTools.Domain.Models
{
    public class NavigateButtonModel
    {
        public string Title { get; set; }
        public ToolType ToolType { get; set; }
    }
}
