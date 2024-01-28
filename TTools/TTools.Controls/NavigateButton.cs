using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TTools.Domain.Enums;
using TTools.Domain.Models;

namespace TTools.Controls
{
    public class NavigateButton : RadioButton
    {
        public NavigateButton()
        {

            //this.Loaded += NavigateButton_Loaded;
        }

        private void NavigateButton_Loaded(object sender, RoutedEventArgs e)
        {
            Navigate = new NavigateButtonModel() { Title = Content.ToString(), ToolType = ToolTips };
        }

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(NavigateButton));


        public ToolType ToolTips
        {
            get { return (ToolType)GetValue(ToolTipsProperty); }
            set { SetValue(ToolTipsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToolTips.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToolTipsProperty =
            DependencyProperty.Register("ToolTips", typeof(ToolType), typeof(NavigateButton), new PropertyMetadata(ToolType.None, new PropertyChangedCallback(ToolTipCallBack)));

        private static void ToolTipCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                NavigateButton navigateButton = (NavigateButton)d;
                navigateButton.Navigate = new NavigateButtonModel()
                {
                    Title = navigateButton.Content.ToString(),
                    ToolType = (ToolType)e.NewValue
                };
            }
        }

        public NavigateButtonModel Navigate
        {
            get;
            set;
        }
    }
}
